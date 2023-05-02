using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv11.EFCore
{
    internal class Grades
    {
        [Key]
        public int StudentId { get; set; }
        [Key]
        public string NameofSubjectId { get; set; }
        public DateTime DateOfGrade { get; set; }
        public int Grade { get; set; }

    }
}
