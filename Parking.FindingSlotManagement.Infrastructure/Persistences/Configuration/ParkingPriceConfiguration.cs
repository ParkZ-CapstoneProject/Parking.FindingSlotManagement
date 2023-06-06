﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Parking.FindingSlotManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Parking.FindingSlotManagement.Infrastructure.Persistences.Configuration
{
    public class ParkingPriceConfiguration : IEntityTypeConfiguration<ParkingPrice>
    {
        public void Configure(EntityTypeBuilder<ParkingPrice> builder)
        {
            builder.ToTable("ParkingPrice");

            builder.Property(e => e.ParkingPriceName)
                .HasMaxLength(250);

            builder.Property(x => x.UserId)
                    .HasColumnName("BusinessId");

            builder.Property(e => e.PenaltyPrice).HasColumnType("money");

            builder.Property(e => e.StartingTime).HasColumnName("StartingTime")
                .HasColumnType("int");


            builder.HasOne(x => x.User)
                    .WithMany(x => x.ParkingPrices)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Business__ParkingPri__sdwq23dca");

            builder.HasOne(x => x.Traffic)
                .WithMany(x => x.ParkingPrices)
                .HasForeignKey(x => x.TrafficId)
                .HasConstraintName("FK__Traffic_Parkingpri");
        }
    }
}
