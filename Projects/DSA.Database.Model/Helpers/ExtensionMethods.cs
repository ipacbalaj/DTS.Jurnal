using System;
using System.Collections.Generic;
using System.Linq;
using DSA.Common.Infrastructure.Entities;
using DSA.Common.Infrastructure.Styles;
using DSA.Database.Model.EfSQlLite;
using DSA.Database.Model.Entities.Local;
using DTS.Jurnal.Database.Model.Entities.Local;
using DTS.Jurnal.V3.Database.Module.Entities.Local;

namespace DTS.Jurnal.V3.Database.Module.Helpers
{
    public static class ExtensionMethods
    {
        public static SettingItem ToLocalWork(this Work from)
        {
            return new SettingItem
            {
                Id = from.Id,
                Name = from.Name
            };
        }

        public static List<SettingItem> ToLocalWorks(this IEnumerable<Work> from)
        {
            return from.Select(item => item.ToLocalWork()).ToList();
        }

        public static SettingItem ToLocalLocation(this Location from)
        {
            return new SettingItem
            {
                Id = from.Id,
                Name = from.Name
            };
        }

        public static List<SettingItem> ToLocalLocations(this IEnumerable<Location> from)
        {
            return from.Select(item => item.ToLocalLocation()).ToList();
        }

        public static SettingItem ToLocalArea(this Area from)
        {
            return new SettingItem
            {
                Id = from.Id,
                Name = from.Name
            };
        }

        public static List<SettingItem> ToLocalAreass(this IEnumerable<Area> from)
        {
            return from.Select(item => item.ToLocalArea()).ToList();
        }

        public static LocalPatient ToLocalPatient(this Patient from)
        {
            return new LocalPatient
            {
                Id = from.id,
                FirstName = from.surname,
                LastName = from.name,
                AllName = from.surname + " " + from.name,
                BirthDate = from.BirthDate,
                City = from.City,
                Country = from.Country,
                Street = from.Street,
                Block = from.Block,
                StreetNumber = from.StreetNumber,
                Job = from.Job,
                Ocupation = from.Ocupation,
                Phone = from.Phone,
                Email = from.Email,
                //                WasExported = from.WasExported,
                Brush = BackgroundColors.JurnalColor
            };
        }

        public static List<LocalPatient> ToLocalPatients(this IEnumerable<Patient> from)
        {
            return from.Select(item => item.ToLocalPatient()).ToList();
        }

        public static InterventionModel ToInterventionModel(this Intervention from)
        {
            var area = from.Area;
            var work = from.Work;
            var location = from.Location;
            return new InterventionModel
            {
                Id = from.Id,
                Date = from.DateHourDetail.Date,
                Duration = TimeSpan.FromTicks(from.DateHourDetail.Duration.Value),
                IsSelected = from.IsSelected,
                Start = from.DateHourDetail.StartHour,
                End = from.DateHourDetail.EndingHour,
                Location = location != null ? location.Name : "",
                LocationId = location != null ? location.Id : 0,
                Area = area != null ? area.Name : "",
                AreaId = area != null ? area.Id : 0,
                Work = work != null ? work.Name : "",
                WorkId = work != null ? work.Id : 0,
                PatientName = from.Patient.surname + " " + from.Patient.name,
                PatientId = from.Patient_id,
                Revenue = from.Revenue,
                Remainder = from.Remainder,
                WasPayed = from.WasPayedByDental.HasValue ? from.WasPayedByDental.Value : false,
                MaterialCost = from.MaterialCost.HasValue ? from.MaterialCost.Value : 0,
                Percent = from.Percent
                //                WasExported = from.WasExported
            };
        }

        public static List<InterventionModel> ToInterventionModels(this IEnumerable<Intervention> from)
        {
            return from.Select(item => item.ToInterventionModel()).ToList();
        }
    }
}
