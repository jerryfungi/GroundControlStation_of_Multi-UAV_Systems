The Ground Control Station (GCS) interface software for a multi-UAV system is developed, and the database is built using MySQL. 
This software is designed to monitor and control multiple drones and facilitates outdoor UAV flight experiments. The communication between the UAVs and the GCS is established through XBee Pro S3B and X2 ConnectPort modules. Additionally, the PC communicates with the X2 module using UDP.

The GCS allows users to generate virtual drones on the Google Map interface by clicking the middle mouse button, which enables users to utilize partial functions.

The GCS is integrated with the program on the UAV, which is developed using the Robot Operating System (ROS). The UAV program repository can be found at https://github.com/jerryfungi/Multi-UAV_System_UAVprogram.git.

Reference (3rd party libarry):
CheckBoxComboBox:  
https://www.codeproject.com/Articles/21085/CheckBox-ComboBox-Extending-the-ComboBox-Class-and
ColorSlider:  
https://www.codeproject.com/Tips/1193311/Csharp-Slider-Trackbar-Control-using-Windows-Forms
CSkin:  
http://www.cskin.net/
PulseButton:  
https://www.codeproject.com/Articles/42968/Pulse-Button
RoundButton:  
https://www.codeproject.com/Articles/15730/RoundButton-Windows-Control-Ever-Decreasing-Circle
XBeeLibrary.Windows:  
https://github.com/digidotcom/xbee-csharp/tree/windows_module
