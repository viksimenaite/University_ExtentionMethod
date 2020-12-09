using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    interface IExtension
    {
        double DetermineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture);
        public bool IsSuitableLecturer(Lecturer lecturer);

        public void SetUniversity(ExtendableUniversity university);
    }
}
