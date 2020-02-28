using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcanysDemo.Core.Helpers
{
    public class DataTypeConverter
    {
        /// <summary>
        /// Converts comma separated string into a list
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <returns></returns>
        public static List<string> ConvertStringToList(string stringToConvert)
        {
            return stringToConvert.Split(',').ToList();
        }
    }
}
