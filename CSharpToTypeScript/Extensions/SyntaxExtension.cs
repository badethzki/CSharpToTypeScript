using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;
using CSharpToTypeScript.Models.Syntaxes;

namespace CSharpToTypeScript.Extensions;

public static class SyntaxExtension
{
    public static LineSyntaxType GetLineSyntaxType(this string type)
    {
        var syntaxType = type.EndsWith('?')
            ? type[..^1]
            : type;

        return syntaxType.StartsWith(SupportedTypeConstant.LIST)
            ? LineSyntaxType.List
            : syntaxType switch
            {
                SupportedTypeConstant.STRING => LineSyntaxType.String,
                SupportedTypeConstant.INTEGER => LineSyntaxType.Integer,
                SupportedTypeConstant.LONG => LineSyntaxType.Long,
                SupportedTypeConstant.CLASS => LineSyntaxType.Class,
                _ => LineSyntaxType.NotSupported
            };
    }

    public static bool IsLineSyntaxAProperty(this LineSyntaxType syntaxType)
    {
        return syntaxType switch
        {
            LineSyntaxType.String => true,
            LineSyntaxType.Integer => true,
            LineSyntaxType.Long => true,
            LineSyntaxType.List => true,
            _ => false,
        };
    }


    public static IEnumerable<ISyntax> GetAllClassTypesFromInnerMost(this IEnumerable<ISyntax> syntaxes)
    {
        return syntaxes.Where(s => s.LineSyntaxType == LineSyntaxType.Class)
            .OrderByDescending(s => s.LineNumber);
    }

    public static ISyntax? GetFirstOpenBracketByClass(this IEnumerable<ISyntax> syntaxes,
        int classLineNumber)
    {
        return syntaxes.FirstOrDefault(s =>
            s.LineNumber == classLineNumber + 1 &&
            s.LineSyntaxType == LineSyntaxType.OpenCurlyBracket);
    }

    public static ISyntax? GetFirstCloseBracketByClass(this IEnumerable<ISyntax> syntaxes,
        int classLineNumber,
        int[] usedCloseBracketLineNumbers)
    {
        return syntaxes.FirstOrDefault(s =>
            s.LineNumber > classLineNumber &&
            s.LineSyntaxType == LineSyntaxType.CloseCurlyBracket &&
            !usedCloseBracketLineNumbers.Any(l => l == s.LineNumber));
    }
}

