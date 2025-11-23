using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Utils
{
    public static class EnumHelper
    {
        public static List<object> ToList<T>()
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(v => new
                {
                    Value = v,
                    Display = (v as Enum).GetDescription()
                })
                .ToList<object>();
        }
    }

}
