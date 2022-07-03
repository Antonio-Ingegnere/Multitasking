using System.Diagnostics;
using Multitasking.ViewModel;
using Multitasking.Data;

namespace Multitasking;

public partial class MainPage : ContentPage
{
    private TrackerViewModel _trackerViewModel;
    int count = 0;

    public MainPage()
    {
        InitializeComponent();

        _trackerViewModel = new TrackerViewModel();
        BindingContext = _trackerViewModel;

        this.Loaded += (object sender, EventArgs e) =>
        {
            this.taskDescription.Focus();

            //Test attempt about working with DB MUST be removed later
            GetDataFromDB();
        };
    }

    private void GetDataFromDB()
    {
        //using(var dataContext = new DataContext())
        {

        }
    }

    private void OnTextChanged(object sender, EventArgs e)
    {
        Debug.WriteLine(sender.ToString);
    }

    private void OnTextCompleted(object sender, EventArgs e)
    {
        Debug.WriteLine(_trackerViewModel.NewTodo.Description);
        AddItemToList();
    }
    private void OnCounterClicked(object sender, EventArgs e)
    {
        AddItemToList();
    }

    private void AddItemToList()
    {
        _trackerViewModel.MoveNewItemToList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

