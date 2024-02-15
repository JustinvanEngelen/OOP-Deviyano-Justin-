using System;
namespace PokebattleProject
{
    public class Charmander
    {
        public string nickname;
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
}

