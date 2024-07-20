﻿using static System.Net.Mime.MediaTypeNames;

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
            //Button mapping
            commandImages.Add(InputCommand.One, "Images/Buttons/One.png");
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
            // Direction mapping
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
            commandImages.Add(InputCommand.HoldDownBack, "Images/Arrows/HoldDownBack.png");
            commandImages.Add(InputCommand.HoldDownForward, "Images/Arrows/HoldDownForward.png");
            commandImages.Add(InputCommand.Back, "Images/Arrows/Back.png");
            commandImages.Add(InputCommand.HoldBack, "Images/Arrows/HoldBack.png");
            commandImages.Add(InputCommand.Forward, "Images/Arrows/Forward.png");
            commandImages.Add(InputCommand.HoldForward, "Images/Arrows/HoldForward.png");
            commandImages.Add(InputCommand.Neutral, "Images/Arrows/Neutrol.png");
            // Miscellaneous
            commandImages.Add(InputCommand.CounterHit, "Images/Miscellaneous/CounterHit.png");
            commandImages.Add(InputCommand.CrouchCancel, "Images/Miscellaneous/CrouchCancel.png");
            commandImages.Add(InputCommand.Dash, "Images/Miscellaneous/Dash.png");
            commandImages.Add(InputCommand.FullCrouch, "Images/Miscellaneous/FullCrouch.png");
           // commandImages.Add(InputCommand.Heat, "Images/Miscellaneous/Heat.png");
            commandImages.Add(InputCommand.HeatBurst, "Images/Miscellaneous/HeatBurtst.png");
            commandImages.Add(InputCommand.HeatSmash, "Images/Miscellaneous/HeatSmash.png");
            commandImages.Add(InputCommand.JustFrame, "Images/Miscellaneous/JustFrame.png");
            commandImages.Add(InputCommand.MicroDash, "Images/Miscellaneous/Microdash.png");
            commandImages.Add(InputCommand.SideStepCrouch, "Images/Miscellaneous/SideStepCrouch.png");
            commandImages.Add(InputCommand.SideStepLeft, "Images/Miscellaneous/SideStepLeft.png");
            commandImages.Add(InputCommand.SideStepRight, "Images/Miscellaneous/SideStepRight.png");
            commandImages.Add(InputCommand.SideWalkLeft, "Images/Miscellaneous/SideWalkLeft.png");
            commandImages.Add(InputCommand.SideWalkRight, "Images/Miscellaneous/SideWalkRight.png");
            commandImages.Add(InputCommand.Tilde, "Images/Miscellaneous/Tilde.png");
            commandImages.Add(InputCommand.Tornado, "Images/Miscellaneous/Tornado.png");
            commandImages.Add(InputCommand.WhileRunning, "Images/Miscellaneous/WhileRunning.png");
            commandImages.Add(InputCommand.WhileStanding, "Images/Miscellaneous/WhileStanding.png");
            // StageInteractions
            commandImages.Add(InputCommand.BalconyBreak, "Images/StageInteractions/BalconyBreak.png");
            commandImages.Add(InputCommand.FloorBlast, "Images/StageInteractions/FloorBlast.png");
            commandImages.Add(InputCommand.FloorBreak, "Images/StageInteractions/FloorBreak.png");
            commandImages.Add(InputCommand.WallBlast, "Images/StageInteractions/WallBlast.png");
            commandImages.Add(InputCommand.WallBound, "Images/StageInteractions/WallBound.png");
            commandImages.Add(InputCommand.WallBreak, "Images/StageInteractions/WallBreak.png");
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
