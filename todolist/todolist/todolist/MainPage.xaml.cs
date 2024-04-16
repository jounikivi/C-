using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Task> tasks;

        public MainPage()
        {
            InitializeComponent();
            tasks = new ObservableCollection<Task>();
            taskListView.ItemsSource = tasks;
        }

        private void AddTaskButton_Clicked(object sender, EventArgs e)
        {
            tasks.Add(new Task { Name = newTaskEntry.Text });
            newTaskEntry.Text = string.Empty;
        }

        private void ClearListButton_Clicked(object sender, EventArgs e)
        {
            tasks.Clear();
        }
    }

    public class Task
    {
        public string Name { get; set; }
    }
}
