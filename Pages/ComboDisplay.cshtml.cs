using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ComboTranslatorTekken8.Model;
using System.Collections.Generic;

namespace ComboTranslatorTekken8.Pages
{
    public class ComboDisplayModel : PageModel
    {
        private readonly CommandImageMapping _imageMapping;
        private readonly InputParser _inputParser = new();  

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
                    var command = ParseInput(c.ToString());
                    if (command != null)
                    {
                        var imagePath = _imageMapping.GetWebAccessibleImagePath(command.Value);
                        if (imagePath != null)
                        {
                            imagePaths.Add(imagePath);
                        }
                    }
                }
            }
            return new JsonResult(imagePaths);
        }

        private InputCommand? ParseInput(string key)
        {
            switch (key)
            {
                case "1": return InputCommand.One;
                case "2": return InputCommand.Two;
                case "3": return InputCommand.Three;
                case "4": return InputCommand.Four;
                case "b": return InputCommand.Back;
                case "d": return InputCommand.Down;
                case "f": return InputCommand.Forward;
                case "u": return InputCommand.Up;
                default: return null;
            }
        }
    }
}