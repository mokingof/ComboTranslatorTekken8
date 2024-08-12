namespace ComboTranslatorTekken8.Model.FSM
{
    public interface IState
    {
        string Accumulator { get; set; }
        IState HandleInput(string input);
        void GenerateToken();
        void Reset();

        List<Token> GetTokens();

    }
}
