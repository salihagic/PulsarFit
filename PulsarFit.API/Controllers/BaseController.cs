using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using PulsarFit.API.Helpers.Auth;
using PulsarFit.COMMON.Configuration;
using PulsarFit.COMMON.Helpers;
using PulsarFit.COMMON.Services;
using PulsarFit.CORE.Helpers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PulsarFit.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
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

        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected int CurrentUserId
        {
            get
            {
                int.TryParse(User.FindFirst(CustomClaimTypes.Id)?.Value, out var currentUserId);
                return currentUserId;
            }
        }

        protected string CurrentUserUsername => User.FindFirst(CustomClaimTypes.Username)?.Value;

        protected ExecutionUser CurrentExecutionUserForRecordLevelAuth
        {
            get
            {
                return null;
                return HttpContext.CurrentExecutionUser();
            }
        }

        protected ExecutionUser CurrentExecutionUser => HttpContext.CurrentExecutionUser();

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}
