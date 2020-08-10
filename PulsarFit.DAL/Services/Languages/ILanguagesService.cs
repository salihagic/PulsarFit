using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.DAL.Services
{
    public interface ILanguagesService : 
        IBaseCrudService<
            Language, 
            LanguageInsertRequest, 
            LanguageUpdateRequest, 
            LanguageSearchRequest, 
            LanguageSearchResponse, 
            LanguageDTO
            > {}
}
