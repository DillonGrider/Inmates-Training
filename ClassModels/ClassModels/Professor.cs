using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Professor
    {
        private Address m_Address;
        private List<Seminar> m_SeminarsInstructing;
        private List<int> m_SeminarsInstructingIDs;

        public int IDNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address
        {
            get { return m_Address; }
            set
            {
                if (value == null)
                    throw new Exception("Professor must have an address");
                m_Address = value;
            }
        }

        // +1 (262) 692-2601
        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        [JsonIgnore]
        public IReadOnlyList<Seminar> SeminarsInstructing
        {
            get { return m_SeminarsInstructing; }
        }

        public List<int> SeminarsInstructingIDs
        {
            get
            {
                if (m_SeminarsInstructingIDs == null)
                {
                    m_SeminarsInstructingIDs = new List<int>();
                    foreach (Seminar s in SeminarsInstructing)
                        m_SeminarsInstructingIDs.Add(s.IDNumber);
                }
                return m_SeminarsInstructingIDs;

            }
            set { m_SeminarsInstructingIDs = value; }
        }

        public Professor()
        {
            m_Address = new Address();
            m_SeminarsInstructing = new List<Seminar>();
        }

        public void AddSeminar(Seminar seminar)
        {
            if (seminar == null)
                throw new Exception("Cannot add null seminar to list");
            if (!m_SeminarsInstructing.Contains(seminar))
            {
                m_SeminarsInstructing.Add(seminar);
                seminar.Instructor = this;
            }
        }

        public void RemoveSeminar(Seminar seminar)
        {
            m_SeminarsInstructing.Remove(seminar);
            seminar.Instructor = null;

        }
    }
}
