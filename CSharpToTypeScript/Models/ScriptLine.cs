using CSharpToTypeScript.Extensions;
using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models;

public record ScriptLine(int LineNumber, string Syntax)
{
    public LineSyntaxType LineSyntaxType { get; private set; }

    public string? Name { get; private set; }

    public string? RawTypeName { get; private set; }

    public IList<string> Errors { get; private set; } = [];

    public void AddError(string message)
    {
        if (!string.IsNullOrWhiteSpace(message) && Errors.Any(e => string.Equals(e, message)) == false)
            Errors.Add(message);
    }

    public void SetAttributes()
    {
        if (string.Equals(Syntax, Constant.OPEN_CURLY_BRACKET))
        {
            LineSyntaxType = LineSyntaxType.OpenCurlyBracket;
            Name = Constant.OPEN_CURLY_BRACKET;
            return;
        }

        if (string.Equals(Syntax, Constant.CLOSE_CURLY_BRACKET))
        {
            LineSyntaxType = LineSyntaxType.CloseCurlyBracket;
            Name = Constant.CLOSE_CURLY_BRACKET;
            return;
        }

        var split = Syntax.Trim().Split(" ", StringSplitOptions.TrimEntries);

        if (split.Length > 2)
        {
            RawTypeName = split[1];
            Name = split[2];

            LineSyntaxType = RawTypeName.GetLineSyntaxType();
        }
    }
}

