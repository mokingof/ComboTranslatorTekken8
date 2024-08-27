using ComboTranslatorTekken8.Model.FSM;

namespace ComboTranslatorTekken8.Model
{
    public class ProcessingState : BaseState
    {
        public ProcessingState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            throw new NotImplementedException();
        }

        public override IState HandleInput(char input)
        {
            throw new NotImplementedException();
        }
    }
}
