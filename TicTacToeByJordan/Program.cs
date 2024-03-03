namespace TicTacToeByJordan
{
    /// <summary>
    /// TIC TAC TOE PROJECT
    /// TODO: 
    /// --!CHECK [*] IF IT'S COMPLETED
    /// 
    ///  [*] MAKE THE FIELD IN CONSOLE
    ///  [*] MAKE THE FIELD IN 2D ARRAY
    ///  [*] LINKING
    ///  [*] SET USER INPUT
    ///  [*] PRINT USER INPUT IN FIELD CONSOLE
    ///  [*] LOOPING UNTIL WINNING OR DRAW
    ///  [*] MAKE PLAYERS
    ///  [*] MAKE WINNING CONDITIONS
    ///  [*] MAKE DRAW
    ///  [*] MAKE PLAY AGAIN
    /// - ALL4NOW
    /// </summary>
    /// 

    class Program
    {
        // STATIC VARIABLES
        static int turns = 0;
        static string currentPlayer = "X";
        static bool validInput;
        static string? userInput;

        static string[,] field = new string[,]
        {
            {"1", "2", "3" },
            {"4", "5", "6" },
            {"7", "8", "9" }
        };

        // RUN THE GAME
        public static void Main(string[] args)
        {
            Menu();
        }

        // MENU
        public static void Menu()
        {
            string tiggerASCII = @"
                                   __,,,,_
                    _ __..-;''`--/'/ /.',-`-.
                (`/' ` |  \ \ \\ / / / / .-'/`,_
               /'`\ \   |  \ | \| // // / -.,/_,'-,
              /<7' ;  \ \  | ; ||/ /| | \/    |`-/,/-.,_,/')
             /  _.-, `,-\,__|  _-| / \ \/|_/  |    '-/.;.\'
             `-`  f/ ;      / __/ \__ `/ |__/ |
                  `-'      |  -| =|\_  \  |-' |
                        __/   /_..-' `  ),'  //
                       ((__.-'((___..-'' \__.'";
            Console.WriteLine(tiggerASCII);
            Console.WriteLine("                       Welcome to TIC TAC TOE");
            menuQuestion();
        }
        public static void menuQuestion()
        {
            Console.WriteLine("\nEnter 'PLAY' to start or 'EXIT' to close");
            string userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            if (userInput != null && userInput == "play")
                Play();
            else if (userInput != null && userInput == "exit")
                Exit();
            else
                Console.WriteLine("Write a valid key subnormal");
                menuQuestion();
        }

        // PLAY BUTTON
        public static void Play()
        {
            Console.Clear();
            Field();
            WinCondition();
            PlayerInput();
        }

        // LINKED CURRENT FIELD
        public static void Field()
        {
            Console.WriteLine("");
            Console.WriteLine($"                             |     |     ");
            Console.WriteLine($"                          {field[0, 0]}  |  {field[0, 1]}  |  {field[0, 2]}  ");
            Console.WriteLine("                        _____|_____|_____");
            Console.WriteLine($"                             |     |     ");
            Console.WriteLine($"                          {field[1, 0]}  |  {field[1, 1]}  |  {field[1, 2]}  ");
            Console.WriteLine("                        _____|_____|_____");
            Console.WriteLine($"                             |     |     ");
            Console.WriteLine($"                          {field[2, 0]}  |  {field[2, 1]}  |  {field[2, 2]}  ");
            Console.WriteLine($"                             |     |     ");
        }

        //INPUT VALIDATION
        public static void PlayerInput()
        {
            Console.WriteLine($"\nPlayer '{currentPlayer}' is your turn!\nSelect a box with number");
            userInput = Console.ReadLine();
            do
            {
                if    ((userInput != null && userInput == "1") && field[0, 0] == "1"
                    || (userInput != null && userInput == "2") && field[0, 1] == "2"
                    || (userInput != null && userInput == "3") && field[0, 2] == "3"
                    || (userInput != null && userInput == "4") && field[1, 0] == "4"
                    || (userInput != null && userInput == "5") && field[1, 1] == "5"
                    || (userInput != null && userInput == "6") && field[1, 2] == "6"
                    || (userInput != null && userInput == "7") && field[2, 0] == "7"
                    || (userInput != null && userInput == "8") && field[2, 1] == "8"
                    || (userInput != null && userInput == "9") && field[2, 2] == "9")
                {
                    MakeChanges();
                    validInput = true;
                }
                else
                    Console.WriteLine("Invalid character, try again");
                    validInput = false;
                    PlayerInput();
            } while (!validInput);
        }

        //MAKE CHANGES
        public static void MakeChanges()
        {
            Console.Clear();
            while (true)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        if (userInput != null && userInput == field[i, j])
                        {
                            field[i, j] = currentPlayer;
                            turns++;
                            SwitchPlayer();
                            Play();
                        }
                    }
                }
            }
        }

        //SWITCH PLAYERS
        public static string SwitchPlayer()
        {
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
            return currentPlayer;
        }

        //CHECK WINNING CONDITIONS
        public static void WinCondition()
        {
            //X WINNER
            if ((field[0, 0] == "X" && field[0, 1] == "X" && field[0, 2] == "X") // X X X 1 ROW
               || (field[1, 0] == "X" && field[1, 1] == "X" && field[1, 2] == "X") // X X X 2 ROW
               || (field[2, 0] == "X" && field[2, 1] == "X" && field[2, 2] == "X") // X X X 3 ROW
               || (field[0, 0] == "X" && field[1, 0] == "X" && field[2, 0] == "X") // X X X 1 COLUMN
               || (field[0, 1] == "X" && field[1, 1] == "X" && field[2, 1] == "X") // X X X 2 COLUMN
               || (field[0, 2] == "X" && field[1, 2] == "X" && field[2, 2] == "X") // X X X 3 COLUMN
               || (field[0, 0] == "X" && field[1, 1] == "X" && field[2, 2] == "X") // X X X DIAG LEFT RIGHT
               || (field[0, 2] == "X" && field[1, 1] == "X" && field[2, 0] == "X"))// X X X DIAG RIGHT LEFT
            {
                string catASCII = @"
 _._     _,-'""`-._
(,-.`._,'(       |\`-/|
    `-.-' \ )-`( , o o)
          `-    \`_`""'-";
                Console.WriteLine(catASCII);
                Console.WriteLine("········Player 1 Win!·····");
                PlayAgain();
            }
            //O WINNER
            else if ((field[0, 0] == "O" && field[0, 1] == "O" && field[0, 2] == "O") // O O O 1 ROW
               || (field[1, 0] == "O" && field[1, 1] == "O" && field[1, 2] == "O") // O O O 2 ROW
               || (field[2, 0] == "O" && field[2, 1] == "O" && field[2, 2] == "O") // O O O 3 ROW
               || (field[0, 0] == "O" && field[1, 0] == "O" && field[2, 0] == "O") // O O O 1 COLUMN
               || (field[0, 1] == "O" && field[1, 1] == "O" && field[2, 1] == "O") // O O O 2 COLUMN
               || (field[0, 2] == "O" && field[1, 2] == "O" && field[2, 2] == "O") // O O O 3 COLUMN
               || (field[0, 0] == "O" && field[1, 1] == "O" && field[2, 2] == "O") // O O O DIAG LEFT RIGHT
               || (field[0, 2] == "O" && field[1, 1] == "O" && field[2, 0] == "O"))// O O O DIAG RIGHT LEFT
            {
                string batASCII = @"
   /\                 /\
  / \'._   (\_/)   _.'/ \
 /_.''._'--('.')--'_.''._\
 | \_ / `;=/ "" \=;` \ _/ |
 \/ `\__|\`\___/`|__/`  \/
          \(/|\)/       
           "" ` "" ";
                Console.WriteLine(batASCII);
                Console.WriteLine("········Player 2 Win!·····");
                PlayAgain();
            }
            //DRAW
            if (turns >= 9)
            {
                string sleepCatASCII = @"
      |\      _,,,---,,_
ZZZzz /,`.-'`'    -.  ;-;;,_
     |,4-  ) )-,_. ,\ (  `'-'
    '---''(_/--'  `-'\_)
";
                Console.WriteLine(sleepCatASCII);
                Console.WriteLine("········Draw!·····");
                PlayAgain();
            }
        }

        //RESET GAME

        // SET CLEAN FIELD
        public static void NewField()
        {
            string[,] newField = new string[,]
            {
                {"1", "2", "3" },
                {"4", "5", "6" },
                {"7", "8", "9" }
            };
            field = newField;
        }

        // ASK IF PLAY AGAIN
        public static void PlayAgain()
        {
            //SET ALL DEFAULT
            SetDefault();
            Console.WriteLine("Do you want to play again? (Y/N)");
            string playAgain = Console.ReadLine();
            playAgain = playAgain.ToLower();
            if (playAgain != null && playAgain == "y")
            {
                Console.Clear();
                Play();
            }else
                Exit();
        }

        // SET DEFAULT
        public static void SetDefault()
        {
            NewField();
            turns = 0;
            currentPlayer = "X";
        }

        // EXIT BUTTON
        public static void Exit()
        {
            Console.Clear();
            Console.WriteLine("                           Bye bye n.n!");
            Console.WriteLine("                              /\\_/\\");
            Console.WriteLine("                             / o o \\");
            Console.WriteLine("                            (   \"   )");
            Console.WriteLine("                             \\~(*)~/");
            Console.WriteLine("                              |___|");
            Console.WriteLine("\nPress a key to close");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}