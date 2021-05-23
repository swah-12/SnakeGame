# SnakeGame
This project is called a snake game. This game is a console application and used C# to program this game. We have at least four obstacles to make this a fun game. The snake will die if it goes over the edge of the confined area or hits the obstacles. After the snake dead, the time user lasts to service will print out in the console.

## Snake.cs
The Snake.cs class create Snake using circular queue. It has a PaintSnake() method that paint the head and body with differet color. This class also have methods of movenment such as up, down, left, and right. 

## Board.cs
The class Board.cs display confine area where the snake can move, and create obstacles where it will kill the snake. There are different method of obstacles from left and right, top and bottom. 

## Program.cs
The purpose of the Program.cs class is to test everything we have write from other classes. It also include the methods such as IsDead() to check if the snake is dead or not. 
