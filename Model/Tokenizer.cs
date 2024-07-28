using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class Tokenizer
    {
        //PrintCombo("b3,dash,2+3+1,ff4,ssl,UB1,d/f1+2+3");
        Regex SingleButton = new Regex(@"[1234]");
        Regex MultiButton = new Regex(@"^[1-4](\+[1-4]){1,3}$");
        Regex SingleDirection = new Regex(@"[dfubnDFUB]");
        Regex Miscellaneous = new Regex(@"(?<!\S)(h!|hs!|hd!|hb!|t!|jf|cc|fc|ch|dash|mc|wr|ws|~|,)(?!\S)");
        Regex StageInteractions = new Regex(@"(?<!\S)(bb!|fbi!|fb!|w!|wbo!|wbr!)(?!\S)");
        Regex Stances = new Regex(@"(?<!\S)(aop|bkp|bok|bt|cd|cfo|ctf|dbt|dck|den|den|des|dew|dgf|dpd|dss|dss|ctf|et_dck|flea]|flk|fly|gen|gmc|gmh|gs|hae|hbs|hms|hyp|iai|ind|isw|izu|jag|jgs|kin|knk|len|iff|lfs|lib|inh|mcr|med|mia|mnt|nss|nwg|pab|prf|rab|rds|rff|rfs|rlx|roll|sbt|scr|sen|sit|sne|snk|stb|stc|swa|swy|szn|taw|trt|uns|vac|wra|zen)(?!\S)");

        Match Match;

        public List<Token> TokenizeString(string input)
        {
            List<Token> tokens = new();

            char[] delimiters = { ' ' };
            List<string> temp = input.Split(delimiters).ToList();
            string value;
            for (int i = 0; i < temp.Count; i++)
            {
                if (SingleButton.IsMatch(temp[i]))
                {
                    if (temp[i].Contains("+"))
                    {
                        value = CombinationButtons(temp[i]);
                        tokens.Add(new Token(TokenType.CombinedButton, value, i));
                    }
                    else
                    {
                        value = Button(temp[i]);
                        tokens.Add(new Token(TokenType.Button, value, i));
                    }
                }
                else if (SingleDirection.IsMatch(temp[i]))
                {
                    value = Direction(temp[i]);
                    tokens.Add(new Token(TokenType.Direction, value, i));
                }
                else if (Miscellaneous.IsMatch(temp[i]))
                {
                    value = Misc(temp[i]);
                    tokens.Add(new Token(TokenType.Miscellaneous, value, i));
                }
                else if (StageInteractions.IsMatch(temp[i]))
                {
                    value = StageInteraction(temp[i]);
                    tokens.Add(new Token(TokenType.StageInteractions, value, i));
                }
                else if (Stances.IsMatch(temp[i]))
                {
                    value = Stance(temp[i]);
                    tokens.Add(new Token(TokenType.Stances, value, i));
                }
               
                
            }
            return tokens;
        }
        private string Button(string input)
        {
            Match = SingleButton.Match(input);
            return Match.Value;
        }
        private string CombinationButtons(string input)
        {
                Match = MultiButton.Match(input);
                return Match.Value;
        }
        private string Direction(string input)
        {
            Match = SingleDirection.Match(input);
            return Match.Value;
        }
        private string Misc(string input)
        {
            Match = Miscellaneous.Match(input);
            return Match.Value;
        }
        private string StageInteraction(string input)
        {
            Match = StageInteractions.Match(input);
            return Match.Value;
        }
        private string Stance(string input)
        {
            Match = Stances.Match(input);
            return Match.Value;
        }
        private string Separators(string input)
        {
            return null;
        }

        private bool ContainsNoDuplicate(string input)
        {
            return input.Replace("+", "").Distinct().Count() == input.Replace("+", "").Length;

        }

        private bool IsCombinedInput(string input)
        {
            bool hasDirection = input.Any(char.IsLetter);
            bool hasButton = input.Any(char.IsDigit);
            return hasDirection && hasButton;
        }
    }
}
