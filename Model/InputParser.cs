using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Reflection;

namespace ComboTranslatorTekken8.Model
{
    public class InputParser
    {
       
        public InputCommand? ParseInput(string inputString)
        {
            return null;
        }

        public InputCommand? ParseSingleInput(string notation)
        {
            return notation switch
            {
                "1" => InputCommand.One,
                "2" => InputCommand.Two,
                "3" => InputCommand.Three,
                "4" => InputCommand.Four,
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

    }
}
