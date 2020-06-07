using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;

namespace SSLPinningClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        StartupEventHandler startupEventHandler;

        public App() : base()
        {
            startupEventHandler += startEvent;
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            Console.WriteLine("In OnStartUp Func");
        }

        private void startEvent(object sender, StartupEventArgs e)
        {
            Console.WriteLine("StartEvent Raised");
        }
    }
}
