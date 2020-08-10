using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;

namespace PulsarFit.COMMON.Helpers
{
    public class Localizer
    {
        public string Unknown => _localizer[nameof(Unknown)];
        public string Ip_address => _localizer[nameof(Ip_address)];
        public string Sign_out => _localizer[nameof(Sign_out)];
        public string Sign_out_and_delete => _localizer[nameof(Sign_out_and_delete)];
        public string Device => _localizer[nameof(Device)];
        public string Login_sessions => _localizer[nameof(Login_sessions)];
        public string Select_role => _localizer[nameof(Select_role)];
        public string Home => _localizer[nameof(Home)];
        public string Print => _localizer[nameof(Print)];
        public string Please_confirm_that_you_want_to_delete_this_item => _localizer[nameof(Please_confirm_that_you_want_to_delete_this_item)];
        public string Warning => _localizer[nameof(Warning)];
        public string Client => _localizer[nameof(Client)];
        public string Trainer => _localizer[nameof(Trainer)];
        public string Admin => _localizer[nameof(Admin)];
        public string Superadmin => _localizer[nameof(Superadmin)];
        public string Male => _localizer[nameof(Male)];
        public string Female => _localizer[nameof(Female)];
        public string Select_gender => _localizer[nameof(Select_gender)];
        public string Select_user_type => _localizer[nameof(Select_user_type)];
        public string Gender => _localizer[nameof(Gender)];
        public string UserType => _localizer[nameof(UserType)];
        public string Please_wait => _localizer[nameof(Please_wait)];
        public string No_records_found => _localizer[nameof(No_records_found)];
        public string First => _localizer[nameof(First)];
        public string Previous => _localizer[nameof(Previous)];
        public string Next => _localizer[nameof(Next)];
        public string Last => _localizer[nameof(Last)];
        public string More_pages => _localizer[nameof(More_pages)];
        public string Page_number => _localizer[nameof(Page_number)];
        public string Select_page_size => _localizer[nameof(Select_page_size)];
        public string Displaying => _localizer[nameof(Displaying)];
        public string Of => _localizer[nameof(Of)];
        public string Records => _localizer[nameof(Records)];
        public string Details => _localizer[nameof(Details)];
        public string Edit => _localizer[nameof(Edit)];
        public string Delete => _localizer[nameof(Delete)];
        public string Clear => _localizer[nameof(Clear)];
        public string City => _localizer[nameof(City)];
        public string Users => _localizer[nameof(Users)];
        public string Add_user => _localizer[nameof(Add_user)];
        public string Edit_user => _localizer[nameof(Edit_user)];
        public string FirstName => _localizer[nameof(FirstName)];
        public string LastName => _localizer[nameof(LastName)];
        public string Select_currency => _localizer[nameof(Select_currency)];
        public string Currencies => _localizer[nameof(Currencies)];
        public string Currency => _localizer[nameof(Currency)];
        public string Add_currency => _localizer[nameof(Add_currency)];
        public string Edit_currency => _localizer[nameof(Edit_currency)];
        public string Symbol => _localizer[nameof(Symbol)];
        public string Cities => _localizer[nameof(Cities)];
        public string Add_city => _localizer[nameof(Add_city)];
        public string Edit_city => _localizer[nameof(Edit_city)];
        public string Country => _localizer[nameof(Country)];
        public string Authorization => _localizer[nameof(Authorization)];
        public string Countries => _localizer[nameof(Countries)];
        public string Add_country => _localizer[nameof(Add_country)];
        public string Edit_country => _localizer[nameof(Edit_country)];
        public string City_details => _localizer[nameof(City_details)];
        public string Country_details => _localizer[nameof(Country_details)];
        public string Currency_details => _localizer[nameof(Currency_details)];
        public string Language_details => _localizer[nameof(Language_details)];
        public string Role_details => _localizer[nameof(Role_details)];
        public string Code => _localizer[nameof(Code)];
        public string Controllers => _localizer[nameof(Controllers)];
        public string Actions => _localizer[nameof(Actions)];
        public string Languages => _localizer[nameof(Languages)];
        public string Add_language => _localizer[nameof(Add_language)];
        public string Edit_language => _localizer[nameof(Edit_language)];
        public string Roles => _localizer[nameof(Roles)];
        public string Add_role => _localizer[nameof(Add_role)];
        public string Edit_role => _localizer[nameof(Edit_role)];
        public string Description => _localizer[nameof(Description)];
        public string Close => _localizer[nameof(Close)];
        public string Save => _localizer[nameof(Save)];
        public string Save_and_continue => _localizer[nameof(Save_and_continue)];
        public string Today => _localizer[nameof(Today)];
        public string Last_7_days => _localizer[nameof(Last_7_days)];
        public string Last_30_days => _localizer[nameof(Last_30_days)];
        public string This_month => _localizer[nameof(This_month)];
        public string Last_month => _localizer[nameof(Last_month)];
        public string Yesterday => _localizer[nameof(Yesterday)];
        public string Dashboard => _localizer[nameof(Dashboard)];
        public string Daily_user_registrations => _localizer[nameof(Daily_user_registrations)];
        public string Home_page => _localizer[nameof(Home_page)];
        public string User_roles => _localizer[nameof(User_roles)];
        public string Issues => _localizer[nameof(Issues)];
        public string Geo_locations => _localizer[nameof(Geo_locations)];
        public string Settings => _localizer[nameof(Settings)];
        public string Documentation => _localizer[nameof(Documentation)];
        public string My_profile => _localizer[nameof(My_profile)];
        public string Messages => _localizer[nameof(Messages)];
        public string Support => _localizer[nameof(Support)];
        public string Logout => _localizer[nameof(Logout)];
        public string Register => _localizer[nameof(Register)];
        public string Bosnian => _localizer[nameof(Bosnian)];
        public string English => _localizer[nameof(English)];
        public string German => _localizer[nameof(German)];
        public string Sign_up_to => _localizer[nameof(Sign_up_to)];
        public string First_name => _localizer[nameof(First_name)];
        public string Last_name => _localizer[nameof(Last_name)];
        public string Email => _localizer[nameof(Email)];
        public string Password_confirm => _localizer[nameof(Password_confirm)];
        public string Add_success => _localizer[nameof(Add_success)];
        public string Add_error => _localizer[nameof(Add_error)];
        public string Edit_success => _localizer[nameof(Edit_success)];
        public string Edit_error => _localizer[nameof(Edit_error)];
        public string Delete_success => _localizer[nameof(Delete_success)];
        public string Delete_error => _localizer[nameof(Delete_error)];
        public string Required_field => _localizer[nameof(Required_field)];
        public string Select_country => _localizer[nameof(Select_country)];
        public string Select_region => _localizer[nameof(Select_region)];
        public string Select_city => _localizer[nameof(Select_city)];
        public string Login => _localizer[nameof(Login)];
        public string Login_error => _localizer[nameof(Login_error)];
        public string Invalid_username_or_password => _localizer[nameof(Invalid_username_or_password)];
        public string Something_went_wrong_here => _localizer[nameof(Something_went_wrong_here)];
        public string It_seams_that_you_are_not_authorized_for => _localizer[nameof(It_seams_that_you_are_not_authorized_for)];
        public string This_part_of_the_system => _localizer[nameof(This_part_of_the_system)];
        public string Dont_have_an_account_yet_questionmark => _localizer[nameof(Dont_have_an_account_yet_questionmark)];
        public string Sign_in_to => _localizer[nameof(Sign_in_to)];
        public string Sign_in => _localizer[nameof(Sign_in)];
        public string Sign_up => _localizer[nameof(Sign_up)];
        public string Username => _localizer[nameof(Username)];
        public string Password => _localizer[nameof(Password)];
        public string Name => _localizer[nameof(Name)];
        public string Search => _localizer[nameof(Search)];
        public string Translate(string key) => _localizer[key];



        private readonly IStringLocalizer _localizer;

        public static IList<CultureInfo> supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("bs-Latn-BA"),
            new CultureInfo("de"),
        };
        
        public Localizer(IStringLocalizerFactory localizerFactory)
        {
            _localizer = localizerFactory.Create("Resource", typeof(Localizer).Assembly.FullName);
        }
    }
}
