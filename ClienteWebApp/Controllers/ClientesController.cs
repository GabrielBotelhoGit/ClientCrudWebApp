using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClienteWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        [HttpGet()]
        public string Manual()
        {
            return "Para inserir um cliente utilize uma requisicao do tipo post com o corpo seguindo o padrao: {\"Nome\":\"Gabriel\",\"Estado\":\"Rio de Janeiro\",\"CPF\":\"12530952728\"}." +
                "Para ler um cliente utilize uma requisicao do tipo get passando depois da barra('/') o cpf do cliente." +
                "Se gostaria de atualizar um cliente utilize uma requisicao do tipo put passando o cpf e no corpo da requisicao respeitando o mesmo padrao para inserir.";
        }

        [HttpGet("{cpf}")]
        public Cliente Get(long cpf)
        {
            Cliente cliente = new Cliente();
            cliente = cliente.PegarCliente(cpf);
            return cliente;
        }

        
        [HttpPost]
        public string Post([FromBody]Cliente cliente)
        {
            string retorno = string.Empty;
            Cliente clienteAux = new Cliente();
            if(cliente != null)
            {                
                if(cliente.Nome != "" && cliente.CPF != "" && cliente.Estado != "")
                {
                    clienteAux = cliente.PegarCliente(Convert.ToInt64(cliente.CPF));
                    if (clienteAux == null)
                    {
                        if (cliente.InserirCliente(cliente))
                        {
                            retorno = "Cliente Inserido com sucesso";
                        }
                        else
                        {
                            retorno = "Cliente não inserido";
                        }
                    }
                    else
                    {
                        retorno = "Cpf encontrado na base de dados";
                    }
                }
                else
                {
                    retorno = "Nenhum campo de cliente pode se encontrar em branco";
                }
            }
            return retorno;
        }

        
        [HttpPut("{cpf}")]
        public string Put(long cpf, [FromBody]Cliente cliente)
        {
            string retorno = string.Empty;
            if (cliente != null)
            {
                if (cliente.AtualizarCliente(cpf, cliente))
                {
                    retorno = "Cliente Atualizado com sucesso";
                }
                else
                {
                    retorno = "Cliente não atualizado";
                }
            }
            return retorno;
        }

        
        [HttpDelete("{cpf}")]
        public string Delete(long cpf)
        {
            string retorno = string.Empty;
            Cliente cliente = new Cliente();
            if (cliente.DeletarCliente(cpf)){
                retorno = "Cliente Deletado com sucesso";
            }
            else
            {
                retorno = "Cliente não deletado";
            }
            return retorno;
        }
    }
}
