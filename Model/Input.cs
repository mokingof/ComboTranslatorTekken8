namespace ComboTranslatorTekken8.Model
{
    public enum InputCommand
    {
        // Button Commands
        [InputString("1")] One,
        [InputString("2")] Two,
        [InputString("3")] Three,
        [InputString("4")] Four,
        [InputString("1+2")] OneTwo,
        [InputString("1+3")] OneThree,
        [InputString("1+4")] OneFour,
        [InputString("2+3")] TwoThree,
        [InputString("2+4")] TwoFour,
        [InputString("3+4")] ThreeFour,
        [InputString("1+2+3")] OneTwoThree,
        [InputString("1+2+4")] OneTwoFour,
        [InputString("1+3+4")] OneThreeFour,
        [InputString("2+3+4")] TwoThreeFour,
        [InputString("1+2+3+4")] OneTwoThreeFour,

        // Direction Commands
        [InputString("N")] Neutral,
        [InputString("f")] Forward,
        [InputString("b")] Back,
        [InputString("u")] Up,
        [InputString("d")] Down,
        [InputString("F")] HoldForward,
        [InputString("B")] HoldBack,
        [InputString("U")] HoldUp,
        [InputString("D")] HoldDown,
        [InputString("u/f"), InputString("uf")] UpForward,
        [InputString("u/b"), InputString("ub")] UpBack,
        [InputString("d/f"), InputString("df")] DownForward,
        [InputString("d/b"), InputString("db")] DownBack,
        [InputString("U/F"), InputString("UF")] HoldUpForward,
        [InputString("U/B"), InputString("UB")] HoldUpBack,
        [InputString("D/F"), InputString("DF")] HoldDownForward,
        [InputString("D/B"), InputString("DB")] HoldDownBack,
        [InputString("qcf"), InputString("QCF")] QuarterCircleForward,
        [InputString("qcb"), InputString("QCB")] QuarterCircleBack,
        [InputString("hcf"), InputString("HCF")] HalfCircleForward,
        [InputString("hcb"), InputString("HCB")] HalfCircleBack,
       // [InputString("SS")] SideStep,
        [InputString("ssl"), InputString("SSL")] SideStepLeft,
        [InputString("ssr"), InputString("SSR")] SideStepRight,
        [InputString("swl"), InputString("SWL")] SideWalkLeft,
        [InputString("swr"), InputString("SWR")] SideWalkRight,
        [InputString("ssc"), InputString("SSC")] SideStepCrouch,

        // Stage Gimmicks
        [InputString("bb"), InputString("BB")] BalconyBreak,
        [InputString("fb"), InputString("FB")] FloorBlast,
        [InputString("flb"), InputString("FLB")] FloorBreak,
        [InputString("wb"), InputString("WB")] WallBlast,
        [InputString("wbo"), InputString("WBO")] WallBound,
        [InputString("wbr"), InputString("WBR")] WallBreak,

        // Misc
        [InputString("hs"), InputString("HS")] HeatSmash,
        [InputString("hd"), InputString("HD")] HeadDash,
        [InputString("hb"), InputString("HB")] HeatBurst,
        [InputString("tor"), InputString("TOR")] Tornado,
        [InputString("jf"), InputString("JF")] JustFrame,
        [InputString("cc"), InputString("CC")] CrouchCancel,
        [InputString("fc"), InputString("FC")] FullCrouch,
        [InputString("ch"), InputString("CH")] CounterHit,
        [InputString("dash"), InputString("DASH")] Dash,
        [InputString("md"), InputString("MD")] MicroDash,
        [InputString("wr"), InputString("WR")] WhileRunning,
        [InputString("ws"), InputString("WS")] WhileStanding,
        [InputString("~")] Tilde,
       // [InputString(",")] Separator
    }
    public class Input
    {
        public InputCommand Command { get; set; }

        // Optional: If you need to store additional information about the input
        public string RawInputString { get; set; }
        public Input(InputCommand command, string rawInputString = null)
        {
            Command = command;
            RawInputString = rawInputString;
        }
        public override string ToString()
        {
            return $"Command: {Command}, Raw Input: {RawInputString ?? "N/A"}";
        }
    }
}
