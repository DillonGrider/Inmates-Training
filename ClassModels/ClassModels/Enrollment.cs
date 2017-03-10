using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Enrollment: IDisposable
    {
        private static List<Enrollment> s_Enrollments;

        private int m_IDNumber;
        private string m_FinalGrade;
        private Student m_Student;
        private Seminar m_Seminar;
        private List<double> m_MarksReceived;
        private int m_StudentID;
        private int m_SeminarID;

        static Enrollment()
        {
            s_Enrollments = new List<Enrollment>();
        }

        public Enrollment()
        {
            s_Enrollments.Add(this);
        }

        public void Dispose()
        {
            s_Enrollments.Remove(this);
        }

        public int IDNumber { get { return m_IDNumber; } set { m_IDNumber = value; } }

        public static IReadOnlyList<Enrollment> AllEnrollments
        {
            get { return s_Enrollments; }
        }

        public double AverageToDate
        {
            get
            {
                if (MarksReceived.Count == 0)
                    return 0.0;
                return MarksReceived.Average();
            }
        }

        public IReadOnlyList<double> MarksReceived { get { return GetMarksReceived(); } }

        [JsonIgnore]
        public Student Student {
            get { return m_Student; }
            set { m_Student = value; }
        }

        [JsonIgnore]
        public Seminar Seminar
        {
            get { return m_Seminar; }
            set { m_Seminar = value; }
        }

        public int StudentID
        {
            get
            {
                if (Student != null)
                    return Student.IDNumber;
                return m_StudentID;
            }
            set
            {
                m_StudentID = value;
            }
        }

        public int SeminarID
        {
            get
            {
                if (Seminar != null)
                    return Seminar.IDNumber;
                return m_SeminarID;
            }
            set
            {
                m_SeminarID = value;
            }
        }

        public string FinalGrade
        {
            get { return m_FinalGrade; }
            set { m_FinalGrade = value; }
        }

        public void AddMark(double mark)
        {
            GetMarksReceived().Add(mark);
        }

        private List<double> GetMarksReceived()
        {
            if (m_MarksReceived == null)
                m_MarksReceived = new List<double>();
            return m_MarksReceived;
        }

    }
}
