using Microsoft.Data.Sqlite;
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
    public partial class EditarDireccionPage : ContentPage
    {
      
        public EditarDireccionPage(Direccion direccion)
        {
            InitializeComponent();
           
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(calleEntry.Text) || string.IsNullOrEmpty(numeroEntry.Text)
                || string.IsNullOrEmpty(ciudadEntry.Text) || string.IsNullOrEmpty(estadoEntry.Text)
                || string.IsNullOrEmpty(paisEntry.Text))
            {
                DisplayAlert("Error", "Debe completar todos los campos", "OK");
                return;
            }
             string connectionString = "Server=DESKTOP-710LBMG\\SQLEXPRESS;Database=EmpresaX;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"UPDATE Direccion SET Calle='{calleEntry.Text}', Numero='{numeroEntry.Text}', " +
                    $"Ciudad='{ciudadEntry.Text}', Estado='{estadoEntry.Text}', Pais='{paisEntry.Text}' WHERE Id={idEntry.Text};";

                int rowsUpdated = command.ExecuteNonQuery();

                if (rowsUpdated > 0)
                {
                    DisplayAlert("Éxito", "Dirección actualizada exitosamente", "OK");
                    Navigation.PopAsync();
                }
                else
                {
                    DisplayAlert("Error", "No se pudo actualizar la dirección", "OK");
                }
            }

       async private void BorrarButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Confirmación", "¿Está seguro de eliminar esta dirección?", "Sí", "No");

            if (answer)
            {
                string connectionString = "Data Source=DESKTOP-710LBMG;Initial Catalog=EmpresaX;Integrated Security=True";

                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                    connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM Direccion WHERE Id={idEntry.Text};";

                int rowsDeleted = command.ExecuteNonQuery();

                if (rowsDeleted > 0)
                {
                    await DisplayAlert("Éxito", "Dirección eliminada exitosamente", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo eliminar la dirección", "OK");
                }
            }
        }

       
    }
}


       

        
