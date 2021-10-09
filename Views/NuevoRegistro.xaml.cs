// using System;
using System.Windows;

namespace App
{

    public partial class NuevoRegistro : Window
    {

        public IControlador Controlador { get; set;}
        public NuevoRegistro(IControlador controlador)
        {
            this.Controlador = controlador;
            InitializeComponent();
        }

        void Crear(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Controlador.CrearNuevoRegistro(new Datos(txtNombre.Text, txtTelefono.Text, txtEmail.Text, txtWeb.Text, txtProvincia.Text, txtRegion.Text, txtActividad.Text, cbxTipo.Text));
            
        }

        void Cancelar(object sender, RoutedEventArgs e){
            this.Close();
        }


        public void nuevoContacto()
        {
            this.Title = "Nuevo Contacto";
            this.Show();
            

        }

    }

}