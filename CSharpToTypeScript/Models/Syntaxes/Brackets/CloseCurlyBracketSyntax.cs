using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Brackets;

public record CloseCurlyBracketSyntax : BaseSyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.CloseCurlyBracket;

    public override string GenerateTypeScriptSyntax()
    {
        return "}";
    }
}