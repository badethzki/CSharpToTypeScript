using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Properties;

public record IntegerPropertySyntax : BasePropertySyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.Integer;

    public override string TypeScriptType => Constant.NUMBER;
}
