using GrupoAEducacaoChallenge.Application.DTOs;
using GrupoAEducacaoChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GrupoAEducacaoChallenge.WebAPI.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AlunoDTO aluno)
        {
            try
            {
                await _alunoService.AddAsync(aluno);

                return Created($"/lote-form/{aluno.Id}", aluno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou: " + e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _alunoService.GetAlunosDTOAsync();

                return Ok(result);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou: " + e.Message);
            }
        }

        [HttpGet("{idAluno}")]
        public async Task<IActionResult> GetClienteAsyncById(int idAluno)
        {
            try
            {
                var result = await _alunoService.GetByIdAsync(idAluno);

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou: " + e.Message);
            }
        }


        [HttpDelete("{idAluno}")]
        public async Task<IActionResult> Delete(int idAluno)
        {
            try
            {
                var aluno = await _alunoService.GetByIdAsync(idAluno);

                if (aluno == null)
                    return NotFound();

                await _alunoService.RemoveAsync(idAluno);

                return Ok();

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou: " + ex.Message);
            }
        }

        [HttpPut("{idAluno}")]
        public async Task<IActionResult> Put(int idAluno, AlunoDTO payload)
        {
            try
            {
                var aluno = await _alunoService.GetByIdAsync(idAluno);

                if (aluno == null)
                    return NotFound();

                await _alunoService.UpdateAsync(payload);

                aluno = await _alunoService.GetByIdAsync(idAluno);
                return Created($"/api/aluno/{payload.Id}", aluno);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou: " + ex.Message);
            }
        }
    }
}