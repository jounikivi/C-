using System;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace todolist
{
    public class TodoItem
    {
        public string Name { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        private ObservableCollection<TodoItem> todoItems;

        public MainPage()
        {
            InitializeComponent();

            todoItems = new ObservableCollection<TodoItem>();
            todoList.ItemsSource = todoItems;
        }

        void OnAddButtonClicked(object sender, EventArgs e)
        {
            todoItems.Add(new TodoItem { Name = entry.Text });
            entry.Text = string.Empty;
        }
    }
}
