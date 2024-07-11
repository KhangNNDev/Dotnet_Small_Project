using Microsoft.EntityFrameworkCore;

public class NoteDBContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }

    public NoteDBContext(DbContextOptions<NoteDBContext> options)
    {
        Database.EnsureCreated();
    }
    
}