using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Brackets;

public record OpenCurlyBracketSyntax : BaseSyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.OpenCurlyBracket;

    public override string GenerateTypeScriptSyntax()
    {
        return "{";
    }
}
