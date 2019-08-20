using System;

namespace CSharp_EpamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Attributes
            //FlueXSystem mainSystem = new FlueXSystem();

            //mainSystem.Start();

            FlueXUserSystem userSystem = new FlueXUserSystem();

            userSystem.AddElement();
            userSystem.AddElement();

            userSystem.ShowList();
            userSystem.DeleteElement();

            userSystem.ShowList();

            Console.ReadKey();
        }
    }
}
