
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManager.Models
{
    
    public class Course
    {
        [Key]
        public int Id {get ;set;}
        [MaxLength(256)]
        public string Name {get;set;}
        [MaxLength(64)]
        public string Slug {get; set;}
        [MaxLength(128)]
        public string Summary {get;set;}
        [MaxLength(512)]
        public string Detail {get ;set;}
        [MaxLength(256)]
        public string Avatar {get ;set;}
        [MaxLength(256)]

        // [ForeignKey("Category")]
        public int CategoryId {get; set;}
        public Category Category {get; set;}
    }
}