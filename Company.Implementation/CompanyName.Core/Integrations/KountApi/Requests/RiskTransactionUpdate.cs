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
using System.ComponentModel.DataAnnotations;

namespace CompanyName.Core.Integrations.KountApi;

public class RiskTransactionUpdate : RiskRequestBase
{
    [StringLength( 32 )]
    public string? OrderNumber
    {
        get => FormValues[ "ORDR" ];
        set => FormValues[ "ORDR" ] = value;
    }

    [StringLength( 32 )]
    public string? TransactionId
    {
        get => FormValues[ "TRAN" ];
        set => FormValues[ "TRAN" ] = value;
    }

    public RiskTransactionUpdate( string transactionId , bool isAuthorized ) : this( isAuthorized ) => TransactionId = transactionId;

    private RiskTransactionUpdate( bool authorized , string? encryption = null )
            : base( authorized ? "Y" : "N" , authorized ? "A" : "D" , encryption ) => RequestMode = KountUpdateType.UpdateOnly.ToString();
}
