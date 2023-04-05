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
    public partial class AgregarDireccionPage : ContentPage
    {
        

        public AgregarDireccionPage(SqlConnection connection)
        {
            InitializeComponent();
      
        }

        public AgregarDireccionPage(Direccion lista)
        {
            Lista = lista;
        }

        public AgregarDireccionPage(Cliente lista)
        {
            Lista1 = lista;
        }

        public Direccion Lista { get; }
        public Cliente Lista1 { get; }

        private void SaveAddressButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=DESKTOP-710LBMG;Initial Catalog=EmpresaX;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        // Agregar valores a la tabla
                        command.CommandText = "INSERT INTO Direccion (Calle, Numero, Ciudad, Estado, Pais, IdCliente) VALUES (@Calle, @Numero, @Ciudad, @Estado, @Pais, @IdCliente);";
                        command.Parameters.AddWithValue("@Calle", calleEntry.Text);
                        command.Parameters.AddWithValue("@Numero", numeroEntry.Text);
                        command.Parameters.AddWithValue("@Ciudad", ciudadEntry.Text);
                        command.Parameters.AddWithValue("@Estado", estadoEntry.Text);
                        command.Parameters.AddWithValue("@Pais", paisEntry.Text);
                        command.Parameters.AddWithValue("@IdCliente", idClienteEntry.Text);

                        // Ejecutar el query
                        command.ExecuteNonQuery();

                        // Mensaje en pantalla
                        DisplayAlert("Éxito", "Dirección agregada correctamente", "OK");
                        Navigation.PopAsync();
                    }
                }
            }
            catch (Exception ex)
            {
            // Mensaje de error
                DisplayAlert("Error", $"No se pudo agregar la dirección: {ex.Message}", "OK");
            }
        }

        
    }
}
