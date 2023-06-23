using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace teste_cartao
{
    public class usuarioBd
    {

        public bool Consultar(string usuario , string senha)
        {
            Cartao cartao = new Cartao();

            bool encontrou = false;

            //será substituido por banco de dados
            string usuarioCadastrado = "";
            string senhaCadastrada = "";


            string connectionString = "Data Source=DESKTOP-CRIBIRH\\SQLEXPRESS01;Initial Catalog=home;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //string connectionString = "Data Source=nomeDoServidor;Initial Catalog=home;User ID=nomeDeUsuario;Password=senhaDoUsuario";

            // Cria a conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abre a conexão
                connection.Open();

                // Cria um comando SQL
                string sql = "SELECT top 1 dsc_usuario, dsc_senha FROM usuario where dsc_usuario = '" + usuario + "' and dsc_senha = '" + senha + "'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Executa o comando e obtém um leitor de dados
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Lê os dados retornados pela consulta
                        encontrou = reader.Read();
                        
                            // Manipule os dados aqui, por exemplo, exiba-os no console
                         //  usuarioCadastrado = reader["dsc_usuario"].ToString();
                         //  senhaCadastrada = reader["dsc_senha"].ToString();
                        
                    }
                }
            }

            /*
            if (usuario == usuarioCadastrado  && senha == senhaCadastrada)
            {
                encontrou = true;
            }*/

            return encontrou;

        }

    }
}
