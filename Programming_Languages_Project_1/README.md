# Project 1 Object-Oriented Programming vs. Procedural Programming

## Definitions:
- **Object Oriented Programming**: A way of programming that is centered around the creation and use of object that encapsulate:
    - an entity's state
    - methods to manipulate that state
  - Programmers typically use a bottom-up approach
  - Makes use of side effects
  - Is data centric
- **Procedural Programming**: A way of programming that is centered around breaking down a problem into smaller and smaller sub-probems or sub-procedures:
  - Programmers typically use a top-down approach
  - avoids side effects
  - Is function centric

## Project Overview:
* Programming using both procedural and object-oriented paradigms
  - You need to write two programs
  - One using a procedural paradigm approach
  - One using an object-oriented approach
  - You can use the same language for both or two different languages
* The programs you write will calculate or retrieve data related to our Solar System:
  - The name of our sun
  - Its diameter given its circumference
  - Its circumference given its diameter
  - How long a ‘year’ is on each of our solar system’s 8 planets given its distance from the sun
  - How far each of the planets is from the sun given how long its ‘year’ is
  - Each planet’s name
  - Each planet’s diameter given its circumference
  - Each planet’s circumference given its diameter
  - The name of any moons given
  - For each given moon:
    - Its diameter given its circumference
    - Its circumference given its diameter
    - Whether or not the sum of the planets’ volumes is greater than the volume of the Sun
  - You will be supplied with any non-common formulas
  - Initial (sparse) data will be supplied as a JSON file. You can either:
  - Programmatically read it in
  - Hard code it into your program(s)
  - A partial example of the expected output follows

## Project Output:
```
    Sun: Sol
    Diameter: 1,400,000 km Circumference: 4,370,006 km
    ...
    Planet: Earth
    Distance from sun: 1 au Orbital period: 1 yr Diameter: 12,756 km Circumference: 40,075 km Moon: Luna
    Diameter: 3,475 km Circumference: 10,917 km
    ...
    All the planets’ volumes added together could fit in the Sun: (True | False)
```

## Project Structure

```plaintext
├── JSONPrettyPrint.txt
├── oop.py
├── procedural
└── procedural.cpp
```

## Class Diagram:

![Class Diagram](/Programming_Languages_Project_1/diagrams/class.jpeg)

## Acticity Diagram:

![Activity Diagram](/Programming_Languages_Project_1/diagrams/activity.jpeg)

## Setup Instructions:

1. Make sure that you are in the `Programming_Languages_Project_1` directory.

2. To run the procedural program, follow these steps:

  - Open a terminal:
    ```bash
    g++ procedural.cpp -o procedural
    ```
  - Start the program by running the following:
    ```bash
    ./procedural
    ```

3. To run the object-oriented program, follow these steps:

  - Open a terminal and start the program by running the following:
    ```bash
    python oop.py
    ```
