using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.CoreStates
{
    public class InputAccumulationState : BaseState
    {
        public InputAccumulationState(ComboContext context) : base(context)
        {
        }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.SingleDirection, Context.Accumulator, Context.CurrentPosition));
            ResetAccumulator(); 
        }

        public override IState HandleInput(char input)
        {
           // Context.Accumulator += input.ToString();

            if (Context.Accumulator.Equals(input))
            {       
                    GenerateToken();   
            }
            


            return new InitialState(Context);
        }


        public bool OnlyOnceCheck(string input)
        {
            return input.GroupBy(x => x).Any(g => g.Count() > 1);
        }
    }
}
