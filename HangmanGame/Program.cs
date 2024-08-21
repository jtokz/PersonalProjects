using System.Collections;
namespace HangmanGame
{
    // jueguito del ahorcado by jordan

    /// <summary>
    /// TODO LIST:
    /// [*] Make a list of words to choise one to play
    /// [*] Generate a random number by indexing in the list
    /// [*] Once got a word separate it in individual chars
    /// [*] Make an input
    /// [*] Make the dummie
    /// [*] Make a validation system when comproves that userInput is inside of the randomized word
    /// [*] isValid true
    /// [*] isValid = false: one step closer to death
    /// [*] Separate all code in different methods
    /// [*] Winning conditions
    /// [*] Losse conditions
    /// [*] Play again
    /// [*] Reset
    /// [*] Exit
    /// [*] for now...
    /// </summary>
    class Program
    {
        // static fields
        static Random index = new Random();

        static int randomIndex;
        static int errors = 0;

        static string? currentWord;
        static string? currentDummy;

        static char[]? charsField;
        static char input;
        

        static bool isValid = false;
        static bool allGuessed;

        static List<char> wrongLetters = new List<char>();
        static List<string> words = new List<string>
        {
            "gato", "perro", "pajaro", "elefante", "leon", "tigre", "oso", "rana", "serpiente", "caballo",
            "raton", "murcielago", "conejo", "zorro", "jirafa", "canguro", "cocodrilo", "pinguino", "ballena", "delfin",
            "aguila", "buho", "loro", "gallina", "pato", "cisne", "cucaracha", "aran~a", "abeja", "mosquito",
            "arbol", "flor", "arbusto", "pasto", "musgo", "hoja", "rama", "tronco", "raiz", "semilla",
            "montana", "colina", "valle", "celular", "volcan", "isla", "oceano", "rio", "lago", "laguna",
            "sol", "luna", "estrella", "planeta", "cometa", "asteroide", "satelite", "galaxia", "nebulosa", "constelacion",
            "casa", "edificio", "apartamento", "sabana", "mansión", "choza", "tienda", "refugio", "albergue", "refugio",
            "coche", "camion", "autobus", "moto", "bicicleta", "tren", "avion", "barco", "velero", "yate",
            "computadora", "telefono", "tableta", "televisor", "radio", "reproductor", "camara", "altavoz", "auriculares", "teclado",
            "manzana", "platano", "naranja", "uva", "sandia", "melon", "fresa", "frambuesa", "arandano", "pina",
            "lechuga", "tomate", "zanahoria", "brocoli", "espinaca", "coliflor", "pepino", "pimiento", "cebolla", "ajo",
            "pan", "arroz", "pasta", "harina", "azucar", "sal", "aceite", "vinagre", "leche", "queso",
            "pollo", "carne", "pescado", "cerdo", "cordero", "ternera", "salmon", "atun", "camaron", "langosta",
            "agua", "refresco", "te", "cafe", "cerveza", "vino", "whisky", "ron", "vodka", "gin",
            "futbol", "baloncesto", "tenis", "beisbol", "golf", "natacion", "atletismo", "ciclismo", "voleibol", "rugby",
            "manana", "tarde", "noche", "amanecer", "atardecer", "mediodia", "madrugada", "hora", "minuto", "segundo",
            "mes", "ano", "decada", "siglo", "milenio", "era", "fecha", "calendario", "reloj", "cronometro",
            "amor", "odio", "felicidad", "tristeza", "enojo", "miedo", "sorpresa", "asombro", "alegria", "esperanza",
            "huevo", "queso", "pan", "agua", "leche", "azucar", "sal", "aceite", "harina", "arroz",
            "silla", "mesa", "sofa", "cama", "armario", "espejo", "estante", "lampara", "cuadro", "alfombra",
            "cuchara", "tenedor", "cuchillo", "plato", "vaso", "taza", "olla", "sarten", "batidora", "microondas",
            "pintura", "lienzo", "pincel", "paleta", "caballete", "oleo", "acuarela", "carboncillo", "tempera", "acrilico",
            "cielo", "nubes", "sol", "luna", "estrellas", "rayo", "tormenta", "arcoiris", "viento", "nieve",
            "manzana", "pera", "naranja", "uva", "limon", "sandia", "melon", "fresa", "platano", "kiwi",
            "albahaca", "perejil", "oregano", "menta", "romero", "tomillo", "laurel", "cilantro", "canela", "clavo",
            "pelota", "raqueta", "pescar", "gafas", "guantes", "sombrero", "bufanda", "abrigo", "botas", "paraguas",
            "camisa", "pantalon", "chaqueta", "corbata", "falda", "vestido", "zapatos", "calcetines", "gorra", "bufanda",
            "bicicleta", "patines", "patineta", "patinaje", "equitacion", "surf", "natacion", "buceo", "senderismo", "escalada",
            "guitarra", "piano", "violin", "flauta", "bateria", "trompeta", "saxofon", "tambor", "arpa", "ukelele",
            "azul", "rojo", "verde", "amarillo", "naranja", "morado", "rosa", "blanco", "negro", "gris",
            "triangulo", "cuadrado", "circulo", "rectangulo", "rombo", "estrella", "corazon", "flecha", "espiral", "cruz",
            "playa", "montana", "bosque", "desierto", "ciudad", "campo", "selva", "isla", "volcan", "glaciar",
            "lapiz", "boligrafo", "rotulador", "marcador", "crayon", "tiza", "papel", "cuaderno", "libro", "revista",
            "teclado", "raton", "monitor", "CPU", "altavoces", "microfono", "auriculares", "camara", "impresora", "router",
            "pelicula", "serie", "documental", "anime", "drama", "comedia", "accion", "terror", "romance", "ciencia ficcion",
            "leon", "tigre", "elefante", "jirafa", "cebra", "mono", "hipopotamo", "rinoceronte", "cocodrilo", "leopardo",
            "aguila", "buho", "cuervo", "halcon", "colibri", "pavo real", "pinguino", "avestruz", "loro", "cotorra"
        };
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            InterfaceDraws();
            Input();
            if (input != null)
                Play();
        }
        static void InterfaceDraws()
        {
            string menuBanner =@"
          ███████████████████████▀███████████████████████
          █─█─██▀▄─██▄─▀█▄─▄█─▄▄▄▄█▄─▀█▀─▄██▀▄─██▄─▀█▄─▄█
          █─▄─██─▀─███─█▄▀─██─██▄─██─█▄█─███─▀─███─█▄▀─██
          ▀▄▀▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▄▄▄▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀";
            string defaultDummy = 
                @"
                              +---+
                              |   |
                              O   |
                             /|\  |
                             / \  |
                                  |
                            =========
";
            Console.WriteLine(menuBanner);
            Console.WriteLine(defaultDummy);
            Console.WriteLine("                 Welcome to jueguito del ahorcado!\n                     Please enter a key to start");
        }
        static char Input()
        {
            input = char.ToLower(Console.ReadKey().KeyChar);
            return input;
        }
        static void Play()
        {
            Clear();
            SetField();
            ShowCurrentGame();
            InputRequest();
        }
        static int NextRandom()
        { // generate a random number between 0 and the total number of words there are
            randomIndex = index.Next(0, words.Count+1); 
            return randomIndex;
        }
        static void NextWord()
        { // once having a random index put it onto our List to choice a word
            randomIndex = 0;
            NextRandom();
            currentWord = words[randomIndex];           
        }
        static void SetField()
        { // setting a new Field with a different word and replace it with _ _ _ _ depending the length of the word choose
            NextWord();
            charsField = new char[currentWord.Length];
            for ( int i = 0; i < charsField.Length; i++ )
            {
                charsField[i] = '_';
            }
        }
        static string CurrentDummie()
        { // returns the current state of our poor dummy depending the number of errors
            switch (errors)
            {
                case 0:
                    currentDummy = "  +---+\r\n  |   |\r\n      |\r\n      |\r\n      |\r\n      |\r\n=========\r\n";
                    break;
                case 1:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n      |\r\n      |\r\n      |\r\n=========\r\n";
                    break;
                case 2:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n  |   |\r\n      |\r\n      |\r\n=========\r\n";
                    break;
                case 3:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n /|   |\r\n      |\r\n      |\r\n=========\r\n";
                    break;
                case 4:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n      |\r\n      |\r\n=========\r\n";
                    break;
                case 5:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n /    |\r\n      |\r\n=========\r\n";
                    break;
                case 6:
                    currentDummy = "  +---+\r\n  |   |\r\n  O   |\r\n /|\\  |\r\n / \\  |\r\n      |\r\n=========\r\n";
                    break;
            }
            return currentDummy;
        }
        static void ShowCurrentGame()
        { // the method's name explain all
            Console.WriteLine(CurrentDummie());
            Console.WriteLine(string.Join(" ", charsField));
            if (wrongLetters.Count > 0)
            {
                Console.Write("Wrong letters:");
                foreach (char c in wrongLetters)
                {
                    Console.Write(" " + c);
                }
            }
        }
        static void InputRequest()
        { 
            GetUserInput();
            Clear();
            Validation();
        }
        static void GetUserInput()
        { // this is used to get the letter that player choice
            Console.WriteLine("\nEnter a key");
            Input();
        }
        static void Clear()
        {
            Console.Clear();
        }
        static void Validation()
        {
            isValid = false;
            allGuessed = true; /// <summary> allGuessed se setea en true y luego recorre el largo de la palabra
                               /// si en su camino se encuentra un '_' lo cambia a false, lo que quiere decir
                               /// que aún quedan letras por encontrar, cuando vuelva a loopear vuelve a ser true
                               /// y se quedará true si no encuentra ningún '_', porque eso hará que no se cambie
                               /// allGuessed a false y pueda pasar al siguiente paso </summary> 
            
            for (int i = 0; i < currentWord.Length; i++)
            {
                if (currentWord[i] == input)
                {
                    charsField[i] = input;
                    isValid = true;
                } 
                else if (charsField[i] == '_')               
                    allGuessed = false;               
            }
            Veredict();
        }
        static void Veredict()
        {   // Here, since isValid is true, it will give way to the GuessedLetter method
            // which will make the corresponding changes
            if (isValid == true)
                GuessedLetter();
            // if isValid = false, WrongLetter method will be called
            else
                WrongLetter();
        }

        static void GuessedLetter()
        { // Show changes, clears the console and validates if user wins yet
            Clear();
            ShowCurrentGame();
            if (allGuessed)
            {
                Win();
            }
            InputRequest();
        }
        static void WrongLetter()
        { // add an error, validates if user has lost, show a message and request an input
            errors++;
            // Stores the wrong letters in a List to show them on screen
            WrongLetters();
            if (errors >= 6)
                Loss();                
            ShowCurrentGame();
            Console.WriteLine("\nNot valid!");
            InputRequest();
        }
        static void WrongLetters()
        {
            wrongLetters.Add(input);
        }
        static void Win()
        {
            //            string winAscii = @"
            //⠀  ⠀   (\__/)
            //       (•ㅅ•)      Don’t talk to
            //    ＿ノヽ ノ＼＿      me or my son
            //`/　`/ ⌒Ｙ⌒ Ｙ  ヽ     ever again.
            //( 　(三ヽ人　 /　  |
            //|　ﾉ⌒＼ ￣￣ヽ   ノ         -Cannot use this :(
            //ヽ＿＿＿ ＞ ､＿_／
            //     ｜( 王 ﾉ〈 (\__/)
            //     /ﾐ`ー―彡\  (•ㅅ•)
            //    / ╰    ╯ \ /    \>
            //";
            string winAscii = @"
                                  .--~~,__
                    :-....,-------`~~'._.'
                     `-,,,  ,_      ;'~U'
                      _,-' ,'`-__; '--.
                     (_/'~~      ''''(;";
            Console.WriteLine(winAscii);
            Console.WriteLine("                    Congrats! You Win !!!");
            PlayAgain();
        }
        static void Loss()
        {
            ShowCurrentGame();
            string catAscii = @"
                           /\_/\
                          (='_' )
                         (, ("")("")";
            Console.WriteLine(catAscii);
            Console.WriteLine("                        You loss u.u");
            Console.WriteLine($"The word was ** {currentWord} **");
            PlayAgain();
        }
        static void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? Press Y or press other key to exit");
            Input();
            if (input == 'y')
                Reset();
            else            
                Exit();
        }
        static void Reset()
        {
            errors = 0;
            wrongLetters.Clear();
            isValid = false;
            Clear();
            Play();
        }
        static void Exit()
        {
            Clear();
            string exitAscii = @"
                                     .
                                    / V\
                                  / `  /
                                 <<   |
                                 /    |
                               /      |
                             /        |
                           /    \  \ /
                          (      ) | |
                  ________|   _/_  | |
                <__________\______)\__)";
            Console.WriteLine(exitAscii);
            Console.WriteLine("                               bye bye!");
            Environment.Exit(0);
        }
    }
}