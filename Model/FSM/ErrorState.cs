
namespace ComboTranslatorTekken8.Model.FSM
{
    public class ErrorState : BaseState
    {

        public ErrorState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
          
        }

        public override IState HandleInput(string input)
        {
            throw new NotImplementedException();
        }

    }
}
