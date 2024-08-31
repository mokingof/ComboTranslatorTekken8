using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.MiscStates
{
    public class MiscellaneousState : BaseState
    {
        public MiscellaneousState(ComboContext context) : base(context) { }


        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.Miscellaneous, Context.Accumulator, Context.CurrentPosition));
        }

        public override IState HandleInput(char input)
        {
       
            return this;
        }


    }
}
