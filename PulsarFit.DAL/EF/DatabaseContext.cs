using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PulsarFit.CORE.Helpers;
using System;
using System.Threading.Tasks;
using System.Threading;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.EF
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #region Models 

        public DbSet<City> Cities { get; set; }
        public DbSet<ClientPlan> ClientPlans { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MultimediaFile> MultimediaFiles { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanWorkout> PlanWorkouts { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var cascadeFKs = builder.Model.GetEntityTypes()
                                         .SelectMany(t => t.GetForeignKeys())
                                         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            OnModelCreating_Currencies(builder);
        }

        #region Models constraints

        private void OnModelCreating_Currencies(ModelBuilder builder)
        {
            builder.Entity<Currency>().HasIndex(x => x.Code).IsUnique();
        }

        #endregion

        #region Helpers 

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddTimestamps();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = DateTime.UtcNow;
                }
                if (entity.State == EntityState.Modified)
                {
                    if (((BaseEntity)entity.Entity).IsDeleted)
                    {
                        ((BaseEntity)entity.Entity).DeletedAt = DateTime.UtcNow;
                    }
                    else
                    {
                        ((BaseEntity)entity.Entity).ModifiedAt = DateTime.UtcNow;
                    }
                }
            }
        }

        #endregion
    }
}
