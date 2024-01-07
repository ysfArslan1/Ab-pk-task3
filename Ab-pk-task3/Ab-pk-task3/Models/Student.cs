using System.ComponentModel.DataAnnotations.Schema;

namespace Ab_pk_task3.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int  ClassId { get; set; }
        public int BookGenreId { get; set; }
        public DateTime TestDate { get; set; }
    }
}
