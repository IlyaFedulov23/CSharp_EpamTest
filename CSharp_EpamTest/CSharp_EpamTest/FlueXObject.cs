using System;
using System.Collections.Generic;

// Version 1.0 - Ilya.F

namespace CSharp_EpamTest
{
    [Serializable]
    class FlueXObject
    {
        // Class Constructor
            public FlueXObject() {
                _listTask = new List<FlueXTask>();
            } 

        // Class Methods
            public bool ShowList()
            {
                Console.Clear();
                if (_listTask.Count <= 0)
                {
                    return false;
                }
                else
                {
                    int f_counter = 0;
                    foreach (FlueXTask ft_task in _listTask)
                    {
                        Console.Write($"\t{f_counter + 1}.");
                        ft_task.ShowInfo();
                        f_counter++;
                    }
                }
                return true;
            }

            public void DeleteTaskByID(int f_id)
            {
                int f_counter = 0;
                foreach (FlueXTask ft_task in _listTask)
                {
                    if (ft_task._id == f_id)
                    {
                        _listTask.RemoveAt(f_counter);
                        return;
                    }
                    f_counter++;
                }
            }

        // Class Variables
            // List
                public List<FlueXTask> _listTask { get; }
    }

    interface FlueXObjectSystem
    {
        bool ShowList();
        bool AddElement();
        bool DeleteElement();
    }
}
