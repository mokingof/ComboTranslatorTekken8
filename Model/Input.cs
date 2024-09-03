namespace ComboTranslatorTekken8.Model.Utilities;

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
    [InputString("n")] Neutral,
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
   
    // Special direction
    [InputString("qcf"), InputString("QCF")] QuarterCircleForward,
    [InputString("qcb"), InputString("QCB")] QuarterCircleBack,
    //[InputString("hcf"), InputString("HCF")] HalfCircleForward,
    //[InputString("hcb"), InputString("HCB")] HalfCircleBack,
    
    [InputString("ssl"), InputString("SSL")] SideStepLeft,
    [InputString("ssr"), InputString("SSR")] SideStepRight,
    [InputString("swl"), InputString("SWL")] SideWalkLeft,
    [InputString("swr"), InputString("SWR")] SideWalkRight,
    [InputString("ssc"), InputString("SSC")] SideStepCrouch,

    // Stage Interactions
    [InputString("bb!"), InputString("BB!")] BalconyBreak,
    [InputString("fbl!"), InputString("FBL!")] FloorBlast,
    [InputString("fb!"), InputString("FB!")] FloorBreak,
    [InputString("wbl!"), InputString("WBL!")] WallBlast,
    [InputString("wbo!"), InputString("WBO!")] WallBound,
    [InputString("wb!"), InputString("WB!")] WallBreak,

    // Misc
    [InputString("h!"), InputString("H!")] Heat,
    [InputString("hs!"), InputString("HS!")] HeatSmash,
    //[InputString("hd!"), InputString("HD!")] HeadDash,
    [InputString("hb!"), InputString("HB!")] HeatBurst,
    [InputString("t!"), InputString("T!")] Tornado,
    [InputString("jf"), InputString("JF")] JustFrame,
    [InputString("cc"), InputString("CC")] CrouchCancel,
    [InputString("fc"), InputString("FC")] FullCrouch,
    [InputString("ch"), InputString("CH")] CounterHit,
    [InputString("dash"), InputString("DASH")] Dash,
    [InputString("microdash"), InputString("mc")] MicroDash,
    [InputString("wr"), InputString("WR")] WhileRunning,
    [InputString("ws"), InputString("WS")] WhileStanding,
    [InputString("~")] Tilde,
    [InputString(",")] Separator,
    
    // Stances
    [InputString("aop"), InputString("AOP")] AOP,
    [InputString("bkp"), InputString("BKP")] BKP,
    [InputString("bok"), InputString("BOK")] BOK,
    [InputString("bt"), InputString("BT")] BT,
    [InputString("cd"), InputString("CD")] CD,
    [InputString("cfo"), InputString("CFO")] CFO,
    [InputString("cft"), InputString("CFT")] CFT,
    [InputString("dbt"), InputString("DBT")] DBT,
    [InputString("dck"), InputString("DCK")] DCK,
    [InputString("den"), InputString("DEN")] DEN,
    [InputString("des"), InputString("DES")] DES,
    [InputString("dew"), InputString("DEW")] DEW,
    [InputString("dgf"), InputString("DGF")] DGF,
    [InputString("dpd"), InputString("DPD")] DPD,
    [InputString("dss"), InputString("DSS")] DSS,
    [InputString("ext_dck"), InputString("EXT_DCK")] EXT_DCK,
    [InputString("flea"), InputString("FLEA")] FLEA,
    [InputString("flk"), InputString("FLK")] FLK,
    [InputString("fly"), InputString("FLY")] FLY,
    [InputString("gen"), InputString("Gen")] GEN,
    [InputString("gmc"), InputString("GMC")] GMC,
    [InputString("gmh"), InputString("GMH")] GMH,
    [InputString("gs"), InputString("GS")] GS,
    [InputString("hae"), InputString("HAE")] HAE,
    [InputString("hbs"), InputString("HBS")] HBS,
    [InputString("hms"), InputString("HMS")] HMS,
    [InputString("hyp"), InputString("HYP")] HYP,
    [InputString("iai"), InputString("IAI")] IAI,
    [InputString("ind"), InputString("IND")] IND,
    [InputString("isw"), InputString("ISW")] ISW,
    [InputString("izu"), InputString("IZU")] IZU,
    [InputString("jag"), InputString("JAG")] JAG,
    [InputString("jgs"), InputString("JGS")] JGS,
    [InputString("kin"), InputString("KIN")] KIN,
    [InputString("knk"), InputString("KNK")] KNK,
    [InputString("len"), InputString("LEN")] LEN,
    [InputString("iff"), InputString("IFF")] IFF,
    [InputString("lfs"), InputString("LFS")] LFS,
    [InputString("lib"), InputString("LIB")] LIB,
    [InputString("inh"), InputString("INH")] INH,
    [InputString("mcr"), InputString("MCR")] MCR,
    [InputString("med"), InputString("MED")] MED,
    [InputString("mia"), InputString("MIA")] MIA,
    [InputString("mnt"), InputString("MNT")] MNT,
    [InputString("nss"), InputString("NSS")] NSS,
    [InputString("nwg"), InputString("NWG")] NWG,
    [InputString("pab"), InputString("PAB")] PAB,
    [InputString("prf"), InputString("PRF")] PRF,
    [InputString("rab"), InputString("RAB")] RAB,
    [InputString("rds"), InputString("RDS")] RDS,
    [InputString("rff"), InputString("RFF")] RFF,
    [InputString("rfs"), InputString("RFS")] RFS,
    [InputString("rlx"), InputString("RLX")] RLX,
    [InputString("roll"), InputString("ROLL")] ROLL,
    [InputString("sbt"), InputString("SBT")] SBT,
    [InputString("scr"), InputString("SCR")] SCR,
    [InputString("sen"), InputString("SEN")] SEN,
    [InputString("sit"), InputString("SIT")] SIT,
    [InputString("sne"), InputString("SNE")] SNE,
    [InputString("snk"), InputString("SNK")] SNK,
    [InputString("stb"), InputString("STB")] STB,
    [InputString("stc"), InputString("STC")] STC,
    [InputString("swa"), InputString("SWA")] SWA,
    [InputString("swy"), InputString("SWY")] SWY,
    [InputString("szn"), InputString("SZN")] SZN,
    [InputString("taw"), InputString("TAW")] TAW,
    [InputString("trt"), InputString("TRT")] TRT,
    [InputString("uns"), InputString("UNS")] UNS,
    [InputString("vac"), InputString("VAC")] VAC,
    [InputString("wra"), InputString("WRA")] WRA,
    [InputString("zen"), InputString("ZEN")] ZEN



}
public class Input
{
    public InputCommand Command { get; set; }
    public Input(InputCommand command)
    {
        Command = command;  
    }
    public override string ToString()
    {
        return $"Command: {Command}";
    }
}
