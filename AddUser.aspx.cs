using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Remoting.Lifetime;

namespace Cinema
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GestionaleCinema"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                string nome = TxtNome.Text;
                string cognome = TxtCognome.Text;
                string sala = RBSala.Text;
                string tipoBiglietto = RBTipoBiglietto.Text;


                int countSalaScelta = GetCount(conn,sala);

                SqlCommand insert = new SqlCommand($"Insert Into Utenti (Nome,Cognome,Sala,TipoBiglietto) values ('{nome}','{cognome}','{sala}','{tipoBiglietto}')", conn);
                if(countSalaScelta <= 120)
                {
                    int affectedRow = insert.ExecuteNonQuery();
                    if (affectedRow != 0)
                    {
                        Response.Write("Biglietto acquistato");
                        int countNord = GetCount(conn, "SalaNord");
                        int countEst = GetCount(conn, "SalaEst");
                        int countSud = GetCount(conn, "SalaSud");
                        int countRidottiNord = GetRidotto(conn,"SalaNord");
                        int countRidottiEst = GetCount(conn, "SalaEst");
                        int countRidottiSud = GetCount(conn, "SalaSud");
                        LNord.Text = countNord.ToString();
                        LEst.Text = countEst.ToString();
                        LSud.Text = countSud.ToString();
                        LRidottiNord.Text = countRidottiNord.ToString();
                        LRidottiEst.Text = countRidottiEst.ToString();
                        LRidottiSud.Text = countRidottiSud.ToString();
                    }
                    else
                    {
                        Response.Write("Biglietto NON acquistato");
                    }
                }
                else
                {
                    Response.Write("Posti esauriti sorry");
                }
            }
            catch
            {
                Response.Write("Qualcosa e' andato storto");
            }
            finally 
            { 
                if(conn.State != ConnectionState.Closed)
                {
                    conn.Close(); 
                } 
            }
        }

        private int GetCount(SqlConnection conn, string sala)
        {
            using (SqlCommand countSala = new SqlCommand("select count(*) from Utenti where Sala=@sala", conn))
            {
                countSala.Parameters.AddWithValue("@sala", sala);
                return (int)countSala.ExecuteScalar();
            }
        }

        private int GetRidotto(SqlConnection conn, string sala)
        {
            using (SqlCommand countSala = new SqlCommand("select count(*) from Utenti where Sala=@sala and TipoBiglietto='ridotto'", conn))
            {
                countSala.Parameters.AddWithValue("@sala", sala);
                return (int)countSala.ExecuteScalar();
            }
        }
    }
}