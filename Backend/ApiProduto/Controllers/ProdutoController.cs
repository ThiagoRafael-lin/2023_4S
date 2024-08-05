using ApiProduto.Domains;
using ApiProduto.Interfaces;
using ApiProduto.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {

        private IProdutoRepository _produtoRepository;
        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }

    }
}
