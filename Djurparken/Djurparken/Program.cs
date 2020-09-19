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
        using (StreamWriter sw2 = File.AppendText(path2)) { }

        Load();
        LoadDeceased();
        Intro();
        Commands();
    }

    private void Intro()
    {
        Console.WriteLine("Welcome to the Klara Södra Animal Park\n");
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
                    Console.WriteLine("Unknown Command"); break;
            }
        }
    }

    private void Add()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Type:\n'1' to register a tiger\n'2' to register an elephant\n'3' to register an owl\n");
                string species = Console.ReadLine();




                Console.WriteLine("Please enter a name for the animal: ");
                string name = Console.ReadLine();




                //Add Tiger

                //Tiger t = new Tiger(id, name, weight);
                //animals.Add(t);

                //Add Elephant

                //Elephant e = new Elephant(id, name, trunkLength);
                //animals.Add(e);

                //Add Owl

                //Owl o = new Owl(id, name, wingSpan);
                //animals.Add(o);

                Console.WriteLine("YOur animal was added");
                return;
            }
            catch
            {
                Console.WriteLine("Error");
            }
        }
    }
    private void Search()
    {
        Console.WriteLine("searching");
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
            sr.ReadLine();
            string text;

            //load tigers
            sr.ReadLine();
            sr.ReadLine();
            while ((text = sr.ReadLine()) != null)
            {
                string[] strings = text.Split(char.Parse(","));
                int id = int.Parse(strings[0]);
                string name = strings[1];
                float weight = float.Parse(strings[2]);

                Tiger t = new Tiger(id, name, weight);
                animals.Add(t);
            }
        }
    }

    void LoadDeceased()
    {
        using (StreamReader sr = new StreamReader(path2, true))
        {
            //skip appropriate amounts of lines
            sr.ReadLine();


        }
    }

    void SaveLiving()
    {
        System.IO.File.WriteAllText(path, "");
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine("<Animals>\n");

            sw.WriteLine("<Current tigers at the zoo>\n(ID, Name, Weight (kg)");
            foreach (Tiger t in animals)
                if (t.Living == true)
                    sw.WriteLine(t.ToString());

            sw.WriteLine("<Current elephants at the zoo>\n(ID, Name, Trunk length (m)");
            foreach (Elephant e in animals)
                if (e.Living == true)
                    sw.WriteLine(e.ToString());

            sw.WriteLine("<Current owls at the zoo>\n(ID, Name, Wingspan (m)");
            foreach (Owl o in animals)
                if (o.Living == true)
                    sw.WriteLine(o.ToString());
        }
    }

    void SaveDeceased()
    {
        System.IO.File.WriteAllText(path2, "");
        using (StreamWriter sw = new StreamWriter(path2, true))
        {
            sw.WriteLine("Deceased animals:");

            sw.WriteLine("<Tigers in zoo>\n(Name, Id, Weight");
            foreach (Tiger t in animals)
                if (t.Living == false)
                    sw.WriteLine(t.ToString());

            sw.WriteLine("<Owls in zoo>\n(Name, Id, Wingspan");
            foreach (Owl o in animals)
                if (o.Living == false)
                    sw.WriteLine(o.ToString());

            sw.WriteLine("<Elephants in zoo>\n(Name, Id, Trunk length");
            foreach (Elephant e in animals)
                if (e.Living == false)
                    sw.WriteLine(e.ToString());
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
