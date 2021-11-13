using AutoMapper;
using GrupoAEducacaoChallenge.Application.DTOs;
using GrupoAEducacaoChallenge.Application.Interfaces;
using GrupoAEducacaoChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(AlunoDTO alunoDTO)
        {
            var alunoEntity = _mapper.Map<Aluno>(alunoDTO);
            await _alunoRepository.CreateAsync(alunoEntity);
        }
        public async Task<AlunoDTO> GetByIdAsync(int? id)
        {
            var alunoEntity = await _alunoRepository.GetByIdAsync(id);
            return _mapper.Map<AlunoDTO>(alunoEntity);
        }

        public async Task<IEnumerable<AlunoDTO>> GetAlunosDTOAsync()
        {
            var alunoEntity = await _alunoRepository.GetAlunosAsync();
            return _mapper.Map<IEnumerable<AlunoDTO>>(alunoEntity);
        }


        public async Task RemoveAsync(int? id)
        {
            var alunoEntity = await _alunoRepository.GetByIdAsync(id);
            await _alunoRepository.RemoveAsync(alunoEntity);
        }

        public async Task UpdateAsync(AlunoDTO alunoDTO)
        {
            var alunoEntity = _mapper.Map<Aluno>(alunoDTO);
            await _alunoRepository.UpdateAsync(alunoEntity);
        }
    }
}
