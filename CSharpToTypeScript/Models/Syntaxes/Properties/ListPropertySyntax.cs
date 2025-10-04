using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes.Properties;

public record ListPropertySyntax : BasePropertySyntax
{
    public override LineSyntaxType LineSyntaxType => LineSyntaxType.List;

    public override string TypeScriptType => Constant.ARRAY_SYMBOL;

    public override string GenerateTypeScriptSyntax()
    {
        var className = RawTypeName![(RawTypeName!.IndexOf('<') + 1)..];

        return string.Concat(
            "\t", 
            GetCamelCaseName(), 
            ": ", 
            className[..className.IndexOf('>')],
            TypeScriptType, 
            Constant.LINE_TERMINATOR_SYMBOL);
    }
}