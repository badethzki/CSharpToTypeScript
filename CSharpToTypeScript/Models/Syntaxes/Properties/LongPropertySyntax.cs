using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Properties;

public record LongPropertySyntax : BasePropertySyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.Long;

    public override string TypeScriptType => Constant.NUMBER;
}
