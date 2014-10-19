using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BullsAndCows.Service.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class GameCreateModel
    {
        //        { "name": "The Empire strikes back!", 
        //  "number": "5976" }

        [Required]
        [MinLength(2)]
        [MaxLengthAttribute(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string Number { get; set; }

    }
}