using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PulsarFit.COMMON.Helpers;
using PulsarFit.CORE.Constants;
using PulsarFit.CORE.Domain;
using PulsarFit.DAL.Services;

namespace PulsarFit.WEB.Helpers
{
    public class DropdownHelper
    {
        public async Task<List<SelectListItem>> GetCountries(bool includeChooseOption = true, CountrySearchRequest searchRequest = null)
        {
            return GetDropDown(
                (await _serviceProvider.GetService<ICountriesService>().Get(searchRequest))?.Items,
                item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name },
                includeChooseOption ? _localizer.Select_country : string.Empty);
        }

        public async Task<List<SelectListItem>> GetCities(bool includeChooseOption = true, CitySearchRequest searchRequest = null)
        {
            return GetDropDown(
                (await _serviceProvider.GetService<ICitiesService>().Get(searchRequest))?.Items,
                item => new SelectListItem() { Value = item.Id.ToString(), Text = item.Name },
                includeChooseOption ? _localizer.Select_city : string.Empty);
        }

        public async Task<List<SelectListItem>> GetCurrencies(bool includeChooseOption = true, CurrencySearchRequest searchRequest = null)
        {
            return GetDropDown(
                (await _serviceProvider.GetService<ICurrenciesService>().Get(searchRequest))?.Items,
                item => new SelectListItem() { Value = item.Id.ToString(), Text = $"{item.Name} - {item.Symbol}" },
                includeChooseOption ? _localizer.Select_currency : string.Empty);
        }

        public async Task<List<SelectListItem>> GetGenders(bool includeChooseOption = true)
        {
            return GetDropDown(
                new List<SelectListItem>
                {
                    new SelectListItem { Value = ((int)Enumerations.Gender.Male).ToString(), Text = _localizer.Male },
                    new SelectListItem { Value = ((int)Enumerations.Gender.Female).ToString(), Text = _localizer.Female },
                },
                item => item,
                includeChooseOption ? _localizer.Select_gender : string.Empty);
        }

        public async Task<List<SelectListItem>> GetRoles(bool includeChooseOption = true)
        {
            return GetDropDown(
                new List<SelectListItem>
                {
                    new SelectListItem { Value = ((int)Enumerations.Role.Client).ToString(), Text = _localizer.Client },
                    new SelectListItem { Value = ((int)Enumerations.Role.Trainer).ToString(), Text = _localizer.Trainer },
                    new SelectListItem { Value = ((int)Enumerations.Role.Admin).ToString(), Text = _localizer.Admin },
                    new SelectListItem { Value = ((int)Enumerations.Role.Superadmin).ToString(), Text = _localizer.Superadmin },
                },
                item => item,
                includeChooseOption ? _localizer.Select_user_type : string.Empty);
        }

        #region General

        Localizer _localizer;
        IServiceProvider _serviceProvider;

        public DropdownHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _localizer = serviceProvider.GetService<Localizer>();
        }

        public List<SelectListItem> GetDropDown<T>(List<T> list, Func<T, SelectListItem> getObject, string includeChooseOption = "")
        {
            var selectList = new List<SelectListItem>();

            if (includeChooseOption != string.Empty)
                selectList.Add(new SelectListItem() { Value = string.Empty, Text = includeChooseOption });

            foreach (var item in list)
                selectList.Add(getObject(item));

            return selectList;
        }

        #endregion
    }
}
