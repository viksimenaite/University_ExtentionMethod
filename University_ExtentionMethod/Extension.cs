using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    interface Extension
    {
        double DetermineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture);
        public bool IsSuitableLecturer(Lecturer lecturer);

        void SetUniversity(ExtendableUniversity university);
    }
}
