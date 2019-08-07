using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeGreat.Model
{
    public enum EventType
    {
       OneHM,TwoHm,LongJump, Shortpull, Swimiming
    }
    public enum EventCata
    {
        Juniors, Seniors, Intermediates
    }
    public class Event
    {
      //  public Event()
       // {
          ///  this.Students = new HashSet<Student>();
       // }
        public int EventID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Event Name")]
        public EventType Type { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Event Catagory")]
        public EventCata Name { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name of the School")]

        public int SchoolID { get; set; }
        [Display(Name = "Competition Name")]
        public int CompetitionID { get; set; }
        // public virtual ICollection<Student> Students { get; set; }
        public IList<EventStudent> EventStudents { get; set; }
        public int StudentID { get; set; }
    }
}
