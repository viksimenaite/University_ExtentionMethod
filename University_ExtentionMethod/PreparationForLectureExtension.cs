using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    class PreparationForLectureExtension : IExtension
    {
        private readonly double preparationTimeCoefficient = 0.5;
        private ExtendableUniversity university;
        public double DetermineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return lecture.Duration * (1 + preparationTimeCoefficient);
        }

        public bool IsSuitableLecturer(Lecturer lecturer)
        {
            return true;
        }

        public void SetUniversity(ExtendableUniversity university)
        {
            this.university = university;
        }

        public double GetPreparationTime(Lecturer lecturer, Lecture lecture)
        {
            return this.university.GetLecturerPreparationTime(lecture, lecturer) * preparationTimeCoefficient;
        }


    }
}
