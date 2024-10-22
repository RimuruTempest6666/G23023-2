namespace ConsoleApp7

{
    class Character
    {
        private string _name;
        private int _level;
        private int _health;
        private int _attack;

        public bool IsAlive = true;

        public Character(string name, int level)
        {
            _name = name;
            _level = level;
            _health = 100 + level * 5;
            _attack = 6 + level * 2;
        }
        public int Health => _health;
        public int Attack => _attack;
        public string Name => _name;
        public void TakeDamage(int attack)
        {
            _health -= attack;
            Console.WriteLine($"{_name} нанесли {attack} урона, у меня осталось {_health} hp");
            if (_health < 0)
            {
                IsAlive = false;
                Console.WriteLine($"{_name} мертв");
            }
        }
        
    }
    class Item
    {
        private string _name;
        private string _type;
        private int _level;
        private double _weight;

        public Item(string name, string type, int level, double weight)
        {
            _name = name;
            _type = type;
            _level = level;
            _weight = weight;
        }

        public double Weight => _weight;
    }

    class Inventory
    {
        private List<Item> _items;
        private double _weight;

        public Inventory()
        {
            _items = new List<Item>();
        }
        
        public List<Item> Items => _items;

        public void AddItem(Item item)
        {
            _items.Add(item);
            _weight += item.Weight;
        }

        public void RemoveItem(Item item)
        {
            _items?.Remove(item);
        }

        public double GetTotalWeight()
        {
            return _weight;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character1 = new Character("Pedik", 72);
            Character character2 = new Character("Dovacot", 99);

            while (character1.IsAlive == true & character2.IsAlive == true)
            {
                character1.TakeDamage(character2.Attack);
                if (character1.IsAlive == false)
                {
                    Console.WriteLine($"{character2.Name} аннигилоровал {character1.Name}");
                    break;
                }
                    
                character2.TakeDamage(character1.Attack);
                if (character2.IsAlive == false)
                {
                    Console.WriteLine($"{character1.Name} сделал фистинг {character2.Name}у");
                    break;
                }
            }
            Inventory inventory = new Inventory();
            
            Item excalibur = new Item("excalibur", "sword", 99, 37);
            Item hpPotion = new Item("hpPotion", "potion", 35, 0.5);

            inventory.AddItem(excalibur);
            inventory.AddItem(hpPotion);

            Console.WriteLine(inventory.Items);
        }
    }
}