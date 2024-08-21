using ComboTranslatorTekken8.Model.FSM.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.MiscStates;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class StateFactory
    {

        public IState CreateState(string stateType, ComboContext context)
        {
            return stateType switch
            {
                "CombinedInput" => new CombinedInput(context),
                "SingleButton" => new SingleButtonState(context),
                "CombinedButton" => new CombinedButtonState(context),
                "SingleDirection" => new SingleDirectionState(context),
                "HoldSingleDirection" => new HoldSingleDirectionState(context),
                "CombinedDirection" => new CombinedDirectionState(context),
                "HoldCombinedDirection" => new HoldCombinedDirectionState(context),
                "SpecialDirection" => new SpecialDirectionState(context),
                "Miscellaneous" => new MiscellaneousState(context),
                "StageInteraction" => new StageInteractionState(context),
                "Stance" => new StancesState(context),
                _ => new ErrorState(context),
            };
        }

    }
}
