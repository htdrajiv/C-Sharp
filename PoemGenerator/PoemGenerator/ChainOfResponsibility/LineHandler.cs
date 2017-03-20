﻿using PoemGenerator.Model;
using System;
using System.Collections.Generic;

namespace PoemGenerator.ChainOfResponsibility
{
    class LineHandler : Handler
    {
        // this mapping shoud be generated by reading the Rules from text file. static for now
        private static Dictionary<String, Handler> successorMapping = new Dictionary<string, Handler>()
        {
            {"NOUN",new NounHandler()}, {"PREPOSITION",new PrepositionHandler() }, {"PRONOUN",new PronounHandler() }
        };

        public override void AddToPoem(Dictionary<string, string> input, Poem poem)
        {
            String successorContents = input["LINE"];
            successorContents = successorContents.Replace("$LINEBREAK", "");
            SetSuccessor(GetSuccessor(successorContents, successorMapping));
            successor.AddToPoem(input, poem);
        }
    }
}