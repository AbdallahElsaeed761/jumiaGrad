using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ViewModels
{
    public class ViewsViewModel
    {
        public string CustomerId { get; set; }
        

        public int ProductId { get; set; }
        


        [DefaultValue(false)]
        public bool IsFav { get; set; }
    }
}
