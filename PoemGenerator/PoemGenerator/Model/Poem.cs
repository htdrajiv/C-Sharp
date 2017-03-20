using System;

namespace PoemGenerator.Model
{
    public class Poem
    {
        private String poem;
        private int lines;
        public void SetPoem(String poem)
        {
            this.poem = poem;
        }

        public String GetPoem()
        {
            return this.poem;
        }

        public void AppendPoem(String poem)
        {
            this.poem = this.poem +" "+ poem;
        }

        public int GetLines()
        {
            return this.lines;
        }

        public void SetLines(int lines)
        {
            this.lines = lines;
        }
    }
}
