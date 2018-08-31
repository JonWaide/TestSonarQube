using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSonarQube
{
    public class Foo
    {
        public int Add(int x, int y)
        {
            try
            {
                return (x + y);
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public string Append(string beginning, string end)
        {
            return $"{beginning.ToString()}{end.ToString()}"; //triggering code analysis failure
        }
        public string Add(string beginning, string end) //duplicate method from above
        {
            return $"{beginning.ToString()}{end.ToString()}";
        }
    }
}
