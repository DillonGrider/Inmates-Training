using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Campus
    {
        private List<Student> m_Students;
        private List<Enrollment> m_Enrollments;
        private List<Seminar> m_Seminars;
        private List<Professor> m_Professors;

        public Campus()
        {
            m_Students = new List<Student>();
            m_Enrollments = new List<Enrollment>();
            m_Seminars = new List<Seminar>();
            m_Professors = new List<Professor>();
        }

        public List<Student> Students
        {
            get { return m_Students; }
        }
        public List<Enrollment> Enrollments
        {
            get { return m_Enrollments; }
        }
        public List<Seminar> Seminars
        {
            get { return m_Seminars; }
        }
        public List<Professor> Professors
        {
            get { return m_Professors; }
        }

        public void ReestablishLinks()
        {
            foreach (Enrollment e in Enrollments)
            {
                GetStudent(e.StudentID).AddEnrollment(e);
                GetSeminar(e.SeminarID).AddEnrollment(e);
            }

            foreach (Seminar s in Seminars)
            {
                foreach (int studentID in s.WaitingListIDs)
                    s.AddToWaitingList(GetStudent(studentID));
                GetProfessor(s.InstructorID).AddSeminar(s);
            }
        }

        private Student GetStudent(int id)
        {
            Student s = Students.FirstOrDefault(x => x.IDNumber == id);
            if (s == null)
                throw new Exception("Invalid student ID: " + id.ToString());
            return s;
        }

        private Seminar GetSeminar(int id)
        {
            Seminar s = Seminars.FirstOrDefault(x => x.IDNumber == id);
            if (s == null)
                throw new Exception("Invalid seminar ID: " + id.ToString());
            return s;
        }

        private Professor GetProfessor(int id)
        {
            Professor p = Professors.FirstOrDefault(x => x.IDNumber == id);
            if (p == null)
                throw new Exception("Invalid professor ID: " + id.ToString());
            return p;
        }
    }
}
