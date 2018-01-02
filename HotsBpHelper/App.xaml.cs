﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using HotsBpHelper.Settings;

namespace HotsBpHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string AppPath;
        public static AppSetting AppSetting;

        public static bool Debug;
        public static bool NotCheckProcess;

        public static string Language = CultureInfo.CurrentCulture.Name;

        private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Pages.ErrorView _errorView;
            if (e.Exception.Message.ToLower().Contains("lang")) {
                _errorView = new Pages.ErrorView(e.Exception.Message + "\nApplication language=" + App.Language);
            }
            else _errorView = new Pages.ErrorView(e.Exception.Message);
            _errorView.ShowDialog();
            _errorView.Pause();
            //MessageBox.Show(e.Exception.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
            //Current.Shutdown();
        }
    }
}
