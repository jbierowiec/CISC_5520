open System

// converts decimal to binary
let decimalToBinary (value: int) : string =
    let binary = Convert.ToString((if value < 0 then value + 256 else value), 2)
    binary.PadLeft(8, '0')

// binary addition function, adds two binary numbers, converts them back to decimal and outputs the decimal value
let binaryAdd (a: string) (b: string) : string =
    let aVal = if a.[0] = '1' then Convert.ToInt32(a, 2) - 256 else Convert.ToInt32(a, 2)
    let bVal = if b.[0] = '1' then Convert.ToInt32(b, 2) - 256 else Convert.ToInt32(b, 2)
    decimalToBinary (aVal + bVal)

// binary subtraction function, subtracts two binary numbers, converts them back to decimal and outputs the decimal value
let binarySubtract (a: string) (b: string) : string =
    // Convert binary strings to integers, considering two's complement for negative values
    let aVal = if a.[0] = '1' then Convert.ToInt32(a, 2) - 256 else Convert.ToInt32(a, 2)
    let bVal = if b.[0] = '1' then Convert.ToInt32(b, 2) - 256 else Convert.ToInt32(b, 2)
    // Perform subtraction and convert back to binary, handling two's complement
    decimalToBinary (aVal - bVal)

// Converts binary to decimal
let binaryToDecimal (binary: string) : int =
    if binary.[0] = '1' then Convert.ToInt32(binary, 2) - 256
    else Convert.ToInt32(binary, 2)

// Converts binary to hexadecimal
let binaryToHex (binary: string) : string =
    let decimal = binaryToDecimal binary
    let hex = Convert.ToString(decimal, 16).ToUpper()
    if hex.Length < 2 then "0" + hex else hex

// Performs bitwise OR on two binary numbers
let binaryOr (a: string) (b: string) : string =
    let result = Array.init 8 (fun i -> if a.[i] = '1' || b.[i] = '1' then '1' else '0')
    String(result)

// Performs bitwise XOR on two binary numbers
let binaryXor (a: string) (b: string) : string =
    let result = Array.init 8 (fun i -> if a.[i] <> b.[i] then '1' else '0')
    String(result)

// Performs bitwise AND on two binary numbers
let binaryAnd (a: string) (b: string) : string =
    let result = Array.init 8 (fun i -> if a.[i] = '1' && b.[i] = '1' then '1' else '0')
    String(result)

let binaryNot (a: string) : string =
    // Invert each bit in the binary string
    a |> Seq.map (fun bit -> if bit = '0' then '1' else '0') |> Seq.toArray |> String

let formatHex (value: int) : string =
    // Format as hexadecimal and ensure no sign extension for positive values
    if value < 0 then sprintf "0x%X" (value &&& 0xFF) else sprintf "0x%X" value

// Converts the result of OR, XOR, AND, NOR operations to hexadecimal
let resultToHex (binary: string) : string = binaryToHex binary

let getUserInputAndOperate () =
    Console.WriteLine("Enter the operation (ADD, SUB, OR, XOR, AND, NOT):") // NOR replaced by NOT
    let operation = Console.ReadLine().ToUpper()

    match operation with
    | "ADD" | "SUB" ->
        Console.WriteLine("Enter the first number (decimal -128 to 127):")
        let num1 = Console.ReadLine() |> int

        Console.WriteLine("Enter the second number (decimal -128 to 127):")
        let num2 = Console.ReadLine() |> int

        let binary1 = decimalToBinary num1
        let binary2 = decimalToBinary num2

        let resultBinary = match operation with
                           | "ADD" -> binaryAdd binary1 binary2
                           | "SUB" -> binarySubtract binary1 binary2
                           | _ -> failwith "Unsupported operation"
        
        let resultDecimal = binaryToDecimal resultBinary
        Console.WriteLine($"First number in binary: {binary1}")
        Console.WriteLine($"Second number in binary: {binary2}")
        Console.WriteLine($"Resulting binary: {resultBinary}")
        Console.WriteLine($"Result in decimal: {resultDecimal}")

    | "OR" | "XOR" | "AND" | "NOT" ->
        let num1Hex = 
            Console.WriteLine("Enter the first hexadecimal number:")
            Console.ReadLine() |> fun hex -> Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(8, '0')

        let num2Hex = if operation <> "NOT" then // Skip second number for NOT operation
                          Console.WriteLine("Enter the second hexadecimal number:")
                          Console.ReadLine() |> fun hex -> Convert.ToString(Convert.ToInt32(hex, 16), 2).PadLeft(8, '0')
                      else "00000000" // Dummy value, not used for NOT

        let resultBinary = match operation with
                           | "OR" -> binaryOr num1Hex num2Hex
                           | "XOR" -> binaryXor num1Hex num2Hex
                           | "AND" -> binaryAnd num1Hex num2Hex
                           | "NOT" -> binaryNot num1Hex // Handle NOT operation
                           | _ -> failwith "Unsupported operation"

        let resultHex = formatHex (binaryToDecimal resultBinary) // Adjust the formatHex function for hexadecimal output
        Console.WriteLine($"First number in binary: {num1Hex}")
        if operation <> "NOT" then Console.WriteLine($"Second number in binary: {num2Hex}")
        Console.WriteLine($"Resulting binary: {resultBinary}")
        Console.WriteLine($"Result in hexadecimal: {resultHex}")

    | _ -> Console.WriteLine("Unsupported operation")

// Function to call user input
getUserInputAndOperate()
