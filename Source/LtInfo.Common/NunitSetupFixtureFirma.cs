using NUnit.Framework;
using LtInfo.Common;

/// <summary>
/// Sets up the global logger for the project
/// </summary>
/// <remarks>A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly</remarks>
[SetUpFixture]
// ReSharper disable CheckNamespace
public class NunitSetupFixtureLtInfoCommon
// ReSharper restore CheckNamespace
{
    [SetUp]
    public void RunBeforeAnyTests()
    {
        SitkaLogger.RegisterLogger();
        log4net.Config.XmlConfigurator.Configure();
    }
}
