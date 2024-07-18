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
        [InputString("qcf")] QuarterCircleForward,
        [InputString("qcb")] QuarterCircleBack,
        [InputString("hcf")] HalfCircleForward,
        [InputString("hcb")] HalfCircleBack,
        [InputString("SS")] SideStep,
        [InputString("SSL")] SideStepLeft,
        [InputString("SSR")] SideStepRight,
        [InputString("SWL")] SideWalkLeft,
        [InputString("SWR")] SideWalkRight,
        [InputString("SSC")] SideStepCrouch,

        // Stage Gimmicks
        [InputString("BB")] BalconyBreak,
        [InputString("FB")] FloorBlast,
        [InputString("FLB")] FloorBreak,
        [InputString("WB")] WallBlast,
        [InputString("WBO")] WallBound,
        [InputString("WBR")] WallBreak,

        // Misc
        [InputString("HS")] HeatSmash,
        [InputString("HD")] HeadDash,
        [InputString("HB")] HeatBurst,
        [InputString("TOR")] Tornado,
        [InputString("JF")] JustFrame,
        [InputString("CC")] CrouchCancel,
        [InputString("FC")] FullCrouch,
        [InputString("CH")] CounterHit,
        [InputString("DASH")] Dash,
        [InputString("MD")] MicroDash,
        [InputString("WR")] WhileRunning,
        [InputString("WS")] WhileStanding,
        [InputString("~")] Tilde,
        [InputString(",")] Separator
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
