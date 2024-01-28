using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public class Production
    {
        private int _organizationId = 0;
        private string _organizationName;

        public Production(string organizationName)
        {
            _organizationId++;
            _organizationName = organizationName;
        }

        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }
    }
}
