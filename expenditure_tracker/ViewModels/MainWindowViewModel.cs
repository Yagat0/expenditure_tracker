using System;
using expenditure_tracker.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace expenditure_tracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Expenditure> ExpendituresDg { get; }

    public MainWindowViewModel()
    {
        var expenditures = new List<Expenditure>
        {
            new (100, "Food", "Dinner", DateTime.Now, PaymentMethod.Cash),
            new (5, "Food", "Ice cream"),
            new (20, "Whatever")
        };
        ExpendituresDg = new ObservableCollection<Expenditure>(expenditures);
    }
}