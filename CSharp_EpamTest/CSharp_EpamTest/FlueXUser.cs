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
                FLUEX_INPUTVALUE _inputValue = FLUEX_INPUTVALUE.SKIP;

            //Body
                _inputValue = FlueXInput.TextInput("User delete ID", ref f_number, _listUser.Count, true, false, 1);
                if (_inputValue == FLUEX_INPUTVALUE.CANCEL)
                    return false;
                try{        
                    _listUser.RemoveAt(f_number-1);
                } catch {
                    /* HERE IS AN ERROR CODE */
                }

            //Successful return value
             return true;
        }

        public bool AddElement() // ADD NEW ELEMENT
        {
            //Attributes
                FLUEX_INPUTVALUE f_inputValue = FLUEX_INPUTVALUE.CANCEL;
                string f_name = null;
                string f_surname = null;
                string f_patronymic = null;

            //Birthday
                int f_day = 0;
                int f_month = 0;
                int f_year = 0;

        //Method Body
            Console.Clear();
            Console.WriteLine("\tAdditing new user.");

            //Input Process
            f_inputValue = FlueXInput.TextInput("Name", ref f_name, true);
            if(f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                return false;

            f_inputValue = FlueXInput.TextInput("Surname", ref f_surname, true);
            if (f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                return false;

            f_inputValue = FlueXInput.TextInput("Patronymic", ref f_patronymic, true, true);
            if (f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                return false;

            //Birthday
                while (true){ // Just for the borders
                    Console.WriteLine("\n\tBirthday");
                    //Day
                        f_inputValue = FlueXInput.TextInput("Day: ", ref f_day, 31, true, true);
                        if (f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                            return false;
                        else if (f_inputValue == FLUEX_INPUTVALUE.SKIP){
                            break;
                        }
                    //Month
                        f_inputValue = FlueXInput.TextInput("Month: ", ref f_month, 12, true, true);
                        if (f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                            return false;
                        else if (f_inputValue == FLUEX_INPUTVALUE.SKIP) {
                            f_day = 0;
                            break;
                        }

                    //Year
                        f_inputValue = FlueXInput.TextInput("Year: ", ref f_year, 2019, true, true, 1950);
                        if (f_inputValue == FLUEX_INPUTVALUE.CANCEL)
                            return false;
                        else if (f_inputValue == FLUEX_INPUTVALUE.SKIP) {
                            f_month = f_day = 0;
                            break;
                        }
                    break;
                }

            //Create User object into list
                _listUser.Add(new FlueXUser(ref f_name, ref f_surname, _listUser.Count+1, f_day, f_month, f_year, ref f_patronymic));

            //Return Value
                return true;
        }

        //Attributes
            List<FlueXUser> _listUser;
    }
}
