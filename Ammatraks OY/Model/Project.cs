using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ammatraks_OY.Model
{
    public class Project
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string IDFormatted => "Project #" + ID;
        public string Description { get; set; }
        public List<Worker> Workers { get; set; }
        public List<Invoice> Invoices { get; set; }

    }
}
