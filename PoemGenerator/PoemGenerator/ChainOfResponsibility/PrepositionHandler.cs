﻿using PoemGenerator.Model;
using System;
using System.Collections.Generic;

namespace PoemGenerator.ChainOfResponsibility
{
    class PrepositionHandler : Handler
    {
        // this mapping shoud be generated by reading the Rules from text file. static for now
        private static Dictionary<String, Handler> successorMapping = new Dictionary<string, Handler>()
        {
            {"NOUN",new NounHandler()}, {"PRONOUN",new PronounHandler() }, {"ADJECTIVE",new AdjectiveHandler() }
        };

        public String GetPoemWord(String input)
        {
            String choosen = ReturnChoosen(input, "([a-z]+)\\|*");
            return choosen.Replace("|", ""); ;
        }

        public override void AddToPoem(Dictionary<String, String> input, Poem poem)
        {
            String successorContents = input["PREPOSITION"];
            String poemWord = GetPoemWord(successorContents);
            poem.AppendPoem(poemWord);
            SetSuccessor(GetSuccessor(successorContents, successorMapping));
            successor.AddToPoem(input, poem);
        }
    }
}
