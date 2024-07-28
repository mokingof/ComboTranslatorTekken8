using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class Tokenizer
    {
  
        HashSet<string> SingleButtons = new HashSet<string> { "1", "2", "3", "4" };
        HashSet<string> CombinedButtons = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n", "D", "F", "U", "B", "N" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb", "UF", "UB", "DF", "DB" };

        HashSet<string> Miscellaneous = new HashSet<string> { "h!", "hs!", "hd!", "hb!", "t!", "jf", "cc", "fc", "ch", "dash", "mc", "wr", "ws", "~", "," };
        HashSet<string> StageInteractions = new HashSet<string> { "bb!", "fbi!", "fb!", "w!", "wbo!", "wbr!" };
        HashSet<string> Stances = new HashSet<string> {"aop", "bkp", "bok", "bt", "cd", "cfo", "ctf", "dbt", "dck", "den", "des", "dew", "dgf", "dpd", "dss", "et_dck", "flea", "flk", "fly", "gen", "gmc", "gmh", "gs", "hae", "hbs", "hms", "hyp", "iai", "ind", "isw", "izu", "jag", "jgs", "kin", "knk", "len", "iff", "lfs", "lib", "inh", "mcr", "med", "mia", "mnt", "nss", "nwg", "pab", "prf", "rab", "rds", "rff", "rfs", "rlx", "roll", "sbt", "scr", "sen", "sit", "sne", "snk", "stb", "stc", "swa", "swy", "szn", "taw", "trt", "uns", "vac", "wra", "zen"};
       

        public List<Token> TokenizeString(string input)
        {
            List<Token> tokens = new();
            char[] delimiters = { ' ' };
            List<string> temp = input.Split(delimiters).ToList();

            for (int i = 0; i < temp.Count; i++)
            {
                if (SingleButtons.Contains(temp[i]))
                {
                    tokens.Add(new Token(TokenType.SingleButtons, temp[i], i));
                }
                else if (CombinedButtons.Contains(temp[i]))
                {
                    tokens.Add(new Token(TokenType.CombinedButton, temp[i], i));                  
                }
                else if (SingleDirection.Contains(temp[i]))
                {
                    tokens.Add(new Token(TokenType.SingleDirection, temp[i], i));
                }
                else if (CombinedDirection.Contains(temp[i].Replace("/", "")))
                {
                    tokens.Add(new Token(TokenType.CombinedDirection, temp[i], i));
                }
                else if (Miscellaneous.Contains(temp[i].ToLower()))
                {
                    tokens.Add(new Token(TokenType.Miscellaneous, temp[i], i));
                }
                else if (StageInteractions.Equals(temp[i].ToLower()))
                {
                    tokens.Add(new Token(TokenType.StageInteractions, temp[i], i));
                }
                else if (Stances.Contains(temp[i].ToLower()))
                {
                    tokens.Add(new Token(TokenType.Stances, temp[i], i));
                }


            }
            return tokens;
        }
        private bool IsCombinedInput(string input)
        {
            bool hasDirection = input.Any(char.IsLetter);
            bool hasButton = input.Any(char.IsDigit);
            return hasDirection && hasButton;
        }
    }
}
