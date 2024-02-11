# Ground Control Station of Multi-UAV Systems
The Ground Control Station (GCS) for multi-UAV systems is designed to monitor and control multiple drones, including quadrotors and fixed-wing UAVs, thereby facilitating outdoor UAV flight experiments.

![GCSinterface](https://github.com/jerryfungi/GroundControlStation_of_Multi-UAV_Systems/assets/112320576/fbb89762-5b9a-454f-8c0f-4d2db87cd5f0)

## Requirements
For the designed GCS, downloading MySQL for the database is required. Additionally, communication equipment is also necessary. We utilize the X2 Connectport as the medium for exchanging messages between UAVs and the GCS (XBee using serial port is also available).

|   | Version  |
| ------------ | ------------ |
| Interface  | Visual Studio Code 2019<br> .NET Framework 4.7.2  |
| Database  | MySQL 8.0  |   |

## Architecture
![GCSstructure](https://github.com/jerryfungi/GroundControlStation_of_Multi-UAV_Systems/assets/112320576/9d9fc11e-a0bc-464a-ace0-c09fb40b1ea5)

## Functions
The main interface provides fundamental control commands, including changing the UAV mode, initiating takeoff, time synchronization, and flying to assigned locations. Additionally, mission planning functionalities such as path planning, VRP, and SEAD are available. <br>
The GCS allows users to generate virtual drones on the Google Map interface by clicking the right mouse button, which enables users to utilize partial functions.
### Waypoints/ Path following
![GCSwaypoints](https://github.com/jerryfungi/GroundControlStation_of_Multi-UAV_Systems/assets/112320576/ab346ec0-cdcb-4999-b274-4164afaf1f48)
### VRP
![GCSvrp](https://github.com/jerryfungi/GroundControlStation_of_Multi-UAV_Systems/assets/112320576/da793a72-4312-46ac-8622-91a2ffba0fc7)
### SEAD
![GCSsead](https://github.com/jerryfungi/GroundControlStation_of_Multi-UAV_Systems/assets/112320576/ce64e101-fc97-4721-9b5d-84ec42f9be7d)<br>

## Reference(3rd party libarry)
| Packages  | Source  |
| ------------ | ------------ |
| CheckBoxComboBox  | https://www.codeproject.com/Articles/21085/CheckBox-ComboBox-Extending-the-ComboBox-Class-and  |
| ColorSlider  | https://www.codeproject.com/Tips/1193311/Csharp-Slider-Trackbar-Control-using-Windows-Forms  |
| CSkin  | http://www.cskin.net/  |
| PulseButton  | https://www.codeproject.com/Articles/42968/Pulse-Button  |
| RoundButton  | https://www.codeproject.com/Articles/15730/RoundButton-Windows-Control-Ever-Decreasing-Circle  |
| XBeeLibrary.Windows  | https://github.com/digidotcom/xbee-csharp/tree/windows_module  |
