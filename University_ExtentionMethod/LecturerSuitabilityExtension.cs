using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    class LecturerSuitabilityExtension : Extension
    {
        private readonly int requiredYearsOfExperience = 4;
        public double determineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return lecture.Duration;
        }

        public bool isSuitableLecturer(Lecturer lecturer)
        {
            return lecturer.HasPHD && lecturer.Experience > requiredYearsOfExperience;
        }

        public void setUniversity(IUniversity university){}
    }
}
