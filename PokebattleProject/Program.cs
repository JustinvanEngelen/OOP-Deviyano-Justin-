// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pokemon Battle Simulator");

var trainer1Name = GetValidName("Enter the name for Trainer 1: ");
var trainer1 = new Trainer(trainer1Name);

var trainer2Name = GetValidName("Enter the name for Trainer 2: ");
var trainer2 = new Trainer(trainer2Name);

trainer1.TakePokeball(new Pokeball(new Pokemon("Charmander")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Squirtle")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Bulbassaur")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Charmander")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Squirtle")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Bulbassaur")));

trainer1.TakePokeball(new Pokeball(new Pokemon("Charmander")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Squirtle")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Bulbassaur")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Charmander")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Squirtle")));
trainer1.TakePokeball(new Pokeball(new Pokemon("Bulbassaur")));
while (true)
{
    for (int x = 0; x < trainer1.Belt.Count; x++)
    {
        trainer1.ThrowPokeball();
        trainer1.ReturnPokemon(trainer1.Belt[x].Pokemon);
        trainer2.ThrowPokeball();
        trainer2.ReturnPokemon(trainer2.Belt[x].Pokemon);
    }

    Console.WriteLine("Do you want to play again?");
    string answer = Console.ReadLine();
    if (answer?.ToLower() == "no")
    {
        break;
    }
    else
    {
        trainer1.ResetTeller();
        trainer2.ResetTeller();
    }
}

string GetValidName(string prompt)
{
    string name;
    do
    {
        Console.Write(prompt);
        name = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(name))
        {
            Console.WriteLine("Error: Name cannot be empty. Please enter a valid name.");
        }
    } while (string.IsNullOrEmpty(name));
    return name;
}

public class Pokemon
{
    public string? Nickname;
    public string Strength;
    public string Weakness;

    public Pokemon(string nickname)
    {
        Nickname = nickname;
    }

    public void BattleCry()
    {
        Console.WriteLine(GetName().ToUpper());
    }

    public string GetName()
    {
        return Nickname ?? "Unnamed";
    }
}

public class Charmander : Pokemon
{
    public Charmander(string nickname) : base(nickname)
    {
        Strength = "Fire";
        Weakness = "Water";
    }
}

public class Squirtle : Pokemon
{
    public Squirtle(string nickname) : base(nickname)
    {
        Strength = "Water";
        Weakness = "Grass";
    }
}

public class Bulbasaur : Pokemon
{
    public Bulbasaur(string nickname) : base(nickname)
    {
        Strength = "Grass";
        Weakness = "Fire";
    }
}




public class Pokeball
{
    public Pokemon? Pokemon;
    public bool HasPokemonInside;

    public Pokeball(Pokemon pokemon)
    {
        Pokemon = pokemon;
        HasPokemonInside = true;
    }

    public object Open()
    {
        HasPokemonInside = false;
        return Pokemon;
    }

    public void Close()
    {
        HasPokemonInside = true;
    }
}

public class Trainer
{
    public List<Pokeball> Belt;
    public string? Name;
    public int Teller = 0;

    public Trainer(string name)
    {
        Belt = new List<Pokeball>();
        Name = name;
    }

    public void TakePokeball(Pokeball pokeball)
    {
        if (Belt.Count >= 6)
        {
            Console.WriteLine(Belt.Count);
            throw new Exception("Cannot have more than 6 Pokemon on your belt!");
        }
        else
        {
            Belt.Add(pokeball);
        }
    }

    public void ThrowPokeball()
    {
        Console.WriteLine($"{Name}'s Pokemon says: {Belt[Teller].Pokemon?.GetName()}");
        Teller++;
    }

    public void ReturnPokemon(Pokemon pokemon)
    {
        Console.WriteLine($"{Name} Returns: {pokemon.GetName()}");
    }

    public void ResetTeller()
    {
        Teller = 0;
    }
}
