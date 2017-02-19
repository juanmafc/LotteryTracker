﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public class StringDate
    {
        private DateTime date;

        public StringDate(int day, int month, int year)
        {
            this.date = new DateTime(year, month, day);
            
        }

        public string getDate()
        {            
            return this.date.ToString("ddMMyyyy");
        }

        public void nextDay()
        {
            this.date = this.date.AddDays(1);
        }

        public bool isSunday()
        {
            return ( this.date.DayOfWeek == DayOfWeek.Sunday );
        }

        public int getDayNumber()
        {
            return this.date.Day;
        }

        public int getMonthNumber()
        {
            return this.date.Month;
        }

        public int getYearNumber()
        {
            return this.date.Year;
        }
    }

}
