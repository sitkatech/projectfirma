using ProjectFirma.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using NUnit.Framework;

/// <summary>
/// Sets up the global logger for the project
/// </summary>
/// <remarks>A SetUpFixture outside of any namespace provides SetUp and TearDown for the entire assembly</remarks>
[SetUpFixture]
// ReSharper disable CheckNamespace
public class ProjectFirmaSetupFixture
    // ReSharper restore CheckNamespace
{
    [SetUp]
    public void RunBeforeAnyTests()
    {
        // This is necesary for tests to pass, since many will try to initialize a URL route, and we normally create the route table when the web app starts.
        // So we deliberately build the route table ahead of time.
        RouteTableBuilder.Build(FirmaBaseController.AllControllerActionMethods, null, Global.AreasDictionary);
    }
}