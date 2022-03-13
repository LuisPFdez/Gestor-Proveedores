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
        bool CrearNuevoRegistro(Datos registro);
    }

}