using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TheDebtBook.ViewModels
{
    class MainViewModels : INotifyPropertyChanged
    {
        public MainViewModels()
        {
            _database = new Database();

            AddTodoCommand = new Command(async () => await AddNewTodo());
            CompleteTodoCommand = new Command<TodoItem>(async (item) => await CompleteTodo(item));
            SwipeCompleteTodoCommand = new Command<TodoItem>(async (item) => await SwipeCompleteTodoExecute(item));
            DeleteTodoCommand = new Command<TodoItem>(async (item) => await DeleteTodo(item));
            _ = Initialize();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void RaisePropertyChanged(params string[] properties)
        {
            foreach (var propertyName in properties)
            {
                PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public ObservableCollection<TodoItem> Todos { get; set; } = new();
        public string NewTodoTitle { get; set; } = string.Empty;
        public DateTime NewTodoDue { get; set; } = DateTime.Now;
        public ICommand AddTodoCommand { get; set; }
        public ICommand CompleteTodoCommand { get; set; }
        public ICommand SwipeCompleteTodoCommand { get; set; }
        public ICommand DeleteTodoCommand { get; set; }
        private readonly Database _database;

        #region Methods
        private async Task Initialize()
        {
            var todos = await _database.GetTodos();
            foreach (var todo in todos)
            {
                Todos.Add(todo);
            }
        }

        public async Task AddNewTodo()
        {
            var todo = new TodoItem
            {
                Due = NewTodoDue,
                Title = NewTodoTitle
            };
            var inserted = await _database.AddTodo(todo);
            if (inserted != 0)
            {
                Todos.Add(todo);
                NewTodoTitle = String.Empty;
                NewTodoDue = DateTime.Now;
                RaisePropertyChanged(nameof(NewTodoDue), nameof(NewTodoTitle));
            }
        }

        public async Task CompleteTodo(TodoItem todoitem)
        {
            var completed = await _database.UpdateTodo(todoitem);
            OnPropertyChanged(nameof(Todos));
        }

        public async Task SwipeCompleteTodoExecute(TodoItem todoitem)
        {
            todoitem.Done = true;
            var completed = await _database.UpdateTodo(todoitem);
        }

        public async Task DeleteTodo(TodoItem todoitem)
        {
            var deleted = await _database.DeleteTodo(todoitem);
            if (deleted != 0)
            {
                Todos?.Remove(todoitem);
            }
        }

        #endregion Methods
    }
}
