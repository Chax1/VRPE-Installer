﻿using System;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using JR.Utils.GUI.Forms;

namespace VRPE_Installer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static HttpClient HttpClient;
        [STAThread]


        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception = (Exception)e.ExceptionObject;
            var message = exception.Message;

            FlexibleMessageBox.Show("Exception Message: " + message + "\n\nPlease post your issue here: https://github.com/Chax1/VRPE-Installer/issues\nor contact Chax#1337 on Discord", "Error during runtime!", MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        }

        private static void UnhandledUIException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            FlexibleMessageBox.Show("Exception Message: " + ex.Message + "\n\nPlease post your issue here: https://github.com/Chax1/VRPE-Installer/issues\nor contact Chax#1337 on Discord", "Error during runtime!", MessageBoxButtons.OK,
            MessageBoxIcon.Warning);
        }

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HttpClient = new HttpClient();
            Application.ThreadException += new ThreadExceptionEventHandler(UnhandledUIException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.Run(new MainWindow());
        }
    }
}
