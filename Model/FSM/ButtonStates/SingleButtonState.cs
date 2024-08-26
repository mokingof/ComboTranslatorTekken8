using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using System.Text;

namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
{
    public class SingleButtonState : BaseState
    {
        private bool isReadyForNextInput = false;
        public SingleButtonState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.SingleButtons, Accumulator, context.CurrentPosition));
            isReadyForNextInput = false;
            Accumulator = "";
        }
        public override IState HandleInput(char input)
        {
            if (!isReadyForNextInput)
            {
                // First input - accumulate and prepare for next
                Accumulator = input.ToString();
                isReadyForNextInput = true;
                return this;
            }
            else if (isReadyForNextInput && char.IsDigit(input))
            {
                GenerateToken();
                return new SingleButtonState(context).HandleInput(input);
            }


            // Second input - make decision
            if (input.Equals('+'))
            {
                // Another button input, transition to CombinedButtonState
                return new CombinedButtonState(context).HandleInput(input);
            }
            else
            {
                // Direction input, generate button token and transition to DirectionState
                GenerateToken();
                return new SingleDirectionState(context).HandleInput(input);
            }
        }
    }

  

    }

