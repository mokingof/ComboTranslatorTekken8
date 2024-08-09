namespace ComboTranslatorTekken8.Model.FSM
{
    public interface IState
    {
       
        IState HandleInput(char input);
        Token GenerateToken();
        bool CanCombineWith(char input);
        void Reset();

    }
}
