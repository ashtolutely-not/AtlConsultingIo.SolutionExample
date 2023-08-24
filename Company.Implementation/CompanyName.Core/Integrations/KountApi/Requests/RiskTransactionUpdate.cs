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
