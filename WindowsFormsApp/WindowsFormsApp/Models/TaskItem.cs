using System;

namespace WindowsFormsApp.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public string StatusText => IsCompleted ? "Completed" : "Pending";

        public TaskItem()
        {
            CreatedAt = DateTime.Now;
            DueDate = DateTime.Now.AddDays(1);
        }

        public TaskItem(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            CreatedAt = DateTime.Now;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} - {StatusText} - Due: {DueDate:yyyy-MM-dd}";
        }
    }
}