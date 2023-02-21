using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application;
using Livraria.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Livraria.Controllers
{
    [Route("[controller]")]
    public class LivrosController : Controller
    {
        private readonly ILivroService _livroService; 
        public LivrosController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public async Task<IActionResult> PegarTodosLivros()
        {
            try
            {
                var livros = await _livroService.PegarTodosLivros();
                if (livros == null) return NotFound("Nenhum Livro Encontrado.");

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarLivroPeloId(int id)
        {
            try
            {
                var livro = await _livroService.PegarLivroPeloId(id);
                if (livro == null) return NotFound("Nenhum Livro Encontrado pelo Id.");

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpGet("{titulo}/titulo")]
        public async Task<IActionResult> PegarTodosLivrosPeloTitulo(string titulo)
        {
            try
            {
                var livros = await _livroService.PegarTodosLivrosPeloTitulo(titulo);
                if (livros == null) return NotFound("Nenhum Livro Encontrado pelo Titulo.");

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpGet("{autor}/autor")]
        public async Task<IActionResult> PegarTodosLivrosPeloAutor(string autor)
        {
            try
            {
                var livros = await _livroService.PegarTodosLivrosPeloAutor(autor);
                if (livros == null) return NotFound("Nenhum Livro Encontrado pelo Autor.");

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpGet("{editora}/editora")]
        public async Task<IActionResult> PegarTodosLivrosPelaEditora(string editora)
        {
            try
            {
                var livros = await _livroService.PegarTodosLivrosPelaEditora(editora);
                if (livros == null) return NotFound("Nenhum Livro Encontrado pelo Editora.");

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpGet("{edicao}/edicao")]
        public async Task<IActionResult> PegarTodosLivrosPelaEdicao(int edicao)
        {
            try
            {
                var livros = await _livroService.PegarTodosLivrosPelaEdicao(edicao);
                if (livros == null) return NotFound("Nenhum Livro Encontrado pelo Edicação.");

                return Ok(livros);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentat recuperar os livros. Erro {ex.Message}");
            }
        } 

        [HttpPost]
        public async Task<IActionResult> AdicionarLivro(Livro model)
        {
            try
            {
                var livro = await _livroService.AdicionarLivro(model);
                if (livro == null) return BadRequest("Erro ao tentar adicionar um Livro.");

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Adicionar livro. Erro {ex.Message}");
            }
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            try
            {
                return await _livroService.DeletarLivro(id) 
                    ? Ok(new { mensagem ="Deletado!" }) 
                    : BadRequest("Livro não Deletado");
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar Deletar Livro. Erro: {erro.Message}");
            }
        } 

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarLivro(int id, Livro model)
        {
            try
            {
                var livro = await _livroService.AtualizarLivro(id, model);
                if (livro == null) return BadRequest("Erro ao tentar Atualizar Livro.");

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar livro. Erro {ex.Message}");
            }
        } 

        
    }
}