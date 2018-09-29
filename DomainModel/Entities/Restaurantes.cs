using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace DomainModel.Entities
{
    public class Restaurantes : INotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public int idRestaurante { get; set; }      

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set => SetPropertyAndNotify(ref _nome, value, "Nome");
        }

        private string _imagem;
        public string Imagem
        {
            get
            {
                return _imagem;
            }
            set => SetPropertyAndNotify(ref _imagem, value, "Imagem");
        }

        private string _description;
        public string Descricao
        {
            get => _description;
            set => SetPropertyAndNotify(ref _description, value, "Descrição");
        }

        private string _endereco;
        public string Endereco
        {
            get => _endereco;
            set => SetPropertyAndNotify(ref _endereco, value, "Endereço");
        }

        public Restaurantes()
        {
            Nome = String.Empty;
            Imagem = String.Empty;
            Descricao = string.Empty;
            Endereco = string.Empty;
        }

        public Restaurantes(int _idRestaurante, string _nome, string _description, string _imagem, string _endereco)
        {
            idRestaurante = _idRestaurante;          
            Nome = _nome;
            Descricao = _description;
            Imagem = _imagem;
            Endereco = _endereco;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Dispara notificação apenas se o valor de uma propriedade foi alterada.
        /// </summary>
        /// <typeparam name="T">Tipo da propriedade</typeparam>
        /// <param name="variable">Referencia </param>
        /// <param name="value">Valor a ser atribuido.</param>
        /// <param name="propertyNames">Nome da propriedade para notificar os listeners.  
        /// Nome da propriedade para notificar os listeners.  
        /// Esse valor é opcional porque será preenchido pelo compilador através do CallerMemberName.</param>
        /// <returns>Retorna TRUE se o valor foi alterado.</returns>
        protected bool SetPropertyAndNotify<T>(ref T variable, T value, [CallerMemberName]string propertyName = null)
        {
            if (object.Equals(variable, value))
                return false;

            variable = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifica aos listeners que uma determinada propriedade mudou..
        /// </summary>
        /// <param name="propertyNames">Nome da propriedade para notificar os listeners.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
