using System;
namespace CitrusByte.Computation
{
    public interface IFlatArray
    {
        void BuildTheFlatArray(string nestedArray, char splitCharacter);

        void BuildTheFlatArray(string nestedArray);

        int[] ConvertStringArrayToIntegerArray();

        bool IsFlatArrayEmpty();
        void PrintNestedArray();

        void PrintEmptyNestedArray();
    }
}