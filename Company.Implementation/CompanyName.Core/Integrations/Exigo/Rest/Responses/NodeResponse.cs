// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record NodeResponse
{
    public int CustomerID { get; init; }
    public int NodeID { get; init; }
    public int ParentID { get; init; }
    public int Level { get; init; }
    public int Position { get; init; }
    public int CustomerType { get; init; }
    public int CustomerStatus { get; init; }
    public int RankID { get; init; }
    public int PayRankID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public DateTime CreatedDate { get; init; }
    public Decimal Volume1 { get; init; }
    public Decimal Volume2 { get; init; }
    public Decimal Volume3 { get; init; }
    public Decimal Volume4 { get; init; }
    public Decimal Volume5 { get; init; }
    public Decimal Volume6 { get; init; }
    public Decimal Volume7 { get; init; }
    public Decimal Volume8 { get; init; }
    public Decimal Volume9 { get; init; }
    public Decimal Volume10 { get; init; }
    public Decimal Volume11 { get; init; }
    public Decimal Volume12 { get; init; }
    public Decimal Volume13 { get; init; }
    public Decimal Volume14 { get; init; }
    public Decimal Volume15 { get; init; }
    public Decimal Volume16 { get; init; }
    public Decimal Volume17 { get; init; }
    public Decimal Volume18 { get; init; }
    public Decimal Volume19 { get; init; }
    public Decimal Volume20 { get; init; }
    public Decimal Volume21 { get; init; }
    public Decimal Volume22 { get; init; }
    public Decimal Volume23 { get; init; }
    public Decimal Volume24 { get; init; }
    public Decimal Volume25 { get; init; }
    public Decimal Volume26 { get; init; }
    public Decimal Volume27 { get; init; }
    public Decimal Volume28 { get; init; }
    public Decimal Volume29 { get; init; }
    public Decimal Volume30 { get; init; }
    public Decimal Volume31 { get; init; }
    public Decimal Volume32 { get; init; }
    public Decimal Volume33 { get; init; }
    public Decimal Volume34 { get; init; }
    public Decimal Volume35 { get; init; }
    public Decimal Volume36 { get; init; }
    public Decimal Volume37 { get; init; }
    public Decimal Volume38 { get; init; }
    public Decimal Volume39 { get; init; }
    public Decimal Volume40 { get; init; }
    public Decimal Volume41 { get; init; }
    public Decimal Volume42 { get; init; }
    public Decimal Volume43 { get; init; }
    public Decimal Volume44 { get; init; }
    public Decimal Volume45 { get; init; }
    public Decimal Volume46 { get; init; }
    public Decimal Volume47 { get; init; }
    public Decimal Volume48 { get; init; }
    public Decimal Volume49 { get; init; }
    public Decimal Volume50 { get; init; }
    public Decimal Volume51 { get; init; }
    public Decimal Volume52 { get; init; }
    public Decimal Volume53 { get; init; }
    public Decimal Volume54 { get; init; }
    public Decimal Volume55 { get; init; }
    public Decimal Volume56 { get; init; }
    public Decimal Volume57 { get; init; }
    public Decimal Volume58 { get; init; }
    public Decimal Volume59 { get; init; }
    public Decimal Volume60 { get; init; }
    public Decimal Volume61 { get; init; }
    public Decimal Volume62 { get; init; }
    public Decimal Volume63 { get; init; }
    public Decimal Volume64 { get; init; }
    public Decimal Volume65 { get; init; }
    public Decimal Volume66 { get; init; }
    public Decimal Volume67 { get; init; }
    public Decimal Volume68 { get; init; }
    public Decimal Volume69 { get; init; }
    public Decimal Volume70 { get; init; }
    public Decimal Volume71 { get; init; }
    public Decimal Volume72 { get; init; }
    public Decimal Volume73 { get; init; }
    public Decimal Volume74 { get; init; }
    public Decimal Volume75 { get; init; }
    public Decimal Volume76 { get; init; }
    public Decimal Volume77 { get; init; }
    public Decimal Volume78 { get; init; }
    public Decimal Volume79 { get; init; }
    public Decimal Volume80 { get; init; }
    public Decimal Volume81 { get; init; }
    public Decimal Volume82 { get; init; }
    public Decimal Volume83 { get; init; }
    public Decimal Volume84 { get; init; }
    public Decimal Volume85 { get; init; }
    public Decimal Volume86 { get; init; }
    public Decimal Volume87 { get; init; }
    public Decimal Volume88 { get; init; }
    public Decimal Volume89 { get; init; }
    public Decimal Volume90 { get; init; }
    public Decimal Volume91 { get; init; }
    public Decimal Volume92 { get; init; }
    public Decimal Volume93 { get; init; }
    public Decimal Volume94 { get; init; }
    public Decimal Volume95 { get; init; }
    public Decimal Volume96 { get; init; }
    public Decimal Volume97 { get; init; }
    public Decimal Volume98 { get; init; }
    public Decimal Volume99 { get; init; }
    public Decimal Volume100 { get; init; }
    public Decimal Volume101 { get; init; }
    public Decimal Volume102 { get; init; }
    public Decimal Volume103 { get; init; }
    public Decimal Volume104 { get; init; }
    public Decimal Volume105 { get; init; }
    public Decimal Volume106 { get; init; }
    public Decimal Volume107 { get; init; }
    public Decimal Volume108 { get; init; }
    public Decimal Volume109 { get; init; }
    public Decimal Volume110 { get; init; }
    public Decimal Volume111 { get; init; }
    public Decimal Volume112 { get; init; }
    public Decimal Volume113 { get; init; }
    public Decimal Volume114 { get; init; }
    public Decimal Volume115 { get; init; }
    public Decimal Volume116 { get; init; }
    public Decimal Volume117 { get; init; }
    public Decimal Volume118 { get; init; }
    public Decimal Volume119 { get; init; }
    public Decimal Volume120 { get; init; }
    public Decimal Volume121 { get; init; }
    public Decimal Volume122 { get; init; }
    public Decimal Volume123 { get; init; }
    public Decimal Volume124 { get; init; }
    public Decimal Volume125 { get; init; }
    public Decimal Volume126 { get; init; }
    public Decimal Volume127 { get; init; }
    public Decimal Volume128 { get; init; }
    public Decimal Volume129 { get; init; }
    public Decimal Volume130 { get; init; }
    public Decimal Volume131 { get; init; }
    public Decimal Volume132 { get; init; }
    public Decimal Volume133 { get; init; }
    public Decimal Volume134 { get; init; }
    public Decimal Volume135 { get; init; }
    public Decimal Volume136 { get; init; }
    public Decimal Volume137 { get; init; }
    public Decimal Volume138 { get; init; }
    public Decimal Volume139 { get; init; }
    public Decimal Volume140 { get; init; }
    public Decimal Volume141 { get; init; }
    public Decimal Volume142 { get; init; }
    public Decimal Volume143 { get; init; }
    public Decimal Volume144 { get; init; }
    public Decimal Volume145 { get; init; }
    public Decimal Volume146 { get; init; }
    public Decimal Volume147 { get; init; }
    public Decimal Volume148 { get; init; }
    public Decimal Volume149 { get; init; }
    public Decimal Volume150 { get; init; }
    public Decimal Volume151 { get; init; }
    public Decimal Volume152 { get; init; }
    public Decimal Volume153 { get; init; }
    public Decimal Volume154 { get; init; }
    public Decimal Volume155 { get; init; }
    public Decimal Volume156 { get; init; }
    public Decimal Volume157 { get; init; }
    public Decimal Volume158 { get; init; }
    public Decimal Volume159 { get; init; }
    public Decimal Volume160 { get; init; }
    public Decimal Volume161 { get; init; }
    public Decimal Volume162 { get; init; }
    public Decimal Volume163 { get; init; }
    public Decimal Volume164 { get; init; }
    public Decimal Volume165 { get; init; }
    public Decimal Volume166 { get; init; }
    public Decimal Volume167 { get; init; }
    public Decimal Volume168 { get; init; }
    public Decimal Volume169 { get; init; }
    public Decimal Volume170 { get; init; }
    public Decimal Volume171 { get; init; }
    public Decimal Volume172 { get; init; }
    public Decimal Volume173 { get; init; }
    public Decimal Volume174 { get; init; }
    public Decimal Volume175 { get; init; }
    public Decimal Volume176 { get; init; }
    public Decimal Volume177 { get; init; }
    public Decimal Volume178 { get; init; }
    public Decimal Volume179 { get; init; }
    public Decimal Volume180 { get; init; }
    public Decimal Volume181 { get; init; }
    public Decimal Volume182 { get; init; }
    public Decimal Volume183 { get; init; }
    public Decimal Volume184 { get; init; }
    public Decimal Volume185 { get; init; }
    public Decimal Volume186 { get; init; }
    public Decimal Volume187 { get; init; }
    public Decimal Volume188 { get; init; }
    public Decimal Volume189 { get; init; }
    public Decimal Volume190 { get; init; }
    public Decimal Volume191 { get; init; }
    public Decimal Volume192 { get; init; }
    public Decimal Volume193 { get; init; }
    public Decimal Volume194 { get; init; }
    public Decimal Volume195 { get; init; }
    public Decimal Volume196 { get; init; }
    public Decimal Volume197 { get; init; }
    public Decimal Volume198 { get; init; }
    public Decimal Volume199 { get; init; }
    public Decimal Volume200 { get; init; }
    public string CustomerKey { get; init; }

    public NodeResponse() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        CustomerKey = String.Empty;
    }
}
