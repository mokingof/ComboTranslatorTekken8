namespace ComboTranslatorTekken8.Model.FSM
{
    public interface IState
    {
      //  string Accumulator { get; set; }
        void GenerateToken();
        IState HandleInput(string input);
     //   void Reset();
     //   List<Token> GetTokens();
     //   void AddToken(Token token); 
    }
}
