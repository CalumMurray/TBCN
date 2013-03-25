using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TBCN
{
    //Entity DAO class representing a Room domain business object
    public class Room
    {
        public String RoomName { get; set; } //TODO: replace with ID?
        public String Description { get; set; }
        public int MaxAge { get; set; }
        public int MinAge { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public int MinimumRatio { get; set; }
        public List<Employee> Supervisors { get; set; }
        public List<Child> Children { get; set; }

    }
}
