
using PoemGenerator.Service;

namespace PoemGenerator
{
    class Program
    {
        //        static Dictionary<String, String> rules = new Dictionary<String, String>();
        static void Main(string[] args)
        {
            ParsingService service = new ParsingService();
            service.Parse();
        }
    }
}
