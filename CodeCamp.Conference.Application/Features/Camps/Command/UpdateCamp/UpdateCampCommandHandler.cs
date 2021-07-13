using AutoMapper;
using CodeCamp.Conference.Application.Contracts.Persistence;
using CodeCamp.Conference.Application.Exceptions;
using CodeCamp.Conference.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCamp.Conference.Application.Features.Camps.Command.UpdateCamp
{
    public class UpdateCampCommandHandler : IRequestHandler<UpdateCampCommand, UpdateCampResponse>
    {
        private readonly ICampRepository campRepository;
        private readonly IMapper mapper;

        public UpdateCampCommandHandler(ICampRepository campRepository, IMapper mapper)
        {
            this.campRepository = campRepository;
            this.mapper = mapper;
        }
        public async Task<UpdateCampResponse> Handle(UpdateCampCommand request, CancellationToken cancellationToken)
        {
            var CampToUpdate = await campRepository.GetByIdAsync(request.campId);
            var campResponse = new UpdateCampResponse();

            if (CampToUpdate == null)
            {
                campResponse.statusCode = 404;
                campResponse.Success = false;
                throw new NotFoundException(nameof(Camp), request.campId);
            }



            var updateCampValidator = new UpdateCampCommandValidator();
            var updateCampValidationResult = await updateCampValidator.ValidateAsync(request);


            if (updateCampValidationResult.Errors.Count > 0)
            {
                campResponse.Success = false;
                campResponse.statusCode = 400;
                campResponse.ValidationErrors = new List<string>();
                foreach (var error in updateCampValidationResult.Errors)
                {
                    campResponse.ValidationErrors.Add(error.ErrorMessage);
                }
                throw new ValidationException(updateCampValidationResult);
            }

            if (campResponse.Success)
            {
                campResponse.statusCode = 200;
                mapper.Map(request, CampToUpdate, typeof(UpdateCampCommand), typeof(Camp));
                await campRepository.UpdateAsync(CampToUpdate);
            }

            return campResponse;
        }
    }
}
