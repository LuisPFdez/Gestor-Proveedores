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
                {"Telefono", ""},
                {"Email", ""},
                {"Web", ""},
                {"Provincia", ""},
                {"Region", ""},
                {"Actividad", ""},
                {"Tipo", ""}
            };

            Tareas = new List<Task>();

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
            this.Ventana.DatosGrid.Add(new Datos("asdas", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasddasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlgdaddSDFSasdasdo", "ddasFSSDFdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "ASDASD", "dasrwerd", "weFSDSDFrew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlgdDFSDasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "DAS", "dasrwerd", "werSDFSew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlDFSgdasasdadasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdFDFSFSfsdfdsf", "fgh", "weSFDSDFrew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdasdadasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfhSFDfghfgsdfdsf", "dasrSFDFSwerd", "weSDFSDFrew", "CLIENTE"));
            this.Ventana.DatosGrid.Add(new Datos("AlgdaSsdasdo", "ddasdagfdgdfadsd", "DAdasdSd", "dsadhgffghasds", "dasdfsdSFDfdsf", "dasrSFDSFDwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("FSSAlDFSgdadaasdasdo", "ddasdasd", "DAdasdSd", "dsadasds", "dasdfsdfdsf", "dasrweSFrd", "werDFSFew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("Algdadassdasdo", "ddasahfsdagdfsd", "DAghjgjdasdSd", "dsadasds", "dasdfsdfFDSdsf", "dasrFSSwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlFSDgddaddasdasdo", "fhDASDASg", "DAdDAasdSd", "dsadasds", "dasdfsdfdsf", "dasrweSDrd", "werFSFSDFew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlgdaSDASsdasdo", "ddasdagfdgdfDASDAadsd", "DAdasdSd", "dsadhgffghasds", "dasdfsdSFDfdsf", "dasrSFDSFDwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("FSSAlDFASDDASSgdadaasdasdo", "ddasSDADAdasd", "DAdaDASAsdSd", "dsadaDASsds", "dasdfsdfdsf", "dasrweSFrd", "werDFSFew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("DASDAS", "ddasahfsADSSADdagdfsd", "DAASDAghjgjdasDAdSd", "dsadSDASasds", "dasdfsdfFDSdsf", "dasrFSSwerd", "werew", "PROVEEDOR"));
            this.Ventana.DatosGrid.Add(new Datos("AlFSDgAASDASDDAddaDASddasdasdo", "fhg", "DAdaDASsdSd", "dsASDAadasds", "dasdfsdfdsf", "dasrweSDrd", "werFSFSDFew", "PROVEEDOR"));
            FiltrarDatos();

        }

        public void EditarColumna(int index, String nombre, String telefono, String email, String web, String provincia, String region, String actividad, String tipo)
        {
            if (index == -1)
            {
                MessageBox.Show("Es necesario selecionar antes un elemento", "Error");
                return;
            }
            try
            {
                Datos elemento = new Datos(nombre, telefono, email, web, provincia, region, actividad, tipo);

                (Ventana.DatosDG.Items[index] as Datos).actualizarDatos(elemento);

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
                MessageBox.Show("Es necesario selecionar antes un elemento", "Error");
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
                ws.Cell("B1").SetValue("Telefono");
                ws.Cell("C1").SetValue("Email");
                ws.Cell("D1").SetValue("Web");
                ws.Cell("E1").SetValue("Provincia");
                ws.Cell("F1").SetValue("Region");
                ws.Cell("G1").SetValue("Actividad");
                ws.Cell("H1").SetValue("Tipo");

                int i = 2;
                foreach (Datos dato in Ventana.DatosGrid)
                {
                    ws.Cell("A" + i).SetValue(dato.Nombre);
                    ws.Cell("B" + i).SetValue(dato.Telefono);
                    ws.Cell("C" + i).SetValue(dato.Email);
                    ws.Cell("D" + i).SetValue(dato.Web);
                    ws.Cell("E" + i).SetValue(dato.Provincia);
                    ws.Cell("F" + i).SetValue(dato.Region);
                    ws.Cell("G" + i).SetValue(dato.Actividad);
                    ws.Cell("H" + i).SetValue(dato.Tipo);

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
                ImportarDatos(ventana.FileName);
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
                        siguienteFila.Cell(8).GetString()
                    ));
                    siguienteFila = siguienteFila.RowBelow();
                }

                Ventana.DatosGrid = tmpDatos;
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
