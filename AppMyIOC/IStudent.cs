using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    public interface IStudent
    {
        string ReadBook();

        string Write(string content);
    }
}
