using CSharpToTypeScript.Models.Enums;

namespace CSharpToTypeScript.Models.Syntaxes;

public interface ISyntax
{
    LineSyntaxType LineSyntaxType { get; }
    int LineNumber { get; }
    string Name { get; }
    string? RawTypeName { get; }

    bool HasNullSymbol { get; }
    string ScopeId { get; }
    string? ParentScopeId { get; }
    void GenerateNewScopeId();
    void SetParentScopeId(string parentScopeId);
    void SetAttributes(ScriptLine scriptLine);
    string GenerateTypeScriptSyntax();
}
