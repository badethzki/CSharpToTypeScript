using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Services;

namespace CSharpToTypeScript.Validators;

public class OneLevelNestedClassFormatValidator(
    ScriptSyntaxService scriptSyntaxService) : IScriptFormatValidator
{
    public void ValidateScriptFormat(IReadOnlyList<ScriptLine> scriptLines)
    {
        scriptSyntaxService.GenerateSyntaxes(scriptLines);

        scriptSyntaxService.SetParentScope();

        var sortedSyntaxes = scriptSyntaxService.Syntaxes;

        var parentClass = sortedSyntaxes
            .OrderBy(s => s.LineNumber)
            .First()!;

        var invalidNestedClasses = sortedSyntaxes
            .Where(s => s.LineSyntaxType == LineSyntaxType.Class &&
                        s.ParentScopeId != parentClass.ScopeId &&
                        !string.IsNullOrWhiteSpace(s.ParentScopeId))
            .GroupBy(s => s.ParentScopeId)
            .SelectMany(s => s.Select(childClass => childClass))
            .OrderBy(s => s.LineNumber)
            .ToList();

        foreach (var invalidNestedClass in invalidNestedClasses)
        {
            var scriptLine = scriptLines.Where(s => s.LineNumber == invalidNestedClass.LineNumber).FirstOrDefault();
            scriptLine?.AddError("This is invalid nested class. Only one level of class nesting is allowed.");
        }
    }
}
