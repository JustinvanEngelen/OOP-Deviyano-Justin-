using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("***************************************");
        Console.WriteLine("Welcome to the Pokemon Battle Simulator");
        Console.WriteLine("***************************************");
        Console.WriteLine("");

        var trainer1 = new Trainer();
        trainer1.SetName();

        Console.WriteLine("Now for the second trainer.");
        Console.WriteLine("");
        var trainer2 = new Trainer();
        trainer2.SetName();

        var squirtleNames = new string[] { "squirtle1", "squirtle2", "squirtle3", "squirtle4", "squirtle5", "squirtle6" };
        var bulbaNames = new string[] { "bulba1", "bulba2", "bulba3", "bulba4", "bulba5", "bulba6" };
        var charNames = new string[] { "char1", "char2", "char3", "char4", "char5", "char6" };

        for (int i = 0; i < 2; i++)
        {
            trainer1.takePokeball(new Pokeball(new Squirtle(squirtleNames[i])));
            trainer2.takePokeball(new Pokeball(new Squirtle(squirtleNames[i])));
        }

        for (int i = 0; i < 2; i++)
        {
            trainer1.takePokeball(new Pokeball(new Bulbasaur(bulbaNames[i])));
            trainer2.takePokeball(new Pokeball(new Bulbasaur(bulbaNames[i])));
        }

        for (int i = 0; i < 2; i++)
        {
            trainer1.takePokeball(new Pokeball(new Charmander(charNames[i])));
            trainer2.takePokeball(new Pokeball(new Charmander(charNames[i])));
        }


        while (true)
        {
            for (int x = 0; x < trainer1.belt.Count || x < trainer2.belt.Count; x++)
            {
                if (x < trainer1.belt.Count)
                {
                    trainer1.throwPokeball();
                    trainer1.returnPokemon(trainer1.belt[x].Pokemon);
                }

                if (x < trainer2.belt.Count)
                {
                    trainer2.throwPokeball();
                    trainer2.returnPokemon(trainer2.belt[x].Pokemon);
                }
            }

            string answer;
            while (true)
            {
                Console.WriteLine("Do you want to play again? (yes/no)");
                answer = Console.ReadLine().ToLower();

                if (answer == "no" || answer == "yes")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
            }

            if (answer == "no")
            {
                break;
            }
            else
            {
                trainer1.teller = 0;
                trainer2.teller = 0;
            }
        }
    }
}

public abstract class Pokemon
{
    public string? nickname;
    public string? strength;
    public string? weakness;

    public Pokemon(string newNickname)
    {
        this.nickname = newNickname;
    }

    public abstract void BattleCry();

    public string GetName()
    {
        return this.nickname;
    }
}

public class Squirtle : Pokemon
{
    public Squirtle(string nickname) : base(nickname)
    {
        this.strength = "water";
        this.weakness = "leaf";
    }

    public override void BattleCry()
    {
        Console.WriteLine(GetName().ToUpper());
        Console.WriteLine("Squirtle's Battle Cry: Squirtle, Squirtle!");
    }
}

public class Bulbasaur : Pokemon
{
    public Bulbasaur(string nickname) : base(nickname)
    {
        this.strength = "grass";
        this.weakness = "fire";
    }

    public override void BattleCry()
    {
        Console.WriteLine(GetName().ToUpper());
        Console.WriteLine("Bulbasaur's Battle Cry: Bulba, Bulba!");
    }
}

public class Charmander : Pokemon
{
    public Charmander(string nickname) : base(nickname)
    {
        this.strength = "fire";
        this.weakness = "water";
    }

    public override void BattleCry()
    {
        Console.WriteLine(GetName().ToUpper());
        Console.WriteLine("Charmander's Battle Cry: Char, Char!");
    }
}

public class Pokeball
{
    public Pokemon? Pokemon;
    public bool hasPokemonInside;

    public Pokeball(Pokemon pokemon)
    {
        this.Pokemon = pokemon;
        this.hasPokemonInside = true;
    }

    public object Open()
    {
        hasPokemonInside = false;
        return Pokemon;
    }

    public void Close()
    {
        hasPokemonInside = true;
    }
}

public class Trainer
{
    public List<Pokeball> belt;
    public string? name;
    public int teller = 0;

    public Trainer()
    {
        this.belt = new List<Pokeball>();
    }

    public void SetName()
    {
        string new_name = "";
        while (string.IsNullOrEmpty(new_name))
        {
            Console.WriteLine("Enter a name for the trainer :");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("I'm sorry, but an empty name is not possible. Please try again.");
            }
            else if (name.Length > 10)
            {
                Console.WriteLine("I'm sorry, but the name cannot be longer than 10 characters. Please try again.");
            }
            else
            {
                Console.WriteLine("Good choice");
                Console.WriteLine("");
                new_name = name;
            }
        }
        this.name = new_name;
    }

    public string GetName()
    {
        return this.name;
    }

    public void takePokeball(Pokeball pokeball)
    {
        if (belt.Count >= 12) { Console.WriteLine(belt.Count); throw new Exception("Cannot have more than 12 Pokemons on your belt!"); }
        else { belt.Add(pokeball); }
    }

    public Pokemon throwPokeball()
    {
        Console.WriteLine(name + "'s Pokemon says: " + belt[teller].Pokemon.GetName());
        teller = teller + 1;
        return belt[teller - 1].Pokemon;
    }

    public void returnPokemon(Pokemon pokemon)
    {
        Console.WriteLine(name + " Returns: " + pokemon.GetName());
    }
}
