using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.Services;

namespace PulsarFit.API.Controllers
{
    public class BaseReadController<
        TEntity, 
        TSearchRequest,
        TSearchResponse,
        TEntityDTO
        > : BaseController
        where TEntity : BaseEntity, new()
        where TSearchRequest : BaseSearchRequest, new()
        where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>, new()
        where TEntityDTO : BaseDTO
    {
        private IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO> _readService;

        public BaseReadController(IServiceProvider serviceProvider, IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO> readService) : base(serviceProvider)
        {
            _readService = readService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TSearchRequest searchRequest)
        {
            return Ok(await _readService.GetItems(searchRequest, CurrentExecutionUserForRecordLevelAuth));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, [FromQuery] TSearchRequest searchRequest)
        {
            return Ok(await _readService.GetById(id, CurrentExecutionUserForRecordLevelAuth, searchRequest));
        }
    }
}
