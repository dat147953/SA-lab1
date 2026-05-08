using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoUI
    {
        private readonly TodoService _service = new();
        public void ShowTodos()
        {
            var todos = _service.GetAll();
            Console.WriteLine("Todo List:");
            foreach (var todo in todos)
            {
                Console.WriteLine(todo.ToString());
            }
            if (todos.Count == 0)
            {
                Console.WriteLine("No todos found.");
            }
        }
        public void ShowMenu()
        {
            Console.WriteLine("\n Menu:");
            Console.WriteLine("1. Add Todo");
            Console.WriteLine("2. Finish Todo");
            Console.WriteLine("3. Update Todo");
            Console.WriteLine("4. Delete Todo");
            Console.WriteLine("5. Exit");
        }

        private void AddTodo()
        {
            Console.Write("Enter todo title:");
            var input = Console.ReadLine();
            _service.AddTodo(input);
        }
        private void DeleteTodo()
        {
            Console.WriteLine("Nhap id cong viec muon xoa:");
            int id = int.Parse(Console.ReadLine());
            _service.DeleteTodo(id);
        }
        private void ToggleTodo()
        {
            Console.WriteLine("Nhap id cong viec danh dau:");
            int id = int.Parse(Console.ReadLine());
            _service.ToggleTodo(id);
        }
        private void UpdateTodo()
        {
            Console.WriteLine("Nhap id cong viec danh dau:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nhap noi dung moi:");
            string title = Console.ReadLine();
            _service.UpdateTodo(id, title);
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ShowTodos();
                ShowMenu();
                Console.Write("chon:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddTodo();
                        break;
                    case "2":
                        ToggleTodo();
                        break;
                    case "3":
                        UpdateTodo();
                        break;
                    case "4":
                        DeleteTodo();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("lua chon khong hop le!");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }
    }
}
