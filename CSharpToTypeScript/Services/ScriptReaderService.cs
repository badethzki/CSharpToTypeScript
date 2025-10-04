using CSharpToTypeScript.Exceptions;
using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Models.Syntaxes.Brackets;
using System.Text;

namespace CSharpToTypeScript.Services;

public class ScriptReaderService
{
    private string? _script;
    private bool _withErrors;
    private IReadOnlyList<ScriptLine> _scriptLines = [];

    private readonly ScriptSyntaxService _scriptSyntaxService = new();

    public async Task ReadAsync(string filePath)
    {
        using var reader = new StreamReader(filePath);
        _script = await reader.ReadToEndAsync();

        if (string.IsNullOrWhiteSpace(_script))
            throw new EmptyFileException();

        _scriptLines = [.. _script!
           .Split("\n")
           .Select((element, index) => new ScriptLine(index + 1, element.Trim()))];
    }
    public void Validate()
    {
        var scriptValidationService = new ScriptValidatorService(_scriptLines);

        scriptValidationService.ValidateScriptLine();

        _scriptSyntaxService.GenerateSyntaxes(_scriptLines);
        _scriptSyntaxService.SetParentScope();

        scriptValidationService.ValidateScriptFormat();

        _withErrors = scriptValidationService.LogErrorMessageIfAny();
    }


    public void GenerateTypeScriptFormat()
    {
        if (_withErrors) return;

        var skipTypes = new List<LineSyntaxType> {
            LineSyntaxType.OpenCurlyBracket,
            LineSyntaxType.CloseCurlyBracket,
            LineSyntaxType.NotSupported
        };

        var stringBuilder = new StringBuilder();
        foreach (var syntax in _scriptSyntaxService.Syntaxes)
        {
            if (skipTypes.Any(s => s == syntax.LineSyntaxType))
                continue;

            if (syntax.LineNumber > 1 && syntax.LineSyntaxType == LineSyntaxType.Class)
                stringBuilder.AppendLine(new CloseCurlyBracketSyntax().GenerateTypeScriptSyntax());

            if (syntax.LineSyntaxType == LineSyntaxType.Class)
                stringBuilder.AppendLine(syntax.GenerateTypeScriptSyntax());

            if (syntax.LineSyntaxType != LineSyntaxType.Class)
                stringBuilder.AppendLine(syntax.GenerateTypeScriptSyntax());
        }

        stringBuilder.AppendLine(new CloseCurlyBracketSyntax().GenerateTypeScriptSyntax());

        Console.WriteLine(stringBuilder.ToString());
    }
}

