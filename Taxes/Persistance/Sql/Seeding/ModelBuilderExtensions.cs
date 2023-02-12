using Abstractions.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Sql.Seeding
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxeType>()
                        .HasData(
                            new TaxeType
                            {
                                Id = new Guid("6fa81744-71b4-41da-8f38-53102ef99943"),
                                Name = "Yearly",
                            },
                            new TaxeType
                            {
                                Id = new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033"),
                                Name = "Monthly",
                            },
                            new TaxeType
                            {
                                Id = new Guid("edcd5ed2-47f6-434b-92e6-02f47a0c2082"),
                                Name = "Weekly",
                            },
                            new TaxeType
                            {
                                Id = new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"),
                                Name = "Daily",
                            }
                        );

            modelBuilder.Entity<Municipality>()
                        .HasData(
                            new Municipality
                            {
                                Id = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                Name = "Copenhagen",
                            }
                        );

            modelBuilder.Entity<Taxe>()
                        .HasData(
                            new Taxe
                            {
                                Id = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                StartDate = new DateTime(2023, 05, 01),
                                EndDate = new DateTime(2023, 05, 31),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033"),
                                Value = 0.4
                            },
                            new Taxe
                            {
                                Id = new Guid("ac2cc175-4f71-456a-bf4d-3548d7af9f4b"),
                                StartDate = new DateTime(2023, 01, 01),
                                EndDate = new DateTime(2023, 12, 31),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("6fa81744-71b4-41da-8f38-53102ef99943"),
                                Value = 0.2
                            },
                            new Taxe
                            {
                                Id = new Guid("e1296797-f320-48a2-bd6a-f4b14ab93912"),
                                StartDate = new DateTime(2023, 05, 01),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"),
                                Value = 0.1
                            },
                            new Taxe
                            {
                                Id = new Guid("f686e7c2-61f3-4b94-afd7-01a92f3dad8b"),
                                StartDate = new DateTime(2023, 12, 25),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"),
                                Value = 0.1
                            }
                        );


            modelBuilder.Entity<TaxeOrder>()
                        .HasData(
                            new TaxeOrder
                            {
                                Id= new Guid("5d2e7de1-f1c2-4cda-b81e-968a116a9334"),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("6fa81744-71b4-41da-8f38-53102ef99943"),
                            },
                            new TaxeOrder
                            {
                                Id = new Guid("063f535c-4fe0-4003-86be-18c03425969c"),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("cca3f6e8-4687-489e-be62-d0ab1ad65033"),
                                ParentId = new Guid("5d2e7de1-f1c2-4cda-b81e-968a116a9334")
                            },
                            new TaxeOrder
                            {
                                Id = new Guid("4e5e0fa7-f3f2-4d8d-8d44-a5509e1ebd41"),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("edcd5ed2-47f6-434b-92e6-02f47a0c2082"),
                                ParentId = new Guid("063f535c-4fe0-4003-86be-18c03425969c")
                            },
                            new TaxeOrder
                            {
                                Id = new Guid("91daae9b-479a-45c9-965c-79231b89c3da"),
                                MunicipalityId = new Guid("a5c94773-4a0d-429d-9730-0489cf6b5f0d"),
                                TaxeTypeId = new Guid("aeaa5f81-f6c9-4905-9309-99e6998f658c"),
                                ParentId = new Guid("4e5e0fa7-f3f2-4d8d-8d44-a5509e1ebd41")
                            }
                         );
        }
    }
}
