using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBArule
{
    static public class Helper
    {

        public static List<char> GetList(List<char> list, string alphaStr)
        {
            if (list == null)
            {
                list = new List<char>();
            }

            if (!string.IsNullOrEmpty(alphaStr))
            {
                foreach( var c in alphaStr)
                {
                    list.Add(c);
                }

            }

            return list;
        }

        



    }
}
