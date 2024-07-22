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


              char[] delimiters = { ',', ' ' };
               List<string>? tokens = combo.Split(delimiters).ToList();

            if (!string.IsNullOrEmpty(combo))
            {
                var command = _inputParser.ParseInput(tokens);
                if (command != null)
                {
                    var imagePath = _imageMapping.GetWebAccessibleImagePath(command.Value);
                    if (imagePath != null)
                    {
                        imagePaths.Add(imagePath);
                    }
                }

            }
            return new JsonResult(imagePaths);
        }

    }
}