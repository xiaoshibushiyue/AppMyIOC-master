using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    public class Student : IStudent
    {
        private string name;
        public Student()
        {
            this.name = string.Empty;
        }

        public Student(string name)
        {
            this.name = name;
        }
        public string ReadBook()
        {
            return name + "is reading book";
        }

        public string Write(string content)
        {
            return string.Format("{0} wrote {1}", name, content);
        }
    }
}
