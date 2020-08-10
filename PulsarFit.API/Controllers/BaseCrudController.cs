using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.Helpers;
using PulsarFit.DAL.Services;

namespace PulsarFit.API.Controllers
{
    public abstract class BaseCrudController<
        TEntity,
        TEntityInsertRequest,
        TEntityUpdateRequest,
        TSearchRequest,
        TSearchResponse,
        TEntityDTO
        > : BaseReadController<
            TEntity,
            TSearchRequest,
            TSearchResponse,
            TEntityDTO
            >
        where TEntity : BaseEntity, new()
        where TEntityInsertRequest : class, new()
        where TEntityUpdateRequest : BaseUpdateRequest, new()
        where TSearchRequest : BaseSearchRequest, new()
        where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>, new()
        where TEntityDTO : BaseDTO
    {
        protected IBaseCrudService<TEntity, TEntityInsertRequest, TEntityUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO> _crudService;

        public BaseCrudController(IServiceProvider serviceProvider, IBaseCrudService<TEntity, TEntityInsertRequest, TEntityUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO> crudService) : base(serviceProvider, crudService)
        {
            _crudService = crudService;
        }

        [HttpPost, Transaction]
        public async Task<IActionResult> Post([FromBody] TEntityInsertRequest request)
        {
            return Ok(await _crudService.Add(request, CurrentExecutionUserForRecordLevelAuth));
        }

        [HttpPut, Transaction]
        public async Task<IActionResult> Put([FromBody] TEntityUpdateRequest request)
        {
            return Ok(await _crudService.Update(request, CurrentExecutionUserForRecordLevelAuth));
        }

        [HttpDelete("{id}"), Transaction]
        public async Task Delete(int id)
        {
            await _crudService.Delete(id, CurrentExecutionUserForRecordLevelAuth);
        }
    }
}
