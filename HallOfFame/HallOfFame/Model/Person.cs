using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Model
{
    public class Person
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Key]
        public long Id { get; set; }

        /// <summary>
        /// Наименование сотрудника
        /// </summary>
        [Required(ErrorMessage = "Имя отсутствует")]
        [StringLength(30, ErrorMessage = "Длина имени больше 30 символов.")]
        public string Name { get; set; }

        /// <summary>
        /// Отображаемое имя сотредника
        /// </summary>
        [Required(ErrorMessage = "Отображаемое имя отсутствует")]
        [StringLength(30, ErrorMessage = "Длина отображаемого имени больше 30 символов.")]
        public string DisplayName { get; set; }

        /// <summary>
        /// Навыки сотрудника
        /// </summary>
        [InverseProperty("Person")]
        public List<Skill> Skills { get; set; }
    }
}
