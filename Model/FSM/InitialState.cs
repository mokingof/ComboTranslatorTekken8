using ComboTranslatorTekken8.Model.FSM;

namespace ComboTranslatorTekken8.Model
{
    public class InitialState : IState
    {
        private readonly ComboContext context;

        HashSet<string> SingleButton = new HashSet<string> { "1", "2", "3", "4" };
        HashSet<string> CombinedButtons = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n", "D", "F", "U", "B", "N" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb", "UF", "UB", "DF", "DB" };
        HashSet<string> Miscellaneous = new HashSet<string> { "h!", "hs!", "hd!", "hb!", "t!", "jf", "cc", "fc", "ch", "dash", "mc", "wr", "ws", "~", "," };
        HashSet<string> StageInteractions = new HashSet<string> { "bb!", "fbi!", "fb!", "w!", "wbo!", "wbr!" };
        HashSet<string> Stances = new HashSet<string> { "aop", "bkp", "bok", "bt", "cd", "cfo ", "ctf", "dbt", "dck", "den", "den", "des", "dew", "dgf", "dpd", "dss", "dss", "ctf", "et_dck", "flea", "flk", "fly", "gen", "gmc", "gmh", "gs", "hae", "hbs", "hms", "hyp", "iai", "ind", "isw", "izu", "jag", "jgs", "kin", "knk", "len", "iff", "lfs", "lib", "inh", "mcr", "med", "mia", "mnt", "nss", "nwg", "pab", "prf", "rab", "rds", "rff", "rfs", "rlx", "roll", "sbt", "scr", "sen", "sit", "sne", "snk", "stb", "stc", "swa", "swy", "szn", "taw", "trt", "uns", "vac", "wra", "zen" };

        public InitialState(ComboContext context)
        {
            this.context = context;
        }
        public bool CanCombineWith(char input)
        {
            return false;
        }

        public Token GenerateToken()
        {
            return null;
        }

        public IState HandleInput(string input)
        {
            if (SingleButton.Contains(input))
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
            else
            {
                return new ErrorState(context);
            }
        }

        /*    public IState HandleInput(char input)
            {
                if (char.IsWhiteSpace(input))
                {
                    return this;
                }
             else  if (char.IsDigit(input))
                {
                    return new ButtonState(context).HandleInput(input);
                }
                else if (char.IsLetter(input))
                {
                    return new DirectionState(context).HandleInput(input);
                }
                else
                {
                    return new ErrorState(context);
                }

            }*/



        public void Reset(){}
    }
}
