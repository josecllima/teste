using System;
using System.Web.Helpers;
using teste_cartao;

public class Program
{
    public static void Main(string[] args)
    {
        //string cartao = "1234567890123456"; // Insira o número do cartão que deseja verificar aqui

        string opcao ;
     
        Cartao cartao = new Cartao();

        Usuario usuario = new Usuario();


   

        //string numeroCartao;


        bool validaCartao = false;
        Console.Write("Digite o usuário: ");
        usuario.usuario = Console.ReadLine();

        Console.Write("Digite a senha: ");
        usuario.senha = Console.ReadLine();



        bool validaLogin = ConsultaLogin(usuario.usuario, usuario.senha);

        if (!validaLogin)
        {

            Console.WriteLine("Usuário ou Senha inválida!");
            return;
            
        }
        else
            Console.WriteLine("Usuário Validado!");


        Console.Write("Digite 1 para cadastro e 2 para consulta: ");
        opcao = Console.ReadLine();


        if (!escolhaOpcao(opcao))
            {

            Console.WriteLine("Opção inválida!.");
            return;

        }


          Console.Write("Digite o número cartão: ");
        cartao.numeroCartao = Console.ReadLine();


        if (opcao == "2")
        {
            validaCartao = ConsultaCartao(cartao.numeroCartao);
            if (validaCartao)
            {
                Console.WriteLine("O número do cartão encontrado.");
            }
            else
            {
                Console.WriteLine("O número do cartão não encontrado .");
            }
        }

        if (opcao == "1")
        {
            //verifica se numero ja existe
            if (ConsultaCartao(cartao.numeroCartao))
            {
                Console.WriteLine("O número do cartão já existe.");
                return;
            }

            if(GravaCartao(cartao.numeroCartao))
            {
                Console.WriteLine("Cartão cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro no cadastro!");
            }

        }



       
    }

    public static bool escolhaOpcao(string opcao)
    {


        if (opcao != "1" && opcao != "2")
        {

            return false;

        }
        else
        {
            return true;
        }

    }

    public static bool ConsultaCartao(string numeroCartao)
    {

        CartaoBd cartaoBd = new CartaoBd();             

        return (cartaoBd.Consultar(numeroCartao)) ;
    }


    public static bool GravaCartao(string numeroCartao)
    {

        CartaoBd cartaoBd = new CartaoBd();

        
            return (cartaoBd.Gravar(numeroCartao));
    
    }


    public static bool ConsultaLogin(string usuario , string senha)
    {

        usuarioBd usuarioBd = new usuarioBd();



        return (usuarioBd.Consultar(usuario,senha));
    }

}