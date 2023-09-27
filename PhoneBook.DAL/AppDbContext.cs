using PhoneBook.DAL.Models;
using PhoneBook.DAL.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PhoneBook.DAL;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<PublicOrganization> PublicOrganizations { get; set; }
    public DbSet<PrivateOrganization> PrivateOrganizations { get; set; }


    public override int SaveChanges()
    {
        AddModificationDate();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddModificationDate();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var property in modelBuilder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.SeedData();
    }

    private void AddModificationDate()
    {
        var entries = ChangeTracker
                        .Entries()
                            .Where(e => e.Entity is BaseEntity && (
                                        e.State == EntityState.Added
                                || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((BaseEntity)entityEntry.Entity).ModifyDate = DateTime.UtcNow;

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.UtcNow;
            }
        }
    }
}

public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder, Expression<Func<BaseEntity, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(x => x.ClrType.BaseType == typeof(BaseEntity))
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
    }
}