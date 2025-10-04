using CSharpToTypeScript.Models;
using CSharpToTypeScript.Validators;
using CSharpToTypeScript.Validators.ScriptLineValidators;
using System.Text;

namespace CSharpToTypeScript.Services;

public class ScriptValidatorService
{
    private readonly ScriptSyntaxService _scriptSyntaxService;
    private readonly IReadOnlyList<ScriptLine> _scriptLines;

    public ScriptValidatorService(IReadOnlyList<ScriptLine> scriptLines)
    {
        _scriptSyntaxService = new ScriptSyntaxService();
        _scriptLines = scriptLines;
    }

    public void ValidateScriptLine()
    {
         var scriptLineValidators = new List<IScriptLineValidator>()
         {
             new NotSupportedTypeLineValidator(),
             new NonPublicLineValidator()
         };

        foreach (var scriptLine in _scriptLines)
        {
            foreach (var validator in scriptLineValidators)
                validator.Validate(scriptLine);

            scriptLine.SetAttributes();
        }
    }

    public void ValidateScriptFormat()
    {
        var scriptFormatValidators = new List<IScriptFormatValidator>()
        {
             new OneLevelNestedClassFormatValidator(_scriptSyntaxService),
             new NestedClassPositionFormatValidator(_scriptSyntaxService)
        };

        foreach (var validator in scriptFormatValidators)
            validator.ValidateScriptFormat(_scriptLines);
    }

    public bool LogErrorMessageIfAny()
    {
        var scripptLineWithErrors = _scriptLines
            .Where(s => s.Errors.Any())
            .OrderBy(s => s.LineNumber)
            .AsEnumerable();

        if (!scripptLineWithErrors.Any())
            return false;

        var stringBuilder = new StringBuilder();

        foreach (var scriptLine in scripptLineWithErrors)
        {
            stringBuilder.AppendLine($"Line[{scriptLine.LineNumber}]:");

            foreach (var error in scriptLine.Errors)
                stringBuilder.AppendLine($"\t{error}");

            stringBuilder.AppendLine();
        }

        Console.WriteLine(stringBuilder.ToString());

        return true;
    }

}
