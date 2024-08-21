namespace ComboTranslatorTekken8.Model.FSM
{
    public class InputClassifier
    {

        Dictionary<string, string> notations = new()
        {
            {"1", "SingleButton"},
            {"2", "SingleButton"},
            {"3", "SingleButton"},
            {"4", "SingleButton"},

            // CombinedButtons
            {"1+2", "CombinedButtons"},
            {"1+3", "CombinedButtons"},
            {"1+4", "CombinedButtons"},
            {"2+3", "CombinedButtons"},
            {"2+4", "CombinedButtons"},
            {"3+4", "CombinedButtons"},
            {"1+2+3", "CombinedButtons"},
            {"1+2+4", "CombinedButtons"},
            {"1+3+4", "CombinedButtons"},
            {"2+3+4", "CombinedButtons"},
            {"1+2+3+4", "CombinedButtons"},

            // SingleDirection
            {"d", "SingleDirection"},
            {"f", "SingleDirection"},
            {"u", "SingleDirection"},
            {"b", "SingleDirection"},
            {"n", "SingleDirection"},

            // HoldSingleDirection
            {"D", "HoldSingleDirection"},
            {"F", "HoldSingleDirection"},
            {"U", "HoldSingleDirection"},
            {"B", "HoldSingleDirection"},
            {"N", "HoldSingleDirection"},

            // CombinedDirection
            {"uf", "CombinedDirection"},
            {"ub", "CombinedDirection"},
            {"df", "CombinedDirection"},
            {"db", "CombinedDirection"},

            // HoldCombinedDirection
            {"UF", "HoldCombinedDirection"},
            {"UB", "HoldCombinedDirection"},
            {"DF", "HoldCombinedDirection"},
            {"DB", "HoldCombinedDirection"},

            // SpecialDirection
            {"qcf", "SpecialDirection"},
            {"qcb", "SpecialDirection"},
            {"hcf", "SpecialDirection"},
            {"hcb", "SpecialDirection"},
            {"ssl", "SpecialDirection"},
            {"ssr", "SpecialDirection"},
            {"swl", "SpecialDirection"},
            {"swr", "SpecialDirection"},
            {"ssc", "SpecialDirection"},

            // Miscellaneous
            {"h!", "Miscellaneous"},
            {"hs!", "Miscellaneous"},
            {"hd!", "Miscellaneous"},
            {"hb!", "Miscellaneous"},
            {"t!", "Miscellaneous"},
            {"jf", "Miscellaneous"},
            {"cc", "Miscellaneous"},
            {"fc", "Miscellaneous"},
            {"ch", "Miscellaneous"},
            {"dash", "Miscellaneous"},
            {"mc", "Miscellaneous"},
            {"wr", "Miscellaneous"},
            {"ws", "Miscellaneous"},
            {"~", "Miscellaneous"},
            {",", "Miscellaneous"},

            // StageInteractions
            {"bb!", "StageInteractions"},
            {"fbl!", "StageInteractions"},
            {"fb!", "StageInteractions"},
            {"wbl!", "StageInteractions"},
            {"wbo!", "StageInteractions"},
            {"wb!", "StageInteractions"},

               // Stances
            {"aop", "Stance"},
            {"bkp", "Stance"},
            {"bok", "Stance"},
            {"bt", "Stance"},
            {"cd", "Stance"},
            {"cfo", "Stance"},
            {"ctf", "Stance"},
            {"dbt", "Stance"},
            {"dck", "Stance"},
            {"den", "Stance"},
            {"des", "Stance"},
            {"dew", "Stance"},
            {"dgf", "Stance"},
            {"dpd", "Stance"},
            {"dss", "Stance"},
            {"et_dck", "Stance"},
            {"flea", "Stance"},
            {"flk", "Stance"},
            {"fly", "Stance"},
            {"gen", "Stance"},
            {"gmc", "Stance"},
            {"gmh", "Stance"},
            {"gs", "Stance"},
            {"hae", "Stance"},
            {"hbs", "Stance"},
            {"hms", "Stance"},
            {"hyp", "Stance"},
            {"iai", "Stance"},
            {"ind", "Stance"},
            {"isw", "Stance"},
            {"izu", "Stance"},
            {"jag", "Stance"},
            {"jgs", "Stance"},
            {"kin", "Stance"},
            {"knk", "Stance"},
            {"len", "Stance"},
            {"iff", "Stance"},
            {"lfs", "Stance"},
            {"lib", "Stance"},
            {"inh", "Stance"},
            {"mcr", "Stance"},
            {"med", "Stance"},
            {"mia", "Stance"},
            {"mnt", "Stance"},
            {"nss", "Stance"},
            {"nwg", "Stance"},
            {"pab", "Stance"},
            {"prf", "Stance"},
            {"rab", "Stance"},
            {"rds", "Stance"},
            {"rff", "Stance"},
            {"rfs", "Stance"},
            {"rlx", "Stance"},
            {"roll", "Stance"},
            {"sbt", "Stance"},
            {"scr", "Stance"},
            {"sen", "Stance"},
            {"sit", "Stance"},
            {"sne", "Stance"},
            {"snk", "Stance"},
            {"stb", "Stance"},
            {"stc", "Stance"},
            {"swa", "Stance"},
            {"swy", "Stance"},
            {"szn", "Stance"},
            {"taw", "Stance"},
            {"trt", "Stance"},
            {"uns", "Stance"},
            {"vac", "Stance"},
            {"wra", "Stance"},
            {"zen", "Stance"}

        };
        public string ClassifyInput(string input)
        {
            foreach (string key in notations.Keys)
            {
                if (key == input)
                {
                    return notations[input];
                }
            }
            return null;
        }

    }
}
