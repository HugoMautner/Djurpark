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
        Console.WriteLine("Welcome to the Animal Park\n");
        Console.WriteLine("  <Input> ");
        Console.WriteLine("'add' to register a newly arrived animal");
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
        Console.WriteLine("Is the animal you are adding a:");
        Console.WriteLine("1. Tiger");
        Console.WriteLine("2. Elephant");
        Console.WriteLine("3. Owl");
        Console.WriteLine("4. Other");
        Console.WriteLine("\n0. Cancel registration");

        while (true)
        {
            string input = Console.ReadLine();
            try
            {
                int realInput = int.Parse(input);

                if (realInput == 0)
                {
                    Clear();
                    Console.WriteLine("Cancelled");
                    return;
                }
                else if (realInput == 1)
                {
                    AddTiger();
                    return;
                }
                else if (realInput == 2)
                {
                    AddElephant();
                    return;
                }
                else if (realInput == 3)
                {
                    AddOwl();
                    return;
                }
                else
                {
                    Console.WriteLine("Not an option, try again");
                }
            }
            catch
            {
                Console.WriteLine("Please use a whole number");
            }
        }
    }

    private void AddTiger()
    {
        string name;
        string weight;

        #region name
        while (true)
        {
            Console.WriteLine("Enter your tiger's name: ");
            name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();

            foreach (Tiger t in animals)
            {
                if (name == t.Name)
                {
                    Console.WriteLine("There is already a tiger with that name at this zoo." +
                        "Please enter a unique name");
                    continue;
                }
            }
            if (name.Length > 20)
            {
                Console.WriteLine("Please enter a shorter name");
                continue;
            }
            else if (name.Contains(" "))
            {
                Console.WriteLine("Names can't contain spaces");
                continue;
            }
            else
                break;
        }
        #endregion
        #region special + add
        while (true)
        {
            Console.WriteLine("Enter your tigers weight (kg): ");
            weight = Console.ReadLine();

            try
            {
                decimal realWeight = decimal.Parse(weight);

                if (realWeight < 0)
                {
                    Console.WriteLine("Value of the tiger's weight cannot be negative. Try again");
                    break;
                }
                int count = BitConverter.GetBytes(decimal.GetBits(realWeight)[3])[2];
                if (count > 5)
                {
                    Console.WriteLine("Maximum precision: 5 decimals. Try again");
                    break;
                }

                Console.WriteLine("Please confirm that the specifics are correct: \n" +
                    "Name: " + name + "\nWeight: " + realWeight + " kg\nDo you wish to add this tiger? y/n");

                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    Clear();
                    Console.WriteLine("\nCancelled registration\n");
                    return;
                }
                else if (input == "y")
                {
                    Tiger t = new Tiger(name, realWeight, true);
                    Console.WriteLine("Your tiger was added [id, name, status (living), weight (kg), species index (tiger)]");
                    Console.WriteLine(t.ToString());
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'");
                    continue;
                }
            }
            catch
            {
                Console.WriteLine("Please specify with a decimal number");
            }
        }
        #endregion
    }
    private void AddElephant()
    {
        string name;
        string trunkLength;

        #region name
        while (true)
        {
            Console.WriteLine("Enter your Elephant's name: ");
            name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            foreach (Elephant e in animals)
            {
                if (name == e.Name)
                {
                    Console.WriteLine("There is already an elephant with that name at this zoo." +
                        "Please enter a unique name");
                    break;
                }
            }
            if (name.Length > 20)
            {
                Console.WriteLine("Please enter a shorter name");
                break;
            }
            else if (name.Contains(" "))
            {
                Console.WriteLine("Names can't contain spaces");
                break;
            }
            else
                break;
        }
        #endregion
        #region special + add
        while (true)
        {
            Console.WriteLine("Enter your elephant's trunk length (m): ");
            trunkLength = Console.ReadLine();

            try
            {
                decimal realLength = decimal.Parse(trunkLength);

                if (realLength < 0)
                {
                    Console.WriteLine("Value of the elephant's trunk length cannot be negative. Try again");
                    break;
                }
                int count = BitConverter.GetBytes(decimal.GetBits(realLength)[3])[2];
                if (count > 5)
                {
                    Console.WriteLine("Maximum precision: 5 decimals. Try again");
                    break;
                }

                Console.WriteLine("Please confirm that the specifics are correct: \n" +
                    "Name: " + name + "\ntrunk length: " + realLength + " m\nDo you wish to add this elephant? y/n");

                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    Clear();
                    Console.WriteLine("\nCancelled registration\n");
                    return;
                }
                else if (input == "y")
                {
                    Elephant e = new Elephant(name, realLength, true);
                    Console.WriteLine("Your elephant was added [id, name, status (living), " +
                        "trunk length (m), species index (elephant)]");
                    Console.WriteLine(e.ToString());
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'");
                }
            }
            catch
            {
                Console.WriteLine("Please specify with a decimal number");
            }
        }
        #endregion
    }
    private void AddOwl()
    {
        string name;
        string wingSpan;

        #region name
        while (true)
        {
            Console.WriteLine("Enter your owl's name: ");
            name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            foreach (Owl o in animals)
            {
                if (name == o.Name)
                {
                    Console.WriteLine("There is already an owl with that name at this zoo." +
                        "Please enter a unique name");
                    break;
                }
            }
            if (name.Length > 20)
            {
                Console.WriteLine("Please enter a shorter name");
                break;
            }
            else if (name.Contains(" "))
            {
                Console.WriteLine("Names can't contain spaces");
                break;
            }
            else
                break;
        }
        #endregion
        #region special + add
        while (true)
        {
            Console.WriteLine("Enter your owl's wingspan (cm): ");
            wingSpan = Console.ReadLine();

            try
            {
                decimal realSpan = decimal.Parse(wingSpan);

                if (realSpan < 0)
                {
                    Console.WriteLine("Value of the owl's wingspan cannot be negative. Try again");
                    break;
                }
                int count = BitConverter.GetBytes(decimal.GetBits(realSpan)[3])[2];
                if (count > 5)
                {
                    Console.WriteLine("Maximum precision: 5 decimals. Try again");
                    break;
                }

                Console.WriteLine("Please confirm that the specifics are correct: \n" +
                    "Name: " + name + "\nWingspan: " + realSpan + " cm\nDo you wish to add this owl? y/n");

                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    Clear();
                    Console.WriteLine("\nCancelled registration\n");
                    return;
                }
                else if (input == "y")
                {
                    Owl o = new Owl(name, realSpan, true);
                    Console.WriteLine("Your owl was added [id, name, status (living), wingspan (cm), species index (owl)]");
                    Console.WriteLine(o.ToString());
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter 'y' or 'n'");
                }
            }
            catch
            {
                Console.WriteLine("Please specify with a decimal number");
            }
        }
        #endregion
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
            //skip appropriate number of lines
            sr.ReadLine();
            string text;

            while ((text = sr.ReadLine()) != null)
            {
                string[] strings = text.Split(char.Parse(", "));
                string name = strings[0];
                int id = int.Parse(strings[1]);
                decimal attribute = decimal.Parse(strings[2]);
                bool living = bool.Parse(strings[3]);
                int speciesIndex = int.Parse(strings[4]);

                if (speciesIndex == 1)
                {
                    Tiger t = new Tiger(name, attribute, true);
                    animals.Add(t);
                }
                else if (speciesIndex == 2)
                {
                    Elephant e = new Elephant(name, attribute, true);
                    animals.Add(e);
                }
                else if (speciesIndex == 3)
                {
                    Owl o = new Owl(name, attribute, true);
                    animals.Add(o);
                }
                
            }
        }
    }

    void LoadDeceased()
    {
        using (StreamReader sr = new StreamReader(path2, true))
        {

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
