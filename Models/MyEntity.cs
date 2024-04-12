using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestProject.Models
{
    public class MyEntity
    {
        [Key]
        public int Id { get; set; }
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    }
}