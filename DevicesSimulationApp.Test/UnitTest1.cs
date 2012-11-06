using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DevicesSimulationApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tssks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                int index = i;
                var task = new Task(() =>
                {
                    Console.WriteLine("ID: " + Task.CurrentId + ", index: " + index);
                });

                tssks.Add(task);
            }

            foreach (var item in tssks)
            {
                item.Start();
            }
        }

        [TestMethod]
        public void TestDog()
        {
            Dog newDog;

        }
    }

    public class Dog
    {
        static Dog()
        {
            Console.WriteLine("static Dog");
        }

        public Dog()
        {
            Console.WriteLine("constructor Dog");
        }

        public static void New()
        {
            Console.WriteLine("static New");
        }

        public static string DOG = "5555";
    }
}
