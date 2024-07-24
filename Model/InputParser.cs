using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ComboTranslatorTekken8.Model
{
    public class InputParser
    {

        public List<InputCommand?> ParseInput(string inputString)
        {
            char[] delimiters = {',' ,' ' };
            List<string> tokens = inputString.Split(delimiters).ToList();
            List<InputCommand?> storeParsedCommands = new();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (IsCombinedInput(tokens[i]))
                {
                   
                    var CleanString = Regex.Replace(tokens[i], "[^A-Za-z0-9 ]", "");

               
                    var direction = new string(CleanString
                        .SkipWhile(c => char.IsDigit(c))
                        .TakeWhile(c => !char.IsDigit(c))
                        .ToArray());

                    storeParsedCommands.Add(ParseSingleDirection(direction)
                        ?? ParseMultiDirections(direction)
                        ?? ParseStageGimmicks(direction)
                        ?? ParseMisc(direction));

                    // Using LINQ to skip all non integers in the string
                    var input = new string(CleanString
                        .SkipWhile(c => !char.IsDigit(c))
                        .TakeWhile(c => char.IsDigit(c))
                        .ToArray());
                    storeParsedCommands.Add(ParseSingleButton(input) ?? ParseMultiButtons(input));
                }
                else
                {
                    storeParsedCommands.Add(ParseSingleButton(tokens[i])
                        ?? ParseMultiButtons(tokens[i])
                        ?? ParseSingleDirection(tokens[i])
                        ?? ParseMultiDirections(tokens[i])
                        ?? ParseStageGimmicks(tokens[i])
                        ?? ParseMisc(tokens[i]));
                }

            }
            return storeParsedCommands;
        }

        private bool IsCombinedInput(string inputString)
        {
            bool hasDirection = inputString.Any(char.IsLetter);
            bool hasButton = inputString.Any(char.IsDigit);
            return hasDirection && hasButton;
        }

        private InputCommand? ParseSingleButton(string notation)
        {
            return notation switch
            {
                "1" => InputCommand.One,
                "2" => InputCommand.Two,
                "3" => InputCommand.Three,
                "4" => InputCommand.Four,
                _ => null
            };
        }

        private InputCommand? ParseSingleDirection(string notation)
        {
            return notation switch
            {
                "n" or "N" => InputCommand.Neutral,
                "f" => InputCommand.Forward,
                "b" => InputCommand.Back,
                "u" => InputCommand.Up,
                "d" => InputCommand.Down,
                "F" => InputCommand.HoldForward,
                "B" => InputCommand.HoldBack,
                "U" => InputCommand.HoldUp,
                "D" => InputCommand.HoldDown,
                _ => null
            };
        }

        private InputCommand? ParseMultiButtons(string notation)
        {
            string sortedButtons = string.Concat(notation.Replace("+", "").OrderBy(c => c));

            return sortedButtons switch
            {
                "12" => InputCommand.OneTwo,
                "13" => InputCommand.OneThree,
                "14" => InputCommand.OneFour,
                "23" => InputCommand.TwoThree,
                "24" => InputCommand.TwoFour,
                "34" => InputCommand.ThreeFour,
                "123" => InputCommand.OneTwoThree,
                "124" => InputCommand.OneTwoFour,
                "134" => InputCommand.OneThreeFour,
                "234" => InputCommand.TwoThreeFour,
                "1234" => InputCommand.OneTwoThreeFour,
                _ => null
            };
        }

        private InputCommand? ParseMultiDirections(string notation)
        {
            return notation switch
            {
                "uf" or "u/f" => InputCommand.UpForward,
                "ub" or "u/b" => InputCommand.UpBack,
                "df" or "d/f" => InputCommand.DownForward,
                "db" or "d/b" => InputCommand.DownBack,
                "UF" or "U/F" => InputCommand.HoldUpForward,
                "UB" or "U/B" => InputCommand.HoldUpBack,
                "DF" or "D/F" => InputCommand.HoldDownForward,
                "DB" or "D/B" => InputCommand.HoldDownBack,
                "qcf" or "QCF" => InputCommand.QuarterCircleForward,
                "qcb" or "QCB" => InputCommand.QuarterCircleBack,
                "hcf" or "HCF" => InputCommand.HalfCircleForward,
                "hcb" or "HCB" => InputCommand.HalfCircleBack,
                //"ss" or "SS" => InputCommand.SideStep,
                "ssl" or "SSL" => InputCommand.SideStepLeft,
                "ssr" or "SSR" => InputCommand.SideStepRight,
                "swl" or "SWL" => InputCommand.SideWalkLeft,
                "swr" or "SWR" => InputCommand.SideWalkRight,
                "ssc" or "SSC" => InputCommand.SideStepCrouch,
                _ => null
            };
        }

        private InputCommand? ParseStageGimmicks(string notation)
        {
            return notation.ToLower() switch
            {
                "bb!" => InputCommand.BalconyBreak,
                "fbi!" => InputCommand.FloorBlast,
                "fb!" => InputCommand.FloorBreak,
                "w!" => InputCommand.WallBlast,
                "wbo!" => InputCommand.WallBound,
                "wb!" => InputCommand.WallBreak,
                _ => null
            };
        }

        private InputCommand? ParseMisc(string notation)
        {
            return notation.ToLower() switch
            {
                "h!" => InputCommand.Heat,
                "hs!" => InputCommand.HeatSmash,
                "hd!" => InputCommand.HeadDash,
                "hb!" => InputCommand.HeatBurst,
                "t!" => InputCommand.Tornado,
                ":" => InputCommand.JustFrame,
                "cc" => InputCommand.CrouchCancel,
                "fc" => InputCommand.FullCrouch,
                "ch" => InputCommand.CounterHit,
                "dash" => InputCommand.Dash,
                "microdash" or "md" => InputCommand.MicroDash,
                "wr" => InputCommand.WhileRunning,
                "ws" => InputCommand.WhileStanding,
                "~" => InputCommand.Tilde,
                ">" => InputCommand.Separator,
                _ => null
            };
        }

    }
}
