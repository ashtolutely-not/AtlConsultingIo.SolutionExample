using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PeriodTypeId", "PeriodId", "CustomerId")]
[Index("PeriodId", "CustomerId", Name = "IX_PeriodVolumes_CustomerID")]
[Index("PeriodId", Name = "IX_PeriodVolumes_PeriodID")]
[Index("Volume90", Name = "IX_Vol90_Inc")]
[Index("CustomerId", "PeriodId", "PeriodTypeId", Name = "_dta_index_PeriodVolumes_5_2129391464__K3_K2_K1_6")]
[Index("Volume80", "PeriodId", Name = "_dta_index_PeriodVolumes_5_2129391464__K85_K2_84")]
public partial class PeriodVolume
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Key]
    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("RankID")]
    public int? RankId { get; set; }

    [Column("PaidRankID")]
    public int? PaidRankId { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume1 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume2 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume3 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume4 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume5 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume6 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume7 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume8 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume9 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume10 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume11 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume12 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume13 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume14 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume15 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume16 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume17 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume18 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume19 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume20 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume21 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume22 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume23 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume24 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume25 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume26 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume27 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume28 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume29 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume30 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume31 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume32 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume33 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume34 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume35 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume36 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume37 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume38 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume39 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume40 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume41 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume42 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume43 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume44 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume45 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume46 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume47 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume48 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume49 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume50 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume51 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume52 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume53 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume54 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume55 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume56 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume57 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume58 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume59 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume60 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume61 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume62 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume63 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume64 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume65 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume66 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume67 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume68 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume69 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume70 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume71 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume72 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume73 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume74 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume75 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume76 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume77 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume78 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume79 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume80 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume81 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume82 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume83 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume84 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume85 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume86 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume87 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume88 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume89 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume90 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume91 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume92 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume93 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume94 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume95 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume96 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume97 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume98 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume99 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume100 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume101 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume102 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume103 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume104 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume105 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume106 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume107 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume108 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume109 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume110 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume111 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume112 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume113 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume114 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume115 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume116 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume117 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume118 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume119 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume120 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume121 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume122 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume123 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume124 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume125 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume126 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume127 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume128 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume129 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume130 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume131 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume132 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume133 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume134 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume135 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume136 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume137 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume138 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume139 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume140 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume141 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume142 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume143 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume144 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume145 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume146 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume147 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume148 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume149 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume150 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume151 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume152 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume153 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume154 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume155 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume156 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume157 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume158 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume159 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume160 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume161 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume162 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume163 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume164 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume165 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume166 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume167 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume168 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume169 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume170 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume171 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume172 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume173 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume174 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume175 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume176 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume177 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume178 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume179 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume180 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume181 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume182 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume183 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume184 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume185 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume186 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume187 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume188 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume189 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume190 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume191 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume192 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume193 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume194 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume195 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume196 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume197 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume198 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume199 { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume200 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public string? OtherData1 { get; set; }

    public string? OtherData2 { get; set; }

    public string? OtherData3 { get; set; }

    public string? OtherData4 { get; set; }

    public string? OtherData5 { get; set; }

    public string? OtherData6 { get; set; }

    public string? OtherData7 { get; set; }
}
