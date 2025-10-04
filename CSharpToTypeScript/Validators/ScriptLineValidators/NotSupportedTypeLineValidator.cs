using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Constants;

namespace CSharpToTypeScript.Validators.ScriptLineValidators;

public class NotSupportedTypeLineValidator : BaseScriptLineValidator
{
    private readonly string[] _supportedTypes = [
        SupportedTypeConstant.CLASS,
        SupportedTypeConstant.STRING,
        SupportedTypeConstant.INTEGER,
        SupportedTypeConstant.LONG,
        SupportedTypeConstant.LIST
    ];

    public override void ValidateScriptLine(ScriptLine scriptLine)
    {
        if (SkipValidation(scriptLine.Syntax))
            return;

        var type = scriptLine.Syntax
            .Trim()
            .Split(" ", StringSplitOptions.TrimEntries)[1];

        if (!_supportedTypes.Any(type.StartsWith))
            scriptLine.AddError("Only type of string, int, long & list are supported.");
    }
}

