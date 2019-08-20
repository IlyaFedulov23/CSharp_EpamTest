using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    class FlueXUser
    {
        //Constructor & Destructor
            public FlueXUser() { }
            public FlueXUser(ref string f_name, ref string f_surname, int f_id, int f_day, int f_month,
                int f_year, ref string f_patronomic)
            {
                _name       = f_name;
                _surname    = f_surname;
                _id         = f_id;
                _day        = f_day;
                _month      = f_month;
                _year       = f_year;
                _patronymic = f_patronomic;
            }

        //Methods
            public void ShowInfo()
            {
                Console.Write($"{_surname} {_name}");
                if (_patronymic != null)
                    Console.Write($" {_patronymic}");
                if (_day != 0)
                    Console.Write($"\t{ _day}.{ _month}.{ _year}");
                    Console.Write("\n\n");
            }

        //Attributes
            public string _name         { get; set; }
            public string _surname      { get; set; }
            public string _patronymic   { get; set; }
            int     _id;

            //Birthday
                int _day;
                int _month;
                int _year;
    }

    class FlueXUserSystem
    {
        //Constructor & Destructor
            public FlueXUserSystem()
            {
                _listUser = new List<FlueXUser>();
            }

        //Methods
            public bool ShowList()
            {
                Console.Clear();
                if(_listUser.Count <= 0)
                {
                    return false;
                } else
                {
                    for(int i=0; i < _listUser.Count; i++)
                    {
                        Console.Write($"{i + 1}.");
                        _listUser[i].ShowInfo();
                    }        
                }
                return true;
            }

        public bool DeleteElement()
        {
            //Attributes
                int f_number = 0;

            if (!TextInput("User ID to delete", ref f_number))
                return false;
            if (f_number == 0)
                return false;
            try{        
                _listUser.RemoveAt(f_number-1);
            } catch {
                /* HERE IS AN ERROR CODE */
            }
            return true;
        }

        public bool AddElement() // ADD NEW ELEMENT
        {
            //Attributes
                string f_name = null;
                string f_surname = null;
                string f_patronymic = null;

            //Birthday
                int f_day = 0;
                int f_month = 0;
                int f_year = 0;

        //Method Body
            Console.Clear();
            Console.WriteLine("\tAdd new user (q - cancel).");

            //Input Process
                if (!TextInput("Name", ref f_name))
                    return false;
                if (!TextInput("Surname", ref f_surname))
                    return false;
                if (!TextInput("Patronymic", ref f_patronymic, true))
                    return false;
                Console.WriteLine("\n\tBrithday information: ");
            //Birthday
                while (true){ // Just for the borders
                    //Day
                        if (!TextInput("Day", ref f_day, true))
                            return false;
                        if (f_day == 0)
                            break;

                    //Month
                        if (!TextInput("Month", ref f_month, true))
                            return false;
                        if (f_month == 0)
                        {
                            f_day = 0;
                            break;
                        }

                    //Year
                        if (!TextInput("Year", ref f_year, true))
                            return false;
                        if (f_year == 0)
                        {
                            f_day = f_month = 0;
                            break;
                        }
                }

            //Create User object into list
                _listUser.Add(new FlueXUser(ref f_name, ref f_surname, _listUser.Count+1, f_day, f_month, f_year, ref f_patronymic));

            //Return Value
                return true;
        }

        bool TextInput(string f_messageText, ref string f_savedText, bool f_skipState = false)
        {
            while (true)
            {
                if (f_skipState)
                    Console.Write($"{f_messageText} (s - skip): ");
                else
                    Console.Write($"{f_messageText}: ");

                f_savedText = Console.ReadLine();
                
                if (f_skipState && f_savedText == "s")
                {
                    /* HERE IS AN SKIP CODE */
                    f_savedText = null;
                    break;
                } else if (f_savedText == "q")
                {
                    /* HERE IS AN ERROR CODE */
                    f_savedText = null;
                    break;
                } else if (f_savedText.Length >= 20 || f_savedText.Length <= 1)
                {
                    /* HERE IS AN ERROR CODE */
                } else
                {
                    /* SUCCESSFUL */
                    break;
                }
            }

            //Successful return value
                return true;
        }

        bool TextInput(string f_messageText, ref int f_savedNumber, bool f_skipState = false)
        {
            //Attributes
                string f_savedText = null;

            //Body
                while (true)
                {
                    if (f_skipState)
                        Console.Write($"{f_messageText} (s - skip): ");
                    else
                        Console.Write($"{f_messageText}: ");

                    f_savedText = Console.ReadLine();

                    if (f_savedText == "s")
                    {
                        /* HERE IS AN SKIP CODE */
                        f_savedNumber = 0;
                        break;
                    } else if (f_savedText == "q") {
                        /* HERE IS AN QUIT CODE */
                        f_savedNumber = 0;
                        break;
                    } else if (!Int32.TryParse(f_savedText, out f_savedNumber))
                    {
                        /* HERE IS AN ERROR CODE */
                    } else
                    {
                        /* SUCCESSFUL */
                        break;
                    }
                }

            //Successful return value
                return true;
        }

        //Attributes
            List<FlueXUser> _listUser;
    }
}
