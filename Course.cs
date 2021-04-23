namespace Lab2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Crs_Id { get; set; }

        [StringLength(50)]
        public string Crs_Name { get; set; }

        public int? Crs_Duration { get; set; }

        public int? Top_Id { get; set; }

        public virtual Topic Topic { get; set; }
    }

    [Table("Student")]
    public partial class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int St_Id { get; set; }

        [StringLength(50)]
        public string St_Fname { get; set; }

        [StringLength(10)]
        public string St_Lname { get; set; }

        [StringLength(100)]
        public string St_Address { get; set; }

        public int? St_Age { get; set; }

        public int? Dept_Id { get; set; }

        public int? St_super { get; set; }

        [StringLength(150)]
        public string Username { get; set; }

        [StringLength(600)]
        public string Password { get; set; }
    }
}
