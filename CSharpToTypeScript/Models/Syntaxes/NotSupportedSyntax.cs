using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes;

public record NotSupportedSyntax : BaseSyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.NotSupported;

    public override string GenerateTypeScriptSyntax()
    {
        return string.Empty;
    }
}