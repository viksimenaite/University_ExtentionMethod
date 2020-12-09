using System;
using System.Collections.Generic;
using System.Linq;

namespace University_ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Lecturer> lecturersList = new List<Lecturer>
            {
                new Lecturer("Thomas", "Math", true, 6),
                new Lecturer("Julia","Literature", true, 8),
                new Lecturer("Gretchen", "Math", false, 10),
                new Lecturer("John", "Music", false, 1)
            };

            List<Lecture> lecturesList = new List<Lecture>
            {
                new Lecture("Math", 1.5, false, false),
                new Lecture("Literature", 0.75, false, true),
                new Lecture("Music", 1.5, true, false)
            };

            ExtendableUniversity extendableUniversity = new ExtendableUniversity();
            extendableUniversity.AddExtension(new PreparationForLectureExtension());
            extendableUniversity.AddExtension(new LecturerSuitabilityExtension());

            Lecture lecture = lecturesList[AskWhichOneToGet(lecturesList, "lecture") - 1];
            var filteredLecturersList = from lect in lecturersList
                                        where lect.Specialty.Equals(lecture.Subject)
                                        select lect;
            Lecturer lecturer = lecturersList[AskWhichOneToGet(filteredLecturersList.ToList(), "lecturer") - 1];


            Console.WriteLine("Lecture price: " + extendableUniversity.CalculateLecturePrice(lecturer, lecture) + " Eur");
            Console.WriteLine("Lecturer's time to prepare for the lecture: " + ((PreparationForLectureExtension)extendableUniversity.GetExtension(typeof(PreparationForLectureExtension))).GetPreparationTime(lecturer, lecture) + " h");
            Console.WriteLine("All lecturers' time dedicated to the lecture: " + extendableUniversity.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) + " h");

        }

        static int AskWhichOneToGet<T>(List<T> list, String requiredObject)
        {
            Console.WriteLine("\r\nWe have the following " + requiredObject + "s:");
            int count = 1;
            foreach (var obj in list)
            {
                Console.WriteLine(count.ToString() + ". " + obj.ToString());
                count++;
            }

            Console.WriteLine("\r\nEnter the number of the " + requiredObject + " you would like:");
            return GetIntInput(list.Count);
        }

        static int GetIntInput(int bound)
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input > bound || input < 1)
            {
                Console.WriteLine("\r\nYou've entered an invalid number. Try again:");
            }
            return input;
        }
    }
}
