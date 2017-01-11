﻿namespace TeamNectarineScheduleManager.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using Calendars;
    using Users;

    // the team class holds a sequence of members and a team leader and has two basic 
    // functionalities -> adding a member to the team and removing a member from the team
    // TO DO: add a calendar for the team that includes the duties of all of the 
    // team members in the team

    using Contracts;

    [Serializable]

    public class Team : ISchedulable, ITeam
    {
        private ICalendar teamCalendar;
        private const string defaultTeamName = "Global team"; 

        private ICollection<IWorker> members;

        public Team(TeamLeaderWorker teamLeader)
            :this(defaultTeamName, teamLeader)
        {
            this.teamCalendar = new Calendar();
            this.members = new List<IWorker>();   
        }

        public Team(string teamName, TeamLeaderWorker teamLeader)
        {
            this.members = new List<IWorker>();
            this.TeamName = teamName;
            this.TeamLeader = teamLeader;
            this.members.Add(this.TeamLeader);
            this.teamCalendar = new Calendar();
        }

        public int MembersCount
        {
            get
            {
                return this.members.Count;
            }
        }

        public ICollection<IWorker> Members
        {
            get
            {
                return new List<IWorker>(this.members);
            }
        }

        public TeamLeaderWorker TeamLeader { get; set; }

        public string TeamName { get; private set; }

        public void AddMember(RegularWorker worker)
        {
            this.members.Add(worker);
            worker.JoinTeam(this);
        }

        public void RemoveMemeber(RegularWorker worker)
        {
            this.members.Remove(worker);
            worker.QuitTeam();
        }

        public void AddEventToCalendar(int dayOfTheMonth, int month, int year, string eventStart, string eventEnd, EventType evt)
        {
            this.teamCalendar.AddEvent(dayOfTheMonth, month, year, eventStart, eventEnd, evt);

            foreach (var member in this.members)
            {
                member.AddEventToCalendar(dayOfTheMonth, month, year, eventStart, eventEnd, evt);
            }
        }

        public void RemoveEventFromCalendar(int dayOfTheMonth, int month, int year, string eventStart, string eventEnd, EventType eventType)
        {
            this.teamCalendar.RemoveEvent(dayOfTheMonth, month, year, eventStart, eventEnd, eventType);

            foreach (var member in this.members)
            {
                member.RemoveEventFromCalendar(dayOfTheMonth, month, year, eventStart, eventEnd, eventType);
            }
        }

        public string[] GetEventForDay(int dayOfTheMonth, int month, int year)
        {
            return this.teamCalendar.ToString(dayOfTheMonth, month, year);
        }
        // Needed for DataBase
        #region NeededForDataBase.

        private List<string> NFDBRegularWorkerNames = new List<string>();
        private string NFDBTeamLeaderName;

        public List<string> NFDBGetRegularWorkerNames()
        {
            return NFDBRegularWorkerNames;
        }

        public void NFDBSetRegularWorkerNames()
        {
            NFDBRegularWorkerNames.Clear();

            foreach (var member in this.members)
            {
                NFDBRegularWorkerNames.Add(member.Username);
            }
        }

        public string NFDBGetTeamLeaderName()
        {
            return NFDBTeamLeaderName;
        }

        public void NFDBSetTeamLeaderName()
        {
            NFDBTeamLeaderName = TeamLeader.Username;
        }

        public void NFDBClearMembersAndLeader()
        {
            members.Clear();
            TeamLeader = null;
        }
        #endregion
        // Needed for DataBase END
    }
}
