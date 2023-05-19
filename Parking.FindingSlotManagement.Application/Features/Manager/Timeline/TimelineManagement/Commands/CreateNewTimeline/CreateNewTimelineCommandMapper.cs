﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Manager.Timeline.TimelineManagement.Commands.CreateNewTimeline
{
    public class CreateNewTimelineCommandMapper
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? StartingTime { get; set; }
        public bool? IsExtrafee { get; set; } = false;
        public decimal? ExtraFee { get; set; }
        public float? ExtraTimeStep { get; set; }
        public bool? HasPenaltyPrice { get; set; } = false;
        public decimal? PenaltyPrice { get; set; }
        public float? PenaltyPriceStepTime { get; set; }

        public int? TrafficId { get; set; }
        public int? ParkingPriceId { get; set; }
    }
}
