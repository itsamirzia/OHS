using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OHDR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Taskbar.Show();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (db.ExecuteSQLQuery(ref db.DBConnectionToCreateDB, "CREATE DATABASE IF NOT EXISTS ohs;"))
            {
                if (db.ExecuteSQLQuery(ref db.conn, @"CREATE TABLE IF NOT EXISTS `ohs`.`register` (
                                      `Fname` varchar(200) NOT NULL DEFAULT '',
                                      `Lname` varchar(45) NOT NULL DEFAULT '',
                                      `Designation` varchar(45) NOT NULL DEFAULT '',
                                      `Company` varchar(45) NOT NULL DEFAULT '',
                                      `Mobile` varchar(45) NOT NULL DEFAULT '',
                                      `Email` varchar(45) NOT NULL DEFAULT '',
                                      `Registered_Time` varchar(45) NOT NULL DEFAULT '',
                                      `Registration_Type` varchar(45) NOT NULL DEFAULT '',
                                      `EmpCode` varchar(45) NOT NULL,
                                      `IsPrinted` varchar(50) NOT NULL,
                                      PRIMARY KEY(`Email`)
                                    ) ENGINE = InnoDB DEFAULT CHARSET = latin1; "))
                {
                    if (db.ExecuteSQLQuery(ref db.conn, @"CREATE TABLE IF NOT EXISTS `ohs`.`retry_print_status` (
                                      `event_id` varchar(8) NOT NULL,
                                      `user_id` varchar(8) NOT NULL,
                                      `print_datetime` varchar(45) NOT NULL,
                                      `print_status` varchar(5) NOT NULL,
                                      PRIMARY KEY (`event_id`,`user_id`)
                                    ) ENGINE=InnoDB DEFAULT CHARSET=latin1;"))
                    {
                        admin objA = new admin();
                        objA.ShowDialog();
                        if (objA.isclose)
                        {
                            Application.Run(new Administrator());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not able to create DB tables", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Database connection could not established. Or database is not installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
