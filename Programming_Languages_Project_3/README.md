# Project 3 Logic Programming

## Definition:
- **Logic Programming**: Uses a form of symbolic logic to set up 'facts' and 'rules' from which questions can be asked and the answers logically deduced.

## Project Overview:
* The application domain for this project will be researching airline flights from and to various airports.
* Specifically, you will have to:
  - Translate the flight schedule/map provided into facts
  - Write the rules required to ask the questions indicated
  - Write and run the questions indicated
  - Capture screen shots (or log) of questions asked and answered
* Questions indicated:
  - Where does the flight from PHX go?
  - Is there a flight to PHX?
  - What time is does the flight from BOS land?
  - Does the flight from ORD to SFO depart after the flight from EWR to ORD lands? 
  - What time do the flights to ORD arrive?
  - What are all the ways to get from LGA to LAX?


## Project Structure

```plaintext
└── airline_travel.pl
```

## Setup Instructions:

1. Make sure that you are in the `Programming_Languages_Project_3` directory.

2. To run the functional program, follow these steps:

  - Open a terminal:
    ```bash
    swipl -s airline_travel.pl
    ```
  - Enter a query such as:
    ```bash
    flight_to_destination('PHX').
    ```
