using CSharpToTypeScript.Exceptions;
using CSharpToTypeScript.Services;

try
{
    /* 
        See SolutionExplorer / CSharpToTypeScript / Assumptions (folder):

        Valid_HappyPath.cs
        Valid_MultipleOneLevel.cs

        Invalid_WithEmptyLines.cs
        Invalid_WithNonPublicModifiers.cs
        Invalid_WithNotSupportedTypes.cs
        Invalid_MoreThanOneNestedLevel.cs
        Invalid_MultipleCombinationErrors.cs
    */

    var reader = new ScriptReaderService();
    await reader.ReadAsync("Assumptions/Valid_HappyPath.cs");

    reader.Validate();

    reader.GenerateTypeScriptFormat();
}
catch (EmptyFileException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}