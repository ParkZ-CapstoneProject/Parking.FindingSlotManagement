﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Application.Features.Customer.FavoriteAddress.FavoriteAddressManagement.Queries.GetFavoriteAddressByUserId
{
    public class GetFavoriteAddressByUserIdResponse
    {
        public int FavoriteAddressId { get; set; }
        public string? TagName { get; set; }
        public string? Address { get; set; }
    }
}
