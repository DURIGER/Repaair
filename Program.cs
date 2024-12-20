using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerRepairRequests
{
    internal static class Program
    {
        public static string ConnectionString
        {
            get
            {          
                return @"Server=DESKTOP-EH9KNDC\SQLEXPRESS;Database=RepairService;Integrated Security=True";
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AuthorizationForm());
        }
    }
}
