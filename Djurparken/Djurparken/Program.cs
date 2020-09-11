using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    #region Initialization

    string path = @"..\..\..\Animals.txt";
    string path2 = @"..\..\..\Deceased.txt";

    List<Animal> animals = new List<Animal>();
    #endregion

    static void Main()
    {
        new Program().Run();
    }

    void Run()
    {
        using (StreamWriter sw = File.AppendText(path)) { }
        using (StreamWriter sw = File.AppendText(path2)) { }

        Load();
        Intro();
        Commands();
    }

    private void Intro()
    {
        Console.WriteLine("Welcome to Animal Park\n");
        Console.WriteLine("  <Type> ");
        Console.WriteLine("'add' to register in a newly arrived animal");
        Console.WriteLine("'update' to look for and change data/status of specific animal in the database");
        Console.WriteLine("'all' to display all current animals in the park");
        Console.WriteLine("'deceased' to display info about all deceased animals from the park's history");
        Console.WriteLine("'clear' to clear up terminal (data is saved)");
        Console.WriteLine("'quit' to exit program and save data to file\n");
        Console.WriteLine("PLEASE DON'T FORGET TO QUIT THE PROGRAM AFTER USE TO SAVE DATA\n");
    }

    private void Commands()
    {
        while (true)
        {
            Console.WriteLine("Enter command: ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "add":
                    Add(); break;
                case "update":
                    Search(); break;
                case "all":
                    PrintLiving(); break;
                case "passed":
                    PrintPassed(); break;
                case "clear":
                    Clear(); break;
                case "quit":
                    SaveLiving(); SaveDeceased(); Quit(); break;
                default:
                    Console.WriteLine("Unknown Command");
                    break;
            }
        }
    }
    private void Add()
    {


        while (true)
        {
            try
            {
                #region ticket specification
                //Specifies adult tickets
                Console.WriteLine("Enter in the amount of adult tickets for this transaction, '0' if none");
                string input = Console.ReadLine();

                if (input == "cancel")
                { Clear(); Console.WriteLine("Cancelled transaction"); return; }

                int adults = int.Parse(input);
                if (adults > 2000)
                {
                    Console.WriteLine("Too many tickets requested");
                    continue;
                }

                //specifies child tickets
                Console.WriteLine("Enter in the amount of child tickets for this transaction, '0' if none");
                string input2 = Console.ReadLine();

                if (input == "cancel")
                { Clear(); Console.WriteLine("Cancelled transaction"); return; }

                int children = int.Parse(input2);
                if (children > 2000)
                {
                    Console.WriteLine("Too many tickets requested");
                    continue;
                }

                //specifies senior tickets
                Console.WriteLine("Enter in the amount of senior tickets for this transaction, '0' if none");
                string input3 = Console.ReadLine();

                if (input == "cancel")
                { Clear(); Console.WriteLine("Cancelled transaction"); return; }

                int seniors = int.Parse(input3);
                if (seniors > 2000)
                {
                    Console.WriteLine("Too many tickets requested");
                    continue;
                }

                if (adults + children + seniors == 0)
                {
                    Console.WriteLine("Minimun ticket amount: 1");
                    continue;
                }
                #endregion

                //Add Tiger
                Tiger t = new Tiger();
                animals.Add(t);

                //Add Elephant
                Elephant e = new Elephant();
                animals.Add(e);

                //Add Owl
                Owl o = new Owl();
                animals.Add(o);

                Console.WriteLine("YOur animal was added");
                return;
            }
            catch
            {
                Console.WriteLine("Please specify tickets with whole numbers");
            }
        }
    }
    private void Search()
    {
        Console.WriteLine("searching");
    }

    private void ChangeLiving()
    {
        Console.WriteLine("Changing status");
    }
    private void PrintLiving()
    {
        Console.WriteLine("printingliving");
    }
    private void PrintPassed()
    {
        Console.WriteLine("printingdeceased");
    }

    void Load()
    {
        using (StreamReader sr = new StreamReader(path, true))
        {
            //skip appropriate amounts of lines
            sr.ReadLine();
            sr.ReadLine();

            string text;
            int ID;
        }
    }

    void LoadDeceased()
    {
        using (StreamReader sr = new StreamReader(path2, true))
        {
            //skip appropriate amounts of lines
            sr.ReadLine();
            sr.ReadLine();

            string text;
            int ID;
        }
    }

    void SaveLiving()
    {
        System.IO.File.WriteAllText(path, "");
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine("Animals\n");

            sw.WriteLine("<Current tigers at the zoo>\n(ID, Name");
            foreach (Tiger a in animals)
                if (a.GetLiving() == true)
                    sw.WriteLine(a.ToString());

            sw.WriteLine("<Current elephants at the zoo>\n(ID, Name");
            foreach (Elephant e in animals)
                if (e.GetLiving() == true)
                    sw.WriteLine(e.ToString());

            sw.WriteLine("<Current owls at the zoo>\n(ID, Name");
            foreach (Owl o in animals)
                if (o.GetLiving() == true)
                    sw.WriteLine(o.ToString());
        }
    }

    void SaveDeceased()
    {
        System.IO.File.WriteAllText(path2, "");
        using (StreamWriter sw = new StreamWriter(path2, true))
        {
            sw.WriteLine("Deceased animals\n");

            sw.WriteLine("<Deceased tigers from the zoo>\n(ID, Name");
            foreach (Tiger a in animals)
                if (!a.GetLiving())
                    sw.WriteLine(a.ToString());

            sw.WriteLine("<Deceased elephants from the zoo>\n(ID, Name");
            foreach (Elephant e in animals)
                if (!e.GetLiving())
                    sw.WriteLine(e.ToString());

            sw.WriteLine("<Deceased owls from the zoo>\n(ID, Name");
            foreach (Owl o in animals)
                if (!o.GetLiving())
                    sw.WriteLine(o.ToString());
        }
    }

    private void Clear()
    {
        Console.Clear();
        Intro();
    }

    private void Quit()
    {
        Environment.Exit(0);
    }
}
