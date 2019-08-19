using System;

namespace CSharp_EpamTest
{
    class FlueXProject
    {
        //Constructor & Destructor 
            public FlueXProject(ref string f_name, int f_id)
            {
                _id             = f_id;
                _name           = f_name;
            }

        //Methods
            public void ShowInfo()
            {
                Console.WriteLine($"{_id}.{_name}");
            }

        //Attributes
            int     _id;
            public string _name { get; set; }
    }
}
