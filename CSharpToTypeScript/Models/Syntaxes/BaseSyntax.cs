using CSharpToTypeScript.Models.Constants;
using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes;

public abstract record BaseSyntax : ISyntax
{
    public abstract LineSyntaxType LineSyntaxType { get; }

    public int LineNumber { get; private set; }

    public string Name { get; private set; } = null!;

    public string? RawTypeName { get; private set; }

    public bool HasNullSymbol { get; private set; }

    public string ScopeId { get; private set; } = null!;

    public string? ParentScopeId { get; private set; }

    public void GenerateNewScopeId()
    {
        if (LineSyntaxType == LineSyntaxType.Class)
            ScopeId = Guid.NewGuid().ToString();
    }

    public void SetParentScopeId(string parentScopeId)
    {
        if (string.IsNullOrWhiteSpace(ParentScopeId))
            ParentScopeId = parentScopeId;
    }

    public void SetAttributes(ScriptLine scriptLine)
    {
        LineNumber = scriptLine.LineNumber;
        Name = scriptLine.Name!;
        RawTypeName = scriptLine.RawTypeName;
        HasNullSymbol = RawTypeName != null && RawTypeName.EndsWith(Constant.NULL_SYMBOL);
    }

    protected string GetCamelCaseName()
    {
        var firstLetter = Name[..1];
        return string.Concat(firstLetter.ToLower(), Name.Substring(1, Name.Length - 1), HasNullSymbol ? Constant.NULL_SYMBOL : "");
    }

    public abstract string GenerateTypeScriptSyntax();
}
