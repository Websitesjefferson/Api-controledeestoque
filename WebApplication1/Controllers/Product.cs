using Microsoft.AspNetCore.Mvc;

using Product.API.Models;

namespace Apiaplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> _produtos = new List<Produto>();
        private static int _idCounter = 1;

        [HttpGet]
        public IActionResult ObterTodosProdutos()
        {
            return Ok(_produtos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterProdutoPorId(int id)
        {
            var produto = _produtos.Find(p => p.Id == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            produto.Id = _idCounter++;
            _produtos.Add(produto);
            return StatusCode(201, produto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, Produto produtoAtualizado)
        {
            var produto = _produtos.Find(p => p.Id == id);
            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Quantidade = produtoAtualizado.Quantidade;
            produto.Preco = produtoAtualizado.Preco;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirProduto(int id)
        {
            var produto = _produtos.Find(p => p.Id == id);
            if (produto == null)
                return NotFound();

            _produtos.Remove(produto);

            return NoContent();
        }
    }


}