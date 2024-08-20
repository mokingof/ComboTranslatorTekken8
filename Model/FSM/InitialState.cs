using ComboTranslatorTekken8.Model.FSM;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class InitialState : BaseState
    {
        public InitialState(ComboContext context) : base(context) { }

        HashSet<string> SingleButton = new HashSet<string> { "1", "2", "3", "4" };
        HashSet<string> CombinedButtons = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n", "D", "F", "U", "B", "N" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb", "UF", "UB", "DF", "DB", "ssl", "ssr", "swl", "swr", "ssc" };
        HashSet<string> Miscellaneous = new HashSet<string> { "h!", "hs!", "hd!", "hb!", "t!", "jf", "cc", "fc", "ch", "dash", "mc", "wr", "ws", "~", "," };
        HashSet<string> StageInteractions = new HashSet<string> { "bb!", "fbl!", "fb!", "wbl!", "wbo!", "wb!" };
        HashSet<string> Stances = new HashSet<string> { "aop", "bkp", "bok", "bt", "cd", "cfo ", "ctf", "dbt", "dck", "den", "den", "des", "dew", "dgf", "dpd", "dss", "dss", "ctf", "et_dck", "flea", "flk", "fly", "gen", "gmc", "gmh", "gs", "hae", "hbs", "hms", "hyp", "iai", "ind", "isw", "izu", "jag", "jgs", "kin", "knk", "len", "iff", "lfs", "lib", "inh", "mcr", "med", "mia", "mnt", "nss", "nwg", "pab", "prf", "rab", "rds", "rff", "rfs", "rlx", "roll", "sbt", "scr", "sen", "sit", "sne", "snk", "stb", "stc", "swa", "swy", "szn", "taw", "trt", "uns", "vac", "wra", "zen" };
        
        protected List<Token> tokens = new List<Token>();
        public string Accumulator { get; set; } = "";
        public List<Token> AddToken => tokens;
     
        public List<Token> GetTokens()
        {
            return AddToken;
        }
        public override void GenerateToken() { }

        public override IState HandleInput(string input)
        {
            if (IsCombinedInput(input))
            {
                return new CombinedInput(context).HandleInput(input);
            }
            else if (SingleButton.Contains(input))
            {
                return new SingleButtonState(context).HandleInput(input);
            }
            else if (CombinedButtons.Contains(input))
            {
                return new CombinedButtonState(context).HandleInput(input);
            }
            else if (SingleDirection.Contains(input))
            {
                return new SingleDirectionState(context).HandleInput(input);
            }
            else if (CombinedDirection.Contains(input))
            {
                return new CombinedDirectionState(context).HandleInput(input);
            }
            else if (Miscellaneous.Contains(input))
            {
                return new MiscellaneousState(context).HandleInput(input);
            }
            else if (StageInteractions.Contains(input))
            {
                return new StageInteractionState(context).HandleInput(input);
            }
            else if (Stances.Contains(input))
            {
                return new StancesState(context).HandleInput(input);
            }
            else
            {
                return new ErrorState(context);
            }
        }
        private bool IsCombinedInput(string input)
        {
            bool hasDirection = input.Any(char.IsLetter);
            bool hasButton = input.Any(char.IsDigit);
            return hasDirection && hasButton;
        }
        private bool IsDigitsOnly(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        private bool IsCombindButton(string value) => CombinedButtons.Contains(value);

       
    }
}
