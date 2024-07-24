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
        public string GetImagePath(InputCommand command)
        {

            if (commandImages.ContainsKey(command))
            {
                string relativePath = commandImages[command];
                return Path.Combine(webHostEnvironment.WebRootPath, relativePath);
            }

            throw new KeyNotFoundException($"No image mapping found for command: {command}");
        }

        public string GetWebAccessibleImagePath(InputCommand command)
        {
            if (commandImages.ContainsKey(command))
            {
                string relativePath = commandImages[command];
                return $"/Images/AllImages/{Path.GetFileName(relativePath)}";
            }
            return null;
        }

        private void InitializeCommandImages()
        {
            //Button mapping
            commandImages.Add(InputCommand.One, "Images/Buttons/One.png");
            commandImages.Add(InputCommand.OneTwo, "Images/Buttons/OneTwo.png");
            commandImages.Add(InputCommand.OneTwoThree, "Images/Buttons/OneTwoThree.png");
            commandImages.Add(InputCommand.OneTwoThreeFour, "Images/Buttons/OneTwoThreeFour.png");
            commandImages.Add(InputCommand.OneTwoFour, "Images/Buttons/OneTwoFour.png");
            commandImages.Add(InputCommand.OneThree, "Images/Buttons/OneThree.png");
            commandImages.Add(InputCommand.OneThreeFour, "Images/Buttons/OneThreeFour.png");
            commandImages.Add(InputCommand.OneFour, "Images/Buttons/OneFour.png");
            commandImages.Add(InputCommand.Two, "Images/Buttons/Two.png");
            commandImages.Add(InputCommand.TwoThree, "Images/Buttons/TwoThree.png");
            commandImages.Add(InputCommand.TwoThreeFour, "Images/Buttons/TwoThreeFour.png");
            commandImages.Add(InputCommand.TwoFour, "Images/Buttons/TwoFour.png");
            commandImages.Add(InputCommand.Three, "Images/Buttons/Three.png");
            commandImages.Add(InputCommand.ThreeFour, "Images/Buttons/ThreeFour.png");
            commandImages.Add(InputCommand.Four, "Images/Buttons/Four.png");
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
            commandImages.Add(InputCommand.QuarterCircleForward, "Images/Arrows/qcf.png");
            // Miscellaneous
            commandImages.Add(InputCommand.CounterHit, "Images/Miscellaneous/CounterHit.png");
            commandImages.Add(InputCommand.CrouchCancel, "Images/Miscellaneous/CrouchCancel.png");
            commandImages.Add(InputCommand.Dash, "Images/Miscellaneous/Dash.png");
            commandImages.Add(InputCommand.FullCrouch, "Images/Miscellaneous/FullCrouch.png");
            commandImages.Add(InputCommand.Heat, "Images/Miscellaneous/Heat.png");
            commandImages.Add(InputCommand.HeatBurst, "Images/Miscellaneous/HeatBurst.png");
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
            commandImages.Add(InputCommand.Separator, "Images/Miscellaneous/Next.png");
            // StageInteractions
            commandImages.Add(InputCommand.BalconyBreak, "Images/StageInteractions/BalconyBreak.png");
            commandImages.Add(InputCommand.FloorBlast, "Images/StageInteractions/FloorBlast.png");
            commandImages.Add(InputCommand.FloorBreak, "Images/StageInteractions/FloorBreak.png");
            commandImages.Add(InputCommand.WallBlast, "Images/StageInteractions/WallBlast.png");
            commandImages.Add(InputCommand.WallBound, "Images/StageInteractions/WallBound.png");
            commandImages.Add(InputCommand.WallBreak, "Images/StageInteractions/WallBreak.png");
            //Stances
            commandImages.Add(InputCommand.AOP, "Images/Stances/aop.png");
            commandImages.Add(InputCommand.BKP, "Images/Stances/bkp.png");
            commandImages.Add(InputCommand.BOK, "Images/Stances/bok.png");
            commandImages.Add(InputCommand.BT, "Images/Stances/bt.png");
            commandImages.Add(InputCommand.CD, "Images/Stances/cd.png");
            commandImages.Add(InputCommand.CFO, "Images/Stances/cfo.png");
            commandImages.Add(InputCommand.CFT, "Images/Stances/cft.png");
            commandImages.Add(InputCommand.DBT, "Images/Stances/dbt.png");
            commandImages.Add(InputCommand.DCK, "Images/Stances/dck.png");
            commandImages.Add(InputCommand.DEN, "Images/Stances/den.png");
            commandImages.Add(InputCommand.DES, "Images/Stances/des.png");
            commandImages.Add(InputCommand.DEW, "Images/Stances/dew.png");
            commandImages.Add(InputCommand.DGF, "Images/Stances/dgf.png");
            commandImages.Add(InputCommand.DPD, "Images/Stances/dpd.png");
            commandImages.Add(InputCommand.DSS, "Images/Stances/dss.png");
            commandImages.Add(InputCommand.EXT_DCK, "Images/Stances/ext_dck.png");
            commandImages.Add(InputCommand.FLEA, "Images/Stances/flea.png");
            commandImages.Add(InputCommand.FLK, "Images/Stances/flk.png");
            commandImages.Add(InputCommand.FLY, "Images/Stances/fly.png");
            commandImages.Add(InputCommand.GEN, "Images/Stances/gen.png");
            commandImages.Add(InputCommand.GMC, "Images/Stances/gmc.png");
            commandImages.Add(InputCommand.GMH, "Images/Stances/gmh.png");
            commandImages.Add(InputCommand.GS, "Images/Stances/gs.png");
            commandImages.Add(InputCommand.HAE, "Images/Stances/hae.png");
            commandImages.Add(InputCommand.HBS, "Images/Stances/hbs.png");
            commandImages.Add(InputCommand.HMS, "Images/Stances/hms.png");
            commandImages.Add(InputCommand.HYP, "Images/Stances/hyp.png");
            commandImages.Add(InputCommand.IAI, "Images/Stances/iai.png");
            commandImages.Add(InputCommand.IND, "Images/Stances/ind.png");
            commandImages.Add(InputCommand.ISW, "Images/Stances/isw.png");
            commandImages.Add(InputCommand.IZU, "Images/Stances/izu.png");
            commandImages.Add(InputCommand.JAG, "Images/Stances/jag.png");
            commandImages.Add(InputCommand.JGS, "Images/Stances/jgs.png");
            commandImages.Add(InputCommand.KIN, "Images/Stances/kin.png");
            commandImages.Add(InputCommand.KNK, "Images/Stances/knk.png");
            commandImages.Add(InputCommand.LEN, "Images/Stances/len.png");
            commandImages.Add(InputCommand.IFF, "Images/Stances/iff.png");
            commandImages.Add(InputCommand.LFS, "Images/Stances/lfs.png");
            commandImages.Add(InputCommand.LIB, "Images/Stances/lib.png");
            commandImages.Add(InputCommand.INH, "Images/Stances/inh.png");
            commandImages.Add(InputCommand.MCR, "Images/Stances/mcr.png");
            commandImages.Add(InputCommand.MED, "Images/Stances/med.png");
            commandImages.Add(InputCommand.MIA, "Images/Stances/mia.png");
            commandImages.Add(InputCommand.MNT, "Images/Stances/mnt.png");
            commandImages.Add(InputCommand.NSS, "Images/Stances/nss.png");
            commandImages.Add(InputCommand.NWG, "Images/Stances/nwg.png");
            commandImages.Add(InputCommand.PAB, "Images/Stances/pab.png");
            commandImages.Add(InputCommand.PRF, "Images/Stances/prf.png");
            commandImages.Add(InputCommand.RAB, "Images/Stances/rab.png");
            commandImages.Add(InputCommand.RDS, "Images/Stances/rds.png");
            commandImages.Add(InputCommand.RFF, "Images/Stances/rff.png");
            commandImages.Add(InputCommand.RFS, "Images/Stances/rfs.png");
            commandImages.Add(InputCommand.RLX, "Images/Stances/rlx.png");
            commandImages.Add(InputCommand.ROLL,"Images/Stances/roll.png");
            commandImages.Add(InputCommand.SBT, "Images/Stances/sbt.png");
            commandImages.Add(InputCommand.SCR, "Images/Stances/scr.png");
            commandImages.Add(InputCommand.SEN, "Images/Stances/sen.png");
            commandImages.Add(InputCommand.SIT, "Images/Stances/sit.png");
            commandImages.Add(InputCommand.SNE, "Images/Stances/sne.png");
            commandImages.Add(InputCommand.SNK, "Images/Stances/snk.png");
            commandImages.Add(InputCommand.STB, "Images/Stances/stb.png");
            commandImages.Add(InputCommand.STC, "Images/Stances/stc.png");
            commandImages.Add(InputCommand.SWA, "Images/Stances/swa.png");
            commandImages.Add(InputCommand.SWY, "Images/Stances/swy.png");
            commandImages.Add(InputCommand.SZN, "Images/Stances/szn.png");
            commandImages.Add(InputCommand.TAW, "Images/Stances/taw.png");
            commandImages.Add(InputCommand.TRT, "Images/Stances/trt.png");
            commandImages.Add(InputCommand.UNS, "Images/Stances/uns.png");
            commandImages.Add(InputCommand.VAC, "Images/Stances/vac.png");
            commandImages.Add(InputCommand.WRA, "Images/Stances/wra.png");
            commandImages.Add(InputCommand.ZEN, "Images/Stances/zen.png");
        }
    }
}
