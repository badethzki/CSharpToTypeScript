using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Properties;

public record StringPropertySyntax : BasePropertySyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.String;

    public override string TypeScriptType => Constant.STRING;
}
