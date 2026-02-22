// Компонент
using System.ComponentModel.Design;

public interface IFileSystemItem
{
    void Display(int depth);
}

// Лист
public class File : IFileSystemItem
{
    private string _name;
    
    public File(string name)
    {
        _name = name;
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + _name);
    }
}

// Композиція
public class Directory : IFileSystemItem
{
    private string _name;
    private List<IFileSystemItem> _fileItems = new();

    public Directory(string name)
    {
        _name = name;
    }

    public void Add(IFileSystemItem item)
    {
        _fileItems.Add(item);
    }

    public void Remove(IFileSystemItem item)
    {
        _fileItems.Remove(item);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + _name);
        
        foreach(var item in _fileItems)
        {
            item.Display(depth + 2);
        }
    }
}

