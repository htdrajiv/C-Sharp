using PoemGenerator.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PoemGenerator.ChainOfResponsibility
{
    public abstract class Handler
    {
        protected static Random randomChooser = new Random();
        protected Handler successor;
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public String ReturnChoosen(String input, String regexPattern)
        {
            var regex = new Regex(regexPattern);
            var matches = regex.Matches(input);
            List<String> temp = new List<String>();
            foreach (var i in matches)
            {
                temp.Add(i.ToString());
            }
            String choosen = temp[randomChooser.Next(temp.Count)];
            return choosen;
        }

        public Handler GetSuccessor(String input, Dictionary<String,Handler> successorMapping)
        {
            Handler successor;
            String choosen = ReturnChoosen(input,"([A-Z]+)\\|*");
            successor = successorMapping[choosen];
            return successor;
        }

        public abstract void AddToPoem(Dictionary<String, String> input, Poem poem);
    }

    class KeywordHandler : Handler
    {
        public override void AddToPoem(Dictionary<string, string> input, Poem poem)
        {            
            Console.WriteLine(poem.GetPoem());
            poem.SetPoem("");            
        }
    }

}
