using System.Text;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model.FSM
{
    public class CombinedInput : BaseState
    {
        public CombinedInput(ComboContext context) : base(context) { }
        public override void GenerateToken()
        {

        }
        public override IState HandleInput(string input)
        {
   
            for (int i = 0; i < input.Length; i++)
            {
                // TODO GO CHARACTER BY CHARACTER CHECK IF NEXT IS DIRECTION THEN ADD ASAP
            
            }
           
            return this;
        }
    }
}
