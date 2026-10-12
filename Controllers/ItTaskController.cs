using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_findrik.Models;

namespace wt_lab4_4mvc_findrik.Controllers;
public class ItTaskController : Controller
{
    private static List<ItTask> _tasks = new List<ItTask>
    {
        new ItTask { Id = 1, Title = "Разработка API", ProjectName = "CRM System", Priority = "High", EstimatedHours = 40, IsCompleted = false },
        new ItTask { Id = 2, Title = "Дизайн интерфейса", ProjectName = "CRM System", Priority = "Medium", EstimatedHours = 20, IsCompleted = true },
        new ItTask { Id = 3, Title = "Тестирование", ProjectName = "Mobile Banking", Priority = "High", EstimatedHours = 30, IsCompleted = false },
        new ItTask { Id = 4, Title = "Настройка CI/CD", ProjectName = "Mobile Banking", Priority = "Low", EstimatedHours = 15, IsCompleted = true },
        new ItTask { Id = 5, Title = "Code Review", ProjectName = "CRM System", Priority = "Medium", EstimatedHours = 10, IsCompleted = false }
    };

    public IActionResult Index()
    {
        return View(_tasks);
    }
    public IActionResult Details(int id)
{
    var task = _tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
        return NotFound();
    }
    return View(task);
}

public IActionResult Create()
{
    return View();
}
[HttpPost]
public IActionResult Create(ItTask task)
{
    task.Id = _tasks.Count > 0 ? _tasks.Max(t => t.Id) + 1 : 1;
    _tasks.Add(task);
    return RedirectToAction("Index");
}

public IActionResult Edit(int id)
{
    var task = _tasks.FirstOrDefault(t => t.Id == id);
    if (task == null) return NotFound();
    return View(task);
}

[HttpPost]
public IActionResult Edit(ItTask task)
{
    var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
    if (existing == null) return NotFound();

    existing.Title = task.Title;
    existing.ProjectName = task.ProjectName;
    existing.Priority = task.Priority;
    existing.EstimatedHours = task.EstimatedHours;
    existing.IsCompleted = task.IsCompleted;

    return RedirectToAction("Index");
}
}