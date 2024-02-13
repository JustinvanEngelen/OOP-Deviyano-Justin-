// See https://aka.ms/new-console-template for more information
Console.WriteLine("Pokemon Battle Simulator");


var c = new Charmander("Fireball");
c.battlecry();

while (true)
{
    Console.WriteLine("Welke naam? Type 'quit' to quit");
    string answer = Console.ReadLine();

    if (answer == "quit")
    {
        Console.WriteLine("dankuwel voor het spelen");
        break;
    }
    c.nickname = answer;

    for (int teller = 0; teller < 11; teller++)
    {
        c.battlecry();
    }
}

public class Charmander
{
    public string? nickname;
    public string strenght;
    public string weakness;

    public Charmander(string newNickname)
    {
        this.nickname = newNickname;
        this.strenght = "fire";
        this.weakness = "water";
    }

    public void battlecry()
    {
        Console.WriteLine(this.nickname.ToUpper());
    }

}
