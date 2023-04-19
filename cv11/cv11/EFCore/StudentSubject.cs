using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.EFCore
{
    internal class StudentSubject
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        public string AbbreviationId { get; set; }

        
    }
}
