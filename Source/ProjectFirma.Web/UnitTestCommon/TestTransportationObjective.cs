using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.UnitTestCommon
{
    public static partial class TestFramework
    {
        public static class TestTransportationObjective
        {
            public static TransportationObjective Create()
            {
                var transportationStrategy = TestTransportationStrategy.Create();
                var transportationObjective = TransportationObjective.CreateNewBlank(transportationStrategy, FundingType.Capital);
                return transportationObjective;
            }

            /// <summary>
            /// Create new TransportationObjective and attach it to the given context
            /// </summary>
            public static TransportationObjective Create(DatabaseEntities dbContext)
            {
                var transportationStrategy = TestTransportationStrategy.Create(dbContext);
                var transportationObjective = new TransportationObjective(transportationStrategy,
                    MakeTestName("Test Transportation Objective Name", TransportationObjective.FieldLengths.TransportationObjectiveName),
                    FundingType.Capital);
                var newTransportationObjective = transportationObjective;
                dbContext.TransportationObjectives.Add(newTransportationObjective);
                return newTransportationObjective;
            }
        }
    }
}