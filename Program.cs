using System;

// Клас, що представляє завдання для редакції
class Task
{
    public string Description { get; set; }
    public TaskType Type { get; set; }

    public Task(string description, TaskType type)
    {
        Description = description;
        Type = type;
    }
}

// Перелік типів завдань
enum TaskType
{
    Edit,
    Layout,
    Design
}

// Абстрактний обробник
abstract class Editor
{
    protected Editor _nextEditor;

    public void SetNextEditor(Editor nextEditor)
    {
        _nextEditor = nextEditor;
    }

    public abstract void HandleTask(Task task);
}

// Конкретний обробник для редактора
class EditingEditor : Editor
{
    public override void HandleTask(Task task)
    {
        if (task.Type == TaskType.Edit)
        {
            Console.WriteLine($"Редактор зайнятий завданням: {task.Description}");
        }
        else if (_nextEditor != null)
        {
            _nextEditor.HandleTask(task);
        }
    }
}

// Конкретний обробник для макетувальника
class LayoutEditor : Editor
{
    public override void HandleTask(Task task)
    {
        if (task.Type == TaskType.Layout)
        {
            Console.WriteLine($"Макетувальник зайнятий завданням: {task.Description}");
        }
        else if (_nextEditor != null)
        {
            _nextEditor.HandleTask(task);
        }
    }
}

// Конкретний обробник для дизайнера
class DesignEditor : Editor
{
    public override void HandleTask(Task task)
    {
        if (task.Type == TaskType.Design)
        {
            Console.WriteLine($"Дизайнер зайнятий завданням: {task.Description}");
        }
        else if (_nextEditor != null)
        {
            _nextEditor.HandleTask(task);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення ланцюжка обробників
        Editor editingEditor = new EditingEditor();
        Editor layoutEditor = new LayoutEditor();
        Editor designEditor = new DesignEditor();

        // Налаштування послідовності ланцюжка
        editingEditor.SetNextEditor(layoutEditor);
        layoutEditor.SetNextEditor(designEditor);

        // Створення завдань для редакції
        Task task1 = new Task("Внести правки", TaskType.Edit);
        Task task2 = new Task("Створити макет нової сторінки журнала", TaskType.Layout);
        Task task3 = new Task("Розробити дизайн", TaskType.Design);

        // Обробка завдань
        editingEditor.HandleTask(task1);
        editingEditor.HandleTask(task2);
        editingEditor.HandleTask(task3);
    }
}