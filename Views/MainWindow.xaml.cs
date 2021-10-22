using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Datos> DatosGrid { get; set; }
        public Controlador Controlador { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DatosGrid = new List<Datos>();
            DatosDG.ItemsSource = DatosGrid;
        }

        void Buscar_Elemento(object sender, RoutedEventArgs e)
        {
            TextBlock tck = ((Grid)((Button)sender).Parent).Children[0] as TextBlock;
            TextBox tbx = ((Grid)((Button)sender).Parent).Children[1] as TextBox;

            Controlador.Buscar(tck.Text, tbx.Text);
        }

        void MostrarDatos(object sender, EventArgs e)
        {
            Datos info = (Datos)DatosDG.SelectedItem;

            if (info == null) return;

            txtNombre.Text = info.Nombre;
            txtTelefono.Text = info.Telefono;
            txtEmail.Text = info.Email;
            txtWeb.Text = info.Web;
            txtProvincia.Text = info.Provincia;
            txtRegion.Text = info.Region;
            txtActividad.Text = info.Actividad;
            cbxTipo.Text = info.Tipo.ToString();

            Controlador.MostrarColumna();
        }

        void EditarElemento(object sender, RoutedEventArgs e)
        {
            Controlador.EditarColumna(DatosDG.SelectedIndex, txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtWeb.Text, txtProvincia.Text, txtRegion.Text, txtActividad.Text, cbxTipo.Text);
        }

        void BorrarElemento(object sender, RoutedEventArgs e)
        {
            Controlador.BorrarColumna(DatosDG.SelectedItem as Datos);
        }

        void Eliminar_Busqueda(object sender, RoutedEventArgs e)
        {
            TextBox txb = ((Grid)((Button)sender).Parent).Children[1] as TextBox;
            TextBlock tck = ((Grid)((Button)sender).Parent).Children[0] as TextBlock;
            txb.Text = "";
            Controlador.Buscar(tck.Text, "");
        }

        void NuevoRegistro(object sender, RoutedEventArgs e)
        {
            //Controlador.NuevoRegistro();
            Controlador.Cargar();
        }

        void CerrarBoton(object sender, RoutedEventArgs e)
        {
            Controlador.EsconderColumna();
        }

        void Exportar(object sender, RoutedEventArgs e)
        {
            Controlador.Exportar();
        }

        void Importar(object sender, RoutedEventArgs e)
        {
            Controlador.Importar();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Controlador.FinalizarGuardados();
        }

    }
}
