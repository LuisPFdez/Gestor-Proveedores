using System.Windows;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Controls;
using System;

namespace App
{
    public class Controlador : IControlador
    {

        public MainWindow Ventana { get; set; }
        private Dictionary<string, string> DatosBusqueda;
        public Controlador(MainWindow ventana)
        {
            this.Ventana = ventana;
            DatosBusqueda = new Dictionary<string, string>(){
                {"Nombre", ""},
                {"Telefono", ""},
                {"Email", ""},
                {"Web", ""},
                {"Provincia", ""},
                {"Region", ""},
                {"Actividad", ""},
                {"Tipo", ""}
            };

        }

        public void MostrarColumna()
        {
            Ventana.GridPrin.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
            Ventana.Columna_Vertical.Visibility = Visibility.Visible;
        }
        public void EsconderColumna()
        {
            Ventana.Columna_Vertical.Visibility = Visibility.Collapsed;
            Ventana.GridPrin.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Star);
        }

        public void Cargar()
        {
            this.Ventana.DatosGrid.Add(new Datos("Datos"));
            this.Ventana.DatosGrid.Add(new Datos("Algo", "Mas", "DASd", "dsad", "dasd", "dasd", "dasd", "CLIENTE"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));

            FiltrarDatos();

        }

        public void EditarColumna(int index, String nombre, String telefono, String email, String web, String provincia, String region, String actividad, String tipo)
        {
            if (index == -1)
            {
                MessageBox.Show("Es necesario selecionar antes un elemento");
                return;
            }

            Datos elemento = new Datos(nombre, telefono, email, web, provincia, region, actividad, tipo);

            (Ventana.DatosDG.Items[index] as Datos).actualizarDatos(elemento);

            Ventana.DatosDG.Items.Refresh();
        }


        public void Buscar(string clave, string valor)
        {
            DatosBusqueda[clave] = valor;
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            Ventana.DatosDG.ItemsSource = Ventana.DatosGrid.FindAll((Elemento) =>
                {
                    return Elemento.comparar(DatosBusqueda["Nombre"],
                    DatosBusqueda["Telefono"], DatosBusqueda["Email"],
                    DatosBusqueda["Web"], DatosBusqueda["Provincia"],
                    DatosBusqueda["Region"], DatosBusqueda["Actividad"],
                    DatosBusqueda["Tipo"]);
                });

        }

        public void BorrarColumna(Datos index)
        {
            if (index == null)
            {
                MessageBox.Show("Es necesario selecionar antes un elemento");
                return;
            }

            Ventana.DatosGrid.Remove(index);

            EsconderColumna();

            FiltrarDatos();
        }

        public void NuevoRegistro()
        {
            NuevoRegistro nr = new NuevoRegistro(this);
            nr.nuevoContacto();
        }

        public void CrearNuevoRegistro(Datos registro)
        {
            Ventana.DatosGrid.Add(registro);
            FiltrarDatos();
        }

        public void Exportar(){

        }

        public void Importar () {

        }

    }
}
