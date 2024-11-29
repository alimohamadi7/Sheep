using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.Framework.Application.Utilities
{
    public static class Calculate
    {

        /// <summary>  
        /// For calculating age  
        /// </summary>  
        /// <param name="Dob">Enter Date of Birth to Calculate the age</param>  
        /// <returns> years, months,days, hours...</returns>  
    public    static string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            if ((Days == 0) && (Months == 0))
            {
                return String.Format($"  {Years} سال ");
            }
            if ((Days == 0) && (Years == 0))
            {
                return String.Format($"{Months} ماه ");
            }
            if ((Months == 0) && (Years == 0))
            {
                return String.Format($" {Days} روز ");
            }
            if (Years == 0)
            {
                return String.Format($"  {Months} ماه {Days} روز ");
            }
            if (Months == 0)
            {
                return String.Format($" {Years} سال {Days}  روز ");
            }
            if (Days == 0 )
            {
                return String.Format($"  {Years} سال {Months} ماه ");
            }
  
            return String.Format($"  {Years} سال {Months} ماه {Days} روز ");
        }
        public static int CalculateAge(DateTime dateOfBirth)
        {
            TimeSpan age = DateTime.Now - dateOfBirth;
            var a = Math.Round(age.TotalDays, 0);
            return Convert.ToInt32(Math.Round(age.TotalDays, 0));
        }
    }
}
