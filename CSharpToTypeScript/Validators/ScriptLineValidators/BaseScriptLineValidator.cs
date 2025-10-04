using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Constants;

namespace CSharpToTypeScript.Validators.ScriptLineValidators;

public abstract class BaseScriptLineValidator : IScriptLineValidator
{
    public void Validate(ScriptLine scriptLine)
    {
        if (!string.IsNullOrWhiteSpace(scriptLine.Syntax))
            ValidateScriptLine(scriptLine);
        else
            scriptLine.AddError("No empty line should be in the class definition.");
    }

    protected static bool SkipValidation(string syntax) =>
        string.Equals(syntax, Constant.OPEN_CURLY_BRACKET) ||
        string.Equals(syntax, Constant.CLOSE_CURLY_BRACKET);

    public abstract void ValidateScriptLine(ScriptLine scriptLine);
}