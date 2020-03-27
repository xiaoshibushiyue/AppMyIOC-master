using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMyIOC
{
    public class OprateController
    {
        IStudent stu1;
        public OprateController()
        {
            stu1 = Mapper.GetInstance<IStudent>();             
        }

        public string OprateRead()
        {
            return stu1.ReadBook();
        }

        public string OprateWrite()
        {
            return stu1.Write(" opration ");
        }

    }
}
