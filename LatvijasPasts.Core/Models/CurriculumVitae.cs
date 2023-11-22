using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LatvijasPasts.Core.Models
{
    public class CurriculumVitae : Entity
    {
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [MaxLength(50)]
        public string? LastName { get; set; }

        [MaxLength(50)]
        public string? OtherName { get; set; }

        [MaxLength(12)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }
    }
}
