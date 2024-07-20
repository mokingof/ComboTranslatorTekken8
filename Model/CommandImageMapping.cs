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
            commandImages.Add(InputCommand.OneTwo, "Images/Buttons/12.png");
            commandImages.Add(InputCommand.OneTwoThree, "Images/Buttons/123.png");
            commandImages.Add(InputCommand.OneTwoThreeFour, "Images/Buttons/1234.png");
            commandImages.Add(InputCommand.OneTwoFour, "Images/Buttons/124.png");
            commandImages.Add(InputCommand.OneThree, "Images/Buttons/13.png");
            commandImages.Add(InputCommand.OneThreeFour, "Images/Buttons/134.png");
            commandImages.Add(InputCommand.OneFour, "Images/Buttons/14.png");
            commandImages.Add(InputCommand.Two, "Images/Buttons/2.png");
            commandImages.Add(InputCommand.TwoThree, "Images/Buttons/23.png");
            commandImages.Add(InputCommand.TwoThreeFour, "Images/Buttons/234.png");
            commandImages.Add(InputCommand.TwoFour, "Images/Buttons/24.png");
            commandImages.Add(InputCommand.Three, "Images/Buttons/3.png");        
            commandImages.Add(InputCommand.ThreeFour, "Images/Buttons/34.png");
            commandImages.Add(InputCommand.Four, "Images/Buttons/4.png");

            commandImages.Add(InputCommand.Up, "Images/Arrows/Up.png");
            commandImages.Add(InputCommand.UpBack, "Images/Arrows/UpBack.png");
            commandImages.Add(InputCommand.UpForward, "Images/Arrows/UpForward.png");
            commandImages.Add(InputCommand.HoldUp, "Images/Arrows/HoldUp.png");
            commandImages.Add(InputCommand.HoldUpBack, "Images/Arrows/HoldUpBack.png");
            commandImages.Add(InputCommand.HoldUpForward, "Images/Arrows/HoldUpForward.png");
            commandImages.Add(InputCommand.Down, "Images/Arrows/Down.png");
            commandImages.Add(InputCommand.DownBack, "Images/Arrows/DownBack.png");
            commandImages.Add(InputCommand.DownForward, "Images/Arrows/DownForward.png");
            commandImages.Add(InputCommand.HoldDown, "Images/Arrows/HoldDown.png");
            commandImages.Add(InputCommand.HoldDownForward, "Images/Arrows/HoldDownBack.png");
            commandImages.Add(InputCommand.HoldDownForward, "Images/Arrows/HoldDownForward.png");
            commandImages.Add(InputCommand.Back, "Images/Arrows/Back.png");
            commandImages.Add(InputCommand.HoldBack, "Images/Arrows/HoldBack.png");
            commandImages.Add(InputCommand.Forward, "Images/Arrows/Forward.png");
            commandImages.Add(InputCommand.HoldForward, "Images/Arrows/HoldForward.png");
            commandImages.Add(InputCommand.Forward, "Images/Arrows/Neutrol.png");

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
