using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Data.SqlClient;

namespace PruebaEmpresaX
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           
            InitializeComponent();

            // Abrimos la conexión a la base de datos

            string connectionString = "Server=DESKTOP-710LBMG\\SQLEXPRESS;Database=EmpresaX;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);
   
            using (connection)
            {
                connection.Open();


      
                // Mostramos la lista de clientes
                RefreshClientList();
            }

            // Mostramos la lista de clientes
            void RefreshClientList()
            {
                // Consultamos la lista de clientes
                string query = "SELECT * FROM Clientes";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();


                List<Cliente> clientes = new List<Cliente>();

                // Creamos una lista de objetos Cliente con los datos de la base de datos
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["Id"]);
                    string nombre = reader["Nombre"].ToString();
                    string apellido = reader["Apellido"].ToString();
                    string telefono = reader["Telefono"].ToString();

                    clientes.Add(new Cliente { Id = id, Nombre = nombre, Apellido = apellido, Telefono = telefono });
                }

                // Mostramos la lista de clientes en el ListView
                clientListView.ItemsSource = clientes;
            }

            // Mostramos la lista de direcciones del cliente seleccionado
            void RefreshAddressList(int clienteId)
            {
                // Consultamos la lista de direcciones del cliente seleccionado
                SqlCommand command = new SqlCommand("SELECT * FROM direcciones WHERE clienteId = {clienteId}", connection);

                SqlDataReader reader = command.ExecuteReader();

 

                List<Direccion> direcciones = new List<Direccion>();

                // Creamos una lista de objetos Direccion con los datos de la base de datos
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"]);
                    int idCliente = Convert.ToInt32(reader["clienteId"]);
                    string calle = reader["calle"].ToString();
                    string numero = reader["numero"].ToString();
                    string ciudad = reader["ciudad"].ToString();
                    string estado = reader["estado"].ToString();
                    string pais = reader["pais"].ToString();
                    direcciones.Add(new Direccion { Id = id, idCliente = idCliente, Calle = calle, Numero = numero, Ciudad = ciudad, Estado = estado, Pais = pais });
                }

                // Mostramos la lista de direcciones en el CollectionView
                addressCollectionView.ItemsSource = direcciones;
            }

            // Agregamos un nuevo cliente
             void addClientButton_Clicked(object sender, EventArgs e)
            {
                Navigation.PushAsync(new AgregarClientePage(connection));
            }

     
                // Abrimos una nueva página para ingresar los datos del nuevo cliente
            
            


            // Método asociado al botón de agregar dirección
            async void addAddressButton_Clicked(object sender, EventArgs e)
            {
                if (clientListView.SelectedItem != null)
                {
                    var lista = clientListView.SelectedItem as Cliente;
                    await Navigation.PushAsync(new AgregarDireccionPage(lista));
                }
                else
                {
                    await DisplayAlert("Error", "Debe seleccionar un cliente primero", "OK");
                }
            }

            // Método asociado al botón de editar cliente
            async void EditClientButton_Clicked(object sender, EventArgs e)
            {
                if (clientListView.SelectedItem != null)
                {
                    var lista = clientListView.SelectedItem as Cliente;
                    await Navigation.PushAsync(new EditarClientePage(lista));
                }
                else
                {
                    await DisplayAlert("Error", "Debe seleccionar un cliente primero", "OK");
                }
            }

            // Método asociado al botón de editar dirección
            async void EditAddressButton_Clicked(object sender, EventArgs e)
            {
                if (addressCollectionView.SelectedItem != null)
                {
                    var listaDi = addressCollectionView.SelectedItem as Direccion;
                    await Navigation.PushAsync(new EditarDireccionPage(listaDi));

                }
                else
                {
                    await DisplayAlert("Error", "Debe seleccionar una dirección primero", "OK");
                }
            }

        }

        private void clientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }


        private void addAddressButton_Clicked(object sender, EventArgs e)
        {

        }

        private void EditClientButton_Clicked(object sender, EventArgs e)
        {

        }

        private void EditAddressButton_Clicked(object sender, EventArgs e)
        {

        }

        private void addClientButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}
