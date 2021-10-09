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
        public string Telefono { get; set; }
        public string Email { get; set; }
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

        public Datos(string nombre, string telefono, string email, string web, string provincia, string region, string actividad, string tipo)
        {
            this.actualizarDatos(nombre, telefono, email, web, provincia, region, actividad, tipo);
        }

        public void actualizarDatos(string nombre, string telefono, string email, string web, string provincia, string region, string actividad, string tipo)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Email = email;
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
                throw new TipoErroneoException("El tipo introduciodo no existe");
            }
        }

        public void actualizarDatos(Datos elemento)
        {
            this.actualizarDatos(elemento.Nombre, elemento.Telefono, elemento.Email, elemento.Web, elemento.Provincia, elemento.Region, elemento.Actividad, elemento.Tipo.ToString());
        }

        public bool comparar(string nombre, string telefono, string email, string web, string provincia, string region, string actividad, string tipo)
        {
            if (nombre.Length > 0)
            {
                if (this.Nombre == null || this.Nombre.IndexOf(nombre, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }

            if (telefono.Length > 0)
            {
                if (this.Telefono == null || this.Telefono.IndexOf(telefono, System.StringComparison.CurrentCultureIgnoreCase) < 0)
                {
                    return false;
                }
            }
            if (email.Length > 0)
            {
                if (this.Email == null || this.Email.IndexOf(email, System.StringComparison.CurrentCultureIgnoreCase) < 0)
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