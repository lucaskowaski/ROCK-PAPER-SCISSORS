using System;

namespace RockPaperScissors
{
    public class NoSuchStrategyExcepition : Exception
    {
        public NoSuchStrategyExcepition(string message)
       : base(message)
        {
        }
    }
}
