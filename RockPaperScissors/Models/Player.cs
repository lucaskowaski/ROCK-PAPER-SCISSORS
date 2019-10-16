using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors
{
    public class Player
    {
        public Player(string nome, string choice)
        {
            Nome = nome;
            Choice = choice;
        }
        public string Nome{ get; set; }
        public string Choice{ get; set; }
    }
}
