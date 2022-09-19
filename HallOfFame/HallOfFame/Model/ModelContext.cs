using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Model
{
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Сотрудники
        /// </summary>
        public DbSet<Person> Person { get; set; }

        /// <summary>
        /// Навыки
        /// </summary>
        public DbSet<Skill> Skill { get; set; }

        public ModelContext()
        {

        }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {

        }

        private static ModelContext context;

        /// <summary>
        /// Получение контекста БД
        /// </summary>
        public static ModelContext GetContext()
        {
            if (context == null)
            {
                context = new ModelContext();
            }
            return context;
        }
    }
}
