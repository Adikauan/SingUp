using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.SingUp.Domain.Aggregates
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? CPF { get; set; }

        public User()
        {
        }

        public User(string? name, DateTime birthDate, string? email, string? phone, string? cpf)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            CPF = cpf;
        }

        public User(Guid id, string? name, DateTime birthDate, string? email, string? phone, string? cpf)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Phone = phone;
            CPF = cpf;
        }

        public void SetNewId()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
