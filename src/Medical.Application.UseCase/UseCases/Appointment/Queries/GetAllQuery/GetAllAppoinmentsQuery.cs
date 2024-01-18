﻿using MediatR;
using Medical.Application.Dtos.Appoinment.Response;
using Medical.Application.UseCase.Commons.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Application.UseCase.UseCases.Appointment.Queries.GetAllQuery
{
    public class GetAllAppoinmentsQuery : IRequest<BaseResponse<IEnumerable<GetAppoinmentsDto>>>
    {
    }
}
