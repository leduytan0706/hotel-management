using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Utils
{
    public class ItemCombo
    {
        public object Value { get; set; }  // Dùng cho ValueMember (ví dụ: ID)
        public string Display { get; set; } // Dùng cho DisplayMember (ví dụ: Tên)

        public ItemCombo(object value, string display)
        {
            Value = value;
            Display = display;
        }
    }
}
