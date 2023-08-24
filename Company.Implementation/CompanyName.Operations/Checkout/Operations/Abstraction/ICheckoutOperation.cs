namespace CompanyName.Operations.Checkout;

public interface ICheckoutOperation<TOperation,TResult> where TOperation : class 
{
    string? OperationError { get;  }
    TResult? Result { get;  }

    Task<TOperation> ExecuteAsync(CancellationToken cancellationToken);

}
