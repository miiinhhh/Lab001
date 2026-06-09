using System;

namespace Bai002
{
    public class Students
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public double Grade{ get; set; }
        public Students(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Grade: {Grade}");
        }
        Dictionary<string, Students> students = new Dictionary<string, Students>();
        public void AddStudentSafe(Students student)
        {
            if (!students.ContainsKey(student.Name))
            {
                students[student.Name] = student;
            }
        }
        public void FindStudent(string name)
        {
            double max= 0;
            for(int i = 0; i < students.Count; i++)
            {
                if (students[name].Grade > max)
                {
                    max = students[name].Grade;
                }
            }
            for(int i = 0; i < students.Count; i++)
            {
                if (students[name].Grade == max)
                {
                    Console.WriteLine($"The student with the highest grade is: {students[name].Name} with grade {students[name].Grade}");
                }
            }
        }
        //Chuyển Dictionary sang List<Student>
        public List<Students> ConvertToList()
        {
            List<Students> studentList = new List<Students>();
            foreach (var student in students.Values)
            {
                studentList.Add(student);
            }
            return studentList;
        }
        //Tạo generic class Repository<TKey, TValue>
        public class Repository<TKey, TValue>
        {
            private Dictionary<TKey, TValue> _items = new Dictionary<TKey, TValue>();

            public void Add(TKey key, TValue value)
            {
                _items[key] = value;
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                return _items.TryGetValue(key, out value);
            }

            public IEnumerable<TKey> Keys => _items.Keys;
            public IEnumerable<TValue> Values => _items.Values;
        }
    };
}