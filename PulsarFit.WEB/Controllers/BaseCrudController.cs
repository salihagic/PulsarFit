using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.Helpers;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
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
        where TEntity : BaseEntity,
        new() where TEntityInsertRequest : class,
        new() where TEntityUpdateRequest : BaseUpdateRequest,
        new() where TSearchRequest : BaseSearchRequest,
        new() where TSearchResponse : BaseSearchResponse<TSearchRequest, TEntityDTO>,
        new() where TEntityDTO : class
    {
        protected IBaseCrudService<TEntity, TEntityInsertRequest, TEntityUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO> _crudService;

        protected string Message_add_success;
        protected string Message_add_error;
        protected string Message_edit_success;
        protected string Message_edit_error;
        protected string Message_delete_success;
        protected string Message_delete_error;

        public BaseCrudController(IServiceProvider serviceProvider, IBaseCrudService<TEntity, TEntityInsertRequest, TEntityUpdateRequest, TSearchRequest, TSearchResponse, TEntityDTO> crudService) : base(serviceProvider, crudService)
        {
            _crudService = crudService;

            Message_add_success = Localizer.Add_success;
            Message_add_error = Localizer.Add_error;
            Message_edit_success = Localizer.Edit_success;
            Message_edit_error = Localizer.Edit_error;
            Message_delete_success = Localizer.Delete_success;
            Message_delete_error = Localizer.Delete_error;
        }

        public virtual async Task<IActionResult> Add(bool fullPage = false)
        {
            if(fullPage)
                BreadcrumbItem(null, new { fullPage });

            return View(await _crudService.InitForAdd());
        }

        [HttpPost]
        [Transaction]
        public virtual async Task<IActionResult> Add(TEntityInsertRequest request)
        {
            ViewBag.Title = Localizer.Translate(CurrentAction);

            if (!ModelState.IsValid)
                return View(request);

            try
            {
                await _crudService.Add(request, CurrentExecutionUserForRecordLevelAuth);

                Toast.AddSuccessToastMessage(Message_add_success);
                return Json(new { success = true });
            }
            catch (Exception e)
            {
                Toast.AddErrorToastMessage(Message_add_error);
            }
            return View(request);
        }

        public virtual async Task<IActionResult> Edit(int id, bool fullPage = false) 
        {
            if(fullPage)
                BreadcrumbItem(null, new { id, fullPage });

            return View(await _crudService.InitForUpdate(id, CurrentExecutionUserForRecordLevelAuth));
        }

        [HttpPut]
        [Transaction]
        public virtual async Task<IActionResult> Edit(TEntityUpdateRequest request)
        {
            ViewBag.Title = Localizer.Translate(CurrentAction);

            if (!ModelState.IsValid)
                return View(request);

            try
            {
                await _crudService.Update(request, CurrentExecutionUserForRecordLevelAuth);

                Toast.AddSuccessToastMessage(Message_edit_success);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                Toast.AddErrorToastMessage(Message_edit_error);
            }
            return View(request);
        }

        [HttpDelete]
        [Transaction]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _crudService.Delete(id, CurrentExecutionUserForRecordLevelAuth);

                Toast.AddSuccessToastMessage(Message_delete_success);
                return Json(new { success = true });
            }
            catch
            {
                Toast.AddErrorToastMessage(Message_delete_error);
            }
            return Json(new { success = false });
        }
    }
}