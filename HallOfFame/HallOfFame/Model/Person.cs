using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Model
{
    public class Person
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Имя отсутствует")]
        [StringLength(30, ErrorMessage = "Длина имени больше 30 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Отображаемое имя отсутствует")]
        [StringLength(30, ErrorMessage = "Длина отображаемого имени больше 30 символов.")]
        public string DisplayName { get; set; }

        [InverseProperty("Person")]

        public List<Skill> Skills { get; set; }
    }
}
