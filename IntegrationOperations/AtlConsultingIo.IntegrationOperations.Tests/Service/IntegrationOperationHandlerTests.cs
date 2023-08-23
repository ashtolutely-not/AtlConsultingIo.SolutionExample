

using Moq;


namespace AtlConsultingIo.IntegrationOperations.Tests.Service
{
    public class IntegrationOperationHandlerTests
    {
        private MockRepository mockRepository;

        private Mock<OperationContext> mockOperationContext;
        private Mock<IntegrationOperationsLogger> mockIntegrationOperationsLogger;

        public IntegrationOperationHandlerTests()
        {
            this.mockRepository = new MockRepository( MockBehavior.Strict );

            this.mockOperationContext = this.mockRepository.Create<OperationContext>();
            this.mockIntegrationOperationsLogger = this.mockRepository.Create<IntegrationOperationsLogger>();
        }

        private IntegrationOperationHandler CreateIntegrationOperationHandler()
        {
            return new IntegrationOperationHandler(
                this.mockOperationContext.Object ,
                this.mockIntegrationOperationsLogger.Object );
        }

        [Fact]
        public async Task ExecuteOperation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var integrationOperationHandler = this.CreateIntegrationOperationHandler();
            object request = null;
            IIntegrationTransaction<RestClientJsonTransaction> operation = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await integrationOperationHandler.ExecuteOperation<>(
        request,
        operation,
        cancellationToken);

            // Assert
            Assert.True( false );
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ExecuteOperation_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var integrationOperationHandler = this.CreateIntegrationOperationHandler();
            object request = null;
            IIntegrationCommand<UpsertTableDocument> operation = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await integrationOperationHandler.ExecuteOperation(
        request,
        operation,
        cancellationToken);

            // Assert
            Assert.True( false );
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ExecuteOperation_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var integrationOperationHandler = this.CreateIntegrationOperationHandler();
            object request = null;
            IIntegrationQuery<RestClientJsonQuery> operation = null;
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await integrationOperationHandler.ExecuteOperation(
        request,
        operation,
        cancellationToken);

            // Assert
            Assert.True( false );
            this.mockRepository.VerifyAll();
        }
    }
}
