using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Constants;

namespace CSharpToTypeScript.Validators.ScriptLineValidators;

public class NonPublicLineValidator : BaseScriptLineValidator
{
    public override void ValidateScriptLine(ScriptLine scriptLine)
    {
        if (SkipValidation(scriptLine.Syntax))
            return;

        var accessModifier = scriptLine.Syntax
             .Trim()
             .Split(" ", StringSplitOptions.TrimEntries)[0];

        if (!string.Equals(Constant.PUBLIC, accessModifier))
            scriptLine.AddError("Access modifier should be public.");
    }
}

