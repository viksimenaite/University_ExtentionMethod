using System;
using System.Collections.Generic;
using System.Text;

namespace University_ExtentionMethod
{
    class PreparationForLectureExtension : Extension
    {
        private readonly double preparationTimeCoefficient = 0.5;
        private IUniversity university;
        public double determineLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture)
        {
            return lecture.Duration * (1 + preparationTimeCoefficient);
        }

        public bool isSuitableLecturer(Lecturer lecturer)
        {
            return true;
        }

        public void setUniversity(IUniversity university)
        {
            this.university = university;
        }

        public double getPreparationTime(Lecturer lecturer, Lecture lecture)
        {
            return this.university.CalculateOverallLecturerTimeDedicatedToLecture(lecturer, lecture) * preparationTimeCoefficient;
        }


    }
}
