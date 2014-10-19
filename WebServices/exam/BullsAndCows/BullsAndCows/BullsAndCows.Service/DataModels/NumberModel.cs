using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Service.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class NumberModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }
    }
}