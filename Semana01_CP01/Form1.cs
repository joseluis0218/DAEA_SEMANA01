using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace Semana01_CP01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);

        public void ListaClientes()
        {

            string client = txtQuery.Text;
            using (SqlDataAdapter Df = new SqlDataAdapter("Usp_ListadoClientes_Neptuno", cn))
            {
                Df.SelectCommand.CommandType = CommandType.StoredProcedure;
                Df.SelectCommand.Parameters.AddWithValue("@Nombre", client);
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Clientes");
                    dgClientes.DataSource = Da.Tables["Clientes"];
                    lblCantidad.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //ListaClientes();
        }

        private void TxtQuery_TextChanged(object sender, EventArgs e)
        {
            ListaClientes();
        }
    }
}
