using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        LoadLiving();
        LoadDeceased();
        Intro();
        Commands();
    }
    private void Intro()
    {
        Console.WriteLine("Register of animals at Mautner National Park\n");
        Console.WriteLine(" Input: ");
        Console.WriteLine("'add'       to register a newly arrived animal");
        Console.WriteLine("'update'    to look for and change data/status of specific animal in the database");
        Console.WriteLine("'all'       to display information about all current animals in the park");
        Console.WriteLine("'tigers'    to display information about all current tigers in the park");
        Console.WriteLine("'elephants' to display information about all current elephants in the park");
        Console.WriteLine("'owls'      to display information about all current owls in the park");
        Console.WriteLine("'deceased'  to display information about all deceased animals from the park's history");
        Console.WriteLine("'clear'     to clear up terminal (data is saved)");
        Console.WriteLine("'quit'      to exit program and save data to file\n");
        Console.WriteLine("Please don't forget to quit the program after use to save data\n");
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
                    SortAllLiving(); break;
                case "tigers":
                    SortTigers(); break;
                case "elephants":
                    SortElephants(); break;
                case "owls":
                    SortOwls(); break;
                case "deceased":
                    PrintDeceased(); break;
                case "clear":
                    Clear(); break;
                case "quit":
                    SaveLiving(); SaveDeceased(); Quit(); break;
                default:
                    Console.WriteLine("Unknown Command"); break;
            }
        }
    }

    #region add
    private void Add()
    {
        Console.WriteLine("\nIs the animal you are adding a:");
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

                switch (realInput)
                {
                    case 0:
                        Clear(); Console.WriteLine("Cancelled"); return;
                    case 1:
                        AddTiger(); return;
                    case 2:
                        AddElephant(); return;
                    case 3:
                        AddOwl(); return;
                    default:
                        Console.WriteLine("Not an option, try again"); continue;
                }
            }
            catch
            {
                Console.WriteLine("Please input a whole number");
            }
        }
    }

    private void AddTiger()
    {
        string name = CreateName();
        int weight = CreateSpecial();

        while (true)
        {
            Console.WriteLine("\nPlease confirm that the specifics are correct: \n" +
                "Name: " + name + "\nWeight: " + weight + " kg\nDo you wish to add this tiger? y/n");

            string input = Console.ReadLine().ToLower();
            if (input == "n")
            {
                Clear();
                Console.WriteLine("\nCancelled registration\n");
                return;
            }
            else if (input == "y")
            {
                Tiger t = new Tiger(name, weight, true, CurrentDateTime());
                animals.Add(t);
                Console.WriteLine("\nYour tiger was added \n\nId: " + t.GetId() + "\nName: " + t.GetName() +
                    "\nStatus (living): " + t.GetLiving() + "\nLast updated: " + t.GetLastUpdated() +
                    "\nWeight (kg): " + t.GetWeight() + "\nSpecies: " + t.GetSpecies() + "\n");
                return;
            }
            else
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                continue;
            }
        }
    }
    private void AddElephant()
    {
        string name = CreateName();
        int trunkLength = CreateSpecial();

        while (true)
        {
            Console.WriteLine("\nPlease confirm that the specifics are correct: \n" +
                "Name: " + name + "\nTrunk length: " + trunkLength + " cm\nDo you wish to add this elephant? y/n");

            string input = Console.ReadLine().ToLower();
            if (input == "n")
            {
                Clear();
                Console.WriteLine("\nCancelled registration\n");
                return;
            }
            else if (input == "y")
            {
                Elephant e = new Elephant(name, trunkLength, true, CurrentDateTime());
                animals.Add(e);
                Console.WriteLine("\nYour elephant was added \n\nId: " + e.GetId() + "\nName: " + e.GetName() +
                    "\nStatus (living): " + e.GetLiving() + "\nLast updated: " + e.GetLastUpdated() +
                    "\nTrunk length (cm): " + e.GetTrunkLength() + "\nSpecies: " + e.GetSpecies() + "\n");
                return;
            }
            else
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                continue;
            }
        }
    }
    private void AddOwl()
    {
        string name = CreateName();
        int wingspan = CreateSpecial();

        while (true)
        {
            Console.WriteLine("\nPlease confirm that the specifics are correct: \n" +
                "Name: " + name + "\nWingspan: " + wingspan + " cm\nDo you wish to add this owl? y/n");

            string input = Console.ReadLine().ToLower();
            if (input == "n")
            {
                Clear();
                Console.WriteLine("\nCancelled registration\n");
                return;
            }
            else if (input == "y")
            {
                Owl o = new Owl(name, wingspan, true, CurrentDateTime());
                animals.Add(o);
                Console.WriteLine("\nYour owl was added \n\nId: " + o.GetId() + "\nName: " + o.GetName() +
                    "\nStatus (living): " + o.GetLiving() + "\nLast updated: " + o.GetLastUpdated() +
                    "\nWingspan (cm): " + o.GetWingspan() + "\nSpecies: " + o.GetSpecies() + "\n");
                return;
            }
            else
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                continue;
            }
        }
    }

    private string CreateName()
    {
        string name;
        bool containsInt;

        while (true)
        {
            Console.WriteLine("Enter a name for this animal: ");
            name = Console.ReadLine();
            name = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
            containsInt = name.Any(char.IsDigit);
            bool found = false;

            foreach (Animal a in animals)
            {
                if (name == a.GetName())
                {
                    Console.WriteLine("There is already an animal with that name at this zoo." +
                        " Please enter a unique name");
                    found = true;
                }
            }
            if (found == true)
                continue;
            else if (name.Length > 20 || string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Please enter a name consisting of 1-20 letters");
                continue;
            }
            else if (name.Contains(" "))
            {
                Console.WriteLine("Names can't contain spaces");
                continue;
            }
            else if (containsInt == true)
            {
                Console.WriteLine("Names can't contain numbers");
                continue;
            }
            else
                return name;
        }
    }
    private int CreateSpecial()
    {
        while (true)
        {
            Console.WriteLine("Enter your tiger's weight (kg), " +
                "elephant's trunk length (cm), or owl's wingspan (cm): ");
            string special = Console.ReadLine();
            int realSpecial;
            try
            {
                realSpecial = int.Parse(special);
            }
            catch
            {
                Console.WriteLine("Please specify with a whole number");
                continue;
            }

            realSpecial = int.Parse(special);
            if (realSpecial < 0 || realSpecial > 1000)
            {
                Console.WriteLine("Please enter a whole number between 0 and 1000");
                continue;
            }

            return realSpecial;
        }
    }
    #endregion

    #region search and update status
    private void Search()
    {
        Console.WriteLine("Enter a name or an id: ");

        while (true)
        {
            string input = Console.ReadLine().ToLower();
            bool containsOnlyInt = input.All(char.IsDigit);
            bool containsAnyInt = input.Any(char.IsDigit);
            if (containsOnlyInt == true || containsAnyInt == false)
            {
                for (int i = 0; i < animals.Count(); i++)
                {
                    if (input == animals[i].GetId() || input == animals[i].GetName().ToLower())
                    {
                        Console.WriteLine("\nFound animal \n\nId: " + animals[i].GetId() + "\nName: " + animals[i].GetName() +
                            "\nStatus (living): " + animals[i].GetLiving() + "\nLast updated: " + animals[i].GetLastUpdated() +
                            "\nWeight (kg) / Trunk length (cm) / Wingspan (cm): " + animals[i].GetSpecial() + "\nSpecies: " + animals[i].GetSpecies() + "\n");

                        Console.WriteLine("Would you like to change this animal's status? y/n");
                        string confirmation = Console.ReadLine();

                        if (confirmation == "y")
                        {
                            ChangeStatus(animals[i].GetId());
                            return;
                        }

                        else if (confirmation == "n")
                        {
                            Console.WriteLine("ok, cancelled and returned");
                            return;
                        }
                    }
                }
                Console.WriteLine("No animal with your entered id/name was found");
                return;
            }
            Console.WriteLine("Names contain no digits, and id:s are 6-digit whole numbers");
        }
    }
    private void ChangeStatus(string id)
    {
        Console.WriteLine("Do you really wish to change the status of the animal above from living to deceased (or vice versa)? y/n");

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "y")
            {
                for (int i = 0; i < animals.Count; i++)
                {
                    if (id == animals[i].GetId() && animals[i].GetLiving() == true)
                    {
                        animals[i].SetLiving(false);
                        animals[i].SetLastUpdated(CurrentDateTime());
                        Console.WriteLine("As of: " + animals[i].GetLastUpdated() +
                            "\nSet " + animals[i].GetName() + "'s status as deceased");
                        return;
                    }
                    else if (id == animals[i].GetId() && animals[i].GetLiving() == false)
                    {
                        animals[i].SetLiving(true);
                        animals[i].SetLastUpdated(CurrentDateTime());
                        Console.WriteLine("As of: " + animals[i].GetLastUpdated() +
                            "\nSet " + animals[i].GetName() + "'s status as alive");
                        return;
                    }
                }
            }
            else if (input == "n")
            {
                Console.WriteLine("ok, cancelled and returned");
                return;
            }
            else
            {
                Console.WriteLine("Please enter 'y' for yes, and 'n' for no");
                continue;
            }
        }
    }
    #endregion

    #region print
    private void SortAllLiving()
    {
        Animal[] animalsArr = new Animal[0];

        foreach (Animal a in animals)
        {
            Array.Resize(ref animalsArr, animalsArr.Length + 1);
            animalsArr[^1] = a;
        }

        int n = animalsArr.Length;
        if (n <= 0)
        {
            Console.WriteLine("This register is empty. Use command 'add' to register animals\n");
            return;
        }
        else if (n == 1)
        {
            Console.WriteLine("\nAll current animals (sorted alphabetically): ");
            PrintLiving(animalsArr);
            return;
        }

        //Selective sorting Animals in animalsArr alphabetically
        for (int i = 0; i < n - 1; i++)
        {
            int minPos = i;

            for (int j = i + 1; j < n; j++)
                if (string.Compare(animalsArr[minPos].GetName(), animalsArr[j].GetName()) == 1)
                    minPos = j;

            //swap
            var temp = animalsArr[minPos];
            animalsArr[minPos] = animalsArr[i];
            animalsArr[i] = temp;
        }
        Console.WriteLine("\nAll current animals (sorted alphabetically): ");
        PrintLiving(animalsArr);
    }
    private void SortTigers()
    {
        if (animals.OfType<Tiger>().Any() == false)
        {
            Console.WriteLine("\nThere are no tigers in this register. Use command 'add' to register animals\n");
            return;
        }

        Animal[] tigersArr = new Animal[0];

        foreach (Animal a in animals)
        {
            if (a is Tiger)
            {
                Array.Resize(ref tigersArr, tigersArr.Length + 1);
                tigersArr[^1] = a;
            }
        }

        int n = tigersArr.Length;
        if (n == 1)
        {
            Console.WriteLine("\n\nTigers sorted by weight (decending):");
            PrintLiving(tigersArr);
            return;
        }

        //Bubble sort Tigers in tigersArr by weight (decending)
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - 1; j++)
            {
                if (tigersArr[j].GetSpecial() < tigersArr[j + 1].GetSpecial())
                {
                    //swap
                    var temp = tigersArr[j];
                    tigersArr[j] = tigersArr[j + 1];
                    tigersArr[j + 1] = temp;
                }
            }

        Console.WriteLine("\n\nTigers sorted by weight (decending):");
        PrintLiving(tigersArr);
    }
    private void SortElephants()
    {
        if (animals.OfType<Elephant>().Any() == false)
        {
            Console.WriteLine("\nThere are no elephants in this register. Use command 'add' to register animals\n");
            return;
        }

        Animal[] elephantsArr = new Animal[0];

        foreach (Animal a in animals)
        {
            if (a is Elephant)
            {
                Array.Resize(ref elephantsArr, elephantsArr.Length + 1);
                elephantsArr[^1] = a;
            }
        }

        int n = elephantsArr.Length;
        if (n == 1)
        {
            Console.WriteLine("\n\nElephants sorted by trunk length (decending):");
            PrintLiving(elephantsArr);
            return;
        }

        //Bubble sort Elephants in elephantsArr by trunk length (decending)
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - 1; j++)
            {
                if (elephantsArr[j].GetSpecial() < elephantsArr[j + 1].GetSpecial())
                {
                    //swap
                    var temp = elephantsArr[j];
                    elephantsArr[j] = elephantsArr[j + 1];
                    elephantsArr[j + 1] = temp;
                }
            }

        Console.WriteLine("\n\nElephants sorted by trunk length (decending):");
        PrintLiving(elephantsArr);
    }
    private void SortOwls()
    {
        if (animals.OfType<Owl>().Any() == false)
        {
            Console.WriteLine("\nThere are no owls in this register. Use command 'add' to register animals\n");
            return;
        }

        Animal[] owlsArr = new Animal[0];

        foreach (Animal a in animals)
        {
            if (a is Owl)
            {
                Array.Resize(ref owlsArr, owlsArr.Length + 1);
                owlsArr[^1] = a;
            }
        }

        int n = owlsArr.Length;
        if (n == 1)
        {
            Console.WriteLine("\n\nOwls sorted by wingspan (decending):");
            PrintLiving(owlsArr);
            return;
        }

        //Bubble sort Owls in owlsArr by wingspan (decending)
        for (int i = 0; i < n - 1; i++)
            for (int j = 0; j < n - 1; j++)
            {
                if (owlsArr[j].GetSpecial() < owlsArr[j + 1].GetSpecial())
                {
                    //swap
                    var temp = owlsArr[j];
                    owlsArr[j] = owlsArr[j + 1];
                    owlsArr[j + 1] = temp;
                }
            }

        Console.WriteLine("\n\nOwls sorted by wingspan (decending):");
        PrintLiving(owlsArr);
    }

    private void PrintLiving(Animal[] animals)
    {
        foreach (Animal a in animals)
            if (a.GetLiving() == true)
                Console.WriteLine("\nId: " + a.GetId() + "\nName: " + a.GetName() +
                    "\nStatus (living): " + a.GetLiving() + "\nLast updated: " + a.GetLastUpdated() +
                    "\nWeight (kg) / Trunk length (cm) / Wingspan (cm): " + a.GetSpecial() +
                    "\nSpecies: " + a.GetSpecies() + "\n");
        Console.WriteLine();
    }
    private void PrintDeceased()
    {
        Console.WriteLine("\nDeceased animals (archived):");
        foreach (Animal a in animals)
            if (a.GetLiving() == false)
                Console.WriteLine("\nId: " + a.GetId() + "\nName: " + a.GetName() +
                    "\nStatus (living): " + a.GetLiving() + "\nLast updated: " + a.GetLastUpdated() +
                    "\nWeight (kg) / Trunk length (cm) / Wingspan (cm): " + a.GetSpecial() +
                    "\nSpecies: " + a.GetSpecies() + "\n");
        Console.WriteLine();
    }
    #endregion

    #region Stream I/O
    private void LoadLiving()
    {
        using StreamReader sr = new StreamReader(path, true);
        //skip appropriate number of lines
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();

        string text;

        while ((text = sr.ReadLine()) != null)
        {
            string[] strings = text.Split(char.Parse("|"));
            string name = strings[1];
            string lastUpdated = strings[3];
            int special = int.Parse(strings[4]);
            string species = strings[5];

            if (species == "tiger")
            {
                Tiger t = new Tiger(name, special, true, lastUpdated);
                animals.Add(t);
            }
            else if (species == "elephant")
            {
                Elephant e = new Elephant(name, special, true, lastUpdated);
                animals.Add(e);
            }
            else if (species == "owl")
            {
                Owl o = new Owl(name, special, true, lastUpdated);
                animals.Add(o);
            }
        }
    }
    private void LoadDeceased()
    {
        using StreamReader sr = new StreamReader(path2, true);
        //skip appropriate number of lines
        sr.ReadLine();
        sr.ReadLine();
        sr.ReadLine();

        string text;

        while ((text = sr.ReadLine()) != null)
        {
            string[] strings = text.Split(char.Parse("|"));
            string name = strings[1];
            string lastUpdated = strings[3];
            int special = int.Parse(strings[4]);
            string species = strings[5];

            if (species == "tiger")
            {
                Tiger t = new Tiger(name, special, false, lastUpdated);
                animals.Add(t);
            }
            else if (species == "elephant")
            {
                Elephant e = new Elephant(name, special, false, lastUpdated);
                animals.Add(e);
            }
            else if (species == "owl")
            {
                Owl o = new Owl(name, special, false, lastUpdated);
                animals.Add(o);
            }
        }
    }
    private void SaveLiving()
    {
        System.IO.File.WriteAllText(path, "");
        using StreamWriter sw = new StreamWriter(path, true);
        sw.WriteLine("Animals registered: \n[id, name, status (living), last updated, " +
            "weight (kg) / trunk length (cm) / wingspan (cm), species]\n");

        foreach (Animal animal in animals)
        {
            if (animal.GetLiving() == true)
            {
                sw.WriteLine(animal.ToString());
            }
        }
    }
    private void SaveDeceased()
    {
        System.IO.File.WriteAllText(path2, "");
        using StreamWriter sw = new StreamWriter(path2, true);
        sw.WriteLine("Deceased animals archived: \n[id, name, status (living), last updated, " +
            "weight (kg) / trunk length (cm) / wingspan (cm), species]\n");

        foreach (Animal animal in animals)
        {
            if (animal.GetLiving() == false)
            {
                sw.WriteLine(animal.ToString());
            }
        }
    }
    #endregion

    private string CurrentDateTime()
    {
        DateTime localDate = DateTime.Now;
        return localDate.ToString();
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
