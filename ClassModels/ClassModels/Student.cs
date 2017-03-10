using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    [Serializable]
    public class Student
    {
        private Address m_Address;
        private List<Enrollment> m_Enrollments;
        private List<int> m_EnrollmentIDs;

        public int IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address {
            get { return m_Address; }
            set {
                if (value == null)
                    throw new Exception("Student must have an address");
                m_Address = value;
            }
        }

        // +1 (262) 692-2601
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
        public double CurrentGPA { get; set; }
        public string Major { get; set; }

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

        public Student()
        {
            m_Address = new Address();
            m_Enrollments = new List<Enrollment>();
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if (enrollment == null)
                throw new Exception("Cannot add null enrollment to list");
            if (!m_Enrollments.Contains(enrollment))
            {
                m_Enrollments.Add(enrollment);
                enrollment.Student = this;
            }
        }

        public void RemoveFromEnrollments(Enrollment enrollment)
        {
            m_Enrollments.Remove(enrollment);
            enrollment.Student = null;
        }
    }
}
