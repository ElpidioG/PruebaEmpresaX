
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaEmpresaX
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarClientePage : ContentPage
    {
     

        public AgregarClientePage(SqlConnection connection)
        {
            InitializeComponent();


        }
        public AgregarClientePage(Cliente lista)
        {
           Lista = lista;
        }
        public Cliente Lista { get; }
        private void AgregarButton_Clicked(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-710LBMG;Initial Catalog=EmpresaX;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                string nombre = nombreEntry.Text;
                string apellido = apellidoEntry.Text;
                string telefono = telefonoEntry.Text;
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                {
                    DisplayAlert("Error", "Debe llenar todos los campos.", "OK");
                    return;
                }

                string query = $"INSERT INTO Clientes (Nombre, Apellido, Telefono) VALUES ('{nombre}', '{apellido}', '{telefono}')";

                try
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            DisplayAlert("Éxito", "El cliente ha sido agregado correctamente.", "OK");
                            Navigation.PopAsync();
                        }
                        else
                        {
                            DisplayAlert("Error", "No se pudo agregar el cliente.", "OK");
                        }
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", $"Ocurrió un error al agregar el cliente: {ex.Message}", "OK");
                }
            }
        }
    }
}