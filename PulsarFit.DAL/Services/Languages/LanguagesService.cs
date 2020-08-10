using System;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public class LanguagesService 
        : BaseCrudService<
            Language, 
            LanguageInsertRequest, 
            LanguageUpdateRequest, 
            LanguageSearchRequest, 
            LanguageSearchResponse, 
            LanguageDTO
            >, ILanguagesService
    {
        public LanguagesService(IServiceProvider serviceProvider) : base(serviceProvider){}
    }
}