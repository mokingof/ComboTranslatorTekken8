using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.Interface;

namespace ComboTranslatorTekken8.Model.FSM.CoreStates
{
    public class InputAccumulationState : BaseState
    {
        public InputAccumulationState(ComboContext context) : base(context) {}

        public override void GenerateToken() 
        {
            foreach (var character in Context.Accumulator)
            {
                if (char.IsUpper(character))
                {
                    AddToken(new Token(TokenType.HoldSingleDirection, character.ToString(), Context.CurrentPosition));
                }
                else
                {
                    AddToken(new Token(TokenType.SingleDirection, character.ToString(), Context.CurrentPosition));
                }
            }


        }

        public override IState HandleInput(char input)
        {
         /*   if (Context.Accumulator.Length == 3)
            {
                Context.Accumulator += input.ToString();
            }
            

            if (OnlyOnceCheck(Context.Accumulator) && !input.Equals('!'))
            {
                return new SingleDirectionState(Context); 
            }
            else if (OnlyOnceCheck(Context.Accumulator) && input.Equals('!'))
            {
           
                return new ProcessingState(Context).HandleInput(input);
            }*/


            return this;
        }


        public bool OnlyOnceCheck(string s)
        {
            return s.Length >= 2 && s.Length <= 3 && s.Distinct().Count() == 1;
        }
    }
}
