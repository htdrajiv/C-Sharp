using PoemGenerator.ChainOfResponsibility;
using PoemGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PoemGenerator.Service
{
    class ParsingService
    {
        public void Parse() {
            String line;
            StreamReader reader = File.OpenText("Rules.txt");            
            Dictionary<String, String> rules = new Dictionary<String, String>();
            char[] splittingChars = {':'};
            while ((line = reader.ReadLine()) != null)
            {
                String[] splitted = line.Split(splittingChars);
                rules.Add(splitted[0], splitted[1]);
            }
            Poem poem = new Poem();
            string[] splittedRules = rules["POEM"].Trim().Split(' ');
            Handler handler = new LineHandler();
            foreach (var rule in splittedRules)
            {
                handler.AddToPoem(rules, poem);                
            }
            Console.ReadLine();             
        }
    }
}
