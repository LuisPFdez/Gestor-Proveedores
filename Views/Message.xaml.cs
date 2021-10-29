using System.Windows;

namespace App
{
    public partial class Message: Window{
        public Message(string msg, string titulo = "Titulo", WindowStyle estilo = WindowStyle.None){
            InitializeComponent();
            Mensaje.Text = msg;
            this.Title = titulo;
            this.WindowStyle = estilo;
            this.Show();
        }
    }
} 