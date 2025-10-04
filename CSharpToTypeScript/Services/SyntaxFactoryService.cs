using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Models.Syntaxes;
using CSharpToTypeScript.Models.Syntaxes.Brackets;
using CSharpToTypeScript.Models.Syntaxes.Properties;

namespace CSharpToTypeScript.Services;

public class SyntaxFactoryService
{
    public static ISyntax GetNewSyntax(ScriptLine scriptLine)
    {
        var syntax = CreateNewSyntax(scriptLine.LineSyntaxType);

        syntax?.SetAttributes(scriptLine);

        return syntax!;
    }

    private static ISyntax CreateNewSyntax(LineSyntaxType syntaxType)
    {
        return syntaxType switch
        {
            LineSyntaxType.Class => new ClassSyntax(),
            LineSyntaxType.String => new StringPropertySyntax(),
            LineSyntaxType.Integer => new IntegerPropertySyntax(),
            LineSyntaxType.Long => new LongPropertySyntax(),
            LineSyntaxType.List => new ListPropertySyntax(),
            LineSyntaxType.OpenCurlyBracket => new OpenCurlyBracketSyntax(),
            LineSyntaxType.CloseCurlyBracket => new CloseCurlyBracketSyntax(),
            _ => new NotSupportedSyntax(),
        };
    }

}
