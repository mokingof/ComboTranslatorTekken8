using static System.Net.Mime.MediaTypeNames;

namespace ComboTranslatorTekken8.Model
{
    public class CommandImageMapping
    {
        private readonly Dictionary<InputCommand, string> commandImages;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CommandImageMapping(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
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
            commandImages.Add(InputCommand.Forward, "Images/Arrows/Forward.png");
         
        }

        public string GetImagePath(InputCommand command)
        {
            if (commandImages.TryGetValue(command, out string relativePath))
            {
                return Path.Combine(webHostEnvironment.WebRootPath, relativePath);
            }

            throw new KeyNotFoundException($"No image mapping found for command: {command}");
        }

        public bool TryGetImagePath(InputCommand command, out string imagePath)
        {
            if (commandImages.TryGetValue(command, out string relativePath))
            {
                // Convert the relative path to a web-accessible path
                imagePath = $"/Images/Arrows/{Path.GetFileName(relativePath)}";
                return true;
            }
            imagePath = null;
            return false;
        }
    }
}
