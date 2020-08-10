using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.Services;
using PulsarFit.WEB.Helpers;

namespace PulsarFit.WEB.Controllers
{
    public abstract class BaseReadController<
        TEntity,
        TSearchRequest,
        TSearchResponse,
        TEntityDTO
        > : BaseController
        where TEntity : BaseEntity,
        new() where TSearchRequest : BaseSearchRequest,
        new() where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>,
        new() where TEntityDTO : class
    {
        protected IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO> _readService;

        protected bool ShouldResetNavigationStack { get; set; }

        protected string __sessionSearchRequestKey__ = $"__{typeof(TSearchRequest).Name}__{nameof(TSearchRequest)}__";
        private TSearchRequest _sessionSearchRequest
        {
            get => HttpContext.Session.GetObject<TSearchRequest>(__sessionSearchRequestKey__);
            set => HttpContext.Session.SetObject(__sessionSearchRequestKey__, value);
        }

        protected string __sessionSearchResponseKey__ = $"__{typeof(TSearchResponse).Name}__{nameof(TSearchResponse)}__";
        private TSearchResponse _sessionSearchResponse
        {
            get => HttpContext.Session.GetObject<TSearchResponse>(__sessionSearchResponseKey__);
            set => HttpContext.Session.SetObject(__sessionSearchResponseKey__, value);
        }

        public BaseReadController(IServiceProvider serviceProvider, IBaseReadService<TEntity, TSearchRequest, TSearchResponse, TEntityDTO> readService) : base(serviceProvider)
        {
            _readService = readService;

            ShouldResetNavigationStack = true;
        }

        public virtual async Task<IActionResult> Index()
        {
            if (ShouldResetNavigationStack)
            {
                ResetNavigationStack();
            }

            BreadcrumbItem(Localizer.Translate(CurrentController));

            _sessionSearchRequest = _sessionSearchRequest ?? await _readService.InitForGet();

            return View(_sessionSearchRequest);
        }

        public virtual async Task<IActionResult> IndexJson(TSearchRequest searchRequest)
        {
            searchRequest = searchRequest ?? new TSearchRequest();
            searchRequest.Pagination = Request.Query.GetPagination();

            _sessionSearchRequest = searchRequest;
            _sessionSearchResponse = await _readService.Get(searchRequest, CurrentExecutionUserForRecordLevelAuth);
            _sessionSearchRequest = searchRequest;

            return Ok(new
            {
                meta = new
                {
                    page = searchRequest.Pagination?.Page,
                    pages = searchRequest.Pagination?.TotalNumberOfPages,
                    perpage = searchRequest.Pagination?.Take,
                    total = searchRequest.Pagination?.TotalNumberOfRecords
                },
                data = _sessionSearchResponse?.Items,
            });
        }

        public virtual async Task<IActionResult> Details(int id, TSearchRequest searchRequest, bool fullPage = false)
        {
            if(fullPage)
                BreadcrumbItem(null, new { id, searchRequest, fullPage });

            return View(await _readService.GetById(id, CurrentExecutionUserForRecordLevelAuth, searchRequest));
        }
    }
}