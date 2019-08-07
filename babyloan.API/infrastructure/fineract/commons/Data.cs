using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace babyloan.API.infrastructure.fineract.commons
{
    public class Data<t,r>
    {
        public t body { get; set; }
        public string queryString { get; set; }
        
        public string resource{ get; set; }
        public string method { get; set; }
        public r res { get; set; }
        public List<string> fields { get; set; }
        public string command { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public string tenant_id { get; set; }


}
}
