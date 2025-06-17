using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using expenditure_tracker.Models;

namespace expenditure_tracker.Services;

public class ExpenditureDbContext : DbContext
{
    public DbSet<Expenditure> Expenditures { get; set; }
    public string DbPath { get; set; }

    public enum FilterOptions
    {
        Before, After, More, Less
    }
    
    public ExpenditureDbContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "expenditures.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expenditure>()
            .OwnsOne(e => e.Recurrence);
    }*/
    
    public async Task AddExpenditure(Expenditure expenditure)
    {
        Add(expenditure);
        await SaveChangesAsync();
    }
    
    public List<Expenditure> GetExpenditures(
        DateTime? date = null, FilterOptions? dateFilter = null,
        string? category = null,
        double? amount = null, FilterOptions? amountFilter = null,
        PaymentMethod? paymentMethod = null, string? currency = null, 
        string? location = null, string? vendor = null)
    {
        var q = Expenditures.AsQueryable();

        if (date.HasValue && dateFilter.HasValue)
        {
            q = dateFilter switch
            {
                FilterOptions.Before => q.Where(e => e.Date < date),
                FilterOptions.After => q.Where(e => e.Date > date),
                _ => q
            };
        }
        if (category != null) q = q.Where(e => e.Category == category);
        if (amount.HasValue && amountFilter.HasValue)
        {
            q = amountFilter switch
            {
                FilterOptions.More => q.Where(e => e.Amount > amount),
                FilterOptions.Less => q.Where(e => e.Amount < amount),
                _ => q
            };
        }

        if (paymentMethod.HasValue)
            q = q.Where(e => e.PaymentMethod == paymentMethod.Value);
        if (currency != null) q = q.Where(e => e.Currency == currency);
        if (location != null) q = q.Where(e => e.Location == location);
        if (vendor != null) q = q.Where(e => e.Vendor == vendor);
        return q.ToList();
    }
    
    public async Task RemoveExpenditure(Expenditure expenditure)
    {
        Remove(expenditure);
        await SaveChangesAsync();
    }
}