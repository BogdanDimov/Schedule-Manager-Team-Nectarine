﻿namespace TeamNectarineScheduleManager.Users
{
    using System;

    [Serializable]
    public abstract class Employee : User, ILoggable, IEmployee
    {
        private string firstName;
        private string lastName;

        public Employee(string username, string password, string firstName, string lastName)
            : base(username, password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public ContractType ContractType { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (!IsNameValid(value))
                {
                    throw new ArgumentException("Invalid first name! Each name of a person should be at least two symbols long and contain only letter symbols");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (!IsNameValid(value))
                {
                    throw new ArgumentException("Invalid last name! Each name of a person should be at least two symbols long and contain only letter symbols.");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\nName: {0} {1}", this.FirstName, this.LastName);
        }

        private bool IsNameValid(string name)
        {
            if (name.Length < 2)
            {
                return false;
            }

            foreach (var symbol in name)
            {
                if (!char.IsLetter(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
