using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

class Program
{

    /*class TestResult
    {
        public string PlayerName { get; set; }
        public int Score  { get; set; }
    }
     */
    public static List<string> TstText = new List<string>()
    {
        "Дядя Семён ехал из города домой. С ним была собака Жучка, Вдруг из леса выскочили волки. Жучка испугалась и прыгнула в сани. У дяди Семёна была хорошая лошадь. Она тоже испугалась и быстро помчалась по дороге. Деревня была близко. Показались огни в окнах. Волки отстали."
    };
    public static char[] words = TstText[0].ToCharArray();


    static void Main()
    {

        string playerName = Console.ReadLine();
        PrintTest(playerName);
    }

    public static int IndexChar = 0;

    public static void PrintTest(string playerName)
    {
        while (true)
        {
            Console.Clear();
            string numbersStr = string.Join("", words);
            Console.WriteLine(numbersStr);
            Console.SetCursorPosition(0, 5);
            Console.Write(new string(' ', words.Length));
            Console.SetCursorPosition(0, 5);
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.ReadKey();
            Timer();

            int strochka = 7;

            while (IndexChar < words.Length)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                if (consoleKeyInfo.KeyChar == words[IndexChar])
                {
                    if (IndexChar % Console.WindowWidth == 0)
                        strochka++;
                    Console.SetCursorPosition(IndexChar % Console.WindowWidth, strochka);
                    Console.Write(consoleKeyInfo.KeyChar);
                    IndexChar++;
                }
            }

        }
    }
    /*
     * Я сидела над сохранением два года и ничего не вышло(((((
     * 
    public static void SaveResult()
    {
        string playerName = Console.ReadLine();
        int speed = 0;

        TestResult testResult = new TestResult
        {
            PlayerName = playerName,
            Score = speed
        };

        List<TestResult> results = new List<TestResult>();

        if (File.Exists("typing_speed.json"))
        {
            string json = File.ReadAllText("typing_speed.json");
            results = JsonConvert.DeserializeObject<List<TestResult>>(json);
        }

        results.Add(testResult);

        string output = JsonConvert.SerializeObject(results, Formatting.Indented);
        File.WriteAllText("typing_speed.json", output);
        playerName = Console.ReadLine();    
        Console.WriteLine("Таблица ");
        Console.WriteLine("-------");
        Console.WriteLine($"{playerName}, {speed}");
    }*/

    public static void Timer()
    {
        Thread timerThread = new Thread(() =>
        {

            int minutes = 1;
            int seconds = 0;

            while (minutes > 0 || seconds > 0)
            {
                Console.SetCursorPosition(2, 5);
                Console.WriteLine($"{minutes}:{seconds.ToString().PadLeft(2, '0')}");
                Thread.Sleep(1000);
                seconds--;
                if (seconds < 0)
                {
                    minutes--;
                    seconds = 59;
                }
            }

            Console.WriteLine("Таймер завершен!");
        });


        timerThread.Start();

    }

}
