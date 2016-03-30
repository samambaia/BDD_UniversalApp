using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD_Specs.Winium
{
    public class ElementMap
    {
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }

        public ElementMap(string componentId, string componentName)
        {
            this.ComponentId = componentId;
            this.ComponentName = componentName;
        }

        public ElementMap()
        {

        }
    }
}
