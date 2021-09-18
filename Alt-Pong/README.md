# Bike Pong!

***Bike Pong is an alternative controller, game combo where players use hand cranks to move their ‘paddles’ up and down the screen, ya know, pong style.***

<p align="center"><img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-ControllerDemo.gif" width="75%"></p>

The controller is designed to use infrared signals to detect the speed of the wheel, and move the game paddle accordingly. There are 3 speed settings built into the game, coasting, biking and boosting. 

Coasting occurs when the speed inputs from the sensors are above 500 millisecond intervals, which makes the biker coast down the screen. Readings between 250 – 500 milliseconds make the player bike up the screen at the same speed as the ball. Finally, signal differences faster than 250 milliseconds will boost the player up the screen twice as fast.

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-Sensors.jpg" width="50%"><img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-CircuitDiagram.jpg" width="36%">

In the images above, you can see that when the wheel is being rotated, the gaps cut into the wheel allow for the IR LED to send a signal through to the IR receiver. A simple circuit diagram shows how to wire the sensors to the Teensy LC. Below are links to the code used to run the sensors on the Teensy, and the Unity project for the game on Github.

[Unity Project](https://github.com/zSpaceSheikh/AltArcadeInterfaces/tree/main/Alt-Pong/Alt_Pong_Game)

[Teensy LC Controller Code](https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Controller/Alt_Pong_Controller.ino)

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-Demo.jpg" width="50%"><img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-Controller.jpg" width="50%">

<p align="center"><img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Pong/Alt_Pong_Media/BikePong-GameDemo.gif" width="75%"></p>
