﻿using ComboTranslatorTekken8.Model.FSM.DirectionStates;

namespace ComboTranslatorTekken8.Model.FSM.ButtonStates
{
    public class CombinedButtonState : BaseState
    {
        private bool isReadyForNextInput = false;

        public CombinedButtonState(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedButton, context.Accumulator, context.CurrentPosition));
            isReadyForNextInput = false;
            context.Accumulator = "";
        }
        public override IState HandleInput(char input)
        {
            if (!isReadyForNextInput)
            {
                context.Accumulator += input;
                isReadyForNextInput = true;
                return this;
            }

            if (input.Equals('\0'))
            {
                if (!string.IsNullOrEmpty(context.Accumulator))
                {
                    GenerateToken();
                }
                return new InitialState(context);
            }

            if (char.IsDigit(input))
            {
                context.Accumulator += input;
                return this;
            }

            if (input.Equals('+'))
            {
                context.Accumulator += input;
                return this;
            }

            if (char.IsLetter(input))
            {
                if (!string.IsNullOrEmpty(context.Accumulator))
                {
                    GenerateToken();
                }
                return new ProcessingState(context).HandleInput(input);
            }

            return new ErrorState(context);
        }
    }
    
}
