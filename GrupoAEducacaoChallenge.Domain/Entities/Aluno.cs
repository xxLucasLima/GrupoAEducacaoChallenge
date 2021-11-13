using GrupoAEducacaoChallenge.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Domain
{
    public class Aluno
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public int Ra { get; private set; }
        public string CPF { get; private set; }

        public Aluno(string email, string name, int ra, string CPF)
        {
            ValidateDomain(email, name, ra, CPF);
        }       
        
        public Aluno(int id, string email, string name, int ra, string CPF)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(email, name, ra, CPF);
        }

        public void Update(string email, string name, int ra, string CPF)
        {
            ValidateDomain(email, name, ra, CPF);
        }
        public void ValidateDomain(string email, string name, int ra, string CPF)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Invalid email. Email is required.");
            DomainExceptionValidation.When(!IsValidEmail(email), "Invalid email.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(ra <= 0, "Invalid Ra. Ra can not be 0.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(CPF), "Invalid CPF. CPF is required.");

            Email = email;
            Name = name;
            Ra = ra;
            this.CPF = CPF;

        }

        bool IsValidEmail(string email)
        {
            if (email.Trim().EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
