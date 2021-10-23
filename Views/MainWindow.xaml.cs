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
            txtTelefono1.Text = info.Telefono1;
            txtTelefono2.Text = info.Telefono2;
            txtEmail1.Text = info.Email1;
            txtEmail2.Text = info.Email2;
            txtWeb.Text = info.Web;
            txtProvincia.Text = info.Provincia;
            txtRegion.Text = info.Region;
            txtActividad.Text = info.Actividad;
            cbxTipo.Text = info.Tipo.ToString();

            Controlador.MostrarColumna();
        }

        void EditarElemento(object sender, RoutedEventArgs e)
        {
            Controlador.EditarColumna(DatosDG.SelectedIndex, txtNombre.Text, txtTelefono1.Text, txtTelefono2.Text, txtEmail1.Text, txtEmail2.Text, txtWeb.Text, txtProvincia.Text, txtRegion.Text, txtActividad.Text, cbxTipo.Text);
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
            Controlador.NuevoRegistro();
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
            e.Cancel = true;
            Controlador.FinalizarGuardados();
            if (Controlador.CambiosRealizados)
            {
                MessageBoxResult result = MessageBox.Show("Hay cambios sin guardar, ¿Desea continuar?", "Error", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Controlador.Exportar();
                }
                else if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            e.Cancel = false;
        }

    }
}
