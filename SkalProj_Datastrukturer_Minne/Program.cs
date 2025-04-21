using System;

namespace SkalProj_Datastrukturer_Minne;

class Program
{
    /// <summary>
    /// The main method, vill handle the menues for the program
    /// </summary>
    /// <param name="args"></param>
    static void Main()
    {

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                + "\n1. Examine a List"
                + "\n2. Examine a Queue"
                + "\n3. Examine a Stack"
                + "\n4. CheckParenthesis"
                + "\n0. Exit the application");
            char input = ' '; //Creates the character input to be used with the switch-case below.
            try
            {
                input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
            }
            catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
            {
                Console.Clear();
                Console.WriteLine("Please enter some input!");
            }
            switch (input)
            {
                case '1':
                    ExamineList();
                    break;
                case '2':
                    ExamineQueue();
                    break;
                case '3':
                    ExamineStack();
                    break;
                case '4':
                    CheckParanthesis();
                    break;
                /*
                 * Extend the menu to include the recursive 
                 * and iterative exercises.
                 */
                case '0':
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
            }
        }
    }

    /// <summary>
    /// Examines the datastructure List
    /// 
    /// </summary>
    static void ExamineList()
    {
        /*
            The capacity of the list doubles in size when the count of the List would be greater than the capacity of the list.
            If the capacity of the list were to increase each time we add an item to the list, 
            we would have to copy all the items from the internal array into a new one each time we add an item,
            which in turn would lead to poor performance in high capacity situations.
            The capacity of the list does not decrease as we remove items from it.
                
            Conclusion: If we know how many items we will be using or if we have a max roof of items that can be in use, 
            we should prefer to use an array over the list datastructure.
        */
        bool isAddingItems = true;
        List<string> list = [];
        Console.Clear();
        do
        {
            Console.WriteLine(
                $"{Environment.NewLine} Enter your input" +
                $"{Environment.NewLine}Add a + sign as your first character to add an item to the list" +
                $"{Environment.NewLine}Add a - sign as your first character to remove an item from the list" +
                $"{Environment.NewLine}Write the letter e to exit to the main menu");
            Console.Write("Input: ");

            string? input = Console.ReadLine();
            if (input is null)
            {
                DisplayTextWithColor("Input can't be null.", Status.Error);
                continue;
            }
            char nav = char.ToLower(input[0]);
            if (input.Length <= 1 && nav is not 'e')
            {
                DisplayTextWithColor("Input needs to be longer than one character.", Status.Error);
                continue;
            }

            string listInput = input[1..];

            switch (nav)
            {
                case '+':
                    list.Add(listInput);
                    DisplayTextWithColor($"Added: {listInput}", Status.Ok);
                    DisplayCapacity(list);
                    break;
                case '-':
                    bool success = list.Remove(listInput);
                    if (success)
                        DisplayTextWithColor($"Removed: {listInput}", Status.Ok);
                    else
                        DisplayTextWithColor($"{listInput} not found in list", Status.Error);
                    DisplayCapacity(list);
                    break;
                case 'e':
                    isAddingItems = false;
                    break;
                default:
                    DisplayTextWithColor("Use + or - as a prefix to what you want to add or remove from the list.", Status.Warning);
                    break;
            }
        }
        while (isAddingItems);

        static void DisplayCapacity<T>(List<T> items) => Console.WriteLine($"List Capacity: {items.Capacity}\nList Count: {items.Count}");

    }

    /// <summary>
    /// Examines the datastructure Queue
    /// </summary>
    static void ExamineQueue()
    {
        /*
         * Loop this method untill the user inputs something to exit to main menue.
         * Create a switch with cases to enqueue items or dequeue items
         * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
        */

        bool isAddingItems = true;
        Queue<string> queue = [];
        Console.Clear();
        do
        {
            Console.WriteLine(
                $"{Environment.NewLine}Enter your input" +
                $"{Environment.NewLine}Add a + sign as your first character to enqueue an item" +
                $"{Environment.NewLine}Write - to dequeue an item" +
                $"{Environment.NewLine}Write the letter e to exit to the main menu");
            Console.Write("Input: ");

            string? input = Console.ReadLine();
            if (input is null)
            {
                DisplayTextWithColor("Input can't be null.", Status.Error);
                continue;
            }
            char nav = char.ToLower(input[0]);

            string listInput = input[1..];

            switch (nav)
            {
                case '+':
                    queue.Enqueue(listInput);
                    DisplayTextWithColor($"Enqueued: {listInput}", Status.Ok);
                    break;
                case '-':
                    if (queue.TryDequeue(out string? s))
                        DisplayTextWithColor($"Dequeued: {s}", Status.Ok);
                    else
                        DisplayTextWithColor("Queue is empty", Status.Error);
                    break;
                case 'e':
                    isAddingItems = false;
                    break;
                default:
                    DisplayTextWithColor("Use + or - as a prefix to what you want to enqueue or dequeue from the queue.", Status.Warning);
                    break;
            }
        }
        while (isAddingItems);
    }

    /// <summary>
    /// Examines the datastructure Stack
    /// </summary>
    static void ExamineStack()
    {
        /*
         * Loop this method until the user inputs something to exit to main menue.
         * Create a switch with cases to push or pop items
         * Make sure to look at the stack after pushing and and poping to see how it behaves
        */


        bool isAddingItems = true;
        Stack<string> stack = [];
        Console.Clear();
        do
        {
            Console.WriteLine(
                $"{Environment.NewLine}Enter your input" +
                $"{Environment.NewLine}Add a + sign as your first character to push an item" +
                $"{Environment.NewLine}Write - to pop an item" +
                $"{Environment.NewLine}Write the letter r to reverse a string" +
                $"{Environment.NewLine}Write the letter e to exit to the main menu");
            Console.Write("Input: ");

            string? input = Console.ReadLine();
            if (input is null)
            {
                DisplayTextWithColor("Input can't be null.", Status.Error);
                continue;
            }
            char nav = char.ToLower(input[0]);

            string listInput = input[1..];

            switch (nav)
            {
                case '+':
                    stack.Push(listInput);
                    DisplayTextWithColor($"Push: {listInput}", Status.Ok);
                    break;
                case '-':
                    if (stack.TryPop(out string? s))
                        DisplayTextWithColor($"Pop: {s}", Status.Ok);
                    else
                        DisplayTextWithColor("Stack is empty", Status.Error);
                    break;
                case 'e':
                    isAddingItems = false;
                    break;
                case 'r':
                    ReverseText();
                    break;
                default:
                    DisplayTextWithColor("Use + or - as a prefix to what you want to push or pop from the queue.", Status.Warning);
                    break;
            }
        }
        while (isAddingItems);



        static void ReverseText()
        {
            string? input;
            string? prompt = "Enter Text: ";
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                prompt = $"Invalid input{Environment.NewLine}Enter Text: ";
            }
            while (string.IsNullOrWhiteSpace(input));

            Stack<char> charStack = [];

            foreach (char c in input)
                charStack.Push(c);

            string result = "";

            while (charStack.TryPop(out char c))
                result += c;


            Console.WriteLine($"Your string reversed is: {result}");
        }
    }

    static void CheckParanthesis()
    {
        /*
         * Use this method to check if the paranthesis in a string is Correct or incorrect.
         * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
         * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
         */

        Dictionary<char, char> parenthesisPairs = new()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' }
        };

        string? input;
        string? prompt = "Enter text: ";
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            prompt = $"Invalid input{Environment.NewLine}Enter Text: ";
        }
        while (string.IsNullOrWhiteSpace(input));

        Stack<char> openingParenthesis = [];

        bool validParenthesis = true;

        for (int i = 0; i < input.Length && validParenthesis; i++)
        {
            char c = input[i];

            if (parenthesisPairs.ContainsValue(c))
                openingParenthesis.Push(c);
            else if (
                parenthesisPairs.TryGetValue(c, out char value) && 
                openingParenthesis.TryPop(out char op))
                validParenthesis = op == value;
        }


        if (validParenthesis)
            DisplayTextWithColor("Valid Parenthesis!", Status.Ok);
        else
            DisplayTextWithColor("Invalid Parenthesis!", Status.Error);

        Console.WriteLine("Press any button to go back to the main menu");
        Console.ReadKey();

    }


    static void DisplayTextWithColor(string text, Status status)
    {
        switch (status)
        {
            case Status.Ok:
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(text);
                break;
            case Status.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(text);
                break;
            case Status.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(text);
                break;
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
    enum Status
    {
        Ok,
        Warning,
        Error,
    }
}

