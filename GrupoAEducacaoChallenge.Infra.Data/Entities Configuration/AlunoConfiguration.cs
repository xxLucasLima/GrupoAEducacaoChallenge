using GrupoAEducacaoChallenge.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Infra.Data.Entities_Configuration
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Ra).IsRequired();
            builder.Property(p => p.CPF).IsRequired();

            builder.HasData(
                new Aluno(1, "lucas.lima.pinheiro@hotmail.com", "Lucas Lima", 123, "010.486.314-51")

                );
        }
    }
}
