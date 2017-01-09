﻿namespace TeamNectarineScheduleManager.Calendars
{
    using System;
    using System.Text;

    public class DailyEvents
    {
        protected  EventType _event;
        protected DateTime _eventStart;
        protected DateTime _eventEnd;

        public DailyEvents()
        {
        }
        protected internal DailyEvents(int dayOfTheMonth, int month, int year, string eventStart = "09:00", string eventEnd = "17:00", EventType currentEvent = EventType.OffDuty)
        {
            this._event = currentEvent;
            if (int.Parse(eventStart.Substring(0, 2)) < 0 | int.Parse(eventStart.Substring(0, 2)) > 23 |
                int.Parse(eventStart.Substring(3, 2)) < 0 | int.Parse(eventStart.Substring(3, 2)) > 59 |
                int.Parse(eventEnd.Substring(0, 2)) < 0 | int.Parse(eventEnd.Substring(0, 2)) > 23 |
                int.Parse(eventEnd.Substring(3, 2)) < 0 | int.Parse(eventEnd.Substring(3, 2)) > 59)
            {
                throw new ArgumentOutOfRangeException("Start and end time of an Event must be provided in HH:MM format.");
            }
            if (dayOfTheMonth < 1 | dayOfTheMonth > 31)
            {
                throw new ArgumentOutOfRangeException("Day of the month for an event must be an integer number ranging from 1 to 31 inclusive");
            }
            if (month < 1 | month > 12)
            {
                throw new ArgumentOutOfRangeException("Month argument of an event must be integer number ranging from 1 to 12 inclusive");
            }
            if (year < 2016 | year > 2026)
            {
                throw new ArgumentOutOfRangeException("Year argument of an event must be integer number in the range of 2016 to 2026 inclusive");
            }
        }

        public override string ToString()

        {
            StringBuilder result = new StringBuilder(32);
            result.Append(this._eventStart.ToString("HH:mm") + " - " + this._eventEnd.ToString("HH:mm"));
            result.Append(" ");
            result.Append(this._event);
            return result.ToString();
        }
    }
}
//.name връща типа на евента, начало и край като стринг In traning 10:00 - 14:00