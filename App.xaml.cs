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
