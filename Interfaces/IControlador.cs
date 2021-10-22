namespace App
{
    public interface IControlador
    {
        MainWindow Ventana
        {
            get;
            set;
        }

        bool CambiosRealizados
        {
            get;
            set;
        }

        void NuevoRegistro();
        void CrearNuevoRegistro(Datos registro);
    }

}