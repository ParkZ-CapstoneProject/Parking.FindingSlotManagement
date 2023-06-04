﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Manager.Timeline.TimelineManagement.Commands.UpdateTimeline
{
    public class UpdateTimelineCommand : IRequest<ServiceResponse<string>>
    {
        public int TimeLineId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public int? StartingTime { get; set; }
        public bool? IsExtrafee { get; set; }
        public decimal? ExtraFee { get; set; }
        public float? ExtraTimeStep { get; set; }
        public bool? HasPenaltyPrice { get; set; }
        public decimal? PenaltyPrice { get; set; }
        public float? PenaltyPriceStepTime { get; set; }
    }
}
