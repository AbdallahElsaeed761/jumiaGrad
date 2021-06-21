﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Governorate
    {
        public int GovernorateId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string GovernorateName { get; set; }
        [Required]
        [Range(1, 20)]
        public int Duration { get; set; }
        [Required]
        [Range(1, 3000)]
        public float ShippingValue { get; set; }
        [DefaultValue(false)]
        public bool Isdeleted { get; set; }
        public virtual List<ShippingDetails> ShippingDetails { get; set; }
    }
}