using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.MiscStates
{
    public class StancesState : BaseState
    {
        public StancesState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.Stances, Context.Accumulator, Context.CurrentPosition));
            ResetAccumulator(); 
        }

        public override IState HandleInput(char input)
        {

            GenerateToken();
            return new InitialState(Context).HandleInput(input);
        }

    }
}
