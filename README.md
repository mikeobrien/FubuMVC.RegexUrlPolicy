FubuMVC Regex Url Policy
=============

[![Nuget](http://img.shields.io/nuget/v/FubuMVC.RegexUrlPolicy.svg?style=flat)](http://www.nuget.org/packages/FubuMVC.RegexUrlPolicy/) [![Nuget downloads](http://img.shields.io/nuget/dt/FubuMVC.RegexUrlPolicy.svg?style=flat)](http://www.nuget.org/packages/FubuMVC.RegexUrlPolicy/) [![TeamCity Build Status](https://img.shields.io/teamcity/http/build.mikeobrien.net/s/fuburegexurlpolicy.svg?style=flat)](http://build.mikeobrien.net/viewType.html?buildTypeId=fuburegexurlpolicy&guest=1)

The [FubuMVC](http://mvc.fubu-project.org/) regex url policy allows you to use regular expressions to ignore/include portions of the url as well as constraining actions to verbs. The following demonstrates how to apply the policy:
        
    public class Conventions : FubuRegistry
    {        
        public Conventions()
        {    
            Routes.UrlPolicy(
                RegexUrlPolicy.Create(x => x.
                    .IgnoreAssemblyNamespace()
                    .IgnoreClassName()
                    .IgnoreMethodNames("Execute")
                    .ConstrainClassToGetEndingWith("GetHandler")
                    .ConstrainClassToPostEndingWith("PostHandler")
                    .ConstrainClassToPutEndingWith("PutHandler")
                    .ConstrainClassToUpdateEndingWith("UpdateHandler")
                    .ConstrainClassToDeleteEndingWith("DeleteHandler")));    
            ...
        }
    }

Installation
------------

    PM> Install-Package FubuMVC.RegexUrlPolicy  

Policy DSL
------------

The policy DSL contains the following methods:
  
    IgnoreNamespace()
    IgnoreNamespace<T>()
    IgnoreNamespace(Type type)
    IgnoreNamespaces(params string[] patterns)

    IgnoreAssemblyNamespace()
    IgnoreAssemblyNamespace<T>()
    IgnoreAssemblyNamespace(Type type)

    IgnoreClassName()
    IgnoreClassNames(params string[] patterns)
    
    IgnoreMethodName()
    IgnoreMethodNames(params string[] patterns)

    ConstrainNamespaceTo[Get|Post|Put|Update|Delete](params string[] patterns)
    ConstrainNamespaceTo[Get|Post|Put|Update|Delete]StartingWith(params string[] patterns)
    ConstrainNamespaceTo[Get|Post|Put|Update|Delete]EndingWith(params string[] patterns)

    ConstrainClassTo[Get|Post|Put|Update|Delete](params string[] patterns)
    ConstrainClassTo[Get|Post|Put|Update|Delete]StartingWith(params string[] patterns)
    ConstrainClassTo[Get|Post|Put|Update|Delete]EndingWith(params string[] patterns)

    ConstrainMethodTo[Get|Post|Put|Update|Delete](params string[] patterns)
    ConstrainMethodTo[Get|Post|Put|Update|Delete]StartingWith(params string[] patterns)
    ConstrainMethodTo[Get|Post|Put|Update|Delete]EndingWith(params string[] patterns)