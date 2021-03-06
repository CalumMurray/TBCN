﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TBCN
{
    public class DataContainer
    {
        public List<Child> children = new List<Child>();
        public List<Parent> parents = new List<Parent>();
        public List<Employee> employees = new List<Employee>();
        public List<EmergencyContact> contacts = new List<EmergencyContact>();
        public Database dbConnection;


        public DataContainer()
        {
            dbConnection = new Database();
            loadItems();
        }

        public void loadItems()
        {

            children = dbConnection.selectAllChildren();
            parents = dbConnection.selectAllParents();
            employees = dbConnection.selectAllStaff();
            contacts = dbConnection.selectAllContacts();

            Child exampleChild1 = new Child();
            Parent exampleParent1 = new Parent();

            exampleParent1.FirstName = "Lewis";
            exampleParent1.LastName = "Sharp";
            exampleParent1.Title = "Mr";
            exampleParent1.Gender = 'M';
            exampleParent1.WorkPhone = "01234567890";
            exampleParent1.HomePhone = "07704123874";
            exampleParent1.Email = "lewis@gmail.com";

            exampleChild1.ChildID = 12;
            exampleChild1.FirstName = "Gemima";
            exampleChild1.LastName = "Sharp";
            exampleChild1.Gender = 'F';
            exampleChild1.DOB = new DateTime(2008, 04, 15);
            exampleChild1.FirstLanguage = "English";
            exampleChild1.RoomAttending = "Teddy's Transformers";
            exampleChild1.DateApplied = new DateTime(2009, 06, 17);
            exampleChild1.DateLeft = new DateTime();
            exampleChild1.Attendance = new bool[5] { true, false, false, true, true };
            exampleChild1.ExtraDays = 2;
            exampleChild1.Teas = 3;
            exampleChild1.ParentsIDs.Add(exampleParent1.ParentID);

            children.Add(exampleChild1);
            parents.Add(exampleParent1);
        }
    }
}
