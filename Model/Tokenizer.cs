using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System;
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
        HashSet<string> Stances = new HashSet<string> { "aop", "bkp", "bok", "bt", "cd", "cfo ", "ctf", "dbt", "dck", "den", "den", "des", "dew", "dgf", "dpd", "dss", "dss", "ctf", "et_dck", "flea", "flk", "fly", "gen", "gmc", "gmh", "gs", "hae", "hbs", "hms", "hyp", "iai", "ind", "isw", "izu", "jag", "jgs", "kin", "knk", "len", "iff", "lfs", "lib", "inh", "mcr", "med", "mia", "mnt", "nss", "nwg", "pab", "prf", "rab", "rds", "rff", "rfs", "rlx", "roll", "sbt", "scr", "sen", "sit", "sne", "snk", "stb", "stc", "swa", "swy", "szn", "taw", "trt", "uns", "vac", "wra", "zen" };
        List<Token> Tokens = new();
        string value = "";
        public List<Token> TokenizeString(string input)
        {
            char[] delimiters = { ' ' };
            List<string> splitInput = input.Split(delimiters).ToList();

            for (int i = 0; i < splitInput.Count; i++)
            {
                value = splitInput[i];

                if (IsCombinedInput(value))
                {

                }
                else if (IsSingleButton(value))
                {
                    AddToken(TokenType.SingleButtons, value, i);
                }
                else if (IsCombindButton(value))
                {
                    AddToken(TokenType.CombinedButton, value, i);
                }
                else if (IsSingleDirection(value))
                {
                    AddToken(TokenType.SingleDirection, value, i);
                }
                else if (IsCombindDirection(value.Replace("/", "")))
                {
                    AddToken(TokenType.CombinedDirection, value, i);
                }
                else if (IsMiscellaneous(value.ToLower()))
                {
                    AddToken(TokenType.Miscellaneous, value, i);
                }
                else if (IsStageInteractions(value.ToLower()))
                {
                    AddToken(TokenType.StageInteractions, value, i);
                }
                else if (Stances.Contains(value.ToLower()))
                {
                    AddToken(TokenType.Stances, value, i);
                }


            }
            return Tokens;
        }
        private bool IsSingleButton(string value) => SingleButtons.Contains(value);
        private bool IsCombindButton(string value) => CombinedButtons.Contains(value);
        private bool IsSingleDirection(string value) => SingleDirection.Contains(value);
        private bool IsCombindDirection(string value) => CombinedDirection.Contains(value);
        private bool IsMiscellaneous(string value) => Miscellaneous.Contains(value);    
        private bool IsStageInteractions(string value) => StageInteractions.Contains(value);
        private void AddToken(TokenType type, string value, int position) => Tokens.Add(new Token(type, value, position));

        private bool IsCombinedInput(string input)
        {
            bool hasDirection = input.Any(char.IsLetter);
            bool hasButton = input.Any(char.IsDigit);
            return hasDirection && hasButton;
        }
    }
}
