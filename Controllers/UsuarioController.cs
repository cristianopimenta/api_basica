using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtimizeLaudoPredial.Models;
using OtimizeLaudoPredial.Repositorios.Interfaces;

namespace OtimizeLaudoPredial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usurarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usurarioRepositorio)
        {
            _usurarioRepositorio = usurarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuario()
        {
            List<UsuarioModel> usuarios = await _usurarioRepositorio.BuscarTodosUsuarios();

            return Ok(usuarios);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usurarioRepositorio.BuscarPorId(id);

            return Ok(usuario);

        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usurarioRepositorio.Adicionar(usuarioModel);


            return Ok(usuario);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
        usuarioModel.Id = id;
            UsuarioModel usuario = await _usurarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
        [HttpDelete]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _usurarioRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
