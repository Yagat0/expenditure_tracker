using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace expenditure_tracker.Models;

public enum PaymentMethod { Card, Cash, BankTransfer };

/* TODO: Fix recurrence parameter
public enum Period { Daily, Weekly, Monthly, Yearly };

[Owned]
public class Recurrence
{
    bool _isRecurring;
    Period _period;
    int _interval;

    public Recurrence(bool isRecurring, Period period, int interval)
    {
        _isRecurring = isRecurring;
        _period = period;
        _interval = interval;
    }
}*/

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
    //public Recurrence? Recurrence { get; set; }
    public string? Currency { get; set; }
    public string? Location { get; set; }
    public string? Vendor { get; set; }
}