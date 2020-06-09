namespace Compiler
{
    using System;
    using Parsing;

    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();

            try {
                parser.Parse();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
