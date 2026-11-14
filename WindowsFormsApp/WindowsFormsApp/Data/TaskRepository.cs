using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp.Models;

namespace WindowsFormsApp.Data
{
    public class TaskRepository
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private int nextId = 1;

        public TaskRepository()
        {
            // Starter tasks so tab is not empty
            AddTask("Review privacy settings", "Check Facebook / Instagram privacy settings", DateTime.Now.AddDays(2));
            AddTask("Update passwords", "Change old passwords and enable 2FA on email", DateTime.Now.AddDays(3));
            AddTask("Run antivirus scan", "Run full scan and update antivirus", DateTime.Now.AddDays(1));
        }

        // --- Main methods used by Form1 ---
        public List<TaskItem> GetAllTasks() => new List<TaskItem>(tasks);
        public List<TaskItem> GetPendingTasks() => tasks.Where(t => !t.IsCompleted).ToList();
        public List<TaskItem> GetCompletedTasks() => tasks.Where(t => t.IsCompleted).ToList();
        public int GetPendingCount() => tasks.Count(t => !t.IsCompleted);
        public int GetTotalCount() => tasks.Count;

        public TaskItem AddTask(string title, string description, DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;
            var task = new TaskItem(title.Trim(), description?.Trim() ?? "", dueDate)
            {
                Id = nextId++
            };
            tasks.Add(task);
            return task;
        }

        // Overload - if your old code used Add(TaskItem)
        public TaskItem Add(TaskItem task)
        {
            if (task == null || string.IsNullOrWhiteSpace(task.Title)) return null;
            task.Id = nextId++;
            if (task.CreatedAt == default(DateTime)) task.CreatedAt = DateTime.Now;
            tasks.Add(task);
            return task;
        }

        public bool MarkComplete(int id)
        {
            var t = tasks.FirstOrDefault(x => x.Id == id);
            if (t == null) return false;
            t.IsCompleted = true;
            return true;
        }

        public bool MarkAsCompleted(int id) => MarkComplete(id);

        public bool DeleteTask(int id)
        {
            var t = tasks.FirstOrDefault(x => x.Id == id);
            if (t == null) return false;
            tasks.Remove(t);
            return true;
        }

        public bool Delete(int id) => DeleteTask(id);

        public TaskItem GetTaskById(int id) => tasks.FirstOrDefault(t => t.Id == id);
        public TaskItem GetById(int id) => GetTaskById(id);

        public List<TaskItem> GetDueToday()
        {
            return tasks.Where(t => !t.IsCompleted && t.DueDate.Date == DateTime.Today).ToList();
        }

        public List<TaskItem> GetOverdue()
        {
            return tasks.Where(t => !t.IsCompleted && t.DueDate.Date < DateTime.Today).ToList();
        }
    }
}