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
                case "d":
                    command = InputCommand.DownForward;
                    return true;
                case "u":
                    command = InputCommand.Up;
                    return true;
                case "b":
                    command = InputCommand.Back;
                    return true;
                case "f":
                    command = InputCommand.Forward;
                    return true;
                // Add more cases as needed
                default:
                    command = InputCommand.Down; // Default value
                    return false;
            }
        }
    }
}