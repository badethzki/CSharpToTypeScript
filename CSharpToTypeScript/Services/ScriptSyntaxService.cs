using CSharpToTypeScript.Extensions;
using CSharpToTypeScript.Models;
using CSharpToTypeScript.Models.Syntaxes;

namespace CSharpToTypeScript.Services;

public class ScriptSyntaxService
{
    private readonly IList<ISyntax> _syntaxes = [];

    public IReadOnlyList<ISyntax> Syntaxes
        => [.. _syntaxes.OrderBy(x => x.LineNumber)];

    public void GenerateSyntaxes(IEnumerable<ScriptLine> scriptLines)
    {
        foreach (var scriptLine in scriptLines)
        {
            var syntax = SyntaxFactoryService.GetNewSyntax(scriptLine);
            syntax.GenerateNewScopeId();
            _syntaxes.Add(syntax);
        }
    }

    public void SetParentScope()
    {
        var closeBracketLineNumbers = new List<int>();

        foreach (var classType in _syntaxes.GetAllClassTypesFromInnerMost())
        {
            var classOpenBracket = _syntaxes
                .GetFirstOpenBracketByClass(classType.LineNumber);

            var classCloseBracket = _syntaxes
                .GetFirstCloseBracketByClass(classType.LineNumber, [.. closeBracketLineNumbers]);

            if (classOpenBracket != null && classCloseBracket != null)
            {
                SetChildsParentScope(
                    classOpenBracket.LineNumber,
                    classCloseBracket.LineNumber,
                    classType.ScopeId);

                closeBracketLineNumbers.Add(classCloseBracket.LineNumber);
            }
        }

        void SetChildsParentScope(
            int fromLineNumber,
            int toLineNumber,
            string scopeId)
        {
            var childSyntaxes = _syntaxes
                .Where(s => s.LineNumber >= fromLineNumber &&
                            s.LineNumber <= toLineNumber)
                .ToList();

            foreach (var childSyntax in childSyntaxes)
                childSyntax.SetParentScopeId(scopeId);
        }
    }
}
