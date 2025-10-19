﻿using Application.DTOs;
using Application.Queries;
using Application.UseCases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.UseCases.QueryHandlers
{
    public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, List<DoctorDto>>
    {
        private readonly IDoctorRepository repository;
        private readonly IMapper mapper;

        public GetDoctorsQueryHandler(IDoctorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<List<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await repository.GetDoctors();
            return mapper.Map<List<DoctorDto>>(doctors);
        }
    }
}
