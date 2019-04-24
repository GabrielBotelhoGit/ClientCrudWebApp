using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebApp.Controllers
{
    public class Conexao
    {
        static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "1aKdMnG1ic14xghAhNSDhIVegPEuuAf7wq8qtdwD",
            BasePath = "https://clientewebapp.firebaseio.com"
        };
        static IFirebaseClient client;
        public Conexao()
        {
            client = new FirebaseClient(config);            
        }
        public bool Inserir(Cliente cliente)
        {
            bool retorno = false;
            SetResponse resposta;
            FirebaseResponse clienteAntigo;
            clienteAntigo = client.Get("Clientes/" + cliente.CPF);
            if(clienteAntigo.Body != null)
            {
                resposta = client.Set<Cliente>("Clientes/" + cliente.CPF, cliente);
                if (resposta.Body != "")
                {
                    retorno = true;
                }
            }            
            return retorno;
        }
        public bool Atualizar(long cpf, Cliente cliente)
        {
            bool retorno = false;
            FirebaseResponse resposta;
            resposta = client.Update<Cliente>("Clientes/" + cliente.CPF, cliente);            
            if (resposta.Body != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public bool Deletar(long cpf)
        {
            bool retorno = false;
            FirebaseResponse resposta;
            resposta = client.Delete("Clientes/" + cpf);
            if (resposta.Body != null)
            {
                retorno = true;
            }
            return retorno;
        }
        public Cliente Ler(long cpf)
        {            
            Cliente cliente = new Cliente();
            FirebaseResponse resposta;
            resposta = client.Get("Clientes/" + cpf);
            cliente = resposta.ResultAs<Cliente>();

            return cliente;
        }
    }
}
