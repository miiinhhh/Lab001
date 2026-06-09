namespace bai005
{
    public class Character
    {
        public string? Name;
        public int Level=1;
        public decimal Health=100;


        Dictionary<string, int> Inventory = new Dictionary<string, int>();
        
       String[] skill= new String[5];

       //kiểm tra item
       public bool checkItem(string itemName)
        {
            return Inventory.ContainsKey(itemName);
        }
        //thêm item
        public void addItem(string itemName, int quantity)
        {
            if (Inventory.ContainsKey(itemName))
            {
                Inventory[itemName] += quantity;
            }
            else
            {
                Inventory[itemName] = quantity;
            }
        }
        //xóa item
        public void removeItem(string itemName, int quantity)
        {
            if (Inventory.ContainsKey(itemName))
            {
                Inventory[itemName] -= quantity;
                if (Inventory[itemName] <= 0)
                {
                    Inventory.Remove(itemName);
                }
            }
        }
        //hiển thị inventory
        public void displayInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        //thêm kỹ năng
        public void addSkill(string skillName)
        {
            for (int i = 0; i < skill.Length; i++)
            {
                if(checkSkill(skillName))
                {
                    Console.WriteLine("Skill already exists.");
                    return;
                }
                else
                {
                    if (skill[i] == null)
                    {
                        skill[i] = skillName;
                        Console.WriteLine($"Added skill: {skillName}");
                        return;
                    }
                }
            }
        }
        //kiểm tra trùng kỹ năng
        public bool checkSkill(string skillName)
        {
            foreach (string s in skill)
            {
                if (s == skillName)
                {
                    return true;
                }
            }
            return false;
        }

        //lên cấp tăng level và heal
        public void levelUp()
        {
            Level++;
            Health += 25;
        }

        public void displayInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Health: {Health}");
            Console.WriteLine("Skills:");
            foreach (string s in skill)            {
                if (s != null)
                {
                    Console.WriteLine($"- {s}");
                }
            }
            Console.WriteLine("Inventory:");
            foreach (var item in Inventory)            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
        //A1. Implement IComparer<Character> (Level giảm dần)
        public class CharacterComparer : IComparer<Character>
        {
            public int Compare(Character x, Character y)
            {
                return y.Level.CompareTo(x.Level); // Sắp xếp giảm dần theo Level
            }
        }
        //A2. Deep copy List và Dictionary
        public Character DeepCopy()
        {
            Character copy = new Character();
            copy.Name = this.Name;
            copy.Level = this.Level;
            copy.Health = this.Health;

            // Deep copy Inventory
            foreach (var item in this.Inventory)
            {
                copy.Inventory[item.Key] = item.Value;
            }

            // Deep copy skill
            for (int i = 0; i < this.skill.Length; i++)
            {
                copy.skill[i] = this.skill[i];
            }

            return copy;
        }
        //A3. So sánh hai Character
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Character other = (Character)obj;
            return Name == other.Name && Level == other.Level && Health == other.Health;
        }
    }

}