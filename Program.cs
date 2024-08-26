using System;
using System.Text;
using Figgle;
using static System.Net.Mime.MediaTypeNames;
class Program
{
    public static double x; // making x public so it can be accessed across classes and methods
    public static double y; // making x public so it can be accessed across classes and methods

    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Blue; //setting console background to blue
        Console.ForegroundColor = ConsoleColor.Yellow; // setting console text color to yellow
        Console.WriteLine(FiggleFonts.Standard
            .Render("Calculator v2"));
        Console.WriteLine("Welcome! Please select one of the following options.");
        Console.WriteLine("a to Add");
        Console.WriteLine("m to Multiply");
        Console.WriteLine("s to Subtract");
        Console.WriteLine("d to Divide");
        Console.WriteLine("q to Exit");
        char operation = char.Parse(Console.ReadLine()); //getting char input from user

        switch (operation) //based on char input, cooresponding method will be called
        {
            case 'a':
                readNum();
                Calculations.Sum(x, y);
                break;
            case 'm':
                readNum();
                Calculations.Mult(x, y);
                break;
            case 'd':
                readNum();
                Calculations.Div(x, y);
                break;
            case 's':
                readNum();
                Calculations.Sub(x, y);
                break;
            case 'q':
                quitGame(); //calling a function that handles closing the console if the user wants to quit
                break;

            /* TEST FUNCTION TO SEE IF THE CALCULATOR ART WAS PRINTING CORRECTLY
        case 'p':
            String printout = (32 + " + " + 23);
            configCalc(printout,8);
            break;
            */
            default:
                resetColor(); // callling a custom function that resets the console to black background and white text
                Console.ForegroundColor = ConsoleColor.Red; //setting console text color to red so that the error message shows up in red
                Console.Clear(); // clearing everything above this point in the console
                Console.WriteLine("Invalid operation entered. Try again."); //printing error message
                resetColor(); // callling a custom function that resets the console to black background and white text
                Main(); //calling Main again so that the program effectively restarts without re-running it
                break;
        }



    }
    public static void readNum()
    {
        //function that assigns x and y values to valid numbers
        x = getValidNumber(nameof(x));
        y = getValidNumber(nameof(y));

    }
    public static double getValidNumber(string varName) //takes in the variable name as a string so that the same method can be re-used for mulitple variables of different names
    {
        Boolean isNumber = false; //setting up initial value
        double validNum = 0; // setting up intial value
        while (!isNumber)
        {
            Console.Write("Enter " + varName + ":  "); // Prompting user to enter a value for the specified variable passed into the method
            string input = Console.ReadLine(); //getting input from user as a string
            bool check = double.TryParse(input, out _); //checking to see if the string input is parsable as a double
            if (check) // if the string is parsable as a double (i.e. boolean = true)
            {
                //number is a parsable double so we parse it for real and store it into a double variable;
                validNum = double.Parse(input.ToString());
                isNumber = true; // setting to true so that it will exit the loop after this run


            }
            else
            {
                //string is not parsable as a valid double, so error message is printed 
                Console.WriteLine("Enter a Valid Digit.");
                //loop will execute again (prompting user to enter another value) because isNumber is still set to the default value of false.
            }
        }
        return validNum; // will only reach this point if a valid number was entered. Returns the users input as a maniputable double 
    }

    public class Calculations
    { //this class groups together all of the methods responsible for arithmetic functions
        public static void Sum(double x, double y)
        {
            configCalc((x + "+" + y), x + y);// sends the equation and the sum into the configCalc function,which is what will print both into the calculator aasci art
            //   Printer("Sum", x + y);
        }
        public static void Mult(double x, double y)
        {
            configCalc((x + "*" + y), x * y); // sends the equation and the product to the configCalc function,which is what will print both into the calculator aasci art
            // Printer("Product", x * y);
        }
        public static void Div(double x, double y)
        {
            configCalc((x + "/" + y), x / y); // sends the equation and the answer into the configCalc function,which is what will print both into the calculator aasci art
            // Printer("Quotient", x / y);

        }
        public static void Sub(double x, double y)
        {
            configCalc((x + "-" + y), x - y); // sends the equation and the answer into the configCalc function,which is what will print both into the calculator aasci art
            //Printer("Difference", x - y);
        }

    }

    /* DEFUNCT PRINTER METHOD ORIGINALLY USED FOR TESTING
     public static void Printer(String whichMethod, double answer)
    {
        resetColor();
        Console.Clear();

        //Console.BackgroundColor = ConsoleColor.White;
        // Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(whichMethod + " is: " + answer);
        Restart();
    }
    */
    public static void Restart() //method that is invoked after a successful calculation is provoked
    {
        resetColor(); // changing console foreground and background colors back to default
        Console.WriteLine("Please enter r to restart."); //presenting the user with the key input needed for restart
        Console.WriteLine("Enter any other key to quit.");// presenting hte user with the key input needed for quit
#pragma warning disable CS8604 // Possible null reference argument.
        char letter = char.Parse(Console.ReadLine()); //getting the key that user pressed
#pragma warning restore CS8604 // Possible null reference argument.

        if (letter == 'r') //if they pressed r
        {
            Console.Clear(); //clear everything in the console prior to this point
            Main(); //call the main method again and restart the program

        }
        else //any other key was entered 
        {

            quitGame(); // calls quitGame method
        }
    }
    public static void quitGame()
    {
        resetColor(); // reseting console colors to default
        Console.Clear(); // clear everything in console to that point
        Console.ForegroundColor = ConsoleColor.Green; //chaning console text color to green
        Console.WriteLine(FiggleFonts.Starwars.Render("Goodbye!")); //printing goodbye message using 
        resetColor(); // reseting console colors to default
        System.Environment.Exit(0); //exiting program
    }
    public static void resetColor() //resets console colors to default
    {
        Console.ForegroundColor = ConsoleColor.White; //default foreground color is white
        Console.BackgroundColor = ConsoleColor.Black; //default background color is black
    }
    public static void configCalc(string equation, double result) //method that takes in the equation and result and prints out both into their respective calculator aasci art
    {
        string resultString = result.ToString();
        if (result == Double.PositiveInfinity || result == Double.NegativeInfinity)
        {
            resultString = "UNDEFINED";
        }
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;

        // string that holds the top portion of the calculator aasci art
        string calculatortop = @" 

 _____________________
|  _________________  |
| |                 | |
";
        // string that holds the bottom portion of the calculator aasci art
        string calculatorbottom = @" 
| |_________________| |
|  ___ ___ ___   ___  |
| | 7 | 8 | 9 | | + | |
| |___|___|___| |___| |
| | 4 | 5 | 6 | | - | |
| |___|___|___| |___| |
| | 1 | 2 | 3 | | x | |
| |___|___|___| |___| |
| | . | 0 | = | | / | |
| |___|___|___| |___| |
|_____________________|


"
        ;

        //Printing out two calculators,
        Console.Write(calculatortop); //printing top part of calculator
                                      //  Console.Write($"| |{equation.PadLeft((18 + equation.Length) / 2).PadRight(17)}| |"); // printing out the equation, and centering it
        Console.Write($"| |{equation.PadLeft((18 + equation.Length) / 2).PadRight(17).Substring(0, 17)}| |");
        Console.WriteLine(calculatorbottom); // printing bottom part of calculator --> so equation is placed on the calculator display
        Console.WriteLine("Calculating...");
        //Printing another calculator, this time with the answer to the equation
        System.Threading.Thread.Sleep(3000); Console.Write(calculatortop); //delaying the print by 3 seconds to give the appearance of calculating
        // Console.Write($"| |{resultString.PadLeft((18 + resultString.Length) / 2).PadRight(17)}| |"); // printing out the equation, and centering it
        Console.Write($"| |{resultString.PadLeft((18 + resultString.Length) / 2).PadRight(17).Substring(0, 17)}| |");
        Console.WriteLine(calculatorbottom); // printing bottom part of calculator --> so answer is placed on the calculator display
        Restart(); //calling Restart method
    }

}

