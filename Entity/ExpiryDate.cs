using System;

namespace c_sharp_delegate.Entity
{
    internal class ExpiryDate
    {
        public int Month { get; private set; }
        public int Year { get; private set; }

        public ExpiryDate(int month, int year)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentException("Month must be between 1 and 12.");
            }

            if (year < DateTime.Now.Year || (year == DateTime.Now.Year && month < DateTime.Now.Month))
            {
                throw new ArgumentException("Expiry date must be in the future.");
            }

            Month = month;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Month:D2}/{Year}";
        }
    }
}

