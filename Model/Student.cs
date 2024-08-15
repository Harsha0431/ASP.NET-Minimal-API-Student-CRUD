using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace http_api_minimal_student.Model
{
    public class Student
    {
        [Key]
        [Required]
        [Column(TypeName = "bigint")]
        public required int Id { get; set; }
        [Required, Column(TypeName = "varchar(300)")]
        public required string Name { get; set; }
        [Required, Column(TypeName = "varchar(400)")]
        public required string Email { get; set; }

        // public Student(){
        //     Id = 0;
        //     Name = "";
        //     Email = "";
        // }

        // public Student(int Id, string name, string email){
        //     this.Id = Id;
        //     this.Email = email;
        //     this.Name = name;
        // }
    }
}
