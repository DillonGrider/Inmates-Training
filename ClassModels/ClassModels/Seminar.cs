using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Seminar
    {
        private List<Student> m_WaitingList;

        private List<int> m_WaitingListIDs;

        private List<Enrollment> m_Enrollments;

        private List<int> m_EnrollmentIDs;

        private int m_InstructorID;

        public int IDNumber { get; set; }
        public string Name { get; set; }
        public double Fee { get; set; }

        [JsonIgnore]
        public Professor Instructor { get; set; }

        public int InstructorID
        {
            get
            {
                if (Instructor != null)
                    return Instructor.IDNumber;
                return m_InstructorID;
            }
            set
            {
                m_InstructorID = value;
            }
        }

        [JsonIgnore]
        public IReadOnlyList<Student> WaitingList
        {
            get { return m_WaitingList; }
        }

        public List<int> WaitingListIDs
        {
            get
            {
                if (m_WaitingListIDs == null)
                {
                    m_WaitingListIDs = new List<int>();
                    foreach (Student s in WaitingList)
                        m_WaitingListIDs.Add(s.IDNumber);
                }
                return m_WaitingListIDs;
            }
            set
            {
                m_EnrollmentIDs = value;
            }
        }

        [JsonIgnore]
        public IReadOnlyList<Enrollment> Enrollments
        {
            get { return m_Enrollments; }
        }

        public List<int> EnrollmentIDs
        {
            get
            {
                if (m_EnrollmentIDs == null)
                {
                    m_EnrollmentIDs = new List<int>();
                    foreach (Enrollment e in Enrollments)
                        m_EnrollmentIDs.Add(e.IDNumber);
                }
                return m_EnrollmentIDs;
            }
            set
            {
                m_EnrollmentIDs = value;
            }
        }

        public Seminar()
        {
            m_WaitingList = new List<Student>();
            m_Enrollments = new List<Enrollment>();
        }

        public void AddToWaitingList(Student student)
        {
            if (student == null)
                throw new Exception("Cannot add null student to waiting list");
            if (!m_WaitingList.Contains(student))
                m_WaitingList.Add(student);
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
                throw new Exception("Cannot add null enrollment to list");
            if (!m_Enrollments.Contains(enrollment))
            {
                enrollment.Seminar = this;
                m_Enrollments.Add(enrollment);
            }
        }

        public void RemoveFromWaitingList(Student student)
        {
            m_WaitingList.Remove(student);
        }

        public void RemoveFromEnrollments(Enrollment enrollment)
        {
            m_Enrollments.Remove(enrollment);
            enrollment.Seminar = null;
        }
    }
}
