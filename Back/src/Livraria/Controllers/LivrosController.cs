using Microsoft.AspNetCore.Mvc;
using Livraria.Models;
using Livraria.Models.Contratos;


namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        
        private readonly ILivroModel _livroModel;

        public LivrosController(ILivroModel livroModel)
        {
            _livroModel = livroModel;
            
        }

        
        [HttpGet]
        public async Task<ActionResult> PegarTodosLivros()
        {
            try
            {
                var livros = await _livroModel.PegarTodosLivros();
                if(livros == null) return NotFound("Nenhum livro encontrado!");

                return Ok(livros);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar livros. Erro: {erro.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarLivroPeloId(int id)
        {
             try
            {
                var livro = await _livroModel.PegarLivroPeloId(id);
                if(livro == null) return NotFound("Nenhum livro foi encontrado pelo Id");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar livro. Erro: {erro.Message}");
            }
        }

        [HttpGet("{titulo}/titulo")]
        public async Task<IActionResult> PegarTodosLivrosPeloTitulo(string titulo)
        {
             try
            {
                var livro = await _livroModel.PegarTodosLivrosPeloTitulo(titulo);
                if(livro == null) return NotFound("Nenhum Livro foi encontrado pelo titulo");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os livros. Erro: {erro.Message}");
            }
        }

        [HttpGet("{editora}/editora")]
        public async Task<IActionResult> PegarTodosLivrosPelaEditora(string editora)
        {
             try
            {
                var livro = await _livroModel.PegarTodosLivrosPelaEditora(editora);
                if(livro == null) return NotFound("Nenhum Livro foi encontrado pelo editora");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os livros. Erro: {erro.Message}");
            }
        }

        [HttpGet("{edicao}/edicao")]
        public async Task<IActionResult> PegarTodosLivrosPelaEdicao(int edicao)
        {
             try
            {
                var livro = await _livroModel.PegarTodosLivrosPelaEdicao(edicao);
                if(livro == null) return NotFound("Nenhum livro foi encontrado pela edição");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar os livros. Erro: {erro.Message}");
            }
        }
        

        [HttpPost]
        public async Task<IActionResult>AdicionarLivro(Livro model)
        {
           try
            {
                var livro = await _livroModel.AdicionarLivro(model);
                if(livro == null) return BadRequest("Erro ao tentar adicionar livro");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar livro. Erro: {erro.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>AtualizarLivro(int id, Livro model)
        {
           try
            {
                var livro = await _livroModel.AtualizarLivro(id, model);
                if(livro == null) return BadRequest("Erro ao tentar atualizar livro");

                return Ok(livro);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar livro. Erro: {erro.Message}");
            }
        }


        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarLivro(int id)
        {
            try
            {
                return await _livroModel.DeletarLivro(id) 
                    ? Ok(new { mensagem ="Deletado!" }) 
                    : BadRequest("Livro não Deletado");
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar livro. Erro: {erro.Message}");
            }
        }
    }
}
