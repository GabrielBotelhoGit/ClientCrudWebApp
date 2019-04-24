using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWebApp.Controllers
{
    public class Cliente
    {        
        private string nome = string.Empty;
        private string estado = string.Empty;
        private string cPF = string.Empty;

        public string Estado { get => estado; set => estado = value; }
        public string CPF { get => cPF; set => cPF = value; }
        public string Nome { get => nome; set => nome = value; }     

        public Cliente PegarCliente(long cpf)
        {
            Cliente cliente = new Cliente();
            Conexao conexao = new Conexao();            
            return conexao.Ler(cpf);
        }
        public bool AtualizarCliente(long cpf, Cliente cliente)
        {
            Conexao conexao = new Conexao();
            return conexao.Atualizar(cpf, cliente);
        }
        public bool DeletarCliente(long cpf)
        {
            Conexao conexao = new Conexao();
            return conexao.Deletar(cpf);
        }
        public bool InserirCliente(Cliente cliente)
        {
            Conexao conexao = new Conexao();
            return conexao.Inserir(cliente);
        }
    }
}
