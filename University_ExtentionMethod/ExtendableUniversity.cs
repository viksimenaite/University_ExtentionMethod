using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University_ExtentionMethod
{
    class ExtendableUniversity:IUniversity
    {
        private readonly decimal privateLecturePriceCoefficient = 2m;
        private readonly decimal lerturerWithPHDLecturePriceCoefficient = 1.2m;
        private readonly decimal lerturerWithExperienceLecturePriceCoefficient = 1.3m;
        private readonly int requiredYearsOfExperience = 5;
        private readonly double lerturerWithExperiencePreparationTimeCoefficient = 1.5;
        private readonly double lerturerWithoutExperiencePreparationTimeCoefficient = 2.5;

        private List<IExtension> extensions = new List<IExtension>();

        public decimal CalculateLecturePrice(Lecturer lecturer, Lecture lecture)
        {
            bool isLecturerSuitable = extensions.Select(extension => extension.IsSuitableLecturer(lecturer)).Aggregate(true, (first, second) => first && second);

            if (isLecturerSuitable)
            {
                decimal price = lecture.BasePrice;
                if (lecture.IsPrivate)
                {
                    price *= privateLecturePriceCoefficient;
                }
                if (lecturer.HasPHD)
                {
                    price *= lerturerWithPHDLecturePriceCoefficient;
                }
                if (lecturer.Experience > 2)
                {
                    price *= lerturerWithExperienceLecturePriceCoefficient;
                }
                return price;
            }else
            {
                return -1;
            }

        }

        public double CalculateOverallLecturerTimeDedicatedToLecture(Lecturer lecturer, Lecture lecture) //include time to prepare for the lecture
        {
            double duration = GetLecturerPreparationTime(lecture, lecturer);

            foreach (IExtension ext in extensions){
                duration = ext.DetermineLecturerTimeDedicatedToLecture(lecturer, lecture);
            }
            return duration;
        }

        public void AddExtension(IExtension extension)
        {
            this.extensions.Add(extension);
            extension.SetUniversity(this);
        }

        public double GetLecturerPreparationTime(Lecture lecture, Lecturer lecturer)
        {
            if (lecturer.Experience > requiredYearsOfExperience)
            {
                return lecture.Duration * lerturerWithExperiencePreparationTimeCoefficient;
            }
            else
            {
                return lecture.Duration * lerturerWithoutExperiencePreparationTimeCoefficient;
            }
        }

        public IExtension GetExtension (Type objType)
        {
            List<IExtension> extensionsList = (from ext in extensions
                                             where objType.IsInstanceOfType(ext)
                                             select ext).ToList();

            return (IExtension)extensionsList.First();
        }
    }
}
