# Project 2 Functional Programming

## Definition:
- **Functional Programming**: A programming language that is based on evaluation of functions that map values onto other values:
  - In pure functional languages:
    - No side effects, no variables, no state
    - No assignment, no looping, just application and recursion
    - Functions can be passed to other functions
    - Functions can be returned from other functions

## Project Overview:
* Build an emulator for some simple computer arithmetic and logical operations:
  - Addition, subtraction
  - Bit-wise and, or, xor, not
* All operations will be done on an 8-bit value
  - Arithmetic operations will be on 8-bit signed integers: -128 to 127
  - All logical operations will be on 8-bit unsigned values: 0x0 to 0xFF

## Project Structure

```plaintext
└── Emulator
    ├── bin
    ├── obj
    ├── Emulator.fsproj
    └── Program.fs
```

## Setup Instructions:

1. Make sure that you are in the `Programming_Languages_Project_2` directory.

2. To run the functional program, follow these steps:

  - Open a terminal:
    ```bash
    cd Emulator
    ```
  - Start the program by running the following:
    ```bash
    dotnet run
    ```
