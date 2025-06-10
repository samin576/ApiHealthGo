using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.Entity;
using MinhaPrimeiraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApi.Contracts.Services;
using MinhaPrimeiraApi.Response;
using MinhaPrimeiraApi.Services;

namespace MinhaPrimeiraApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private ICidadeService _service;
        public CidadeController()
        {
            _service = new CidadeService();
        }
        [HttpGet]
        public async Task<ActionResult<CidadeGetAllResponse>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CidadeEntity>> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPost]
        public async Task<ActionResult<MessageResponse>> Post(CidadeInsertDTO cidade)
        {
            return Ok(await _service.Post(cidade));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<MessageResponse>> Delete(int id)
        {
            return Ok(await _service.Delete(id));
        }
        [HttpPut]
        public async Task<ActionResult<MessageResponse>> Update(CidadeEntity cidade)
        {
            return Ok(await _service.Update(cidade));
        }
    }
}
