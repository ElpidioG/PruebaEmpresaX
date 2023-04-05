using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PruebaEmpresaX
{
    public partial class EditarClientePage : ContentPage
    {
     

        public EditarClientePage()
        {
            InitializeComponent();
        }

        public EditarClientePage(Cliente lista)
        {
            Lista = lista;
        }

        public Cliente Lista { get; }

        private void GuardarCambios_Clicked_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-710LBMG;Initial Catalog=EmpresaX;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    var command = connection.CreateCommand();
                    command.Transaction = transaction;

                    command.CommandText = "UPDATE Clientes SET Nombre = @nombre, Apellido = @apellido, Telefono = @telefono WHERE Id = @id";
                    command.Parameters.AddWithValue("@nombre", nombreEntry.Text);
                    command.Parameters.AddWithValue("@apellido", apellidoEntry.Text);
                    command.Parameters.AddWithValue("@telefono", telefonoEntry.Text);
                    command.Parameters.AddWithValue("@id", idEntry.Text);

                    var rowsUpdated = command.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                    {
                        transaction.Commit();
                        DisplayAlert("Éxito", "Los cambios han sido guardados correctamente.", "Aceptar");
                    }
                    else
                    {
                        transaction.Rollback();
                        DisplayAlert("Error", "No se han podido guardar los cambios. Intente de nuevo.", "Aceptar");
                    }
                }
            }
        }

      
    }
}
