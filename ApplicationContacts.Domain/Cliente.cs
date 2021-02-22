using ApplicationContacts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ApplicationContacts.Domain
{
    public class Cliente
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }

        private HashSet<ClienteXTelefone> _clienteXtelefones;
        public IEnumerable<ClienteXTelefone> ClienteXTelefones => _clienteXtelefones?.ToList();

        private HashSet<ClienteXEndereco> _clienteXendereco;
        public IEnumerable<ClienteXEndereco> ClienteXEnderecos => _clienteXendereco?.ToList();

        private HashSet<RedeSocial> _redesSociais;
        public IEnumerable<RedeSocial> RedesSociais => _redesSociais?.ToList();

        private Cliente()
        {
            _clienteXendereco = new HashSet<ClienteXEndereco>();
            _clienteXtelefones = new HashSet<ClienteXTelefone>();
            _redesSociais = new HashSet<RedeSocial>();
        }

        public Cliente(ClienteCadastroDTO clienteDTO)
        {
            Nome = clienteDTO.Nome;
            RG = clienteDTO.RG;
            CPF = clienteDTO.CPF;
            DataNascimento = clienteDTO.DataNascimento;
            _redesSociais = new HashSet<RedeSocial>();
            for (int i = 1; i < 5; i++)
            {
                var redeSocial = new RedeSocial(this, i);
                _redesSociais.Add(redeSocial);
            }
        }

        public Cliente(ClienteDTO clienteDTO)
        {
            Nome = clienteDTO.Nome;
            RG = clienteDTO.RG;
            CPF = clienteDTO.CPF;
            DataNascimento = clienteDTO.DataNascimento;
            _redesSociais = new HashSet<RedeSocial>();
            _clienteXendereco = new HashSet<ClienteXEndereco>();
            _clienteXtelefones = new HashSet<ClienteXTelefone>();
            for (int i = 1; i < 5; i++)
            {
                var redeSocial = new RedeSocial(this, i);
                _redesSociais.Add(redeSocial);
            }
        }

        public void CadastrarTelefone(Telefone telefone, TipoClienteXTelefone tipo)
        {
            var clienteXtelefone = new ClienteXTelefone(this, telefone, tipo);
            _clienteXtelefones.Add(clienteXtelefone);
        }

        public void CadastrarEndereco(Telefone telefone, TipoClienteXTelefone tipo)
        {
            var clienteXtelefone = new ClienteXTelefone(this, telefone, tipo);
            _clienteXtelefones.Add(clienteXtelefone);
        }

        public void AtualizarTelefones(List<Telefone> telefones, List<TipoClienteXTelefone> tipos)
        {
            for (int i = 0; i < telefones.Count; i++)
            {
                var clienteXtelefone = ClienteXTelefones.FirstOrDefault(f => f.Telefone.Id == telefones[i].Id);
                if (clienteXtelefone != null)
                {
                    clienteXtelefone.Atualizar(tipos[i]);
                }
                else
                {
                    clienteXtelefone = new ClienteXTelefone(this, telefones[i], tipos[i]);
                    _clienteXtelefones.Add(clienteXtelefone);
                }
            }
            var clienteXtelefonesParaRemocao = _clienteXtelefones
                .Where(w => !telefones.Select(s => s.Id).Contains(w.Telefone.Id)).ToList();
            foreach (var cxt in clienteXtelefonesParaRemocao) _clienteXtelefones.Remove(cxt);
            //return clienteXtelefonesParaRemocao;
        }

        public void AtualizarEnderecos(List<Endereco> enderecos, List<TipoClienteXEndereco> tipos)
        {
            for (int i = 0; i < enderecos.Count; i++)
            {
                var clienteXendereco = ClienteXEnderecos.FirstOrDefault(f => f.Endereco.Id == enderecos[i].Id);
                if (clienteXendereco != null)
                {
                    clienteXendereco.Atualizar(tipos[i]);
                }
                else
                {
                    clienteXendereco = new ClienteXEndereco(this, enderecos[i], tipos[i]);
                    _clienteXendereco.Add(clienteXendereco);
                }
            }
            var clienteXenderecosParaRemocao = _clienteXendereco
                .Where(w => !enderecos.Select(s => s.Id).Contains(w.Endereco.Id)).ToList();
            foreach (var cxe in clienteXenderecosParaRemocao) _clienteXendereco.Remove(cxe);
            //return clienteXenderecosParaRemocao;
        }

        public void AtualizarRedesSociais(List<RedeSocialDTO> redesSociaisDTO)
        {
            foreach (var redeSocialDTO in redesSociaisDTO)
            {
                var redeSocial = RedesSociais.FirstOrDefault(f => f.TipoRedeSocialId == redeSocialDTO.TipoRedeSocial.Id);
                redeSocial.Atualizar(redeSocialDTO);
            }
        }

        private bool ValidarCPF(string cpf)
        {
            Regex regex = new Regex(@"^\d$");
            var cpfNumerico = regex.Match(cpf).Value;
            if (cpfNumerico.Length != 11)
                return false;

            for (int i = 0; i < 2; i++)
            {
                var soma = 0;
                for (int j = 0; j < (9 + i); j++)
                {
                    if (i == 0) soma += cpfNumerico[j] * (j + 1);
                    else soma += cpfNumerico[j] * j;
                    var digitoValidador = soma % 11;
                    digitoValidador = digitoValidador == 10 ? 0 : digitoValidador;
                    if (cpfNumerico[9 + i] != digitoValidador) return false;
                }
            }
            return true;
        }
    }
}
