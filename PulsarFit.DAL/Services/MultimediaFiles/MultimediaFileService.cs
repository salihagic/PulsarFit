using Microsoft.Extensions.DependencyInjection;
using PulsarFit.DAL.Services;
using Pulsar.MultimediaFileProvider.Client;
using System;
using System.Threading.Tasks;
using PulsarFit.CORE.Domain;

namespace PulsarFit.DAL.Services
{
    public class MultimediaFilesService
        : BaseCrudService<
            MultimediaFile, 
            MultimediaFileInsertRequest, 
            MultimediaFileUpdateRequest, 
            MultimediaFileSearchRequest, 
            MultimediaFileSearchResponse,
            MultimediaFileDTO
            >, IMultimediaFilesService
    {
        private IPulsarMultimediaFileProvider _pulsarMultimediaFileProvider;

        public MultimediaFilesService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _pulsarMultimediaFileProvider = serviceProvider.GetService<IPulsarMultimediaFileProvider>();
        }

        public override async Task<MultimediaFileDTO> Add<TExecutionUser>(MultimediaFileInsertRequest request, TExecutionUser executionUser = null)
        {
            var pulsarRequest = Mapper.Map<PulsarMultimediaFileInsertRequest>(request);

            var response = await _pulsarMultimediaFileProvider.Add(pulsarRequest);

            var entity = Mapper.Map<MultimediaFile>(response);

            return await base.Add(entity, executionUser);
        }
    }
}