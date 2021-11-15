using GrupoAEducacaoChallenge.Domain;
using GrupoAEducacaoChallenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Infra.Data.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        ApplicationDbContext _alunoContext;

        public AlunoRepository(ApplicationDbContext alunoContext)
        {
            _alunoContext = alunoContext;   
        }
        public async Task<Aluno> CreateAsync(Aluno aluno)
        {
            _alunoContext.Add(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosAsync()
        {
            return await _alunoContext.Alunos.ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int? id)
        {
            return await _alunoContext.Alunos.AsNoTracking().Where(p=>p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Aluno> RemoveAsync(Aluno aluno)
        {
            _alunoContext.Remove(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }

        public async Task<Aluno> UpdateAsync(Aluno aluno)
        {
            _alunoContext.Update(aluno);
            await _alunoContext.SaveChangesAsync();
            return aluno;
        }
    }
}
