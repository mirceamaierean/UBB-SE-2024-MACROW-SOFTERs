using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MauiApp1.Model
{
    public static class Extensions
    {
        public static string ToStringWithLeadingZero(this int number)
        {
            if (number <= 9)
            {
                return "0" + number.ToString();
            }
            else
            {
                return number.ToString();
            }
        }
    }
}