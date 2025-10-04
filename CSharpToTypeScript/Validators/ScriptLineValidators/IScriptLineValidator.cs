using CSharpToTypeScript.Models;

namespace CSharpToTypeScript.Validators.ScriptLineValidators;

public interface IScriptLineValidator
{
    void Validate(ScriptLine scriptLine);
}