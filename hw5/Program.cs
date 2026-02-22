// Основне дерево
var root = new Directory("Root");

var file1 = new File("file1.txt");
var file2 = new File("file2.txt");

// Розветління
var subDir = new Directory("SubFolder");
subDir.Add(new File("inner.txt"));

// Додавання гілки на дерево
root.Add(file1);
root.Add(file2);
root.Add(subDir);

root.Display(1);

