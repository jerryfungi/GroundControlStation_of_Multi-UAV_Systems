using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS_5895
{
    public class GA_VRP
    {
        public List<double[]> Targets_locations { get; private set; }
        public List<agents> UAV_set { get; private set; }
        public List<List<double[]>> costTable { get; private set; }
        private int population_size = 300;
        private int crossover_num = 200;
        private int mutation_num = 96;
        private int elitism_num = 4;
        private Random random = new Random();
        private int UAV_num, target_num;
        private Chromosome chromosome, offspring_1, offspring_2;
        private Dictionary<int, int> UAV_ID_index;

        public struct Chromosome
        {
            public List<int[]> genes;
            public double fitness_value;
            public double weighting;
        }

        public GA_VRP(List<double[]> Targets_locations, List<agents> UAV_set)
        {
            this.Targets_locations = Targets_locations;
            this.UAV_set = UAV_set;
            this.target_num = Targets_locations.Count();
            this.UAV_num = UAV_set.Count();
            UAV_ID_index = new Dictionary<int, int> { };
            // 定義cost矩陣
            var costTable = new List<double[]>() { new double[target_num + 1] };
            this.costTable = new List<List<double[]>>() { };
            for (int i = 1; i < target_num + 1; i++)
            {
                var costArray = new double[target_num + 1];
                for (int j = 1; j < target_num + 1; j++)
                {
                    costArray[j] = Distance(Targets_locations[i-1], Targets_locations[j-1]);
                }
                costTable.Add(costArray);
            }
            for (int i = 0; i < UAV_num; i++)
            {
                this.costTable.Add(costTable);
                for (int j = 1; j < target_num + 1; j++)
                {
                    var d = Distance(UAV_set[i].initial_pos, Targets_locations[j-1]);
                    this.costTable[i][0][j] = d;
                    this.costTable[i][j][0] = d;
                }
                UAV_ID_index.Add(UAV_set[i].ID, i);
            }
        }

        public double Distance(double[] starting_point, double[] end_point)
        {
            return Math.Sqrt(Math.Pow(end_point[0] - starting_point[0], 2) + Math.Pow(end_point[1] - starting_point[1], 2));
        }

        private List<Chromosome> population_initiation()
        {
            List<Chromosome> population = new List<Chromosome>() { };
            chromosome = new Chromosome()
            {
                genes = new List<int[]>() { new int[target_num], new int[target_num] }
            };
            for (int i = 0; i < population_size; i++)
            {
                chromosome.genes[0] = Enumerable.Range(1, target_num).OrderBy(e => random.NextDouble()).ToArray();
                for (int j = 0; j < target_num; j++)
                {
                    chromosome.genes[1][j] = UAV_set[random.Next(UAV_num)].ID;
                }
                population.Add(chromosome);
            }
            return population;
        }

        private List<Chromosome> fitness_evaluation(List<Chromosome> population)
        {
            int[] uav_state;
            double[] uav_cost;
            int assign_uav_index, assign_target;
            for (int i = 0; i < population_size; i++)
            {
                uav_state = new int[UAV_num];
                uav_cost = new double[UAV_num];
                for (int j = 0; j < target_num; j++)
                {
                    assign_uav_index = UAV_ID_index[population[i].genes[1][j]];
                    assign_target = population[i].genes[0][j];
                    uav_cost[assign_uav_index] += costTable[assign_uav_index][uav_state[assign_uav_index]][assign_target];
                    uav_state[assign_uav_index] = assign_target;
                }
                for (int j = 0; j < UAV_num; j++)
                {
                    uav_cost[j] += costTable[j][uav_state[j]][0];
                }
                chromosome =  population[i];
                chromosome.fitness_value = 1 / uav_cost.Max();
                population[i] = chromosome;
            }
            double fitness_sum = population.Sum(e => e.fitness_value);
            chromosome = population[0];
            chromosome.weighting = population[0].fitness_value / fitness_sum;
            population[0] = chromosome;
            for (int i = 1; i < population_size; i++)
            {
                chromosome = population[i];
                chromosome.weighting = population[i - 1].weighting + (population[i].fitness_value / fitness_sum);
                population[i] = chromosome;
            }
            return population;
        }

        private List<Chromosome> selection_operator(List<Chromosome> population, int select_number)
        {
            var select_chromosome = new List<Chromosome>() { };
            for (int i = 0; i < select_number; i++)
            {
                var prob = random.NextDouble();
                select_chromosome.Add(population.First(e => e.weighting >= prob));
            }
            return select_chromosome;
        }

        private List<Chromosome> crossover_operator(Chromosome parent_1, Chromosome parent_2)
        {
            offspring_1 = new Chromosome()
            {
                genes = new List<int[]>() { new int[target_num], new int[target_num] }
            };
            offspring_2 = new Chromosome()
            {
                genes = new List<int[]>() { new int[target_num], new int[target_num] }
            };
            var cut_sites = new List<int>() { random.Next(target_num) , random.Next(target_num) };
            cut_sites.Sort();
            for (int i = 0; i < 2; i++)
            {
                parent_1.genes[i].ToList().GetRange(cut_sites[0], cut_sites[1] - cut_sites[0]).CopyTo(offspring_2.genes[i], cut_sites[0]);
                parent_2.genes[i].ToList().GetRange(cut_sites[0], cut_sites[1] - cut_sites[0]).CopyTo(offspring_1.genes[i], cut_sites[0]);
            }
            int index;
            for (int i = 0; i < target_num; i++)
            {
                if (!offspring_1.genes[0].Contains(parent_1.genes[0][i]))
                {
                    index = Array.IndexOf(offspring_1.genes[0], 0);
                    offspring_1.genes[0][index] = parent_1.genes[0][i];
                    offspring_1.genes[1][index] = parent_1.genes[1][i];
                }
                if (!offspring_2.genes[0].Contains(parent_2.genes[0][i]))
                {
                    index = Array.IndexOf(offspring_2.genes[0], 0);
                    offspring_2.genes[0][index] = parent_2.genes[0][i];
                    offspring_2.genes[1][index] = parent_2.genes[1][i];
                }
            }
            return new List<Chromosome>() { offspring_1, offspring_2};
        }

        private Chromosome mutation_operator(Chromosome chromosome)
        {
            this.chromosome.genes = new List<int[]>(chromosome.genes);
            if (random.NextDouble() > 0.5)
            {
                this.chromosome.genes[1][random.Next(target_num)] = UAV_set[random.Next(UAV_num)].ID;
            }
            else
            {
                var rev_sites = new List<int>() { random.Next(target_num), random.Next(target_num) };
                rev_sites.Sort();
                for (int i = 0; i < 2; i++)
                {
                    var rev_genes = chromosome.genes[i].ToList().GetRange(rev_sites[0], rev_sites[1] - rev_sites[0]);
                    rev_genes.Reverse();
                    rev_genes.CopyTo(this.chromosome.genes[i], rev_sites[0]);
                }
            }
            return this.chromosome;
        }

        private List<Chromosome> elitism_operator(List<Chromosome> population)
        {
            var elitism = population.OrderByDescending(e => e.fitness_value).Take(elitism_num).ToList();
            return elitism;
        }

        public Chromosome main_program(int iteration_times)
        {
            List<Chromosome> next_population, population, elitism, chromosomes, offspring;
            population = population_initiation();
            fitness_evaluation(population);
            for (int i = 0; i < iteration_times; i++)
            {
                Console.WriteLine($"iteration {i}");
                next_population = new List<Chromosome>() { };
                // elitism
                elitism = elitism_operator(population);
                next_population.AddRange(elitism);
                // crossover
                for (int j = 0; j < crossover_num; j+=2)
                {
                    chromosomes = selection_operator(population, 2);
                    offspring = crossover_operator(chromosomes[0], chromosomes[1]);
                    next_population.AddRange(offspring);
                }
                // mutation
                for (int j = 0; j < mutation_num; j++)
                {
                    chromosomes = selection_operator(population, 1);
                    chromosome = mutation_operator(chromosomes[0]);
                    next_population.Add(chromosome);
                }
                population = next_population;
                fitness_evaluation(population);
            }
            double best_fitness = population.Max(e => e.fitness_value);
            return population.First(c => c.fitness_value == best_fitness);
        }
    } 
}
