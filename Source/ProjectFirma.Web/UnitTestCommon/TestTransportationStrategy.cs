using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTransportationStrategy
        {
            public static TransportationStrategy Create()
            {
                var transportationStrategy = TransportationStrategy.CreateNewBlank();
                return transportationStrategy;
            }

            public static TransportationStrategy Create(DatabaseEntities dbContext)
            {
                var transportationStrategy = new TransportationStrategy(MakeTestName("Test Transportation Strategy Name", TransportationStrategy.FieldLengths.TransportationStrategyName));
                dbContext.TransportationStrategies.Add(transportationStrategy);
                return transportationStrategy;
            }
        }
    }
}