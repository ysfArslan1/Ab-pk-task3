using Microsoft.EntityFrameworkCore;
using Ab_pk_task3.Models;

namespace Ab_pk_task3.DBOperations;

public class PatikaDbContext : DbContext
{
    public PatikaDbContext(DbContextOptions<PatikaDbContext> options) : base(options)
    {
    }


    public DbSet<Student> Students { get; set; }

}

