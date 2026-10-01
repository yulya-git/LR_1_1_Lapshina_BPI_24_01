using System;

namespace LR_1_1_Lapshina_BPI_24_01
{
    public class Date
    {
        private DateTime date;

        public int Day
        {
            get { return date.Day; }
        }

        public int Month
        {
            get { return date.Month; }
        }

        public int Year
        {
            get { return date.Year; }
        }

        public Date(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        public void EditData(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        public void AddOneYear()
        {
            date = date.AddYears(1);
        }

        public void SubtractTwoDays()
        {
            date = date.AddDays(-2);
        }
    }
}