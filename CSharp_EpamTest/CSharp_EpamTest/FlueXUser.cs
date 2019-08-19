using System;

namespace CSharp_EpamTest
{
    class FlueXUser
    {
        //Constructor & Destructor
            public FlueXUser(ref string f_name, ref string f_surname, int f_id, short f_day, short f_month,
                short f_year, ref string f_patronomic)
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
                Console.WriteLine($"{_id}.{_surname} {_name} {_patronymic}\t{_day}.{_month}.{_year}");
            }

        //Attributes
            public string _name         { get; set; }
            public string _surname      { get; set; }
            public string _patronymic   { get; set; }
            int     _id;

            //Birthday
                short _day;
                short _month;
                short _year;
    }
}
