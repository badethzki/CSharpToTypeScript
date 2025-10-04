using CSharpToTypeScript.Models.Constants;

namespace CSharpToTypeScript.Models.Syntaxes.Properties;

public abstract record BasePropertySyntax : BaseSyntax
{
    public abstract string TypeScriptType { get; }

    public override string GenerateTypeScriptSyntax()
    {
        return string.Concat(
            "\t",
            GetCamelCaseName(),
            ": ",
            Constant.STRING,
            Constant.LINE_TERMINATOR_SYMBOL);
    }
}
