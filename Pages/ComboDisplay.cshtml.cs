using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ComboTranslatorTekken8.Model;
using System.Collections.Generic;

namespace ComboTranslatorTekken8.Pages
{
    public class ComboDisplayModel : PageModel
    {
        private readonly CommandImageMapping _imageMapping;

        public ComboDisplayModel(CommandImageMapping imageMapping)
        {
            _imageMapping = imageMapping;
        }

        public IActionResult OnGetParseCombo(string combo)
        {
            var imagePaths = new List<string>();
            
            if (!string.IsNullOrEmpty(combo))
            {
                foreach (char c in combo)
                {
                    if (TryParseInput(c.ToString(), out InputCommand command) &&
                        _imageMapping.TryGetImagePath(command, out string imagePath))
                    {
                        imagePaths.Add(imagePath);
                    }
                }
            }
            return new JsonResult(imagePaths);
        }

        private bool TryParseInput(string key, out InputCommand command)
        {
            switch (key)
            {
                case "1":
                    command = InputCommand.One;
                    return true;          
                case "2":
                    command = InputCommand.Two;
                    return true;          
                case "3":
                    command = InputCommand.Three;
                    return true;
                case "4":
                    command = InputCommand.Four;
                    return true;
                case "b":
                    command = InputCommand.Back;
                    return true;
                case "d":
                    command = InputCommand.Down;
                    return true;
                case "f":
                    command = InputCommand.Forward;
                    return true;
                case "u":
                    command = InputCommand.Up;
                    return true;
                case "B":
                    command = InputCommand.HoldBack;
                    return true;
                case "D":
                    command = InputCommand.HoldDown;
                    return true;
                case "F":
                    command = InputCommand.HoldForward;
                    return true;
                case "U":
                    command = InputCommand.HoldUp;
                    return true;
                case "n":
                    command = InputCommand.Neutral;
                    return true;
                default:
                    command = InputCommand.Down; // Default value
                    return false;
            }
        }
    }
}