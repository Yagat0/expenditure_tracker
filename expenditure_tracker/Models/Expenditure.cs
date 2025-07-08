using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace expenditure_tracker.Models;

public enum PaymentMethod { Card, Cash, BankTransfer };

public enum Period { Daily, Weekly, Monthly, Yearly, Never };

[ComplexType]
public class Recurrence(bool isRecurring = false, Period period = Period.Never, int interval = 0)
{
    public bool IsRecurring = isRecurring;
    public Period Period = period;
    public int Interval = interval;
}

public class Expenditure
{
    [Key]
    public int Id { get; set; } // Primary key

    public double Amount { get; set; }
    
    [MaxLength(100)]
    public string? Category { get; set; }
    
    [MaxLength(250)]
    public string? Note { get; set; }
    public DateTime? Date { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }
    public Recurrence? Recurrence { get; set; }
    public string? Currency { get; set; }
    public string? Location { get; set; }
    public string? Vendor { get; set; }

    public Expenditure(double amount, string? category = null,
        string? note = null, DateTime? date = null, 
        PaymentMethod? paymentMethod = null,
        Recurrence? recurrence = null, string? currency = null)
    {
        Amount = amount;
        Category = category;
        Note = note;
        Date = date;
        PaymentMethod = paymentMethod;
        Recurrence = recurrence;
        Currency = currency;
    }

    // needed for EF
    public Expenditure() { }
}