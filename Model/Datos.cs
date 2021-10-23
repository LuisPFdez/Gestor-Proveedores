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
            if (nombre.Length > 0)
            {
                if (this.Nombre == null || this.Nombre.IndexOf(nombre, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (telefono1.Length > 0)
            {
                if (this.Telefono1 == null || this.Telefono1.IndexOf(telefono1, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (telefono2.Length > 0)
            {
                if (this.Telefono2 == null || this.Telefono2.IndexOf(telefono2, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (email1.Length > 0)
            {
                if (this.Email1 == null || this.Email1.IndexOf(email1, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (email2.Length > 0)
            {
                if (this.Email2 == null || this.Email2.IndexOf(email2, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (web.Length > 0)
            {
                if (this.Web == null || this.Web.IndexOf(web, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }


            if (provincia.Length > 0)
            {
                if (this.Provincia == null || this.Provincia.IndexOf(provincia, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }

            }

            if (region.Length > 0)
            {
                if (this.Region == null || this.Region.IndexOf(region, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (actividad.Length > 0)
            {
                if (this.Actividad == null || this.Actividad.IndexOf(actividad, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (tipo.Length > 0)
            {
                if (this.Tipo.ToString().IndexOf(tipo, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }

}