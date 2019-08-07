using HomeGreat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HomeGreat.Model
{
    public class Competition
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Competition Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(70)]
        [Display(Name = "Competition Type")]
        public string Type { get; set; }
        [StringLength(50)]
        [Display(Name = "Competition Location")]
        public string Location { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate{ get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Key]
        [ForeignKey("School")]
        public int SchoolID { get; set; }

        public virtual School School { get; set; }
    }
}
