using CSharpToTypeScript.Models;

namespace CSharpToTypeScript.Validators;

public interface IScriptFormatValidator
{
    void ValidateScriptFormat(IReadOnlyList<ScriptLine> scriptLines);
}
