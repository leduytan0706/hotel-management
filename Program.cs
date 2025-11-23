using HotelManagement.Forms.Room;
using HotelManagement.Forms.RoomType;
using HotelManagement.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine(PasswordHelper.EncryptPassword("hotel@123"));
            Application.Run(new RoomForm());
        }
    }
}
