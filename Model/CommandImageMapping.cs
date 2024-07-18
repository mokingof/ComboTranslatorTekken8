using static System.Net.Mime.MediaTypeNames;

namespace ComboTranslatorTekken8.Model
{
    public class CommandImageMapping
    {
        private readonly Dictionary<InputCommand, string> commandImages;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CommandImageMapping()
        {
            this.webHostEnvironment = webHostEnvironment;
            commandImages = new Dictionary<InputCommand, string>();
            InitializeCommandImages();

        }

        private void InitializeCommandImages()
        {
            commandImages.Add(InputCommand.One, "Images/Buttons/1.png");
            commandImages.Add(InputCommand.Two, "Images/Buttons/2.png");
            commandImages.Add(InputCommand.Three, "Images/Buttons/3.png");
            commandImages.Add(InputCommand.Four, "Images/Buttons/4.png");

            commandImages.Add(InputCommand.Up, "Images/Arrows/Up.png");
            commandImages.Add(InputCommand.Down, "Images/Arrows/Down.png");
            commandImages.Add(InputCommand.Back, "Images/Arrows/Back.png");
            commandImages.Add(InputCommand.Forward, "Images/Arrows/Ford.png");
         
        }

        public string GetImagePath(InputCommand command)
        {
            if (commandImages.TryGetValue(command, out string relativePath))
            {
                return Path.Combine(webHostEnvironment.WebRootPath, relativePath);
            }

            throw new KeyNotFoundException($"No image mapping found for command: {command}");
        }

        public bool TryGetImagePath(InputCommand command, out string fullPath)
        {
            if (commandImages.TryGetValue(command, out string relativePath))
            {
                fullPath = Path.Combine(webHostEnvironment.WebRootPath, relativePath);
                return true;
            }

            fullPath = null;
            return false;
        }
    }
}
