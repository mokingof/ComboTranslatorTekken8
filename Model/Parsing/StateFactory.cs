using ComboTranslatorTekken8.Model.FSM.InputStates.ButtonStates;
using ComboTranslatorTekken8.Model.FSM.Context;
using ComboTranslatorTekken8.Model.FSM.InputStates.DirectionStates;
using ComboTranslatorTekken8.Model.FSM.Interface;
using ComboTranslatorTekken8.Model.FSM.MiscStates;
using ComboTranslatorTekken8.Model.FSM.InputStates.SpecialDirectionStates;
using ComboTranslatorTekken8.Model.FSM.CoreStates;

namespace ComboTranslatorTekken8.Model.Parsing
{
    public class StateFactory
    {

        public IState CreateState(string stateType, ComboContext context)
        {
            return stateType switch
            {
                "SingleButton" => new SingleButtonState(context),
                "CombinedButtons" => new CombinedButtonState(context),
                "SingleDirection" => new SingleDirectionState(context),
                "CombinedDirection" => new CombinedDirectionState(context),
                "QuarterCircle" => new QuarterCircleDirectionState(context),
                "SideStep" => new SideStepDirectionState(context),
                "Miscellaneous" => new MiscellaneousState(context),
              /*  "StageInteraction" => new StageInteractionState(context),
                "Stance" => new StancesState(context),*/
                _ => new ErrorState(context),
            };
        }

    }
}
