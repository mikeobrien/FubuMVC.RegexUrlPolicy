require "albacore"
require_relative "filesystem"
require_relative "gallio-task"

reportsPath = "reports"
version = ENV["BUILD_NUMBER"]

task :build => :createPackage
task :deploy => :pushPackage

assemblyinfo :assemblyInfo do |asm|
    asm.version = version
    asm.company_name = "Ultraviolet Catastrophe"
    asm.product_name = "FubuMVC Regex Url Policy"
    asm.title = "FubuMVC Regex Url Policy"
    asm.description = "FubuMVC Regex Url Policy."
    asm.copyright = "Copyright (c) #{Time.now.year} Ultraviolet Catastrophe"
    asm.output_file = "src/RegexUrlPolicy/Properties/AssemblyInfo.cs"
end

msbuild :buildLibrary => :assemblyInfo do |msb|
    msb.properties :configuration => :Release
    msb.targets :Clean, :Build
    msb.solution = "src/RegexUrlPolicy/RegexUrlPolicy.csproj"
end

msbuild :buildTests => :buildLibrary do |msb|
    msb.properties :configuration => :Release
    msb.targets :Clean, :Build
    msb.solution = "src/Tests/Tests.csproj"
end

task :unitTestInit do
	FileSystem.EnsurePath(reportsPath)
end

gallio :unitTests => [:buildTests, :unitTestInit] do |runner|
	runner.echo_command_line = true
	runner.add_test_assembly("src/Tests/bin/Release/Tests.dll")
	runner.verbosity = 'Normal'
	runner.report_directory = reportsPath
	runner.report_name_format = 'tests'
	runner.add_report_type('Html')
end

nugetApiKey = ENV["NUGET_API_KEY"]
deployPath = "deploy"

packagePath = File.join(deployPath, "package")
nuspecFilename = "FubuMVC.RegexUrlPolicy.nuspec"
packageLibPath = File.join(packagePath, "lib")
binPath = "src/RegexUrlPolicy/bin/release"

task :prepPackage => :unitTests do
	FileSystem.DeleteDirectory(deployPath)
	FileSystem.EnsurePath(packageLibPath)
	FileSystem.CopyFiles(File.join(binPath, "FubuMVC.RegexUrlPolicy.dll"), packageLibPath)
	FileSystem.CopyFiles(File.join(binPath, "FubuMVC.RegexUrlPolicy.pdb"), packageLibPath)
end

nuspec :createSpec => :prepPackage do |nuspec|
   nuspec.id = "FubuMVC.RegexUrlPolicy"
   nuspec.version = version
   nuspec.authors = "Mike O'Brien"
   nuspec.owners = "Mike O'Brien"
   nuspec.title = "FubuMVC Regex Url Policy"
   nuspec.description = "Allows you to use regular expressions to ignore/include portions of the url as well as constraining actions to verbs."
   nuspec.summary = "Allows you to use regular expressions to ignore/include portions of the url as well as constraining actions to verbs."
   nuspec.language = "en-US"
   nuspec.licenseUrl = "https://github.com/mikeobrien/FubuMVC.RegexUrlPolicy/blob/master/LICENSE"
   nuspec.projectUrl = "https://github.com/mikeobrien/FubuMVC.RegexUrlPolicy"
   nuspec.iconUrl = "https://github.com/mikeobrien/FubuMVC.RegexUrlPolicy/raw/master/misc/logo.png"
   nuspec.working_directory = packagePath
   nuspec.output_file = nuspecFilename
   nuspec.tags = "fubumvc"
   nuspec.dependency "FubuMVC.References", "0.9.0.0"
end

nugetpack :createPackage => :createSpec do |nugetpack|
   nugetpack.nuspec = File.join(packagePath, nuspecFilename)
   nugetpack.base_folder = packagePath
   nugetpack.output = deployPath
end

nugetpush :pushPackage => :createPackage do |nuget|
    nuget.apikey = nugetApiKey
    nuget.package = File.join(deployPath, "FubuMVC.RegexUrlPolicy.#{version}.nupkg").gsub('/', '\\')
end