using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace ClassModels
{
    public partial class MainForm : Form
    {
        private Student m_Student;
        private Campus m_Campus;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            m_Student = new Student()
            {
                FirstName = "Mike",
                LastName = "Denzien",
                CurrentGPA = 0.9,
                Major = "Computer Science"
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (m_Student == null) return;
            FileStream stream = new FileStream("Student.dat", FileMode.Create);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, m_Student);
            }
            finally
            {
                stream.Dispose();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream("Student.dat", FileMode.Open);
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                m_Student = (Student) bf.Deserialize(stream);
            }
            finally
            {
                stream.Dispose();
            }
            MessageBox.Show("CurrentGPA = " + m_Student.CurrentGPA.ToString());
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            if (m_Student == null) return;
            StreamWriter writer = new StreamWriter("Student.json");
            try
            {
                string jsonString = JsonConvert.SerializeObject(m_Student);
                writer.Write(jsonString);
            }
            finally
            {
                writer.Dispose();
            }
        }

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("Student.json");
            try
            {
                string jsonString = reader.ReadToEnd();
                m_Student = JsonConvert.DeserializeObject<Student>(jsonString);
            }
            finally
            {
                reader.Dispose();
            }
            MessageBox.Show("CurrentGPA = " + m_Student.CurrentGPA.ToString());
        }

        private void btnCreateCampus_Click(object sender, EventArgs e)
        {
            m_Campus = new Campus();

            for (int i = 0; i < 3; ++i)
            {
                Student s = new Student()
                {
                    IDNumber = i + 1,
                    FirstName = "FName" + (i + 1).ToString(),
                    LastName = "LName" + (i + 1).ToString()
                };
                m_Campus.Students.Add(s);
            }

            for (int i = 0; i < 3; ++i)
            {
                Seminar s = new Seminar()
                {
                    IDNumber = i + 1,
                    Name = "Seminar " + (i + 1).ToString(),
                    Fee = 100.0 * (i + 1)
                };
                m_Campus.Seminars.Add(s);
                s.AddToWaitingList(m_Campus.Students[(i + 1) % 3]);
            }

            for (int i = 0; i < 3; ++i)
            {
                Professor p = new Professor()
                {
                    IDNumber = i + 1,
                    FirstName = "FName" + (i + 1).ToString(),
                    LastName = "LName" + (i + 1).ToString()
                };
                m_Campus.Professors.Add(p);
                p.AddSeminar(m_Campus.Seminars[i]);
            }

            for (int i = 0; i < 3; ++i)
            {
                Enrollment er = new Enrollment() { IDNumber = (i + 1) };
                m_Campus.Students[i].AddEnrollment(er);
                m_Campus.Seminars[i].AddEnrollment(er);
                m_Campus.Enrollments.Add(er);
            }

        }

        private void btnSaveCampus_Click(object sender, EventArgs e)
        {
            if (m_Campus == null) return;
            StreamWriter writer = new StreamWriter("Campus.json");
            try
            {
                string jsonString = JsonConvert.SerializeObject(m_Campus, Formatting.Indented);
                writer.Write(jsonString);
            }
            finally
            {
                writer.Dispose();
            }
        }

        private void btnLoadCampus_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("Campus.json");
            try
            {
                string jsonString = reader.ReadToEnd();
                m_Campus = JsonConvert.DeserializeObject<Campus>(jsonString);
                m_Campus.ReestablishLinks();
            }
            finally
            {
                reader.Dispose();
            }
        }
    }
}
