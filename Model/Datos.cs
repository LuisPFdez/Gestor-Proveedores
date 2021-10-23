using System.Diagnostics;
using System.Reflection;
namespace App
{
    public enum Tipo
    {
        CLIENTE,
        PROVEEDOR

    }

    public class Datos
    {
        /* Getters y Setters */
        public string Nombre { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Web { get; set; }
        public string Provincia { get; set; }
        public string Region { get; set; }
        public string Actividad { get; set; }
        public Tipo Tipo { get; set; }

        public Datos(string nombre)
        {
            this.Nombre = nombre;
        }

        public Datos(string nombre, string actividad)
        {
            this.Nombre = nombre;
            this.Actividad = actividad;
        }

        public Datos(string nombre, string telefono1, string telefono2, string email1, string email2, string web, string provincia, string region, string actividad, string tipo)
        {
            this.actualizarDatos(nombre, telefono1, telefono2, email1, email2, web, provincia, region, actividad, tipo);
        }

        public void actualizarDatos(string nombre, string telefono1, string telefono2, string email1, string email2, string web, string provincia, string region, string actividad, string tipo)
        {
            tipo = tipo.ToUpper().Trim();
            if (nombre.Length == 0 || nombre == null)
            {
                throw new NombreNuloException("El nombre ha de tener algun valor");
            }


            this.Nombre = nombre;
            this.Telefono1 = telefono1;
            this.Telefono2 = telefono2;
            this.Email1 = email1;
            this.Email2 = email2;
            this.Web = web;
            this.Provincia = provincia;
            this.Region = region;
            this.Actividad = actividad;
            if (Tipo.IsDefined(typeof(Tipo), tipo))
            {
                this.Tipo = (Tipo)Tipo.Parse(typeof(Tipo), tipo);
            }
            else
            {
                throw new TipoErroneoException("El tipo introducido no existe");
            }
        }

        public void actualizarDatos(Datos elemento)
        {
            this.actualizarDatos(elemento.Nombre, elemento.Telefono1, elemento.Telefono2, elemento.Email1, elemento.Email2, elemento.Web, elemento.Provincia, elemento.Region, elemento.Actividad, elemento.Tipo.ToString());
        }

        public bool comparar(string nombre, string telefono1, string telefono2, string email1, string email2, string web, string provincia, string region, string actividad, string tipo)
        {
            string[] parametros = { nombre, telefono1, telefono2, email1, email2, web, provincia, region, actividad, tipo };
            string[] valores = { this.Nombre, this.Telefono1, this.Telefono2, this.Email1, this.Email2, this.Web, this.Provincia, this.Region, this.Actividad, this.Tipo.ToString() };

            for ( int i = 0; i < valores.Length; i++){
                if ( parametros[i].Length == 0 ) continue;
                if ( valores[i] == null || valores[i].IndexOf(parametros[i]) < 0  ) return false;
            }

            return true;
        }

    }
}