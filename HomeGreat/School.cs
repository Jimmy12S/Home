using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeGreat.Model
{
   
    public enum Names
   {
       Pakalinding, Soma, Mansakonko, Brikama, Banjul, Basse, Jatta
    }
    public enum Regions
    {
        Lower_River_Reg, North_Bank_Reg, West_Coast, Upper_River_Reg, Central_River_Reg
   }
    public enum SchoolType
    {
        Nursery, Primary, Secondary, High
    }
    public class School
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Name of the School")]
      //  [StringLength(100)]
        public Names Name { get; set; }
        [Required]
      
        [Display(Name = "Name of the Region")]
        [StringLength(50)]
        public Regions Region { get; set; }
        [Required]


        // public SchoolType Type { get; set; }
        [Display(Name = "Type of School")]
        //[Column(TypeName = "varchar(200)")]
        [StringLength(50)]
        public SchoolType Type { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registration Date")]
        public DateTime RegisterDate { get; set; }

        public string FullName
        {
            get { return Name + ", " + Region + ", " +" SchoolType" + ", "+ RegisterDate; }
        }

        public virtual ICollection<Student> Students{ get; set; }
        //public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Competition> Competition { get; set; }
        public int EventID { get; set; }

    }
  
}
