C# Tests

    Allowed editors: Visual Studio Code
    All tests should be inside a separate folder and named as specified in each task
    All your test files will be executed using dotnet test
    We strongly encourage you to work together on tests so that you don’t miss any edge cases

More Info

In past C# assignments, you have been creating individual console application projects for each task. In this assignment, you are going to create a solution file to allow you to manage multiple projects. Each task is one solution containing two projects: one class library solving the task and one test library to test the class library.

For each task in this project:

    Create task directory (ex: 0-add)
    Inside that directory, run dotnet new sln
    Create a new directory for your task solution based on the namespace given (ex: MyMath). This directory will hold your new standard class library.
    Inside that directory, run dotnet new classlib. Rename the resulting .cs file after the namespace (ex: MyMath.cs)
    Enable XML documentation by adding <DocumentationFile>bin\$(Configuration)\$(TargetFramework)\$(AssemblyName).xml</DocumentationFile> to MyMath.csproj
        The target framework for this standard class library should be netstandard2.0
    Change directory back to the root directory of the task (ex: 0-add) and run dotnet sln add <classlibrary/classlibrary.csproj> (ex. dotnet sln add MyMath/MyMath.csproj)
    Create a new directory for your tests based on the namespace given plus .Tests (ex: MyMath.Tests). This directory will hold your test library.
        The target framework for this library should be netcoreapp2.1
    Inside that directory, run dotnet new nunit. Rename the resulting .cs file after the namespace of classes you are testing plus .Tests (ex: MyMath.Tests.cs)
    To add your class library as a dependency to the project, run dotnet add reference <../classlibrary/classlibrary.csproj> (ex: dotnet add reference ../MyMath/MyMath.csproj)
    In the task’s root directory, run dotnet sln add <testlibrary/testlibrary.csproj (ex: dotnet sln add MyMath.Tests/MyMath.Tests.csproj)
    If you’d like to run your class library method in a console application, create a new directory and run dotnet new console inside it. Run dotnet add reference <../classlibrary/classlibrary.csproj> and you can then call your class library methods inside the console application.

For more detail, read the Unit Testing C# with NUnit and .NET Core tutorial.

The resulting directory hierarchy for task #0 will look like this:

/0-add
    0-add.sln
    /MyMath
        MyMath.cs
        MyMath.csproj
    /MyMath.Tests
        MyMath.Tests.cs
        MyMath.Tests.csproj

For this project:

    Based on the requirements of each task, you should write the documentation and tests first before you actually code anything
    The intranet checks for C# projects won’t be released before their first deadline in order for you to focus more on TDD and thinking about all possible cases
    We strongly encourage you to work together on tests so that you don’t miss any edge cases
    Don’t trust the user, always think about all possible edge cases

Note: The videos provided as resources use Visual Studio, not Visual Studio Code. While the two programs differ, the methods and concepts behind unit testing are the same.

If NUnit is not already installed, use the command: dotnet new -i NUnit3.DotNetNew.Template
