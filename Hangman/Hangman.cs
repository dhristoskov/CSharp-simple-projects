using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hangman
{
    class Hangman
    {
        static List<string> easyWords = new List<string>()
        {
            "дим","сом","топ","кола","пола","ръка","стол","слон"
        };
        static List<string> medWords = new List<string>()
        {
            "монитор","запетая","почивка","ваканция","портокал","писалка"
        };
        static List<string> hardWords = new List<string>()
        {
            "командировка","велосипед","разузнаване","конституция","развлечение"
        };
        static List<string> wrongGuess = new List<string>();
        static List<string> correctGuess = new List<string>();
        static string word = String.Empty;
        static int choise;
        static int misses = 0;
        static ConsoleColor clrNow = Console.ForegroundColor;
        static ConsoleColor[] colors = new ConsoleColor[] {ConsoleColor.Yellow,ConsoleColor.Magenta,ConsoleColor.Green};

        static int DifficultyAsk()
        {
            Console.ForegroundColor = colors[0];
            Console.WriteLine("Изберете трудноста на думата");
            Console.WriteLine("натиснете 1 за лесна дума");
            Console.WriteLine("натиснете 2 за дума със средна трудност");
            Console.WriteLine("натиснете 3 за трудна дума");
            try{
                 choise = int.Parse(Console.ReadLine());
                 if (choise < 1 || choise > 3)
                 {
                     Console.WriteLine("Невалиден вход опитайте отново");
                     Thread.Sleep(2000);
                     Console.Clear();
                     DifficultyAsk();
                 }               
            }catch(Exception)
            {
                Console.WriteLine("Невалиден вход опитайте отново");
                Thread.Sleep(2000);
                Console.Clear();
                DifficultyAsk();
            }
            Console.ForegroundColor = clrNow;
            Console.Clear();
            return choise;          
        }
        static void SetWord()
        {
            Random rnd = new Random();
            switch (choise)
            {
                case 1: word = easyWords[rnd.Next(0, easyWords.Count)]; break;
                case 2: word = medWords[rnd.Next(0, medWords.Count)]; break;
                case 3: word = hardWords[rnd.Next(0, hardWords.Count)]; break;
            }
        }
        static void UserGuess()
        {
            Console.ForegroundColor = colors[2];
            Console.WriteLine("Направете своето предположение");
            string guess = String.Empty;
            try
            {
                guess = Console.ReadLine().ToLower();
                if (guess.Length > 1 || string.IsNullOrEmpty(guess))
                {
                    Console.WriteLine("Некоректен вход или празен вход");
                    UserGuess();
                }
                else if (!Regex.IsMatch(guess, @"^[а-я]+$"))
                {
                    Console.WriteLine("Некоректен вход трябва да изберете букви");
                    UserGuess();
                }
                else if (wrongGuess.Contains(guess) || correctGuess.Contains(guess))
                {
                    Console.WriteLine("Вече сте направили този избор");
                    UserGuess();
                }
                else if (word.Contains(guess))
                {
                    correctGuess.Add(guess);
                }
                else
                {
                    wrongGuess.Add(guess);
                    misses++;
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Некоректен вход");
                UserGuess();
            }
            Console.ForegroundColor = clrNow;
        }

        static void DrawWord()
        {
            StringBuilder guessString = new StringBuilder();
            foreach(char letter in word)
            {
                if (correctGuess.Contains(letter.ToString()))
                {
                    guessString.Append(" " + letter + " ");
                }
                else
                {
                    guessString.Append(" " + "___" + " ");
                }
            }
            Console.WriteLine(guessString);
        }
        static void UsedLetters()
        {        
            Console.ForegroundColor = colors[2];
            Console.Write("Използвани букви: ");
            foreach (string str in wrongGuess)
            {
                Console.Write(str+", ");
            }
            Console.WriteLine();
            Console.ForegroundColor = clrNow;
        }
        static void BuildGallows()
        {
            String[] gallows = new String[6];
            gallows[0] = "     _____";
            for (int a = 1; a < gallows.Length; a++)
                gallows[a] = "         |";

            if (misses >= 1)
            {
                gallows[1] = "     |   |";
                gallows[2] = "     O   |";
            }
            if (misses >= 2)
                gallows[3] = "     |   |";
            if (misses >= 3)
                gallows[2] = "    \\O   |";
            if (misses >= 4)
                gallows[1] = "     |   |";
            if (misses >= 5)
                gallows[2] = "    \\O/  |";
            if (misses >= 6)
                gallows[1] = "     |   |";
            if (misses >= 7)
                gallows[4] = "    /    |";
            if (misses >= 8)
                gallows[5] = "   /     |";
            if (misses >= 9)
                gallows[4] = "    / \\  |";
            if (misses >= 10)
                gallows[5] = "   /   \\ |";

            foreach (string s in gallows)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine();
        }
        static void PlayFailTone()
        {
            for (int i = 2638; i > 37; i -= 200)
            {
                Console.Beep(i, 100);
            }
        }
        static void PlayWinTone()
        {
            for (int i = 37; i <= 2638; i += 200)
            {
                Console.Beep(i, 150);
            }
        }
        static void Main(string[] args)
        {
            CultureInfo bg = new CultureInfo("bg-BG");
            Thread.CurrentThread.CurrentCulture = bg;           
            bool isEndGame = false;

            DifficultyAsk();
            SetWord();
            do
            {
                BuildGallows();
                DrawWord();
                UserGuess();
                Console.Clear();                
                UsedLetters();
                if (correctGuess.Count == word.Length)
                {
                    isEndGame = true;
                }
                if (misses == 10)
                {
                    isEndGame = true;
                }
            } while(!isEndGame);

            Console.ForegroundColor = colors[1];
            if (correctGuess.Count == word.Length)
            {
                BuildGallows();
                PlayWinTone();
                Console.WriteLine("Вие победихте!");
                Console.WriteLine("Познатата думата е - '{0}'",word);
            }
            else if (misses == 10)
            {
                BuildGallows();
                PlayFailTone();
                Console.WriteLine("Вие загубихте!");
                Console.WriteLine("Не можахте да познаете думата - '{0}'", word);
            }
            Console.ForegroundColor = clrNow;
        }
    }
}
