﻿namespace TeamNectarineScheduleManager.Users
{
    using System;

    public class Administrator : Employee
    {
        public Administrator(string username, string password, string firstName, string lastName) 
            : base(username, password, firstName, lastName)
        {
        }
        
        // methods
        public void ShowCompanyCalendar(Day day)
        {
            throw new NotImplementedException();
        }

        //public void ShowCompanyCalendar(Week week)
        //{
        //    throw new NotImplementedException();
        //}
    }
}