using FubuMVC.RegexUrlPolicy;
using NUnit.Framework;
using Should;

namespace Tests
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        [TestCase("", false)]
        [TestCase("/build/img/2colimghttp:/yada/1.png", false)]
        [TestCase("/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx" +
            "/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx" +
            "/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx" +
            "/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/xxxxxxxxx/", false)]
        [TestCase(@"/""http:/www.yada.com/images/2011/home-2-1-Leagues.gif/""", false)]
        [TestCase("/yada/yada.gif", true)]
        [TestCase("//MAClogo-2.png", true)]
        [TestCase("/client_files/2.png", true)]
        public void should_determine_valid_path(string path, bool valid)
        {
            path.IsValidPath().ShouldEqual(valid);
        }
    } 
}