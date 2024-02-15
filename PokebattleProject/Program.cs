using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Pokemon Battle Simulator");
        Charmander c = new Charmander("Fireball");
        c.Battlecry();
        bool opnieuw = true;

        while (true)
        {
            while (opnieuw)
            {
                Console.WriteLine("Welke naam? Type 'quit' to quit");
                string answer = Console.ReadLine();

                if (answer == "quit")
                {
                    Console.WriteLine("Dankuwel voor het spelen");
                    return;
                }
                if (string.IsNullOrWhiteSpace(answer))
                {
                    Console.WriteLine("Je hebt geen naam ingevoerd, dat kan niet.");
                    continue;
                }
                else
                {
                    c.Nickname = answer;
                    opnieuw = false;
                }

                for (int teller = 0; teller < 11; teller++)
                {
                    c.Battlecry();
                }
            }
        }
    }
}

public class Charmander
{
    public string Nickname;
    public string Strength;
    public string Weakness;

    public Charmander(string newNickname)
    {
        this.Nickname = newNickname;
        this.Strength = "fire";
        this.Weakness = "water";
    }

    public void Battlecry()
    {
        Console.WriteLine(this.Nickname.ToUpper());
    }
}
