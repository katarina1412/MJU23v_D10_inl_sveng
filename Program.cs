namespace MJU23v_D10_inl_sveng
{
    internal class Program
    {
        static List<SweEngGloss> dictionary = null;// Added initial state for the dictionary
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
            string defaultFile = @"C:\Users\kkata\source\repos\uppgift1\sweeng.lis";
            Console.WriteLine("Welcome to the dictionary app!");
            Console.WriteLine("Avaliable commands: ");
            Console.WriteLine("help        Avalible commands");
            Console.WriteLine("quit         End of program ");
            Console.WriteLine("delete      The word is removed from the dictionary");
            Console.WriteLine("load        load words data from the file sweeng.lis   ");
            Console.WriteLine("list        a list of words is showed   ");
            Console.WriteLine("translate        a list of words is showed   ");
            Console.WriteLine("new         The program first asks for a word in  Swedish, then in English");//create new word


            Console.WriteLine("english     Translation from Swedish to English ");
            Console.WriteLine("swedish     Translation from English to Swedish ");
            
            do
            {
                Console.Write("> ");
                string[] argument = Console.ReadLine().Split();
                string command = argument[0];
                if (command == "quit")
                {
                    Console.WriteLine("Goodbye!"); 
                   break;
                    
                }


                else if (command == "load")
                {
                    try
                    {
                        string file = "";
                        if (argument.Length == 2)
                        {
                            file = argument[1];
                        }
                        else if (argument.Length == 1)
                        {
                            file = defaultFile;
                        }
                        else if (argument.Length > 2)
                        {
                            Console.WriteLine("Invalid command format");
                            continue; 
                        }

                        if (File.Exists(file))
                        {
                            dictionary = new List<SweEngGloss>(); // Clearing the dictionary
                            using (StreamReader sr = new StreamReader(file))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    SweEngGloss gloss = new SweEngGloss(line);
                                    dictionary.Add(gloss);
                                }
                            }
                            Console.WriteLine("Dictionary successfully loaded!");
                        }
                        else
                        {
                            Console.WriteLine("File does not exist!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }



               

                else if (command == "list")
                {
                    
                    if (dictionary == null)
                    {
                        Console.WriteLine("First, you need to load the dictionary!");
                    }

                    foreach (SweEngGloss gloss in dictionary)
                    {
                        Console.WriteLine($"{
                            gloss.word_swe,-10}  - {gloss.word_eng,-10}");
                    }
                }
                else if (command == "new")
                {

                    if (dictionary == null || dictionary.Count == 0)
                    {
                        Console.WriteLine("First, you need to load  the dictionary");
                    }
                    else
                    {
                        if (argument.Length == 3)
                        {
                            dictionary.Add(new SweEngGloss(argument[1], argument[2]));
                            Console.WriteLine("Successfully added a word to the dictionary!");
                        }
                        else if (argument.Length == 1)
                        {
                            Console.WriteLine("Write word in Swedish: ");
                            string swedish = Console.ReadLine();
                            Console.Write("Write word in English: ");
                            string english = Console.ReadLine();
                            dictionary.Add(new SweEngGloss(swedish, english));
                            Console.WriteLine("Successfully added a word to the dictionary");
                        }
                    }

                   


                }
                else if (command == "delete")

                
                {
                    if (dictionary == null)
                    {
                        Console.WriteLine("First, you need to load  the dictionary!");
                    }
                    else
                    {
                        string swedish = "";
                        string english = "";
                        if (argument.Length == 3)
                        {
                            swedish = argument[1];
                            english = argument[2];

                        }
                        else if (argument.Length == 1)
                        {

                            Console.WriteLine("Write word in Swedish: ");
                            swedish = Console.ReadLine();
                            Console.Write("Write word in English: ");
                            english = Console.ReadLine();

                        }
                        else if (argument.Length != 1 || argument.Length != 3)
                        {
                            Console.WriteLine("You have not entered the command in the correct format!");
                        }


                        if (argument.Length == 1 || argument.Length == 3)
                        {
                            int index = -1;
                            for (int i = 0; i < dictionary.Count; i++)
                            {
                                SweEngGloss gloss = dictionary[i];
                                if (gloss.word_swe == swedish && gloss.word_eng == english)
                                    index = i;
                            }

                            if (index == -1)
                            {
                                Console.WriteLine("The word does not exist in the dictionary.");
                            }
                            else
                            {
                                dictionary.RemoveAt(index);
                                Console.WriteLine("Word has been successfully deleted!");
                            }

                        }
                    }


                }

                else if (command == "translate")
                {
                    
                    if (dictionary == null)
                    {
                        Console.WriteLine("First, you need to load  the dictionary!");
                    }
                    else
                    {
                        string swedish = "";
                        if (argument.Length == 2)
                        {
                            swedish = argument[1];

                        }
                        else if (argument.Length == 1)
                        {
                            Console.WriteLine("Write word to be translated: ");
                            swedish = Console.ReadLine();

                        }
                        else if (argument.Length > 2)
                        {
                            Console.WriteLine("Niste uneli komandu u dobrom formatu!!!");
                        }

                        if (argument.Length < 3)
                        {
                            bool isFind = false; 
                            foreach (SweEngGloss gloss in dictionary)
                            {
                                if (gloss.word_swe == swedish)
                                {
                                    Console.WriteLine($"English for {gloss.word_swe} is {gloss.word_eng}");
                                    isFind = true;
                                }
                                if (gloss.word_eng == swedish)
                                {
                                    Console.WriteLine($"Swedish for {gloss.word_eng} is {gloss.word_swe}");
                                    isFind = true;
                                }
                            }
                            if (isFind)
                                Console.WriteLine("rec je uspesno nadjena!!!");
                            else
                                Console.WriteLine("rec je uspesno prevedena!!!");
                        }
                    }
                }
                

                else if (command == "help")
                {
                    Console.WriteLine("help        Avalible commands");
                    Console.WriteLine("quit         End of program ");
                    Console.WriteLine("delete      The word is removed from the dictionary");
                    Console.WriteLine("load        load words data from the file sweeng.lis   ");
                    Console.WriteLine("list        a list of words is showed   ");
                    Console.WriteLine("translate        a list of words is showed   ");
                    Console.WriteLine("new         The program first asks for a word in  Swedish, then in English");//create new word
                    Console.WriteLine("english     Translation from Swedish to English ");
                    Console.WriteLine("swedish     Translation from English to Swedish ");

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