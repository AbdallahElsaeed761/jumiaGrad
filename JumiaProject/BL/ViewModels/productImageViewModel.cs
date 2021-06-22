using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class productImageViewModel
    {
       

        public int ProductId { get; set; }


        public string Image { get; set; }

        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
       
    }
}
