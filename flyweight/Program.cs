using System;
using System.Collections.Generic;

namespace FlyweightPatternExample
{
    // ১. Flyweight Class (এখানে শেয়ার করা বা Intrinsic ডাটা থাকে)
    public class TreeType
    {
        private string _name;
        private string _color;
        private string _texture;

        public TreeType(string name, string color, string texture)
        {
            _name = name;
            _color = color;
            _texture = texture;
        }

        // এক্সট্রিনসিক স্টেট (x, y) মেথডের প্যারামিটার হিসেবে পাস করা হচ্ছে
        public void Render(int x, int y)
        {
            Console.WriteLine($"Rendering {_color} {_name} at ({x}, {y})");
        }
    }

    // ২. Flyweight Factory (এটি অবজেক্ট ক্যাশ করে এবং বারবার একই অবজেক্ট তৈরি করা আটকায়)
    public static class TreeFactory
    {
        private static Dictionary<string, TreeType> _treeTypes = new Dictionary<string, TreeType>();

        public static TreeType GetTreeType(string name, string color, string texture)
        {
            string key = $"{name}_{color}_{texture}";

            if (!_treeTypes.ContainsKey(key))
            {
                Console.WriteLine($"[-] Creating NEW TreeType for: {name} ({color})");
                _treeTypes[key] = new TreeType(name, color, texture);
            }
            
            return _treeTypes[key];
        }

        public static int GetTotalCachedTypes() => _treeTypes.Count;
    }

    // ৩. Context Class (এখানে প্রতিটি গাছের নিজস্ব Extrinsic ডাটা এবং Flyweight-এর রেফারেন্স থাকে)
    public class Tree
    {
        private int _x; // Extrinsic
        private int _y; // Extrinsic
        private TreeType _type; // Reference to Intrinsic Flyweight

        public Tree(int x, int y, TreeType type)
        {
            _x = x;
            _y = y;
            _type = type;
        }

        public void Draw()
        {
            _type.Render(_x, _y);
        }
    }

    // ৪. Client Code
    class Program
    {
        static void Main(string[] args)
        {
            List<Tree> forest = new List<Tree>();

            // ১ নম্বর গাছ তৈরি (নতুন TreeType তৈরি হবে)
            TreeType oakType = TreeFactory.GetTreeType("Oak", "Green", "Rough");
            forest.Add(new Tree(10, 20, oakType));

            // ২ নম্বর গাছ তৈরি (নতুন কোনো TreeType তৈরি হবে না, আগেরটাই ব্যবহার হবে)
            TreeType sharedOakType = TreeFactory.GetTreeType("Oak", "Green", "Rough");
            forest.Add(new Tree(50, 60, sharedOakType));

            // ৩ নম্বর গাছ তৈরি (আলাদা টাইপ, তাই নতুন TreeType তৈরি হবে)
            TreeType pineType = TreeFactory.GetTreeType("Pine", "Dark Green", "Smooth");
            forest.Add(new Tree(100, 150, pineType));

            Console.WriteLine("\n--- Rendering Forest ---");
            foreach (var tree in forest)
            {
                tree.Draw();
            }

            Console.WriteLine($"\nTotal Tree instances created in forest: {forest.Count}");
            Console.WriteLine($"Total TreeType objects stored in memory: {TreeFactory.GetTotalCachedTypes()}");
        }
    }
}
// output:
// [-] Creating NEW TreeType for: Oak (Green)
// [-] Creating NEW TreeType for: Pine (Dark Green)
// 
// --- Rendering Forest ---
// Rendering Green Oak at (10, 20)
// Rendering Green Oak at (50, 60)
// Rendering Dark Green Pine at (100, 150)
// 
// Total Tree instances created in forest: 3
// Total TreeType objects stored in memory: 2
