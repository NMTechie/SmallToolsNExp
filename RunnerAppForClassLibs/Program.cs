using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperExtensionMethods;

namespace RunnerAppForClassLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MyListItem> list = new List<MyListItem>() { 
                new MyListItem()
                {
                    Name="Nilesh",
                    Roll=1
                },
                new MyListItem()
                {
                    Name="Nilesh",
                    Roll=2
                },
                new MyListItem()
                {
                    Name="Nilesh",
                    Roll=2
                },
                new MyListItem()
                {
                    Name="Nikhil",
                    Roll=1
                },
                new MyListItem()
                {
                    Name="Archana",
                    Roll=1
                },
                new MyListItem()
                {
                    Name="Abhipsa",
                    Roll=1
                },
                new MyListItem()
                {
                    Name="Abhipsa",
                    Roll=2
                },
                new MyListItem()
                {
                    Name="Abhipsa",
                    Roll=2
                }
            };

            var distinctResult = list.DistinctBy(p => new { p.Roll, p.Name });
            foreach (MyListItem item in distinctResult)
            {
                Console.WriteLine($"The name is {item.Name} and roll is {item.Roll.ToString()}");
            }
            Console.ReadLine();
        }
    }

    public class MyListItem
    {
        public string Name { get; set; }
        public int Roll { get; set; }
    }
}
