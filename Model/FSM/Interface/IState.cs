namespace ComboTranslatorTekken8.Model.FSM.Interface
{
    public interface IState
    {
        //  string Accumulator { get; set; }
        void GenerateToken();
        IState HandleInput(char input);
        //   void Reset();
        //   List<Token> GetTokens();
        //   void AddToken(Token token); 
    }
}
