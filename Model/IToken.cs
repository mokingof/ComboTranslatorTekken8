namespace ComboTranslatorTekken8.Model
{
    public interface IToken
    {
        TokenType Type { get; }
        string Value { get; }
        int Position { get; }
    }
}
