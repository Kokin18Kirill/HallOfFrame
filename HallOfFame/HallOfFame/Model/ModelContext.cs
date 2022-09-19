using Microsoft.EntityFrameworkCore;

namespace HallOfFame.Model
{
    public class ModelContext : DbContext
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private string ConnectionStrings = "Server=DESKTOP-AM8V2BP;Database=NSTDB;Trusted_Connection=True;";

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

        /// <summary>
        /// Подключение к БД
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStrings);
            }
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
