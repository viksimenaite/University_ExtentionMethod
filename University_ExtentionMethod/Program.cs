using System;

namespace University_ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtendableUniversity extendableUniversity = new ExtendableUniversity();
            extendableUniversity.AddExtension(new PreparationForLectureExtension());
            extendableUniversity.AddExtension(new LecturerSuitabilityExtension());

        }
    }
}
