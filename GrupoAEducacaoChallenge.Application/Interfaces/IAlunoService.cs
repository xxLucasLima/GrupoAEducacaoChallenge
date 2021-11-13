using GrupoAEducacaoChallenge.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoDTO>> GetAlunosDTOAsync();
        Task<AlunoDTO> GetByIdAsync(int? id);
        Task AddAsync(AlunoDTO alunoDTO);
        Task UpdateAsync(AlunoDTO alunoDTO);
        Task RemoveAsync(int? id);
    }
}
