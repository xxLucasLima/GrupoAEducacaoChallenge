using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Domain
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAlunosAsync();
        Task<Aluno> GetByIdAsync(int? id);

        Task<Aluno> CreateAsync(Aluno Aluno);
        Task<Aluno> UpdateAsync(Aluno Aluno);
        Task<Aluno> RemoveAsync(Aluno Aluno);
    }
}
