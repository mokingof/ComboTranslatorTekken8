namespace ComboTranslatorTekken8.Model.FSM
{
    public interface IState
    {
       
        IState HandleInput(string input);
        Token GenerateToken();
        bool CanCombineWith(char input);
        void Reset();

    }
}
