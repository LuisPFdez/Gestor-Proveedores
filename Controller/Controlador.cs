using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Win32;
using ClosedXML.Excel;

namespace App
{
    public class Controlador : IControlador
    {

        public MainWindow Ventana { get; set; }
        public bool CambiosRealizados { get; set; }

        private Dictionary<string, string> DatosBusqueda;

        private static readonly String NombreHojaCalculo = "Datos";

        private static readonly String DirectorioInicio = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Documents");

        private static readonly String FiltroArchivos = "Libro Excel|*.xlsx";


        private List<Task> Tareas;

        public Controlador(MainWindow ventana)
        {
            this.Ventana = ventana;
            DatosBusqueda = new Dictionary<string, string>(){
                {"Nombre", ""},
                {"Telefono1", ""},
                {"Telefono2", ""},
                {"Email1", ""},
                {"Email2", ""},
                {"Web", ""},
                {"Provincia", ""},
                {"Region", ""},
                {"Actividad", ""},
                {"Tipo", ""}
            };

            Tareas = new List<Task>();
            CambiosRealizados = false;
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

        public void EditarColumna(int index, String nombre, String telefono1, String telefono2, String email1, String email2, String web, String provincia, String region, String actividad, String tipo)
        {
            if (index == -1)
            {
                MessageBox.Show("Es necesario selecionar antes un elemento", "Error");
                return;
            }
            try
            {
                Datos elemento = new Datos(nombre, telefono1, telefono2, email1, email2, web, provincia, region, actividad, tipo);

                (Ventana.DatosDG.Items[index] as Datos).actualizarDatos(elemento);

                CambiosRealizados = true;
                Ventana.DatosDG.Items.Refresh();
            }
            catch (NombreNuloException)
            {
                MessageBox.Show("El campo del nombre no puede quedar vacio", "Error");
            }
        }


        public void Buscar(string clave, string valor)
        {
            DatosBusqueda[clave] = valor;
            FiltrarDatos();
        }

        private void FiltrarDatos()
        {
            Message ms = new Message("Buscando ...", "Espera");
            Ventana.DatosDG.ItemsSource = Ventana.DatosGrid.FindAll((Elemento) =>
                {
                    return Elemento.comparar(DatosBusqueda["Nombre"],
                    DatosBusqueda["Telefono1"], DatosBusqueda["Telefono2"],
                    DatosBusqueda["Email1"], DatosBusqueda["Email2"],
                    DatosBusqueda["Web"], DatosBusqueda["Provincia"],
                    DatosBusqueda["Region"], DatosBusqueda["Actividad"],
                    DatosBusqueda["Tipo"]);
                });
            ms.Close();

        }

        public void BorrarColumna(Datos index)
        {
            if (index == null)
            {
                MessageBox.Show("Es necesario selecionar antes un elemento", "Error");
                return;
            }

            CambiosRealizados = true;
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
            CambiosRealizados = true;
            FiltrarDatos();
        }

        public void FinalizarGuardados()
        {
            Task.WaitAll(Tareas.ToArray());
            Tareas = new List<Task>();
        }

        public void Exportar()
        {

            SaveFileDialog ventana = new SaveFileDialog();
            ventana.Title = "Guardar archivo";
            ventana.Filter = FiltroArchivos;
            ventana.FileName = "Documento";
            ventana.InitialDirectory = DirectorioInicio;
            bool? resultado = ventana.ShowDialog();

            if (resultado == true)
            {
                Tareas.Add(Task.Run(() =>
                {
                    ExportarDatos(ventana.FileName);
                }));
            }

        }

        private void ExportarDatos(String ruta)
        {
            try
            {

                XLWorkbook wb = new XLWorkbook();
                IXLWorksheet ws = wb.Worksheets.Add(NombreHojaCalculo);

                ws.Cell("A1").SetValue("Nombre");
                ws.Cell("B1").SetValue("Telefono 1");
                ws.Cell("C1").SetValue("Telefono 2");
                ws.Cell("D1").SetValue("Email 1");
                ws.Cell("E1").SetValue("Email 2");
                ws.Cell("F1").SetValue("Web");
                ws.Cell("G1").SetValue("Provincia");
                ws.Cell("H1").SetValue("Region");
                ws.Cell("I1").SetValue("Actividad");
                ws.Cell("J1").SetValue("Tipo");

                int i = 2;
                foreach (Datos dato in Ventana.DatosGrid)
                {
                    ws.Cell("A" + i).SetValue(dato.Nombre);
                    ws.Cell("B" + i).SetValue(dato.Telefono1);
                    ws.Cell("C" + i).SetValue(dato.Telefono2);
                    ws.Cell("D" + i).SetValue(dato.Email1);
                    ws.Cell("E" + i).SetValue(dato.Email2);
                    ws.Cell("F" + i).SetValue(dato.Web);
                    ws.Cell("G" + i).SetValue(dato.Provincia);
                    ws.Cell("H" + i).SetValue(dato.Region);
                    ws.Cell("I" + i).SetValue(dato.Actividad);
                    ws.Cell("J" + i).SetValue(dato.Tipo);

                    i++;
                }

                wb.SaveAs(ruta);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Error al sobreescibir el archivo, comprueba que otra aplicación no lo tenga abierto", "Error");
            }
        }

        public void Importar()
        {
            OpenFileDialog ventana = new OpenFileDialog();
            ventana.Title = "Abrir archivo";
            ventana.Filter = FiltroArchivos;
            ventana.InitialDirectory = DirectorioInicio;
            bool? resultado = ventana.ShowDialog();
            if (resultado == true && ventana.CheckFileExists == true)
            {
                FinalizarGuardados();
                if (CambiosRealizados)
                {
                    MessageBoxResult result = MessageBox.Show("Hay cambios sin guardar, ¿Desea continuar?", "Error", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        Exportar();
                    }
                    else if (result == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
                Message ms = new Message("Abriendo ...", "Espera");
                ImportarDatos(ventana.FileName);
                ms.Close();
            }
        }

        private void ImportarDatos(String ruta)
        {
            try
            {

                XLWorkbook wb = new XLWorkbook(ruta);
                IXLWorksheet ws = wb.Worksheet(NombreHojaCalculo);
                List<Datos> tmpDatos = new List<Datos>();

                IXLRow siguienteFila = ws.Row(2);
                while (!siguienteFila.IsEmpty())
                {
                    tmpDatos.Add(new Datos(
                        siguienteFila.Cell(1).GetString(),
                        siguienteFila.Cell(2).GetString(),
                        siguienteFila.Cell(3).GetString(),
                        siguienteFila.Cell(4).GetString(),
                        siguienteFila.Cell(5).GetString(),
                        siguienteFila.Cell(6).GetString(),
                        siguienteFila.Cell(7).GetString(),
                        siguienteFila.Cell(8).GetString(),
                        siguienteFila.Cell(9).GetString(),
                        siguienteFila.Cell(10).GetString()
                    ));
                    siguienteFila = siguienteFila.RowBelow();
                }

                Ventana.DatosGrid = tmpDatos;
                CambiosRealizados = false;
                FiltrarDatos();
            }
            catch (NombreNuloException)
            {
                MessageBox.Show("Error, una fila contiene un nombre nulo o vacio", "Error");
            }
            catch (TipoErroneoException)
            {
                MessageBox.Show("Error, el tipo ha de ser CLIENTE o PROVEEDOR", "Error");
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Error al abrir el archivo, comprueba que otra aplicación no lo tenga abierto", "Error");
            }
        }
    }
}
