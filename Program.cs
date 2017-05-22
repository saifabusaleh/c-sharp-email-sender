using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                Repl repl = new Repl();
                repl.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
        }
    }
}