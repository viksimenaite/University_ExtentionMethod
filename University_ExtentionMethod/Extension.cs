using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    interface Extension
    {
        double determineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture);
        public bool isSuitableLecturer(Lecturer lecturer);

        void setUniversity(IUniversity university);
    }
}
