using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.EFCore
{
    internal class Subject
    {
        [Key]
        public string AbbreviationId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
