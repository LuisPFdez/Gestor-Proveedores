using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class Applicacion : Application
    {
        private MainWindow ventana;
        private Controlador controlador;
        public Applicacion()
        {

            ventana = new MainWindow();
            controlador = new Controlador( ventana );
            ventana.Controlador = controlador;
            ventana.Show();

            
        }
    }
}
