using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Assignment.Models;
using Assignment.Services;
using PropertyChanged;

namespace Assignment.MVVM.ViewModels;

public class Assignment13ViewModel
{
    Assignment13Service _assignment13Service;

    public ObservableCollection<Assignment13Model> Assignment13 { get; set; } = [];
    public Assignment13Model CurrentAssignment13 { get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public Assignment13ViewModel (Assignment13Service assignment13Service)
    {
        this._assignment13Service = assignment13Service;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentAssignment13 = new Assignment13Model();
            await this.Refresh();
        }
        );
        AddOrUpdateCommand = new Command(async () =>
        {
            await this.Save();
            await this.Refresh();
        });
        DeleteCommand = new Command(async () =>
        {
            await this.Delete();
            await this.Refresh();
        });

    }
    public async Task GetAll()
    {
        Assignment13 = [];
        var items = await _assignment13Service.GetAllAssignment13();
        foreach (var item in items)
        {
            Assignment13.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentAssignment13.Id))
       {
            await _assignment13Service.InsertAssignment13(this.CurrentAssignment13);
       }
       else{
            await _assignment13Service.UpdateAssignment13(this.CurrentAssignment13);
       }
    }

    private async Task Refresh()
    {
        CurrentAssignment13 = new Assignment13Model();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _assignment13Service.DeleteAssignment13(this.CurrentAssignment13.Id);
    }
}
