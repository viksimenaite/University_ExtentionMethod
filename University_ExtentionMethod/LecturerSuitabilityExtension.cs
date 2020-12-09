using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    class LecturerSuitabilityExtension : IExtension
    {
        private readonly int requiredYearsOfExperience = 4;
        public double DetermineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return lecture.Duration;
        }

        public bool IsSuitableLecturer(Lecturer lecturer)
        {
            return lecturer.HasPHD && lecturer.Experience > requiredYearsOfExperience;
        }

        public void SetUniversity(ExtendableUniversity university){}
    }
}
