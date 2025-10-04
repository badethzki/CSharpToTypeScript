using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Models.Syntaxes.Brackets;

namespace CSharpToTypeScript.Models.Syntaxes;

public record ClassSyntax : BaseSyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.Class;

    public override string GenerateTypeScriptSyntax()
    {
        return string.Concat(Constant.EXPORT,
            " ",
            Constant.INTERFACE,
            " ",
            Name,
            " ",
            new OpenCurlyBracketSyntax().GenerateTypeScriptSyntax());
    }
}
