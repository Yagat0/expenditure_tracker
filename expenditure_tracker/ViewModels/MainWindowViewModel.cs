using System;
using expenditure_tracker.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace expenditure_tracker.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<Expenditure> ExpendituresDg { get; }
    
    private bool _isAdd;
    private bool _isEdit;
    
    [ObservableProperty]
    private bool _isMenuVisible;

    [RelayCommand]
    private void MenuAddVisible()
    {
        IsMenuVisible = true;
        _isAdd = true;
        _isEdit = false;
    }

    [RelayCommand]
    private void MenuEditVisible()
    {
        IsMenuVisible = true;
        _isAdd = false;
        _isEdit = true;
    }

    [RelayCommand]
    private void MenuCancel()
    {
        IsMenuVisible = false;
        _isAdd = false;
        _isEdit = false;
    }

    [RelayCommand]
    private void MenuSave()
    {
        throw new NotImplementedException();
    }
    
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