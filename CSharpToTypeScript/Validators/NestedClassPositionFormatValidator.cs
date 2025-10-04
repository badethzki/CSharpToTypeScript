using CSharpToTypeScript.Extensions;
using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Services;

namespace CSharpToTypeScript.Validators;

public class NestedClassPositionFormatValidator(
    ScriptSyntaxService scriptSyntaxService) : IScriptFormatValidator
{
    public void ValidateScriptFormat(IReadOnlyList<ScriptLine> scriptLines)
    {
        var groupClass = scriptSyntaxService.Syntaxes
            .Where(s => !string.IsNullOrWhiteSpace(s.ParentScopeId))
            .GroupBy(s => s.ParentScopeId)
            .ToList();

        foreach (var gc in groupClass)
        {
            var sortedChildSyntaxes = gc.OrderBy(g => g.LineNumber).ToList();

            foreach (var child in sortedChildSyntaxes)
            {
                if (child.LineSyntaxType != LineSyntaxType.Class)
                    continue;

                var classIndex = sortedChildSyntaxes.FindIndex(s => s.LineNumber == child.LineNumber);
                var nextIndex = classIndex + 1;
                if (classIndex == -1 || sortedChildSyntaxes.Count < nextIndex)
                    continue;

                var nextSyntaxItem = sortedChildSyntaxes[nextIndex];
                if (nextSyntaxItem.LineSyntaxType.IsLineSyntaxAProperty() || nextSyntaxItem.LineSyntaxType == LineSyntaxType.NotSupported)
                {
                    var scriptLine = scriptLines.FirstOrDefault(s => s.LineNumber == child.LineNumber);
                    scriptLine?.AddError("Nested class should be at the end of the definition of the parent class.");
                }
            }
        }
    }
}
