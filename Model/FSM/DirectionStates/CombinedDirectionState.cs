﻿using System.Runtime.CompilerServices;

namespace ComboTranslatorTekken8.Model.FSM.DirectionStates
{
    public class CombinedDirectionState : BaseState
    {
        public CombinedDirectionState(ComboContext context) : base(context) { }

        public override void GenerateToken()
        {
            AddToken(new Token(TokenType.CombinedDirection, Accumulator, context.CurrentPosition));
        }
        public override IState HandleInput(string input)
        {
            Accumulator = input;
            return this;
        }
    }
}
