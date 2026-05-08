using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepository
    {
        private readonly List<Todo> _todos = new();
        private string _filepath = "todos.txt";
        private int _nextId = 1;


        public TodoRepository()
        {
            LoadFromFile();
        }
        private void LoadFromFile()
        {
            if (!File.Exists(_filepath)) return;
            foreach (var line in File.ReadAllLines(_filepath))
            {
                var todo = Todo.FromFileString(line);
                _todos.Add(todo);
                if (todo.Id >= _nextId)
                {
                    _nextId = todo.Id++;
                }
            }
        }

        private void SaveChanges()
        {
            File.WriteAllLines(
                _filepath,
                _todos.Select(t => t.ToFileString())
            );
        }
        public Todo CreateTodo(string title)
        {
            var todo = new Todo
            {
                Id = _nextId++,
                Title = title,
                IsSuccess = false
            };
            _todos.Add(todo);
            SaveChanges();
            return todo;
        }
        public bool UpdateTodo(int id, string title)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.Title = title;
                SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteTodo(int id)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                _todos.Remove(item);
                SaveChanges();
                return true;
            }
            return false;
        }

        public List<Todo> GetTodos() => _todos;
        public bool ToggleTodo(int id)
        {
            var item = _todos.FirstOrDefault(t => t.Id == id);
            if (item != null)
            {
                item.IsSuccess = !item.IsSuccess;
                SaveChanges();
                return true;
            }
            return false;
        }
    }
}