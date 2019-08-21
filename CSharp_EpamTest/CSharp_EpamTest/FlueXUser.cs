using System;
using System.Collections.Generic;

namespace CSharp_EpamTest
{
    [Serializable]
    class FlueXUser
    {
        //Constructor & Destructor
            public FlueXUser() { }
            public FlueXUser(ref string f_name, ref string f_surname, int f_id, int f_day, int f_month,
                int f_year, ref string f_patronomic)
            {
                _name       = f_name;
                _surname    = f_surname;
                _day        = f_day;
                _month      = f_month;
                _year       = f_year;
                _patronymic = f_patronomic;
                _listTask   = new List<FlueXTask>();
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

        public void DeleteTaskByID(int f_id)
        {
            for(int i = 0; i < _listTask.Count; i++)
            {
                if(_listTask[i]._id == f_id)
                {
                    _listTask.RemoveAt(i);
                    return;
                }
            }
        }

        public bool ShowList()
        {
            Console.Clear();
            if (_listTask.Count <= 0)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < _listTask.Count; i++)
                {
                    Console.Write($"\t{i + 1}.");
                    _listTask[i].ShowInfo();
                }
            }
            return true;
        }


        //Attributes
        public string _name         { get; set; }
            public string _surname      { get; set; }
            public string _patronymic   { get; set; }

            //Birthday
                int _day;
                int _month;
                int _year;

            //List
                public List<FlueXTask> _listTask { get; }
    }

    [Serializable]
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

            //Body
                while (true)
                {
                    if (0 == FlueXInput.TextInput("\nID of the deleted user", ref f_number, _listUser.Count, true, false, 1))
                        return false;
                    else if (_listUser[f_number-1]._listTask.Count > 0)
                    {
                        Console.WriteLine("ERROR: This user working on the tasks!");
                        continue;
                    }
                    _listUser.RemoveAt(f_number - 1);
                    break;
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
                Console.WriteLine("\tAdding new user");

                //Input Process
                if(0 == FlueXInput.TextInput("Name", ref f_name, true))
                    return false;

                if(0 == FlueXInput.TextInput("Surname", ref f_surname, true))
                    return false;

                if(0 == FlueXInput.TextInput("Patronymic", ref f_patronymic, true, true))
                    return false;

                //Birthday
                    while (true){ // Just for the borders
                        Console.WriteLine("\n\tBirthday");
                        //Day
                            if (0 == (f_inputValue = FlueXInput.TextInput("Day", ref f_day, 31, true, true)))
                                return false;
                            else if (f_inputValue == FLUEX_INPUTVALUE.SKIP){
                                break;
                            }
                        //Month
                            if(0 == (f_inputValue = FlueXInput.TextInput("Month", ref f_month, 12, true, true)))
                                return false;
                            else if (f_inputValue == FLUEX_INPUTVALUE.SKIP) {
                                f_day = 0;
                                break;
                            }

                        //Year
                            if (0 == (f_inputValue = FlueXInput.TextInput("Year", ref f_year, 2019, true, true, 1950)))
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
            public List<FlueXUser> _listUser { get; }
    }
}
