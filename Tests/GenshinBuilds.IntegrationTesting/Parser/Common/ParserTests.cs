namespace GenshinBuilds.IntegrationTesting.Parser;

public class ParserTests<TParser>
{
    protected TParser Parser;

    [SetUp]
    public void Setup()
    {
        var type = typeof(TParser);
        var constructor = type.GetConstructor(new Type[] { typeof(HtmlWeb) });
        var instanse = constructor?.Invoke(new object[] { new HtmlWeb() });
        Parser = (TParser)instanse;
    }
}
