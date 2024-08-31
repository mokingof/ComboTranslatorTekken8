using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.CoreStates
{
    public class InputAccumulationState : BaseState
    {
        public InputAccumulationState(ComboContext context) : base(context) { }

        public override void GenerateToken() { }

        public override IState HandleInput(char input)
        {
            throw new NotImplementedException();
        }
    }
}
