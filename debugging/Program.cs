using System;
using System.Diagnostics;

public class Debugging
{
    public static void Main(string[] args)
    {
        // store challenge task
        
        // This application manages transactions at a store check-out line. The
        // check-out line has a cash register, and the register has a cash till
        // that is prepared with a number of bills each morning. The till includes
        // bills of four denominations: $1, $5, $10, and $20. The till is used
        // to provide the customer with change during the transaction. The item 
        // cost is a randomly generated number between 2 and 49. The customer 
        // offers payment based on an algorithm that determines a number of bills
        // in each denomination. 

        // Each day, the cash till is loaded at the start of the day. As transactions
        // occur, the cash till is managed in a method named MakeChange (customer 
        // payments go in and the change returned to the customer comes out). A 
        // separate "safety check" calculation that's used to verify the amount of
        // money in the till is performed in the "main program". This safety check
        // is used to ensure that logic in the MakeChange method is working as 
        // expected.

        string? readResult = null;
        bool useTestData = false;

        Console.Clear();

        int[] cashTill = [0, 0, 0, 0]; // collection expression
        int registerCheckTillTotal = 0;

        // registerDailyStartingCash: $1 x 50, $5 x 20, $10 x 10, $20 x 5 => ($350 total)
        int[,] registerDailyStartingCash = 
            new int[,] { { 1, 50 }, { 5, 20 }, { 10, 10 }, { 20, 5 } };

        int[] testData = [6, 10, 17, 20, 31, 36, 40, 41];
        int testCounter = 0;

        LoadTillEachMorning(registerDailyStartingCash, cashTill);

        registerCheckTillTotal = registerDailyStartingCash[0, 0] * registerDailyStartingCash[0, 1]
                                + registerDailyStartingCash[1, 0] * registerDailyStartingCash[1, 1]
                                + registerDailyStartingCash[2, 0] * registerDailyStartingCash[2, 1]
                                + registerDailyStartingCash[3, 0] * registerDailyStartingCash[3, 1];

        // display the number of bills of each denomination currently in the till
        LogTillStatus(cashTill);

        // display a message showing the amount of cash in the till
        Console.WriteLine(TillAmountSummary(cashTill));

        // display the expected registerDailyStartingCash total
        Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");

        var valueGenerator = new Random((int)DateTime.Now.Ticks);

        int transactions = 100;

        if (useTestData)
        {
            transactions = testData.Length;
        }

        while (transactions > 0)
        {
            transactions -= 1;
            int itemCost = valueGenerator.Next(2, 50);

            if (useTestData)
            {
                itemCost = testData[testCounter];
                testCounter += 1;
            }

            int paymentOnes = itemCost % 2;                 // itemCost ODD --> value = 1, itemCost EVEN --> value = 0         
            int paymentFives = (itemCost % 10 > 7) ? 1 : 0; // itemCost ends with 8 or 9 --> value = 1 ELSE value = 0  
            int paymentTens = (itemCost % 20 > 13) ? 1 : 0; // (13 < itemCost < 20) OR (33 < itemCost < 40) --> value = 1, ELSE value = 0
            int paymentTwenties = (itemCost < 20) ? 1 : 2;  // itemCost < 20 --> value = 1, ELSE value = 2

            // display messages describing the current transaction
            Console.WriteLine($"Customer is making a ${itemCost} purchase");
            Console.WriteLine($"\t Using {paymentTwenties} twenty dollar bills");
            Console.WriteLine($"\t Using {paymentTens} ten dollar bills");
            Console.WriteLine($"\t Using {paymentFives} five dollar bills");
            Console.WriteLine($"\t Using {paymentOnes} one dollar bills");


            try
            {
                // MakeChange manages the transaction and updates the till 
                MakeChange(itemCost, cashTill, paymentTwenties, paymentTens, paymentFives, paymentOnes);

                // Backup Calculation - each transaction adds current "itemCost" to the till
                registerCheckTillTotal += itemCost;
            } 
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Couldn't complete tranasaction: {ex.Message}");
            } 
            
            Console.WriteLine(TillAmountSummary(cashTill));
            Console.WriteLine($"Expected till value: {registerCheckTillTotal}\n\r");
            Console.WriteLine();
        }

        Console.WriteLine("Press the Enter key to exit");
        do
        {
            readResult = Console.ReadLine();

        } while (readResult == null);

        
        void LoadTillEachMorning(int[,] registerDailyStartingCash, int[] cashTill)
        {
            cashTill[0] = registerDailyStartingCash[0, 1];
            cashTill[1] = registerDailyStartingCash[1, 1];
            cashTill[2] = registerDailyStartingCash[2, 1];
            cashTill[3] = registerDailyStartingCash[3, 1];
        }


        void MakeChange(int cost, int[] cashTill, int twenties, int tens = 0, int fives = 0, int ones = 0)
        {
            int availableTwenties = cashTill[3] += twenties;
            int availableTens = cashTill[2] += tens;
            int availableFives = cashTill[1] += fives;
            int availableOnes = cashTill[0] += ones;

            int amountPaid = twenties * 20 + tens * 10 + fives * 5 + ones;
            int changeNeeded = amountPaid - cost;

            if (changeNeeded < 0)
                throw new InvalidOperationException("\nInvalidOperationException: Not enough money provided to complete the transaction.");

            Console.WriteLine("Cashier prepares the following change:");

            while ((changeNeeded > 19) && (cashTill[3] > 0))
            {
                availableTwenties--;
                changeNeeded -= 20;
                Console.WriteLine("\t A twenty");
            }

            while ((changeNeeded > 9) && (cashTill[2] > 0))
            {
                availableTens--;
                changeNeeded -= 10;
                Console.WriteLine("\t A ten");
            }

            while ((changeNeeded > 4) && (cashTill[1] > 0))
            {
                availableFives--;
                changeNeeded -= 5;
                Console.WriteLine("\t A five");
            }

            while ((changeNeeded > 0) && (cashTill[0] > 0))
            {
                availableOnes--;
                changeNeeded--;
                Console.WriteLine("\t A one");
            }

            if (changeNeeded > 0)
                throw new InvalidOperationException("\nInvalidOperationException: The till is unable to make the correct change.");
            
            cashTill[0] = availableOnes;
            cashTill[1] = availableFives;
            cashTill[2] = availableTens;
            cashTill[3] = availableTwenties;
        }

        void LogTillStatus(int[] cashTill)
        {
            Console.WriteLine("The till currently has:");
            Console.WriteLine($"{cashTill[3] * 20} in twenties");
            Console.WriteLine($"{cashTill[2] * 10} in tens");
            Console.WriteLine($"{cashTill[1] * 5} in fives");
            Console.WriteLine($"{cashTill[0]} in ones");
            Console.WriteLine();
        }

        string TillAmountSummary(int[] cashTill)
        {
            return $"The till has {cashTill[3] * 20 
                                + cashTill[2] * 10 
                                + cashTill[1] * 5 
                                + cashTill[0]} dollars";
        }
        


        // practice task
        /*
        string[][] userEnteredValues = new string[][]
        {
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
        };

        // main try catch
        try
        {
            Workflow1(userEnteredValues);
            Console.WriteLine("'Workflow1' completed successfully.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("An error occurred during 'Workflow1'.");
            Console.WriteLine(ex.Message);
        }


        static void Workflow1(string[][] userEnteredValues)
        {
            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    Process1(userEntries);
                    Console.WriteLine("'Process1' completed successfully.");
                    Console.WriteLine();
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("'Process1' encountered an issue, process aborted.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine();
                }
            }
        }

        static void Process1(string[] userEntries)
        {
            int valueEntered;

            foreach (string userValue in userEntries)
            {
                bool integerFormat = int.TryParse(userValue, out valueEntered);

                if (integerFormat == true)
                {
                    if (valueEntered != 0)
                    {
                        checked
                        {
                            int calculatedValue = 4 / valueEntered;
                        }
                    }
                    else
                    {
                        throw new DivideByZeroException("Invalid data. User input values must be non-zero values");
                    }
                }
                else
                {
                    throw new FormatException("Invalid data. User input values must be valid integers.");
                }
            }
        }
        */

        // 6th task   |   input validation
        /*
        Console.Write("\nEnter the lower bound: ");
        int lowerBound = int.Parse(Console.ReadLine()); 

        Console.Write("Enter the upper bound: ");
        int upperBound = int.Parse(Console.ReadLine());

        decimal averageValue = 0;

        bool continueEntering = true;
        do
        {
            try 
            {
                // Calculate the sum of the even numbers between the bounds
                averageValue = AverageOfEvenNumbers(lowerBound, upperBound);

                // Display the value returned by AverageOfEvenNumbers in the console
                Console.WriteLine($"\nThe average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
                continueEntering = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {   
                Console.WriteLine("\nAn error has been occured!");
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Enter upper bound greater than {lowerBound}");
                
                Console.Write("Enter new upper bound (or q! to exit): ");
                string? userResponse = Console.ReadLine();

                if (userResponse.ToLower().Contains("q!"))
                {
                    continueEntering = false;
                }
                else 
                {
                    // continueEntering = true;
                    upperBound = int.Parse(userResponse);
                }
            }
        }
        while (continueEntering);

        // show stack trace of program to see where is an error
        StackTrace stackTrace = new StackTrace();
        Console.WriteLine("\n-----------------------------------");
        Console.WriteLine("Stack Trace: " + stackTrace.ToString());
        Console.WriteLine("\n-----------------------------------");
        
        Console.ReadLine();

        static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
        {
            if (lowerBound >= upperBound)
            {
                throw new ArgumentOutOfRangeException("upperbound", 
                    "ArgumentOutOfRangeException: upper bound must be grater than lower bound");
            }

            int sum = 0;
            int count = 0;
            decimal average = 0;

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                    count++;
                }
            }

            average = (decimal)sum / count;

            return average;
        }
        */

        // 5th task   |   throwing exceptions
        /*
        try 
        {
            Operation();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Exiting program..");
        }

        void Operation()
        {
            string[][] userEnteredValues = new string[][]
            {
                new string[] { "1", "two", "3"},
                new string[] { "0", "1", "2"}
            };

            foreach (string[] userEntries in userEnteredValues)
            {
                try
                {
                    ParseProcess(userEntries);
                }
                catch (Exception ex)
                {
                    if (ex.StackTrace.Contains("ParseProcess"));
                    {
                        if (ex is FormatException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Corrective action taken in Operation()");
                        }
                        else if (ex is DivideByZeroException)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Partial correction in Operation() - further action required");

                            // re-throw the original exception 
                            throw;
                        }
                        else 
                        {
                            // create a new exception object that wraps the original exception
                            throw new ApplicationException("An error occured: ", ex);
                        }
                    }
                }

            }
        }

        void ParseProcess(string[] userInput)
        {
            int valueEntered;

            foreach (string value in userInput)
            {
                try 
                {
                    valueEntered = int.Parse(value);

                    checked
                    {
                        int calculatedValue = 4 / valueEntered;
                    }
                }
                catch (FormatException)
                {
                    FormatException invalidFormat = new FormatException(
                        "Format Exception: user input values in ParseProcess() must be valid integers");
                    
                    throw invalidFormat;
                }
                catch (DivideByZeroException)
                {
                    DivideByZeroException unexpectedDivideByZero = new DivideByZeroException(
                        "Dividing By Zero: Calculation in ParseProcess() encountered an unexpected divide by zero");

                    throw unexpectedDivideByZero;
                }
            }
        }
        */

        // 4th task   |   catch specific exceptions
        /*
        try 
        {
            checked
            {
                try
                {
                    int num1 = int.MaxValue;
                    int num2 = int.MaxValue;
                    int result = num1 + num2;
                    Console.WriteLine("Result: " + result);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Error: The number is too large to be represented as an integer." + ex.Message);
                }
            }

            try 
            {
                string str = null;
                int length = str.Length;
                Console.WriteLine("String Length: " + length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error: The reference is null." + ex.Message);
            }
                
            try
            {
                int[] numbers = new int[5];
                numbers[5] = 10;
                Console.WriteLine("Number at index 5: " + numbers[5]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error: Index out of range." + ex.Message);
            }

            try
            {
                int num3 = 10;
                int num4 = 0;
                int result2 = num3 / num4;
                Console.WriteLine("Result: " + result2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Error: Cannot divide by zero." + ex.Message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected exception: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Exiting program.");
        }
        */
        
        // 3rd task   |   exploring call stack & try catch
        /*
        try
        {
            Process1();
        }
        catch
        {
            Console.WriteLine("An exception has occurred");
        }
        finally
        {
            Console.WriteLine("Exit program");
        }
        
        static void Process1()
        {
            try 
            {
                WriteMessage();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Expected Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in Process1, \nError: {ex.Message}");
            }
        }

        static void WriteMessage()
        {
            double float1 = 3000.0;
            double float2 = 0.0;
            int number1 = 3000;
            int number2 = 0;
            byte smallNumber;

            try 
            {
                Console.WriteLine(float1 / float2);
                Console.WriteLine(number1 / number2);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Expected error inside WriteMessage(): " + ex.Message);
            }
            checked
            {
                try 
                {
                    smallNumber = (byte)number1;
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Cast error: " + ex.Message);
                }
            }
        }
        */

        // 2nd task   |   using debuger
        /*
        string? readResult;
        int startIndex = 0;
        bool goodEntry = false;

        int[] numbers = { 1, 2, 3, 4, 5 };

        // Display the array to the console.
        Console.Clear();
        Console.Write("\n\rThe 'numbers' array contains: { ");
        foreach (int number in numbers)
        {
            Console.Write($"{number} ");
        }

        // To calculate a sum of array elements, 
        //  prompt the user for the starting element number.
        Console.Write($"}}\n\r\n\rTo sum values 'n' through 5, enter a value for 'n': ");
        while (goodEntry == false)
        {
            readResult = Console.ReadLine();
            goodEntry = int.TryParse(readResult, out startIndex);

            if (startIndex > 5)
            {
                goodEntry = false;
                Console.Write("\n\rEnter an integer value between 1 and 5: ");
            }
        }

        // Display the sum and then pause.
        Console.WriteLine($"\n\rThe sum of numbers {startIndex} through {numbers.Length} " 
                        + $"is: {SumValues(numbers, startIndex - 1)}");

        Console.WriteLine("press Enter to exit");
        readResult = Console.ReadLine();
        */

        // 1st task   |   using conditional breakpoint for 'new' products
        /*
        int productCount = 2000;
        string[,] products = new string[productCount, 2];

        LoadProducts(products, productCount);

        for (int i = 0; i < productCount; i++)
        {
            string result;
            result = Process1(products, i);

            if (result != "obsolete")
            {
                result = Process2(products, i);
            }
        }

        bool pauseCode = true;
        while (pauseCode == true);
        */
    }

    // second task method
    /*
    static int SumValues(int[] numbers, int n)
    {
        int sum = 0;
        for (int i = n; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    */

    // first task methods
    /*
    static void LoadProducts(string[,] products, int productCount)
        {
            Random rand = new Random();

            for (int i = 0; i < productCount; i++)
            {
                int num1 = rand.Next(1, 10000) + 10000;
                int num2 = rand.Next(1, 101); // 1% chance that product will be marked as new

                string prodID = num1.ToString();

                if (num2 < 91)
                {
                    products[i, 1] = "existing";
                }
                else if (num2 == 91)
                {
                    products[i, 1] = "new";
                    prodID = prodID + "-n";
                }
                else
                {
                    products[i, 1] = "obsolete";
                    prodID = prodID + "-0";
                }

                products[i, 0] = prodID;
            }
        }

        static string Process1(string[,] products, int item)
        {
            Console.WriteLine($"Process1 message - working on {products[item, 1]} product");

            return products[item, 1];
        }

        static string Process2(string[,] products, int item)
        {
            Console.WriteLine($"Process2 message - working on product ID #: {products[item, 0]}");
            if (products[item, 1] == "new")
                Process3(products, item);

            return "continue";
        }

        static void Process3(string[,] products, int item)
        {
            Console.WriteLine($"Process3 message - processing product information for 'new' product");
        }
        */
}