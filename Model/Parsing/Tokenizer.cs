using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Net;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ComboTranslatorTekken8.Model.FSM.Context;

namespace ComboTranslatorTekken8.Model.Parsing
{
    public class Tokenizer
    {
        // Tekken Notations
        HashSet<string> SingleButton = new HashSet<string> { "1", "2", "3", "4" };
        HashSet<string> CombinedButtons = new HashSet<string> { "1+2", "1+3", "1+4", "2+3", "2+4", "3+4", "1+2+3", "1+2+4", "1+3+4", "2+3+4", "1+2+3+4" };
        HashSet<string> SingleDirection = new HashSet<string> { "d", "f", "u", "b", "n", "D", "F", "U", "B", "N" };
        HashSet<string> CombinedDirection = new HashSet<string> { "uf", "ub", "df", "db", "qcf", "qcb", "hcf", "hcb", "UF", "UB", "DF", "DB" };
        HashSet<string> Miscellaneous = new HashSet<string> { "h!", "hs!", "hd!", "hb!", "t!", "jf", "cc", "fc", "ch", "dash", "mc", "wr", "ws", "~", "," };
        HashSet<string> StageInteractions = new HashSet<string> { "bb!", "fbi!", "fb!", "w!", "wbo!", "wbr!" };
        HashSet<string> Stances = new HashSet<string> { "aop", "bkp", "bok", "bt", "cd", "cfo ", "ctf", "dbt", "dck", "den", "den", "des", "dew", "dgf", "dpd", "dss", "dss", "ctf", "et_dck", "flea", "flk", "fly", "gen", "gmc", "gmh", "gs", "hae", "hbs", "hms", "hyp", "iai", "ind", "isw", "izu", "jag", "jgs", "kin", "knk", "len", "iff", "lfs", "lib", "inh", "mcr", "med", "mia", "mnt", "nss", "nwg", "pab", "prf", "rab", "rds", "rff", "rfs", "rlx", "roll", "sbt", "scr", "sen", "sit", "sne", "snk", "stb", "stc", "swa", "swy", "szn", "taw", "trt", "uns", "vac", "wra", "zen" };

        private readonly ComboContext comboContext = new();
        List<Token> Tokens = new();
        string Value = "";

        /* public List<Token> TokenizeString(string input)
         {
             List<Token> tokens = new(); 

             for (int i = 0; i < tokens.Count; i++)
             {
                 Value = tokens[i].Value;

                 if (IsSingleButton(Value))
                 {
                     AddToken(TokenType.SingleButtons, Value, i);
                 }
                 else if (IsCombindButton(Value))
                 {
                     AddToken(TokenType.CombinedButton, Value, i);
                 }
                 else if (IsSingleDirection(Value))
                 {
                     AddToken(TokenType.SingleDirection, Value, i);
                 }
                 else if (IsCombindDirection(Value))
                 {
                     AddToken(TokenType.CombinedDirection, Value, i);
                 }
                 else if (IsMiscellaneous(Value.ToLower()))
                 {
                     AddToken(TokenType.Miscellaneous, Value, i);
                 }
                 else if (IsStageInteractions(Value.ToLower()))
                 {
                     AddToken(TokenType.StageInteractions, Value, i);
                 }
                 else if (Stances.Contains(Value.ToLower()))
                 {
                     AddToken(TokenType.Stances, Value, i);
                 }
             }
             return tokens;
         }*/

        private bool IsSingleButton(string value) => SingleButton.Contains(value);
        private bool IsCombindButton(string value) => CombinedButtons.Contains(value);
        private bool IsSingleDirection(string value) => SingleDirection.Contains(value);
        private bool IsCombindDirection(string value) => CombinedDirection.Contains(value);
        private bool IsMiscellaneous(string value) => Miscellaneous.Contains(value);
        private bool IsStageInteractions(string value) => StageInteractions.Contains(value);
        private bool IsStance(string value) => Stances.Contains(value);
        private bool NotAll(string value) => !IsStageInteractions(value) && !IsMiscellaneous(value) && !IsStance(value);
        private void AddToken(TokenType type, string value, int position) => Tokens.Add(new Token(type, value, position));

    }
}