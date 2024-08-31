using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ComboTranslatorTekken8.Model;
using System.Collections.Generic;
using ComboTranslatorTekken8.Model.Parsing;
using ComboTranslatorTekken8.Model.Utilities;

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
                List<InputCommand?> commands = _inputParser.ParseInput(combo);
                foreach (var inputCommand in commands)
                {
                    if (inputCommand.HasValue)
                    {
                        var imagePath = _imageMapping.GetWebAccessibleImagePath(inputCommand.Value);
                        if (imagePath != null)
                        {
                            imagePaths.Add(imagePath);
                        }
                    }
                }
            }
            return new JsonResult(imagePaths);
        }

    }
}