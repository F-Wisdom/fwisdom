using FptRagLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FptRagLab.Infrastructure.Data
{
    /// <summary>
    /// Entity Framework Core DbContext for the FPT RAG Lab application.
    /// Uses PostgreSQL with pgvector extension for vector similarity search.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for all entities
        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<LearningOutcome> LearningOutcomes => Set<LearningOutcome>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<DocumentChunk> DocumentChunks => Set<DocumentChunk>();
        public DbSet<Quiz> Quizzes => Set<Quiz>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<QuestionOption> QuestionOptions => Set<QuestionOption>();
        public DbSet<Citation> Citations => Set<Citation>();
        public DbSet<QuizAttempt> QuizAttempts => Set<QuizAttempt>();
        public DbSet<AttemptAnswer> AttemptAnswers => Set<AttemptAnswer>();
        public DbSet<QuizLearningOutcome> QuizLearningOutcomes => Set<QuizLearningOutcome>();
        public DbSet<TokenUsageLog> TokenUsageLogs => Set<TokenUsageLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all entity configurations from assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Enable pgvector extension
            // modelBuilder.HasPostgresExtension("vector");

            // Configure composite keys
            modelBuilder.Entity<QuizLearningOutcome>()
                .HasKey(x => new { x.QuizId, x.LearningOutcomeId });

            // Unique constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Course>()
                .HasIndex(c => c.Code)
                .IsUnique(); // BR-13: Each course code must be unique

            // TODO: Configure vector column for DocumentChunk.Embedding using pgvector
            // Example: modelBuilder.Entity<DocumentChunk>()
            //     .Property(d => d.Embedding)
            //     .HasColumnType("vector(1536)");
        }
    }
}
