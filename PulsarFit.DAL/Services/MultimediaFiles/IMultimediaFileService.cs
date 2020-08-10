using PulsarFit.DAL.Services;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public interface IMultimediaFilesService
        : IBaseCrudService<
            MultimediaFile, 
            MultimediaFileInsertRequest, 
            MultimediaFileUpdateRequest, 
            MultimediaFileSearchRequest, 
            MultimediaFileSearchResponse, 
            MultimediaFileDTO
            > {}
}
