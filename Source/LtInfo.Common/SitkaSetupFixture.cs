// ReSharper disable CheckNamespace
public class SitkaSetupFixture
// ReSharper restore CheckNamespace
{
    public virtual void RunBeforeAnyTests()
    {
        log4net.Config.XmlConfigurator.Configure();
    }
}
