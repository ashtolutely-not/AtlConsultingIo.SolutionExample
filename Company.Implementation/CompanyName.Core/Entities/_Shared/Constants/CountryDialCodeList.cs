using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
namespace CompanyName.Core.Entities;
public record struct CountryDialCode( string CountryName , string CountryAbbreviation , string Code );
public struct CountryDialCodeList
{
    public static readonly List<CountryDialCode> Values = new List<CountryDialCode>
    {
        new CountryDialCode("Afghanistan", "AF", "+93"),
        new CountryDialCode("Aland Islands", "AX", "+358"),
        new CountryDialCode("Albania", "AL", "+355"),
        new CountryDialCode("Algeria", "DZ", "+213"),
        new CountryDialCode("AmericanSamoa", "AS", "+1684"),
        new CountryDialCode("Andorra", "AD", "+376"),
        new CountryDialCode("Angola", "AO", "+244"),
        new CountryDialCode("Anguilla", "AI", "+1264"),
        new CountryDialCode("Antarctica", "AQ", "+672"),
        new CountryDialCode("Antigua and Barbuda", "AG", "+1268"),
        new CountryDialCode("Argentina", "AR", "+54"),
        new CountryDialCode("Armenia", "AM", "+374"),
        new CountryDialCode("Aruba", "AW", "+297"),
        new CountryDialCode("Australia", "AU", "+61"),
        new CountryDialCode("Austria", "AT", "+43"),
        new CountryDialCode("Azerbaijan", "AZ", "+994"),
        new CountryDialCode("Bahamas", "BS", "+1242"),
        new CountryDialCode("Bahrain", "BH", "+973"),
        new CountryDialCode("Bangladesh", "BD", "+880"),
        new CountryDialCode("Barbados", "BB", "+1246"),
        new CountryDialCode("Belarus", "BY", "+375"),
        new CountryDialCode("Belgium", "BE", "+32"),
        new CountryDialCode("Belize", "BZ", "+501"),
        new CountryDialCode("Benin", "BJ", "+229"),
        new CountryDialCode("Bermuda", "BM", "+1441"),
        new CountryDialCode("Bhutan", "BT", "+975"),
        new CountryDialCode("Bolivia, Plurinational State of", "BO", "+591"),
        new CountryDialCode("Bosnia and Herzegovina", "BA", "+387"),
        new CountryDialCode("Botswana", "BW", "+267"),
        new CountryDialCode("Brazil", "BR", "+55"),
        new CountryDialCode("British Indian Ocean Territory", "IO", "+246"),
        new CountryDialCode("Brunei Darussalam", "BN", "+673"),
        new CountryDialCode("Bulgaria", "BG", "+359"),
        new CountryDialCode("Burkina Faso", "BF", "+226"),
        new CountryDialCode("Burundi", "BI", "+257"),
        new CountryDialCode("Cambodia", "KH", "+855"),
        new CountryDialCode("Cameroon", "CM", "+237"),
        new CountryDialCode("Canada", "CA", "+1"),
        new CountryDialCode("Cape Verde", "CV", "+238"),
        new CountryDialCode("Cayman Islands", "KY", "+ 345"),
        new CountryDialCode("Central African Republic", "CF", "+236"),
        new CountryDialCode("Chad", "TD", "+235"),
        new CountryDialCode("Chile", "CL", "+56"),
        new CountryDialCode("China", "CN", "+86"),
        new CountryDialCode("Christmas Island", "CX", "+61"),
        new CountryDialCode("Cocos (Keeling) Islands", "CC", "+61"),
        new CountryDialCode("Colombia", "CO", "+57"),
        new CountryDialCode("Comoros", "KM", "+269"),
        new CountryDialCode("Congo", "CG", "+242"),
        new CountryDialCode("Congo, The Democratic Republic of the Congo", "CD", "+243"),
        new CountryDialCode("Cook Islands", "CK", "+682"),
        new CountryDialCode("Costa Rica", "CR", "+506"),
        new CountryDialCode("Cote d'Ivoire", "CI", "+225"),
        new CountryDialCode("Croatia", "HR", "+385"),
        new CountryDialCode("Cuba", "CU", "+53"),
        new CountryDialCode("Cyprus", "CY", "+357"),
        new CountryDialCode("Czech Republic", "CZ", "+420"),
        new CountryDialCode("Denmark", "DK", "+45"),
        new CountryDialCode("Djibouti", "DJ", "+253"),
        new CountryDialCode("Dominica", "DM", "+1767"),
        new CountryDialCode("Dominican Republic", "DO", "+1849"),
        new CountryDialCode("Ecuador", "EC", "+593"),
        new CountryDialCode("Egypt", "EG", "+20"),
        new CountryDialCode("El Salvador", "SV", "+503"),
        new CountryDialCode("Equatorial Guinea", "GQ", "+240"),
        new CountryDialCode("Eritrea", "ER", "+291"),
        new CountryDialCode("Estonia", "EE", "+372"),
        new CountryDialCode("Ethiopia", "ET", "+251"),
        new CountryDialCode("Falkland Islands (Malvinas)", "FK", "+500"),
        new CountryDialCode("Faroe Islands", "FO", "+298"),
        new CountryDialCode("Fiji", "FJ", "+679"),
        new CountryDialCode("Finland", "FI", "+358"),
        new CountryDialCode("France", "FR", "+33"),
        new CountryDialCode("French Guiana", "GF", "+594"),
        new CountryDialCode("French Polynesia", "PF", "+689"),
        new CountryDialCode("Gabon", "GA", "+241"),
        new CountryDialCode("Gambia", "GM", "+220"),
        new CountryDialCode("Georgia", "GE", "+995"),
        new CountryDialCode("Germany", "DE", "+49"),
        new CountryDialCode("Ghana", "GH", "+233"),
        new CountryDialCode("Gibraltar", "GI", "+350"),
        new CountryDialCode("Greece", "GR", "+30"),
        new CountryDialCode("Greenland", "GL", "+299"),
        new CountryDialCode("Grenada", "GD", "+1473"),
        new CountryDialCode("Guadeloupe", "GP", "+590"),
        new CountryDialCode("Guam", "GU", "+1671"),
        new CountryDialCode("Guatemala", "GT", "+502"),
        new CountryDialCode("Guernsey", "GG", "+44"),
        new CountryDialCode("Guinea", "GN", "+224"),
        new CountryDialCode("Guinea-Bissau", "GW", "+245"),
        new CountryDialCode("Guyana", "GY", "+595"),
        new CountryDialCode("Haiti", "HT", "+509"),
        new CountryDialCode("Holy See (Vatican City State)", "VA", "+379"),
        new CountryDialCode("Honduras", "HN", "+504"),
        new CountryDialCode("Hong Kong", "HK", "+852"),
        new CountryDialCode("Hungary", "HU", "+36"),
        new CountryDialCode("Iceland", "IS", "+354"),
        new CountryDialCode("India", "IN", "+91"),
        new CountryDialCode("Indonesia", "ID", "+62"),
        new CountryDialCode("Iran, Islamic Republic of Persian Gulf", "IR", "+98"),
        new CountryDialCode("Iraq", "IQ", "+964"),
        new CountryDialCode("Ireland", "IE", "+353"),
        new CountryDialCode("Isle of Man", "IM", "+44"),
        new CountryDialCode("Israel", "IL", "+972"),
        new CountryDialCode("Italy", "IT", "+39"),
        new CountryDialCode("Jamaica", "JM", "+1876"),
        new CountryDialCode("Japan", "JP", "+81"),
        new CountryDialCode("Jersey", "JE", "+44"),
        new CountryDialCode("Jordan", "JO", "+962"),
        new CountryDialCode("Kazakhstan", "KZ", "+77"),
        new CountryDialCode("Kenya", "KE", "+254"),
        new CountryDialCode("Kiribati", "KI", "+686"),
        new CountryDialCode("Korea, Democratic People's Republic of Korea", "KP", "+850"),
        new CountryDialCode("Korea, Republic of South Korea", "KR", "+82"),
        new CountryDialCode("Kuwait", "KW", "+965"),
        new CountryDialCode("Kyrgyzstan", "KG", "+996"),
        new CountryDialCode("Laos", "LA", "+856"),
        new CountryDialCode("Latvia", "LV", "+371"),
        new CountryDialCode("Lebanon", "LB", "+961"),
        new CountryDialCode("Lesotho", "LS", "+266"),
        new CountryDialCode("Liberia", "LR", "+231"),
        new CountryDialCode("Libyan Arab Jamahiriya", "LY", "+218"),
        new CountryDialCode("Liechtenstein", "LI", "+423"),
        new CountryDialCode("Lithuania", "LT", "+370"),
        new CountryDialCode("Luxembourg", "LU", "+352"),
        new CountryDialCode("Macao", "MO", "+853"),
        new CountryDialCode("Macedonia", "MK", "+389"),
        new CountryDialCode("Madagascar", "MG", "+261"),
        new CountryDialCode("Malawi", "MW", "+265"),
        new CountryDialCode("Malaysia", "MY", "+60"),
        new CountryDialCode("Maldives", "MV", "+960"),
        new CountryDialCode("Mali", "ML", "+223"),
        new CountryDialCode("Malta", "MT", "+356"),
        new CountryDialCode("Marshall Islands", "MH", "+692"),
        new CountryDialCode("Martinique", "MQ", "+596"),
        new CountryDialCode("Mauritania", "MR", "+222"),
        new CountryDialCode("Mauritius", "MU", "+230"),
        new CountryDialCode("Mayotte", "YT", "+262"),
        new CountryDialCode("Mexico", "MX", "+52"),
        new CountryDialCode("Micronesia, Federated States of Micronesia", "FM", "+691"),
        new CountryDialCode("Moldova", "MD", "+373"),
        new CountryDialCode("Monaco", "MC", "+377"),
        new CountryDialCode("Mongolia", "MN", "+976"),
        new CountryDialCode("Montenegro", "ME", "+382"),
        new CountryDialCode("Montserrat", "MS", "+1664"),
        new CountryDialCode("Morocco", "MA", "+212"),
        new CountryDialCode("Mozambique", "MZ", "+258"),
        new CountryDialCode("Myanmar", "MM", "+95"),
        new CountryDialCode("Namibia", "NA", "+264"),
        new CountryDialCode("Nauru", "NR", "+674"),
        new CountryDialCode("Nepal", "NP", "+977"),
        new CountryDialCode("Netherlands", "NL", "+31"),
        new CountryDialCode("Netherlands Antilles", "AN", "+599"),
        new CountryDialCode("New Caledonia", "NC", "+687"),
        new CountryDialCode("New Zealand", "NZ", "+64"),
        new CountryDialCode("Nicaragua", "NI", "+505"),
        new CountryDialCode("Niger", "NE", "+227"),
        new CountryDialCode("Nigeria", "NG", "+234"),
        new CountryDialCode("Niue", "NU", "+683"),
        new CountryDialCode("Norfolk Island", "NF", "+672"),
        new CountryDialCode("Northern Mariana Islands", "MP", "+1670"),
        new CountryDialCode("Norway", "NO", "+47"),
        new CountryDialCode("Oman", "OM", "+968"),
        new CountryDialCode("Pakistan", "PK", "+92"),
        new CountryDialCode("Palau", "PW", "+680"),
        new CountryDialCode("Palestinian Territory, Occupied", "PS", "+970"),
        new CountryDialCode("Panama", "PA", "+507"),
        new CountryDialCode("Papua New Guinea", "PG", "+675"),
        new CountryDialCode("Paraguay", "PY", "+595"),
        new CountryDialCode("Peru", "PE", "+51"),
        new CountryDialCode("Philippines", "PH", "+63"),
        new CountryDialCode("Pitcairn", "PN", "+872"),
        new CountryDialCode("Poland", "PL", "+48"),
        new CountryDialCode("Portugal", "PT", "+351"),
        new CountryDialCode("Puerto Rico", "PR", "+1939"),
        new CountryDialCode("Qatar", "QA", "+974"),
        new CountryDialCode("Romania", "RO", "+40"),
        new CountryDialCode("Russia", "RU", "+7"),
        new CountryDialCode("Rwanda", "RW", "+250"),
        new CountryDialCode("Reunion", "RE", "+262"),
        new CountryDialCode("Saint Barthelemy", "BL", "+590"),
        new CountryDialCode("Saint Helena, Ascension and Tristan Da Cunha", "SH", "+290"),
        new CountryDialCode("Saint Kitts and Nevis", "KN", "+1869"),
        new CountryDialCode("Saint Lucia", "LC", "+1758"),
        new CountryDialCode("Saint Martin", "MF", "+590"),
        new CountryDialCode("Saint Pierre and Miquelon", "PM", "+508"),
        new CountryDialCode("Saint Vincent and the Grenadines", "VC", "+1784"),
        new CountryDialCode("Samoa", "WS", "+685"),
        new CountryDialCode("San Marino", "SM", "+378"),
        new CountryDialCode("Sao Tome and Principe", "ST", "+239"),
        new CountryDialCode("Saudi Arabia", "SA", "+966"),
        new CountryDialCode("Senegal", "SN", "+221"),
        new CountryDialCode("Serbia", "RS", "+381"),
        new CountryDialCode("Seychelles", "SC", "+248"),
        new CountryDialCode("Sierra Leone", "SL", "+232"),
        new CountryDialCode("Singapore", "SG", "+65"),
        new CountryDialCode("Slovakia", "SK", "+421"),
        new CountryDialCode("Slovenia", "SI", "+386"),
        new CountryDialCode("Solomon Islands", "SB", "+677"),
        new CountryDialCode("Somalia", "SO", "+252"),
        new CountryDialCode("South Africa", "ZA", "+27"),
        new CountryDialCode("South Sudan", "SS", "+211"),
        new CountryDialCode("South Georgia and the South Sandwich Islands", "GS", "+500"),
        new CountryDialCode("Spain", "ES", "+34"),
        new CountryDialCode("Sri Lanka", "LK", "+94"),
        new CountryDialCode("Sudan", "SD", "+249"),
        new CountryDialCode("Suriname", "SR", "+597"),
        new CountryDialCode("Svalbard and Jan Mayen", "SJ", "+47"),
        new CountryDialCode("Swaziland", "SZ", "+268"),
        new CountryDialCode("Sweden", "SE", "+46"),
        new CountryDialCode("Switzerland", "CH", "+41"),
        new CountryDialCode("Syrian Arab Republic", "SY", "+963"),
        new CountryDialCode("Taiwan", "TW", "+886"),
        new CountryDialCode("Tajikistan", "TJ", "+992"),
        new CountryDialCode("Tanzania, United Republic of Tanzania", "TZ", "+255"),
        new CountryDialCode("Thailand", "TH", "+66"),
        new CountryDialCode("Timor-Leste", "TL", "+670"),
        new CountryDialCode("Togo", "TG", "+228"),
        new CountryDialCode("Tokelau", "TK", "+690"),
        new CountryDialCode("Tonga", "TO", "+676"),
        new CountryDialCode("Trinidad and Tobago", "TT", "+1868"),
        new CountryDialCode("Tunisia", "TN", "+216"),
        new CountryDialCode("Turkey", "TR", "+90"),
        new CountryDialCode("Turkmenistan", "TM", "+993"),
        new CountryDialCode("Turks and Caicos Islands", "TC", "+1649"),
        new CountryDialCode("Tuvalu", "TV", "+688"),
        new CountryDialCode("Uganda", "UG", "+256"),
        new CountryDialCode("Ukraine", "UA", "+380"),
        new CountryDialCode("United Arab Emirates", "AE", "+971"),
        new CountryDialCode("United Kingdom", "GB", "+44"),
        new CountryDialCode("United States", "US", "+1"),
        new CountryDialCode("Uruguay", "UY", "+598"),
        new CountryDialCode("Uzbekistan", "UZ", "+998"),
        new CountryDialCode("Vanuatu", "VU", "+678"),
        new CountryDialCode("Venezuela, Bolivarian Republic of Venezuela", "VE", "+58"),
        new CountryDialCode("Vietnam", "VN", "+84"),
        new CountryDialCode("Virgin Islands, British", "VG", "+1284"),
        new CountryDialCode("Virgin Islands, U.S.", "VI", "+1340"),
        new CountryDialCode("Wallis and Futuna", "WF", "+681"),
        new CountryDialCode("Yemen", "YE", "+967"),
        new CountryDialCode("Zambia", "ZM", "+260"),
        new CountryDialCode("Zimbabwe", "ZW", "+263")
    };

    public static readonly CountryDialCode US = new("United States", "US", "+1");
}
