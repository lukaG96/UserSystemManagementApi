using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementSystemAPI.Contracts.Repository;
using UserManagementSystemAPI.Contracts.Services;
using UserManagementSystemAPI.DataLayer.DTOs.Request;
using UserManagementSystemAPI.DataLayer.DTOs.Response;
using UserManagementSystemAPI.DataLayer.Models;
using UserManagementSystemAPI.Shared.Constants;
using UserManagementSystemAPI.Shared.Exceptions;

namespace UserManagementSystemAPI.Services.Services
{
    public class StatusService : IStatusService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public StatusService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StatusResponseDto>> RetrieveStatuses() =>
                 _mapper.Map<IEnumerable<StatusResponseDto>>(await _repositoryManager.StatusRepository.FindAll().ToListAsync());

         
        public async Task<StatusResponseDto> CreteStatus(StatusRequestDto statusRequest)
        {
          
            if (await _repositoryManager.StatusRepository.StatusExist(statusRequest.Code))
                throw new OperationFailedException(ErrorMessages.StatusAlreadyExists);


            Status newStatus = _mapper.Map<Status>(statusRequest);


            await _repositoryManager.StatusRepository.CreateAsync(newStatus);

            if (await _repositoryManager.UnitOfWork.SaveChangesAsync() == 0)
                throw new OperationFailedException(ErrorMessages.Error);


            return _mapper.Map<StatusResponseDto>(newStatus);
        }
    }
}
