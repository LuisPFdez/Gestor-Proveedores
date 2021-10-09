namespace App
{
    public interface IControlador
    {
        MainWindow Ventana
        {
            get;
            set;
        }

        void Cargar();
        void NuevoRegistro();
        void CrearNuevoRegistro(Datos registro);
    }

}