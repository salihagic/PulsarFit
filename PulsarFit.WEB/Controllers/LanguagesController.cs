using Microsoft.Extensions.DependencyInjection;
using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Controllers
{
    public class LanguagesController
        : BaseCrudController<
            Language,
            LanguageInsertRequest,
            LanguageUpdateRequest,
            LanguageSearchRequest,
            LanguageSearchResponse,
            LanguageDTO
            >
    {
        public LanguagesController(IServiceProvider serviceProvider) : base(serviceProvider, serviceProvider.GetService<ILanguagesService>()) { }
    }
}
