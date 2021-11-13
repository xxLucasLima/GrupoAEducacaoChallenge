using AutoMapper;
using GrupoAEducacaoChallenge.Application.DTOs;
using GrupoAEducacaoChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();

        }
    }
}
