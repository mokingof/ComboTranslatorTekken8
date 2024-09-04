using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.CoreStates;
using ComboTranslatorTekken8.Model.FSM.InputStates.ButtonStates;

namespace ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates
{
    public class SingleDirectionState : BaseState
    {
        public SingleDirectionState(ComboContext context) : base(context) { }
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
            if (HandleInitialInput(input))
            {
                return this;
            }
            else if (HandleNullOrTerminator(input))
            {
                return new InitialState(Context);
            }
            string total = Context.Accumulator + input;

            if (CombinedDirectionPattern.IsMatch(total))
            {
                return new CombinedDirectionState(Context).HandleInput(input);
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && char.IsDigit(input))
            {
                GenerateToken();
                IsReadyForNextInput = false;
                ResetAccumulator();
                return new SingleButtonState(Context).HandleInput(input);
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && SingleDirectionPattern.IsMatch(input.ToString()))
            {
                //  dbt bb! fbl! 
                //  GenerateToken();
                Context.Accumulator += input.ToString();
                return this;
            }
            else if (SingleDirectionPattern.IsMatch(Context.Accumulator) && !SingleDirectionPattern.IsMatch(input.ToString()))
            {       // b t!
                    // bt
                GenerateToken();
                IsReadyForNextInput = false;
                ResetAccumulator();
                return new ProcessingState(Context).HandleInput(input);
            }
         

            return new ErrorState(Context);
        }
        private void ClearPreviousTokens()
        {
            // Remove the last n tokens where n is the length of the accumulator
            int tokensToRemove = Context.Accumulator.Length;
            Context.SharedTokens.RemoveRange(Context.SharedTokens.Count - tokensToRemove, tokensToRemove);
            Context.CurrentPosition -= tokensToRemove;
        }
        public bool OnlyOnceCheck(string s)
        {
            return s.Length >= 2 && s.Length <= 3 && s.Distinct().Count() == 1;
        }

    }
}