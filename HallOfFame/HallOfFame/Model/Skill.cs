using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Model
{
    public class Skill
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Название навыка пустое")]
        [StringLength(50, ErrorMessage = "Название навыка больше 50 символов.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Неуказано значение уровня")]
        [Range(1, 10, ErrorMessage = "Диапазон уровня должен быть от 1 до 10")]
        public byte Level { get; set; }

        [InverseProperty("Skills")]
        public Person Person { get; set; }
    }
}
