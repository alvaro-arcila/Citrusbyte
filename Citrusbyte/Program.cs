using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CitrusByte.Computation;

namespace Citrusbyte
{
    class Program
    {
        private static string _nestedArray;
        private static char _splitCharacterChar;
        private static bool _continueExecute = true;

        /// <summary>
        /// Intial method .
        /// </summary>
 
        static void Main(string[] args)
        {
            /*
            Write some code, that will flatten an array of arbitrarily nested arrays of integers into 
            a flat array of integers.e.g. [[1, 2,[3]],4] -> [1,2,3,4]. 

            Your solution should be a link to a gist on gist.github.com with your implementation.
            When writing this code, you can use any language you're comfortable with. 
            The code must be well tested and documented if necessary, and in general please treat the quality of 
            the code as if it was ready to ship to production.
            Try to avoid using language defined methods like Ruby's Array#flatten.
            */

            while (_continueExecute)
            {
                UserConsole();

                ConvertNestedToFlatArray();
            }

        }

        /// <summary>
        /// Convert the enter nested array into flat array.
        /// </summary>
        static void ConvertNestedToFlatArray()
        {
            IFlatArray flatArray = new FlatArray();
            if (_splitCharacterChar != '\0')
            {
                flatArray.BuildTheFlatArray(_nestedArray, _splitCharacterChar);
            }
            else
            {
                flatArray.BuildTheFlatArray(_nestedArray);
            }

            if (!flatArray.IsFlatArrayEmpty())
            {
                flatArray.PrintNestedArray();
            }
            else
            {
                flatArray.PrintEmptyNestedArray();
            }
        }

        /// <summary>
        /// Collect the nested array and split character from the user.
        /// </summary>
        static void UserConsole()
        {
            _nestedArray = "[[1, 2,[3]],4]";

            Console.WriteLine("Enter nested arrays");
            Console.WriteLine("--Default: " + _nestedArray);
            Console.WriteLine("-- type 'quit' to terminate.");

            string newNestedArray = Console.ReadLine();
            if (newNestedArray == "quit")
            {
                _continueExecute = false;
            }
            if (!String.IsNullOrEmpty(newNestedArray))
            {               
                Console.WriteLine("Array split character, e.g. comma (,)");
                string splitCharacter = Console.ReadLine();
                if (splitCharacter.ToCharArray().Length == 1)
                {
                    _splitCharacterChar = Char.Parse(splitCharacter);
                    _nestedArray = newNestedArray;
                }

            }

        }

    }
}
