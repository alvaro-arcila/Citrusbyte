using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CitrusByte.Computation
{
    public class FlatArray : IFlatArray
    {
        #region Declaration
        private StringBuilder _integerStringArray { get; set; }

        private char _splitCharacter { get; set; }

        private string _nestedArray { get; set; }

        public FlatArray()
        {
            _splitCharacter = ','; // deault value
            _integerStringArray = new StringBuilder();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Check if the character is an integer.
        /// </summary>
        private bool IsInteger(char character)
        {
            return Char.IsDigit(character);
        }

        /// <summary>
        /// Build a string.
        /// </summary>
        private void AppendToString(char character)
        {
            _integerStringArray.Append(character);
            _integerStringArray.Append(_splitCharacter);
        }

        /// <summary>
        /// Convert the string into an array.
        /// </summary>
        public int[] ConvertStringArrayToIntegerArray()
        {
            return ConvertStringToIntergerList().ToArray();
        }

        /// <summary>
        /// return the string array.
        /// </summary>
        private string IntegerStringArray()
        {
            return _integerStringArray.ToString().TrimEnd(_splitCharacter);
        }

        private IEnumerable<int> ConvertStringToIntergerList()
        {
            return IntegerStringArray() != "" ?  IntegerStringArray().Split(_splitCharacter).Select(n => Convert.ToInt32(n)) : new List<int>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Convert the enter nested array into a flat interger array using a split character.
        /// </summary>
        public void BuildTheFlatArray(string nestedArray, char splitCharacter)
        {
            _nestedArray = nestedArray;
            _splitCharacter = splitCharacter;
            foreach (char character in nestedArray)
            {
                if (IsInteger(character))
                {
                    AppendToString(character);
                }
            }
        }

        /// <summary>
        /// Convert the enter nested array into a flat interger array.
        /// </summary>
        public void BuildTheFlatArray(string nestedArray)
        {
            if (!String.IsNullOrEmpty(nestedArray))
            {
                _nestedArray = nestedArray;
                foreach (char character in nestedArray)
                {
                    if (IsInteger(character))
                    {
                        AppendToString(character);
                    }
                }
            }
        }

        /// <summary>
        /// Check if the Convert array is empty.
        /// </summary>
        public bool IsFlatArrayEmpty()
        {
            return (ConvertStringArrayToIntegerArray().Length > 0 ? false : true);
        }

        /// <summary>
        /// Print the flat interger array.
        /// </summary>
        public void PrintNestedArray()
        {
            Console.WriteLine(_nestedArray + " -> [" + string.Join(_splitCharacter.ToString(), ConvertStringArrayToIntegerArray()) + "]");
        }

        /// <summary>
        /// print the error message.
        /// </summary>
        public void PrintEmptyNestedArray()
        {
            Console.WriteLine(_nestedArray + " -> Numeric values were not found in the array.");
        }
        #endregion
    }
}
