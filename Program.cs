﻿namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        static List<SweEngGloss> dictionary;
        class SweEngGloss
        {
            public string word_swe, word_eng;
            public SweEngGloss(string word_swe, string word_eng)
            {
                this.word_swe = word_swe; this.word_eng = word_eng;
            }
            public SweEngGloss(string line)
            {
                string[] words = line.Split('|');
                this.word_swe = words[0]; this.word_eng = words[1];
            }
        }
        static void Main(string[] args)
        {
            
            string defaultFile = "..\\..\\..\\dict\\sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            Console.Write("Write 'Help' to get help ");
            
            // NYI Det finns inget menysystem implementerat
            do
            {
                Console.Write("> ");
               
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                    
                    // FIXME programmet inte avslutar med "QUIT"
                }
               
                else if (command == "load")
                {
                    if(argument.Length == 2)

                    {   // FIXME programmet kraschar
                        using (StreamReader sr = new StreamReader(argument[1]))
                        {
                            dictionary = new List<SweEngGloss>(); // Empty it!
                            string line = sr.ReadLine();
                            while (line != null)
                            {
                                SweEngGloss gloss = new SweEngGloss(line);
                                dictionary.Add(gloss);
                                line = sr.ReadLine();
                            }
                        }
                    }
                    else if(argument.Length == 1)
                    {
                        using (StreamReader sr = new StreamReader(defaultFile))
                        {
                            //NYI Inget medelande om att ordlistan har laddats
                            dictionary = new List<SweEngGloss>(); // Empty it!
                            string line = sr.ReadLine();
                            while (line != null)
                            {
                                SweEngGloss gloss = new SweEngGloss(line);
                                dictionary.Add(gloss);
                                line = sr.ReadLine();
                            }
                        }
                    }
                }
                else if (command == "list")
                {
                    //FIXME programmet kraschar om vi inte har laddat in ordlistan
                    //TODO Meddelande om att ordboken ska läsas först

                    
                    foreach (SweEngGloss gloss in dictionary)
                    {
                        Console.WriteLine($"{gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command == "new")

                // FIXME programmet kraschar om vi inte har laddat in ordlistan
                //TODO Meddelande om att ordboken ska läsas först
                {
                    if (argument.Length == 3)
                    {
                        dictionary.Add(new SweEngGloss(argument[1], argument[2]));
                    }
                    else if(argument.Length == 1)
                    {   
                        Console.WriteLine("Write word in Swedish: ");
                        string s = Console.ReadLine();
                        Console.Write("Write word in English: ");

                        string e = Console.ReadLine();
                        dictionary.Add(new SweEngGloss(s, e));
                    }
                }
                else if (command == "delete")
                {

                    //FIXME programmet kraschar om vi inte har laddat in ordlistan
                    //TODO Meddelande om att ordboken ska läsas först
                    // FIXME programmet kraschar om ord  inte finns


                    if (argument.Length == 3)
                    {
                        int index = -1;
                        for (int i = 0; i < dictionary.Count; i++) {
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == argument[1] && gloss.word_eng == argument[2])
                                index = i;
                        }
                        dictionary.RemoveAt(index);
                    }
                    else if (argument.Length == 1)
                    {   
                        Console.WriteLine("Write word in Swedish: ");
                        string swedish = Console.ReadLine();
                        Console.Write("Write word in English: ");
                        string english = Console.ReadLine();
                        int index = -1;
                        for (int i = 0; i < dictionary.Count; i++)
                        {
                            SweEngGloss gloss = dictionary[i];
                            if (gloss.word_swe == swedish && gloss.word_eng == english)
                                index = i;
                        }
                        dictionary.RemoveAt(index);
                    }
                }
                else if (command == "translate")
                {
                    //FIXME programmet kraschar om vi inte har laddat in ordlistan
                    //TODO Meddelande om att ordboken ska läsas först

                    // FIXME programmet kraschar om ord  inte finns
                    if (argument.Length == 2)
                    {
                        foreach(SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == argument[1])
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == argument[1])
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                    else if (argument.Length == 1)
                    {
                        
                        Console.WriteLine("Write word to be translated: ");
                        string swedish = Console.ReadLine();
                        foreach (SweEngGloss gloss in dictionary)
                        {
                            if (gloss.word_swe == swedish)
                                Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                            if (gloss.word_eng == swedish)
                                Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                        }
                    }
                }
                //NYI HELP menyn
                else if (command == "help")
                {
                    Console.WriteLine("help        Avalible commands");
                    Console.WriteLine("quit        End of program ");
                    Console.WriteLine("delete      The word is removed from the dictionary");
                    Console.WriteLine("load        Load words data from the file sweeng.lis   ");
                    Console.WriteLine("list        A list of words is showed   ");
                    Console.WriteLine("translate   Translation of words  ");
                    Console.WriteLine("new         New word");


       

                }



                else
                {
                    Console.WriteLine($"Unknown command: '{command}'");
                }
            }
            while (true);
        }
    }
}