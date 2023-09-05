# Prototype-self-driving-car-based-on-image-processing-using-Haar-Cascade-Classifier

This project aims to design and implement a prototype robocar system which capable of driving independently in a safe manner.

this project is divided into two parts, In the robotic part which will play the actuator part a Lego EV3 Mindstorm Robot has been used to implement the Prototype robocar.

On the other hand, in the image processing Part which will be used as a sensor part, Viola-Jones object-detection algorithm has been used, Viola-Jones object detector is one of the most successful and widely used object detection  algorithms. Moreover, since training the classifier is one of the most important steps of the Viola-Jones algorithm.

In this project 10 stages trained Haar Cascade classifier has been implemented using more than 1800 images as positive images and 900 images as negative images in a way that the system becomes capable of detecting objects in live camera streaming with such a high efficiency and accuracy within such a short time. 

As a result, in the final phase of this project, using OpenCV, EmguCV, and C# programming language and Lego EV3 Mindstorm libraries we have been able to design and implement a robocar system based on object detection and recognition algorithm that will be able to navigate itself safely. and detect the presence of traffic signs and behave accordingly.

Our robot will act based on detected objects coming from the camera feed In real-time, the robot use cases will be as follows:

1- Move right if the detected sign is a right sign.

2- Move left if the detected sign is left.

3- Stop for a while if the detect sign is a stop sign and then complete moving forward.

4- If the detected object is a traffic light:

  • Complete moving if the light is green.
  • Stop till the light will change to green as long as the light is red.

5- The robot will stop immediately if there’s an obstacle Infront of it using the infrared sensor.

6- Using the light sensor, the robot will detect and recognize the line pattern and adjust its road based on the value of the sensor so he will still on the road.
