using AutoMapper;
using BootstrapBreadcrumbs.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Helpers;
using PulsarFit.WEB.Helpers.Auth;
using PulsarFit.COMMON.Services;

namespace PulsarFit.WEB.Controllers
{
    [Authorization]
    public class BaseController : Controller
    {
        private IServiceProvider _serviceProvider;

        private AppSettings _appSettings;
        protected AppSettings AppSettings => _appSettings = _appSettings ?? _serviceProvider.GetService<AppSettings>();

        private Localizer _localizer;
        protected Localizer Localizer => _localizer = _localizer ?? _serviceProvider.GetService<Localizer>();

        private IFirebaseService _firebaseService;
        protected IFirebaseService FirebaseService => _firebaseService = _firebaseService ?? _serviceProvider.GetService<IFirebaseService>();

        private IMapper _mapper;
        protected IMapper Mapper => _mapper = _mapper ?? _serviceProvider.GetService<IMapper>();

        private IToastNotification _toastNotification;
        protected IToastNotification Toast { get { _toastNotification = _toastNotification ?? _serviceProvider.GetService<IToastNotification>(); return _toastNotification; } }

        private IEmailService _emailService;
        protected IEmailService EmailService { get { _emailService = _emailService ?? _serviceProvider.GetService<IEmailService>(); return _emailService; } }

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected ExecutionUser CurrentExecutionUser => HttpContext.CurrentExecutionUser();

        protected ExecutionUser CurrentExecutionUserForRecordLevelAuth => null;
        //This should be uncommented but there are some bugs in AuthorizationResolvers
        //protected ExecutionUser CurrentExecutionUserForRecordLevelAuth => HttpContext.CurrentExecutionUser();

        #region Navigation

        protected string __sessionNavigationStackKey__ = $"__navigation__stack__";
        private List<BreadcrumbsItem> _sessionNavigationStack
        {
            get => HttpContext.Session.GetObject<List<BreadcrumbsItem>>(__sessionNavigationStackKey__) ?? new List<BreadcrumbsItem>();
            set => HttpContext.Session.SetObject(__sessionNavigationStackKey__, value);
        }

        protected string DefaultAction => "Index";
        protected string CurrentAction => HttpContext.Request.RouteValues["Action"].ToString();
        protected string CurrentController => HttpContext.Request.RouteValues["Controller"].ToString();

        protected void ResetNavigationStack()
        {
            var stack = _sessionNavigationStack;
            stack.Clear();
            _sessionNavigationStack = stack;
        }

        protected void BreadcrumbItem(string title = null, object routeValues = null)
        {
            var currentNavigationItem = new BreadcrumbsItem
            {
                Title = string.IsNullOrEmpty(title) ? Localizer.Translate(CurrentAction) : title,
                Controller = CurrentController,
                Action = CurrentAction,
                RouteValues = routeValues
            };

            if (_sessionNavigationStack.Count > 0)
            {
                var last = _sessionNavigationStack.Last();

                if (last.Controller == currentNavigationItem.Controller && last.Action == currentNavigationItem.Action)
                {
                    var stack1 = _sessionNavigationStack;
                    stack1.RemoveAt(stack1.Count - 1);
                    _sessionNavigationStack = stack1;
                }
                else
                {
                    this.SetBreadcrumbPrefixItems(_sessionNavigationStack);
                }
            }

            this.SetBreadcrumbAction(currentNavigationItem);

            ViewBag.Title = currentNavigationItem.Title;

            var stack = _sessionNavigationStack;
            stack.Add(currentNavigationItem); 
            _sessionNavigationStack = stack;
        }

        protected void BreadcrumbPrefixItem(string title = null, string action = null, string controller = null, object routeValues = null)
        {
            this.SetBreadcrumbPrefixItems(new List<BreadcrumbsItem>
            {
                new BreadcrumbsItem
                {
                    Title = string.IsNullOrEmpty(title) ? Localizer.Translate(CurrentController) : title,
                    Controller = string.IsNullOrEmpty(controller) ? CurrentController : controller,
                    Action = string.IsNullOrEmpty(action) ? DefaultAction : action,
                    RouteValues = routeValues
                }
            });
        }

        #endregion
    }
}
