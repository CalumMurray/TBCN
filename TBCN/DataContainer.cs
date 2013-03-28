using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TBCN
{
    class DataContainer
    {
        public List<Child> children = new List<Child>();
        public List<Parent> parents = new List<Parent>();
        public List<Employee> employees = new List<Employee>();
        public Database dbConnection;


        public DataContainer()
        {
            
            dbConnection = new Database();
        }

        public void loadItems()
        {

            children = dbConnection.selectAllChildren();
            parents = dbConnection.selectAllParents();
            employees = dbConnection.selectAllStaff();

            Child exampleChild1 = new Child();
            Parent exampleParent1 = new Parent();

            exampleParent1.FirstName = "Brian";
            exampleParent1.LastName = "Cox";
            exampleParent1.Title = "Mr";
            exampleParent1.Gender = 'm';
            exampleParent1.WorkPhone = "01234567890";
            exampleParent1.HomePhone = "07704123874";
            exampleParent1.Email = "braincox1@gmail.com";

            exampleChild1.ChildID = 12;
            exampleChild1.FirstName = "Steven";
            exampleChild1.LastName = "Cox";
            exampleChild1.Gender = 'm';
            exampleChild1.DOB = new DateTime(1992,04,15);
            exampleChild1.FirstLanguage = "English";
            exampleChild1.RoomAttending = "Panda Room";
            exampleChild1.DateApplied = new DateTime(2009,06,17);
            exampleChild1.DateLeft = new DateTime();
            exampleChild1.Attendance = new bool[5] {true,false,false,true,true};
            exampleChild1.ExtraDays = 2;
            exampleChild1.Teas = 3;
            //exampleChild1.Parents.Add(exampleParent1);

            children.Add(exampleChild1);
            parents.Add(exampleParent1);
        }
    }
}
