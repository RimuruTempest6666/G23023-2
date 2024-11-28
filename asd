using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();
    }
}

// Класс игрока
class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public List<string> Inventory { get; private set; }
    public string Name { get; set; }

    public Player(int startX, int startY, string name = "Player")
    {
        X = startX;
        Y = startY;
        Name = name;
        Inventory = new List<string>();
    }

    public void Move(int deltaX, int deltaY, int mapHeight, int mapWidth)
    {
        int newX = X + deltaX;
        int newY = Y + deltaY;

        if (newX >= 0 && newX < mapWidth && newY >= 0 && newY < mapHeight)
        {
            X = newX;
            Y = newY;
        }
    }

    public void AddToInventory(string item)
    {
        Inventory.Add(item);
        Console.WriteLine($"You picked up: {item}");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Your Inventory:");
        if (Inventory.Count == 0)
        {
            Console.WriteLine("  - Empty");
        }
        else
        {
            foreach (var item in Inventory)
            {
                Console.WriteLine($"  - {item}");
            }
        }
    }
}

// Класс здания
class Building
{
    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public string Type { get; }
    public List<string> Loot { get; }
    public (int X, int Y) Door { get; }

    public Building(int x, int y, int width, int height, string type)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
        Type = type;
        Loot = GenerateLoot(type);
        Door = (x + width / 2, y); // Дверь всегда в центре стены
    }

    private List<string> GenerateLoot(string type)
    {
        var loot = new List<string>();
        if (type == "Shop") loot.AddRange(new[] { "Water", "Food", "Bandages" });
        else if (type == "House") loot.AddRange(new[] { "Food", "Ammo" });
        else if (type == "Gas Station") loot.AddRange(new[] { "Gasoline", "Ammo" });
        return loot;
    }
}

// Класс карты
class Map
{
    private const int MapHeight = 25;
    private const int RoadWidth = 5;
    private const int SideWidth = (MapHeight - RoadWidth) / 2;
    private const char RoadChar = '-';
    private const char SideChar = '0';
    private const char WallChar = '*';
    private const char DoorChar = '^';

    public char[,] CurrentMap { get; private set; }
    public List<Building> Buildings { get; private set; }

    public Map()
    {
        CurrentMap = new char[MapHeight, 50]; // Текущая видимая часть карты
        Buildings = new List<Building>();
        GenerateInitialMap();
    }

    private void GenerateInitialMap()
    {
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < CurrentMap.GetLength(1); x++)
            {
                if (y < SideWidth || y >= SideWidth + RoadWidth)
                {
                    CurrentMap[y, x] = SideChar;
                }
                else
                {
                    CurrentMap[y, x] = RoadChar;
                }
            }
        }
    }

    public void GenerateNewSegment(int startX)
    {
        Random rnd = new Random();

        // Генерация зданий
        for (int side = 0; side < 2; side++) // Верхняя и нижняя обочины
        {
            int buildingHeight = rnd.Next(3, 6);
            int buildingWidth = rnd.Next(3, 6);
            int buildingY = side == 0 ? 0 : MapHeight - buildingHeight;
            int buildingX = startX + rnd.Next(0, 10);

            string[] types = { "Shop", "House", "Gas Station" };
            string type = types[rnd.Next(types.Length)];

            var building = new Building(buildingX, buildingY, buildingWidth, buildingHeight, type);
            Buildings.Add(building);

            // Отображение здания на карте
            for (int y = 0; y < buildingHeight; y++)
            {
                for (int x = 0; x < buildingWidth; x++)
                {
                    int mapY = buildingY + y;
                    int mapX = buildingX + x;

                    if (x == buildingWidth / 2 && y == 0) // Дверь
                    {
                        CurrentMap[mapY, mapX] = DoorChar;
                    }
                    else // Стены
                    {
                        CurrentMap[mapY, mapX] = WallChar;
                    }
                }
            }
        }
    }

    public void DrawMap(Player player)
    {
        for (int y = 0; y < MapHeight; y++)
        {
            for (int x = 0; x < CurrentMap.GetLength(1); x++)
            {
                if (player.X == x && player.Y == y)
                {
                    Console.Write('P'); // Игрок
                }
                else
                {
                    Console.Write(CurrentMap[y, x]);
                }
            }
            Console.WriteLine();
        }
    }
}

// Основная игра
class Game
{
    private Map map;
    private Player player;

    public void Start()
    {
        Console.WriteLine("Enter your name:");
        string playerName = Console.ReadLine() ?? "Player";

        map = new Map();
        player = new Player(10, Map.MapHeight / 2, playerName);

        while (true)
        {
            Console.Clear();
            map.DrawMap(player);
            HandleInput();
        }
    }

    private void HandleInput()
    {
        Console.WriteLine("Use Arrow keys to move. Press 'I' to view inventory.");
        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.RightArrow:
                player.Move(1, 0, 25, 50);
                break;
            case ConsoleKey.LeftArrow:
                player.Move(-1, 0, 25, 50);
                break;
            case ConsoleKey.UpArrow:
                player.Move(0, -1, 25, 50);
                break;
            case ConsoleKey.DownArrow:
                player.Move(0, 1, 25, 50);
                break;
            case ConsoleKey.I:
                player.ShowInventory();
                Console.ReadKey(true);
                break;
        }
    }
}
