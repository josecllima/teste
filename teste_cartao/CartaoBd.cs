using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace teste_cartao
{
    public class CartaoBd
    {

        public bool Consultar(string numeroCartao)
        {
            Cartao cartao = new Cartao();
            
            bool encontrou = false;
            //será substituido por consulta no bando de dados
            string cartaoCadastrado = "" ; // "123456789";



            string connectionString = "Data Source=DESKTOP-CRIBIRH\\SQLEXPRESS01;Initial Catalog=home;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //string connectionString = "Data Source=nomeDoServidor;Initial Catalog=home;User ID=nomeDeUsuario;Password=senhaDoUsuario";

            // Cria a conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um comando SQL
                string sql = "SELECT top 1 num_cartao FROM cartao where num_cartao = '" + numeroCartao + "'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Executa o comando e obtém um leitor de dados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Lê os dados retornados pela consulta
                        encontrou = reader.Read();
                        // Manipule os dados aqui, por exemplo, exiba-os no console
                        //cartaoCadastrado = reader["num_cartao"].ToString();
                        
                    }
                }
            }

            /*
            if (numeroCartao == cartaoCadastrado)
            {
                encontrou = true;
            }
            */



            return encontrou;

        }


        public bool Gravar(string numeroCartao)
        {
            Cartao cartao = new Cartao();

            bool encontrou = true;
            //será substituido por consulta no bando de dados
            string cartaoCadastrado = ""; // "123456789";



            string connectionString = "Data Source=DESKTOP-CRIBIRH\\SQLEXPRESS01;Initial Catalog=home;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //string connectionString = "Data Source=nomeDoServidor;Initial Catalog=home;User ID=nomeDeUsuario;Password=senhaDoUsuario";

            // Cria a conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abre a conexão
                //connection.Open();

                // Cria um comando SQL
                string sql = "insert into cartao (num_cartao)  values (@num_cartao)";

                SqlCommand cmd = new SqlCommand(sql, connection);

                cmd.Parameters.Add(new SqlParameter("@num_cartao", numeroCartao));

                // SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
               // cmd.CommandText = "INSERT Region (RegionID, RegionDescription) VALUES (5, 'NorthWestern')";
                cmd.Connection = connection;

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }

            /*
            if (numeroCartao == cartaoCadastrado)
            {
                encontrou = true;
            }
            */



            return encontrou;

        }
    }
}
