using APIProjectBackend.Controllers.Contracts;
using APIProjectBackend.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIProjectBackend.Controllers
{
    [ApiController]    
    public class BaseController<U, T> : ControllerBase, IBaseController<T> where U : class where T : class
    {
        protected readonly IMapper _mapper;
        protected readonly IBaseService<U> _baseService;

        public BaseController(IMapper mapper, IBaseService<U> baseService)
        {
            _mapper = mapper;
            _baseService = baseService;
        }

        [HttpGet("all/async")]
        //[Authorize("BasicRead")]
        public async Task<ActionResult<List<T>>> GetAllAsync()
        {
            List<U> list = await _baseService.GetAllAsync();
            return Ok(_mapper.Map<List<U>, List<T>>(list));
        }

        [HttpGet("async/{id}")]
        //[Authorize("BasicRead")]
        public async Task<ActionResult<T>> GetByIdAsync(Guid id)
        {
            U entity = await _baseService.GetByIdAsync(id);
            return Ok(_mapper.Map<U, T>(entity));
        }


        [HttpPost("Async")]
        //[Authorize("BasicWrite")]
        public async Task<ActionResult<T>> SaveEntityAsync([FromBody] T entity)
        {
            U entitySaved = await _baseService.SaveAsync(_mapper.Map<T, U>(entity));
            return Ok(_mapper.Map<U, T>(entitySaved));
        }
        [HttpPut("Async")]
        //[Authorize("BasicWrite")]
        public async Task<ActionResult<T>> UpdateEntityAsync([FromBody] T entity)
        {
            U entitySaved = await _baseService.UpdateAsync(_mapper.Map<T, U>(entity));
            return Ok(_mapper.Map<U, T>(entitySaved));
        }


        [HttpDelete("async/{id}")]
        // [Authorize("BasicWrite")]
        public async Task<IActionResult> DeleteEntityAsync(Guid id)
        {
            var result = await _baseService.DeleteByIdAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

    }
}
