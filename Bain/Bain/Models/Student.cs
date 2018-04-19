using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bain.Models
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }

        public List<int> ExamScores;
    }

}