using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
    }
}
