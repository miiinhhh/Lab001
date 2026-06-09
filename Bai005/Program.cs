namespace Bai005;
using bai005;

class Program
{
    static void Main(string[] args)
    {
        Character Knight= new Character();
        Knight.Name="Saber";
        Knight.addItem("Kiem lua", 1);
        Knight.addItem("Thuoc hoi phuc", 5);
        Knight.addSkill("Chem ngang");
        Knight.addSkill("Chem doc");
        Knight.displayInfo();
        Knight.levelUp();
        Knight.displayInfo();
    }
}
