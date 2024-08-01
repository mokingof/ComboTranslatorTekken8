namespace ComboTranslatorTekken8.Model
{
    public class DirectionState : IState
    {
        private readonly ComboContext context;
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n", "D", "F", "U", "B", "N" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb", "UF", "UB", "DF", "DB" };
        public DirectionState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            throw new NotImplementedException();
        }
        public Token GenerateToken()
        {
            return new Token(TokenType.SingleDirection, "d", 1); ;
        }

        public IState HandleInput(char input)
        {   
                return new ButtonState(context); 
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
