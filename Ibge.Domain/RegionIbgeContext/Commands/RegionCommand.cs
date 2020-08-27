using Flunt.Notifications;
using Flunt.Validations;
using Ibge.Domain.RegionIbgeContext.Commands.Contracts;

namespace Ibge.Domain.RegionIbgeContext.Commands
{
    public class RegionCommand : Notifiable, ICommand
    {
        private RegionCommand()
        {
            
        }
        public RegionCommand(int id, string sigla, string nome)
        {
            this.id = id;
            this.sigla = sigla;
            this.nome = nome;
        }

        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }

        public void Validate()
        {
            new Contract()
                .Requires()
                .IsGreaterThan(id, 0, nameof(id), "Identidade tem que ser maior que {1}.")
                .HasMinLen(sigla, 1, nameof(sigla), "A sigla tem que ter pelo menos {1} letras.")
                .HasMinLen(nome, 3, nameof(nome), "O nome da região precisa ter pelo menos {3} letras.");

        }
    }
}