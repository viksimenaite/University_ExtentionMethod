using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    interface IUniversity
    {
        decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture);

        double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture);
    }
}
