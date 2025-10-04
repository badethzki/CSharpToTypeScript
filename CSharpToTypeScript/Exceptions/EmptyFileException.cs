namespace CSharpToTypeScript.Exceptions;

public class EmptyFileException : Exception
{
    public EmptyFileException() : base("File is empty.")
    {
    }
}
