using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Model
{
    public class Skill
    {
        /// <summary>
        /// Индентификатор навыка
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Наименование навыка
        /// </summary>
        [Required(ErrorMessage = "Название навыка пустое")]
        [StringLength(50, ErrorMessage = "Название навыка больше 50 символов.")]
        public string Name { get; set; }

        /// <summary>
        /// Уровень навыка
        /// </summary>
        [Required(ErrorMessage = "Неуказано значение уровня")]
        [Range(1, 10, ErrorMessage = "Диапазон уровня должен быть от 1 до 10")]
        public byte Level { get; set; }

        [InverseProperty("Skills")]
        public Person Person { get; set; }
    }
}
