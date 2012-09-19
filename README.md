FubuMVC Regex Url Policy
=============

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

Policy Dsl
------------

The policy Dsl contains the following methods:
  
    IgnoreNamespace()
    IgnoreNamespaces(params string[] patterns)
    IgnoreNamespace<T>()

    IgnoreAssemblyNamespace(Type type)
    IgnoreAssemblyNamespace<T>()
    IgnoreAssemblyNamespace()

    IgnoreClassName()
    IgnoreClassNames(params string[] patterns)
    
    IgnoreMethodName()
    IgnoreMethodNames(params string[] patterns)

    ConstrainNamespaceToGet(params string[] patterns)
    ConstrainNamespaceToPost(params string[] patterns)
    ConstrainNamespaceToPut(params string[] patterns)
    ConstrainNamespaceToUpdate(params string[] patterns)
    ConstrainNamespaceToDelete(params string[] patterns)

    ConstrainClassToGet(params string[] patterns)
    ConstrainClassToPost(params string[] patterns)
    ConstrainClassToPut(params string[] patterns)
    ConstrainClassToUpdate(params string[] patterns)
    ConstrainClassToDelete(params string[] patterns)

    ConstrainClassToGetStartingWith(params string[] patterns)
    ConstrainClassToPostStartingWith(params string[] patterns)
    ConstrainClassToPutStartingWith(params string[] patterns)
    ConstrainClassToUpdateStartingWith(params string[] patterns)
    ConstrainClassToDeleteStartingWith(params string[] patterns)

    ConstrainClassToGetEndingWith(params string[] patterns)
    ConstrainClassToPostEndingWith(params string[] patterns)
    ConstrainClassToPutEndingWith(params string[] patterns)
    ConstrainClassToUpdateEndingWith(params string[] patterns)
    ConstrainClassToDeleteEndingWith(params string[] patterns)

    ConstrainMethodToGet(params string[] patterns)
    ConstrainMethodToPost(params string[] patterns)
    ConstrainMethodToPut(params string[] patterns)
    ConstrainMethodToUpdate(params string[] patterns)
    ConstrainMethodToDelete(params string[] patterns)

    ConstrainMethodToGetStartingWith(params string[] patterns)
    ConstrainMethodToPostStartingWith(params string[] patterns)
    ConstrainMethodToPutStartingWith(params string[] patterns)
    ConstrainMethodToUpdateStartingWith(params string[] patterns)
    ConstrainMethodToDeleteStartingWith(params string[] patterns)