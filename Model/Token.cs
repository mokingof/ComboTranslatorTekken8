using Microsoft.Win32.SafeHandles;

namespace ComboTranslatorTekken8.Model
{
    public enum TokenType
    {
        Button,
        CombinedButton,
        Direction,
        HoldDirection,
        CombinedDirection,
        Miscellaneous,
        StageInteractions,
        Stances,
    }

    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }
        public int Position { get; }

        public Token(TokenType type, string value, int position)
        {
            Type = type;
            Value = value;
            Position = position;
        }
    }
}
