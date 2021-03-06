﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Xml;
using GTA;
using _InputChecker;
using _ItemListForm;

namespace Inferno.Scripts
{
    static public class Share
    {
        
        internal static int POINTs=0;
        internal static bool NitroLimit = false;
        internal static bool ScriptError = false;
        internal static bool PonkotsuInferno = false;
        internal static bool Nico_Parupunte = false;
        internal static int Nico_Engo = 0;


        public enum eModel
        {
            // Peds
            PLAYER = unchecked((int)0x6F0783F5),
            M_Y_MULTIPLAYER = unchecked((int)0x879495E2),
            F_Y_MULTIPLAYER = unchecked((int)0xD9BDC03A),
            SUPERLOD = unchecked((int)0xAE4B15D6),
            IG_ANNA = unchecked((int)0x6E7BF45F),
            IG_ANTHONY = unchecked((int)0x9DD666EE),
            IG_BADMAN = unchecked((int)0x5927A320),
            IG_BERNIE_CRANE = unchecked((int)0x596FB508),
            IG_BLEDAR = unchecked((int)0x6734C2C8),
            IG_BRIAN = unchecked((int)0x192BDD4A),
            IG_BRUCIE = unchecked((int)0x98E29920),
            IG_BULGARIN = unchecked((int)0x0E28247F),
            IG_CHARISE = unchecked((int)0x0548F609),
            IG_CHARLIEUC = unchecked((int)0xB0D18783),
            IG_CLARENCE = unchecked((int)0x500EC110),
            IG_DARDAN = unchecked((int)0x5786C78F),
            IG_DARKO = unchecked((int)0x1709B920),
            IG_DERRICK_MC = unchecked((int)0x45B445F9),
            IG_DMITRI = unchecked((int)0x0E27ECC1),
            IG_DWAYNE = unchecked((int)0xDB354C19),
            IG_EDDIELOW = unchecked((int)0xA09901F1),
            IG_FAUSTIN = unchecked((int)0x03691799),
            IG_FRANCIS_MC = unchecked((int)0x65F4D88D),
            IG_FRENCH_TOM = unchecked((int)0x54EABEE4),
            IG_GORDON = unchecked((int)0x7EED7363),
            IG_GRACIE = unchecked((int)0xEAAEA78E),
            IG_HOSSAN = unchecked((int)0x3A7556B2),
            IG_ILYENA = unchecked((int)0xCE3779DA),
            IG_ISAAC = unchecked((int)0xE369F2A6),
            IG_IVAN = unchecked((int)0x458B61F3),
            IG_JAY = unchecked((int)0x15BCAD23),
            IG_JASON = unchecked((int)0x0A2D8896),
            IG_JEFF = unchecked((int)0x17446345),
            IG_JIMMY = unchecked((int)0xEA28DB14),
            IG_JOHNNYBIKER = unchecked((int)0xC9AB7F1C),
            IG_KATEMC = unchecked((int)0xD1E17FCA),
            IG_KENNY = unchecked((int)0x3B574ABA),
            IG_LILJACOB = unchecked((int)0x58A1E271),
            IG_LILJACOBW = unchecked((int)0xB4008E4D),
            IG_LUCA = unchecked((int)0xD75A60C8),
            IG_LUIS = unchecked((int)0xE2A57E5E),
            IG_MALLORIE = unchecked((int)0xC1FE7952),
            IG_MAMC = unchecked((int)0xECC3FBA7),
            IG_MANNY = unchecked((int)0x5629F011),
            IG_MARNIE = unchecked((int)0x188232D0),
            IG_MEL = unchecked((int)0xCFE0FB92),
            IG_MICHAEL = unchecked((int)0x2BD27039),
            IG_MICHELLE = unchecked((int)0xBF9672F4),
            IG_MICKEY = unchecked((int)0xDA0D3182),
            IG_PACKIE_MC = unchecked((int)0x64C74D3B),
            IG_PATHOS = unchecked((int)0xF6237664),
            IG_PETROVIC = unchecked((int)0x8BE8B7F2),
            IG_PHIL_BELL = unchecked((int)0x932272CA),
            IG_PLAYBOY_X = unchecked((int)0x6AF081E8),
            IG_RAY_BOCCINO = unchecked((int)0x38E02AB6),
            IG_RICKY = unchecked((int)0xDCFE251C),
            IG_ROMAN = unchecked((int)0x89395FC9),
            IG_ROMANW = unchecked((int)0x2145C7A5),
            IG_SARAH = unchecked((int)0xFEF00775),
            IG_TUNA = unchecked((int)0x528AE104),
            IG_VINNY_SPAZ = unchecked((int)0xC380AE97),
            IG_VLAD = unchecked((int)0x356E1C42),
            CS_ANDREI = unchecked((int)0x3977107D),
            CS_ANGIE = unchecked((int)0xF866DC66),
            CS_BADMAN = unchecked((int)0xFC012F67),
            CS_BLEDAR = unchecked((int)0xA2DDDBA7),
            CS_BULGARIN = unchecked((int)0x009E4F3E),
            CS_BULGARINHENCH = unchecked((int)0x1F32DB93),
            CS_CIA = unchecked((int)0x4B13F8D4),
            CS_DARDAN = unchecked((int)0xF4386436),
            CS_DAVETHEMATE = unchecked((int)0x1A5B22F0),
            CS_DMITRI = unchecked((int)0x030B4624),
            CS_EDTHEMATE = unchecked((int)0xC74969B0),
            CS_FAUSTIN = unchecked((int)0xA776BDC7),
            CS_FRANCIS = unchecked((int)0x4AA2E9EA),
            CS_HOSSAN = unchecked((int)0x2B578C90),
            CS_ILYENA = unchecked((int)0x2EB3F295),
            CS_IVAN = unchecked((int)0x4A85C1C4),
            CS_JAY = unchecked((int)0x96E9F99A),
            CS_JIMMY_PEGORINO = unchecked((int)0x7055C230),
            CS_MEL = unchecked((int)0x298ACEC3),
            CS_MICHELLE = unchecked((int)0x70AEB9C8),
            CS_MICKEY = unchecked((int)0xA1DFB431),
            CS_OFFICIAL = unchecked((int)0x311DB819),
            CS_RAY_BOCCINO = unchecked((int)0xD09ECB11),
            CS_SERGEI = unchecked((int)0xDBAC6805),
            CS_VLAD = unchecked((int)0x7F5B9540),
            CS_WHIPPINGGIRL = unchecked((int)0x5A6C9C5F),
            CS_MANNY = unchecked((int)0xD0F8F893),
            CS_ANTHONY = unchecked((int)0x6B941ABA),
            CS_ASHLEY = unchecked((int)0x26C3D079),
            CS_ASSISTANT = unchecked((int)0x394C11AD),
            CS_CAPTAIN = unchecked((int)0xE6829281),
            CS_CHARLIEUC = unchecked((int)0xEC96EE3A),
            CS_DARKO = unchecked((int)0xC4B4204C),
            CS_DWAYNE = unchecked((int)0xFB9190AC),
            CS_ELI_JESTER = unchecked((int)0x3D47C135),
            CS_ELIZABETA = unchecked((int)0xAED416AF),
            CS_GAYTONY = unchecked((int)0x04F78844),
            CS_GERRYMC = unchecked((int)0x26DE3A8A),
            CS_GORDON = unchecked((int)0x49D3EAD3),
            CS_ISSAC = unchecked((int)0xB93A5686),
            CS_JOHNNYTHEBIKER = unchecked((int)0x2E009A8D),
            CS_JONGRAVELLI = unchecked((int)0xD7D47612),
            CS_JORGE = unchecked((int)0x5906B7A5),
            CS_KAT = unchecked((int)0x71A11E4C),
            CS_KILLER = unchecked((int)0xB4D0F581),
            CS_LUIS = unchecked((int)0x5E730218),
            CS_MAGICIAN = unchecked((int)0x1B508682),
            CS_MAMC = unchecked((int)0xA17C3253),
            CS_MELODY = unchecked((int)0xEA01EFDC),
            CS_MITCHCOP = unchecked((int)0xD8BA6C47),
            CS_MORI = unchecked((int)0x9B333E73),
            CS_PBXGIRL2 = unchecked((int)0xE9C3C332),
            CS_PHILB = unchecked((int)0x5BEB1A2D),
            CS_PLAYBOYX = unchecked((int)0xE9F368C6),
            CS_PRIEST = unchecked((int)0x4D6DE57E),
            CS_RICKY = unchecked((int)0x88F35A20),
            CS_TOMMY = unchecked((int)0x626C3F77),
            CS_TRAMP = unchecked((int)0x553CBE07),
            CS_BRIAN = unchecked((int)0x2AF6831D),
            CS_CHARISE = unchecked((int)0x7AE0A064),
            CS_CLARENCE = unchecked((int)0xE7AC8418),
            CS_EDDIELOW = unchecked((int)0x6463855D),
            CS_GRACIE = unchecked((int)0x999B9B33),
            CS_JEFF = unchecked((int)0x17C32FB4),
            CS_MARNIE = unchecked((int)0x574DE134),
            CS_MARSHAL = unchecked((int)0x8B0322AF),
            CS_PATHOS = unchecked((int)0xD77D71DF),
            CS_SARAH = unchecked((int)0xEFF3F84D),
            CS_ROMAN_D = unchecked((int)0x42F6375E),
            CS_ROMAN_T = unchecked((int)0x6368F847),
            CS_ROMAN_W = unchecked((int)0xE37B786A),
            CS_BRUCIE_B = unchecked((int)0x0E37C613),
            CS_BRUCIE_T = unchecked((int)0x0E1B45E6),
            CS_BRUCIE_W = unchecked((int)0x765C9667),
            CS_BERNIE_CRANEC = unchecked((int)0x7183C75F),
            CS_BERNIE_CRANET = unchecked((int)0x4231E7AC),
            CS_BERNIE_CRANEW = unchecked((int)0x1B4899DE),
            CS_LILJACOB_B = unchecked((int)0xB0B4BC37),
            CS_LILJACOB_J = unchecked((int)0x7EF858B3),
            CS_MALLORIE_D = unchecked((int)0x5DF63F45),
            CS_MALLORIE_J = unchecked((int)0xCC381BCB),
            CS_MALLORIE_W = unchecked((int)0x45768E2E),
            CS_DERRICKMC_B = unchecked((int)0x8469C377),
            CS_DERRICKMC_D = unchecked((int)0x2FBC9A1E),
            CS_MICHAEL_B = unchecked((int)0x7D0BADD3),
            CS_MICHAEL_D = unchecked((int)0xCF5FD27A),
            CS_PACKIEMC_B = unchecked((int)0x4DFB1B0C),
            CS_PACKIEMC_D = unchecked((int)0x68EED0F3),
            CS_KATEMC_D = unchecked((int)0xAF3F2AC0),
            CS_KATEMC_W = unchecked((int)0x4ABDE1C7),
            M_Y_GAFR_LO_01 = unchecked((int)0xEE0BB2A4),
            M_Y_GAFR_LO_02 = unchecked((int)0xBBD14E30),
            M_Y_GAFR_HI_01 = unchecked((int)0x33D38899),
            M_Y_GAFR_HI_02 = unchecked((int)0x25B4EC5C),
            M_Y_GALB_LO_01 = unchecked((int)0xE1F6A366),
            M_Y_GALB_LO_02 = unchecked((int)0xF1F54363),
            M_Y_GALB_LO_03 = unchecked((int)0x0C61783B),
            M_Y_GALB_LO_04 = unchecked((int)0x1EA71CCE),
            M_M_GBIK_LO_03 = unchecked((int)0x029035B4),
            M_Y_GBIK_HI_01 = unchecked((int)0x5044865F),
            M_Y_GBIK_HI_02 = unchecked((int)0x9C071DE3),
            M_Y_GBIK02_LO_02 = unchecked((int)0xA8E69DBF),
            M_Y_GBIK_LO_01 = unchecked((int)0x5DDE4F9B),
            M_Y_GBIK_LO_02 = unchecked((int)0x8B932B00),
            M_Y_GIRI_LO_01 = unchecked((int)0x10B7B44B),
            M_Y_GIRI_LO_02 = unchecked((int)0xFEDA1090),
            M_Y_GIRI_LO_03 = unchecked((int)0x6DF3EEC6),
            M_M_GJAM_HI_01 = unchecked((int)0x5FF2E9AF),
            M_M_GJAM_HI_02 = unchecked((int)0xEC4D0269),
            M_M_GJAM_HI_03 = unchecked((int)0x4295AEF5),
            M_Y_GJAM_LO_01 = unchecked((int)0xA691BED3),
            M_Y_GJAM_LO_02 = unchecked((int)0xCB77889E),
            M_Y_GKOR_LO_01 = unchecked((int)0x5BD063B5),
            M_Y_GKOR_LO_02 = unchecked((int)0x2D8D8730),
            M_Y_GLAT_LO_01 = unchecked((int)0x1D55921C),
            M_Y_GLAT_LO_02 = unchecked((int)0x8D32F1D9),
            M_Y_GLAT_HI_01 = unchecked((int)0x45A43081),
            M_Y_GLAT_HI_02 = unchecked((int)0x97E25504),
            M_Y_GMAF_HI_01 = unchecked((int)0xEDFA50E3),
            M_Y_GMAF_HI_02 = unchecked((int)0x9FA03430),
            M_Y_GMAF_LO_01 = unchecked((int)0x03DBB737),
            M_Y_GMAF_LO_02 = unchecked((int)0x1E6BEC57),
            M_O_GRUS_HI_01 = unchecked((int)0x9290C4A3),
            M_Y_GRUS_LO_01 = unchecked((int)0x83892528),
            M_Y_GRUS_LO_02 = unchecked((int)0x75CF09B4),
            M_Y_GRUS_HI_02 = unchecked((int)0x5BFE7C54),
            M_M_GRU2_HI_01 = unchecked((int)0x6F31C4B4),
            M_M_GRU2_HI_02 = unchecked((int)0x19BB19C8),
            M_M_GRU2_LO_02 = unchecked((int)0x66CB1E64),
            M_Y_GRU2_LO_01 = unchecked((int)0xB9A05501),
            M_M_GTRI_HI_01 = unchecked((int)0x33EEB47F),
            M_M_GTRI_HI_02 = unchecked((int)0x28C09E23),
            M_Y_GTRI_LO_01 = unchecked((int)0xBF635A9F),
            M_Y_GTRI_LO_02 = unchecked((int)0xF62B4836),
            F_O_MAID_01 = unchecked((int)0xD33B8FE9),
            F_O_BINCO = unchecked((int)0xF97D04E6),
            F_Y_BANK_01 = unchecked((int)0x516F7106),
            F_Y_DOCTOR_01 = unchecked((int)0x14A4B50F),
            F_Y_GYMGAL_01 = unchecked((int)0x507AAC5B),
            F_Y_FF_BURGER_R = unchecked((int)0x37214098),
            F_Y_FF_CLUCK_R = unchecked((int)0xEB5AB08B),
            F_Y_FF_RSCAFE = unchecked((int)0x8292BFB5),
            F_Y_FF_TWCAFE = unchecked((int)0x0CB09BED),
            F_Y_FF_WSPIZZA_R = unchecked((int)0xEEB5DE91),
            F_Y_HOOKER_01 = unchecked((int)0x20EF1FEB),
            F_Y_HOOKER_03 = unchecked((int)0x3B61D4D0),
            F_Y_NURSE = unchecked((int)0xB8D8632B),
            F_Y_STRIPPERC01 = unchecked((int)0x42615D12),
            F_Y_STRIPPERC02 = unchecked((int)0x50AFF9AF),
            F_Y_WAITRESS_01 = unchecked((int)0x0171C5D1),
            M_M_ALCOHOLIC = unchecked((int)0x97093869),
            M_M_ARMOURED = unchecked((int)0x401C1901),
            M_M_BUSDRIVER = unchecked((int)0x07FDDC3F),
            M_M_CHINATOWN_01 = unchecked((int)0x2D243DEF),
            M_M_CRACKHEAD = unchecked((int)0x9313C198),
            M_M_DOC_SCRUBS_01 = unchecked((int)0x0D13AEF5),
            M_M_DOCTOR_01 = unchecked((int)0xB940B896),
            M_M_DODGYDOC = unchecked((int)0x16653776),
            M_M_EECOOK = unchecked((int)0x7D77FE8D),
            M_M_ENFORCER = unchecked((int)0xF410AB9B),
            M_M_FACTORY_01 = unchecked((int)0x2FB107C1),
            M_M_FATCOP_01 = unchecked((int)0xE9EC3678),
            M_M_FBI = unchecked((int)0xC46CBC16),
            M_M_FEDCO = unchecked((int)0x89275CA8),
            M_M_FIRECHIEF = unchecked((int)0x24696C93),
            M_M_GUNNUT_01 = unchecked((int)0x1CFC648F),
            M_M_HELIPILOT_01 = unchecked((int)0xD19BD6D0),
            M_M_HPORTER_01 = unchecked((int)0x2536480C),
            M_M_KOREACOOK_01 = unchecked((int)0x959D9B8A),
            M_M_LAWYER_01 = unchecked((int)0x918DD1CF),
            M_M_LAWYER_02 = unchecked((int)0xBC5DA76E),
            M_M_LOONYBLACK = unchecked((int)0x1699B3B8),
            M_M_PILOT = unchecked((int)0x8C0F140E),
            M_M_PINDUS_01 = unchecked((int)0x301D7295),
            M_M_POSTAL_01 = unchecked((int)0xEF0CF791),
            M_M_SAXPLAYER_01 = unchecked((int)0xB92CCD03),
            M_M_SECURITYMAN = unchecked((int)0x907AF88D),
            M_M_SELLER_01 = unchecked((int)0x1916A97C),
            M_M_SHORTORDER = unchecked((int)0x6FF14E0F),
            M_M_STREETFOOD_01 = unchecked((int)0x0881E67C),
            M_M_SWEEPER = unchecked((int)0xD6D5085C),
            M_M_TAXIDRIVER = unchecked((int)0x0085DCEE),
            M_M_TELEPHONE = unchecked((int)0x46B50EAA),
            M_M_TENNIS = unchecked((int)0xE96555E2),
            M_M_TRAIN_01 = unchecked((int)0x452086C4),
            M_M_TRAMPBLACK = unchecked((int)0xF7835A1A),
            M_M_TRUCKER_01 = unchecked((int)0xFD3979FD),
            M_O_JANITOR = unchecked((int)0xB376FD38),
            M_O_HOTEL_FOOT = unchecked((int)0x015E1A07),
            M_O_MPMOBBOSS = unchecked((int)0x463E4B5D),
            M_Y_AIRWORKER = unchecked((int)0xA8B24166),
            M_Y_BARMAN_01 = unchecked((int)0x80807842),
            M_Y_BOUNCER_01 = unchecked((int)0x95DCB0F5),
            M_Y_BOUNCER_02 = unchecked((int)0xE79AD470),
            M_Y_BOWL_01 = unchecked((int)0xD05CB843),
            M_Y_BOWL_02 = unchecked((int)0xE61EE3C7),
            M_Y_CHINVEND_01 = unchecked((int)0x2DCD7F4C),
            M_Y_CLUBFIT = unchecked((int)0x2851C93C),
            M_Y_CONSTRUCT_01 = unchecked((int)0xD4F6DA2A),
            M_Y_CONSTRUCT_02 = unchecked((int)0xC371B720),
            M_Y_CONSTRUCT_03 = unchecked((int)0xD56DDB14),
            M_Y_COP = unchecked((int)0xF5148AB2),
            M_Y_COP_TRAFFIC = unchecked((int)0xA576D885),
            M_Y_COURIER = unchecked((int)0xAE46285D),
            M_Y_COWBOY_01 = unchecked((int)0xDDCCAF85),
            M_Y_DEALER = unchecked((int)0xB380C536),
            M_Y_DRUG_01 = unchecked((int)0x565A4099),
            M_Y_FF_BURGER_R = unchecked((int)0x000F192D),
            M_Y_FF_CLUCK_R = unchecked((int)0xC3B54549),
            M_Y_FF_RSCAFE = unchecked((int)0x75FDB605),
            M_Y_FF_TWCAFE = unchecked((int)0xD11FBA8B),
            M_Y_FF_WSPIZZA_R = unchecked((int)0x0C55ACF1),
            M_Y_FIREMAN = unchecked((int)0xDBA0B619),
            M_Y_GARBAGE = unchecked((int)0x43BD9C04),
            M_Y_GOON_01 = unchecked((int)0x358464B5),
            M_Y_GYMGUY_01 = unchecked((int)0x8E96352C),
            M_Y_MECHANIC_02 = unchecked((int)0xEABA11B9),
            M_Y_MODO = unchecked((int)0xC10A9D57),
            M_Y_NHELIPILOT = unchecked((int)0x479F2007),
            M_Y_PERSEUS = unchecked((int)0xF6FFEBB2),
            M_Y_PINDUS_01 = unchecked((int)0x1DDEBBCF),
            M_Y_PINDUS_02 = unchecked((int)0x0B1F9651),
            M_Y_PINDUS_03 = unchecked((int)0xF958F2C4),
            M_Y_PMEDIC = unchecked((int)0xB9F5BEA0),
            M_Y_PRISON = unchecked((int)0x9C0BF5CC),
            M_Y_PRISONAOM = unchecked((int)0x0CD38A07),
            M_Y_ROMANCAB = unchecked((int)0x5C907185),
            M_Y_RUNNER = unchecked((int)0xA7ABA2BA),
            M_Y_SHOPASST_01 = unchecked((int)0x15556BF3),
            M_Y_STROOPER = unchecked((int)0xFAAD5B99),
            M_Y_SWAT = unchecked((int)0xC41C88BE),
            M_Y_SWORDSWALLOW = unchecked((int)0xFC2BE1B8),
            M_Y_THIEF = unchecked((int)0xB2F9C1A1),
            M_Y_VALET = unchecked((int)0x102B77F0),
            M_Y_VENDOR = unchecked((int)0xF4E8205B),
            M_Y_FRENCHTOM = unchecked((int)0x87DB1287),
            M_Y_JIM_FITZ = unchecked((int)0x75E29A7D),
            F_O_PEASTEURO_01 = unchecked((int)0xF3D9C032),
            F_O_PEASTEURO_02 = unchecked((int)0x0B50EF20),
            F_O_PHARBRON_01 = unchecked((int)0xEB320486),
            F_O_PJERSEY_01 = unchecked((int)0xF92630A4),
            F_O_PORIENT_01 = unchecked((int)0x9AD4BE64),
            F_O_RICH_01 = unchecked((int)0x0600A909),
            F_M_BUSINESS_01 = unchecked((int)0x093E163C),
            F_M_BUSINESS_02 = unchecked((int)0x1780B2C1),
            F_M_CHINATOWN = unchecked((int)0x51FFF4A5),
            F_M_PBUSINESS = unchecked((int)0xEF0F006B),
            F_M_PEASTEURO_01 = unchecked((int)0x2864B0DC),
            F_M_PHARBRON_01 = unchecked((int)0xB92CE9DD),
            F_M_PJERSEY_01 = unchecked((int)0x844EA438),
            F_M_PJERSEY_02 = unchecked((int)0xAF1EF9D8),
            F_M_PLATIN_01 = unchecked((int)0x3067DA63),
            F_M_PLATIN_02 = unchecked((int)0xF84BEA2C),
            F_M_PMANHAT_01 = unchecked((int)0x32CEF1D1),
            F_M_PMANHAT_02 = unchecked((int)0x04901554),
            F_M_PORIENT_01 = unchecked((int)0x81BA39A8),
            F_M_PRICH_01 = unchecked((int)0x605DF31F),
            F_Y_BUSINESS_01 = unchecked((int)0x1B0DCC86),
            F_Y_CDRESS_01 = unchecked((int)0x3120FC7F),
            F_Y_PBRONX_01 = unchecked((int)0xAECAC8C7),
            F_Y_PCOOL_01 = unchecked((int)0x9568444C),
            F_Y_PCOOL_02 = unchecked((int)0xA52AE3D1),
            F_Y_PEASTEURO_01 = unchecked((int)0xC760585B),
            F_Y_PHARBRON_01 = unchecked((int)0x8D2AC355),
            F_Y_PHARLEM_01 = unchecked((int)0x0A047A8F),
            F_Y_PJERSEY_02 = unchecked((int)0x0006BC78),
            F_Y_PLATIN_01 = unchecked((int)0x0339B6D8),
            F_Y_PLATIN_02 = unchecked((int)0xEE8D8D80),
            F_Y_PLATIN_03 = unchecked((int)0x67F08048),
            F_Y_PMANHAT_01 = unchecked((int)0x6392D986),
            F_Y_PMANHAT_02 = unchecked((int)0x50B8B3D2),
            F_Y_PMANHAT_03 = unchecked((int)0x3EFE105D),
            F_Y_PORIENT_01 = unchecked((int)0xB8DA98D7),
            F_Y_PQUEENS_01 = unchecked((int)0x2A8A0FF0),
            F_Y_PRICH_01 = unchecked((int)0x95E177F9),
            F_Y_PVILLBO_02 = unchecked((int)0xC73ECED1),
            F_Y_SHOP_03 = unchecked((int)0x5E8CD2B8),
            F_Y_SHOP_04 = unchecked((int)0x6E2671EB),
            F_Y_SHOPPER_05 = unchecked((int)0x9A8CFCFD),
            F_Y_SOCIALITE = unchecked((int)0x4680C12E),
            F_Y_STREET_02 = unchecked((int)0xCA5194CB),
            F_Y_STREET_05 = unchecked((int)0x110C2243),
            F_Y_STREET_09 = unchecked((int)0x57D62FD6),
            F_Y_STREET_12 = unchecked((int)0x91AFE421),
            F_Y_STREET_30 = unchecked((int)0x4CEF5CF5),
            F_Y_STREET_34 = unchecked((int)0x6F96222E),
            F_Y_TOURIST_01 = unchecked((int)0x6892A334),
            F_Y_VILLBO_01 = unchecked((int)0x2D6795BA),
            M_M_BUSINESS_02 = unchecked((int)0xDA0E92D1),
            M_M_BUSINESS_03 = unchecked((int)0x976C0D95),
            M_M_EE_HEAVY_01 = unchecked((int)0xA59C6FD2),
            M_M_EE_HEAVY_02 = unchecked((int)0x9371CB7D),
            M_M_FATMOB_01 = unchecked((int)0x74636532),
            M_M_GAYMID = unchecked((int)0x894A8CB2),
            M_M_GENBUM_01 = unchecked((int)0xBF963CE7),
            M_M_LOONYWHITE = unchecked((int)0x1D88B92A),
            M_M_MIDTOWN_01 = unchecked((int)0x89BC811F),
            M_M_PBUSINESS_01 = unchecked((int)0x3F688D84),
            M_M_PEASTEURO_01 = unchecked((int)0x0C717BCE),
            M_M_PHARBRON_01 = unchecked((int)0xC3306A8C),
            M_M_PINDUS_02 = unchecked((int)0x6A3B66CC),
            M_M_PITALIAN_01 = unchecked((int)0xAC686EC9),
            M_M_PITALIAN_02 = unchecked((int)0x9EF053D9),
            M_M_PLATIN_01 = unchecked((int)0x450E5DBF),
            M_M_PLATIN_02 = unchecked((int)0x75633E74),
            M_M_PLATIN_03 = unchecked((int)0x60AD1508),
            M_M_PMANHAT_01 = unchecked((int)0xD8CF835D),
            M_M_PMANHAT_02 = unchecked((int)0xB217B5E2),
            M_M_PORIENT_01 = unchecked((int)0x2BC50FD3),
            M_M_PRICH_01 = unchecked((int)0x6F2AE4DB),
            M_O_EASTEURO_01 = unchecked((int)0xE6372469),
            M_O_HASID_01 = unchecked((int)0x9E495AD7),
            M_O_MOBSTER = unchecked((int)0x62B5E24B),
            M_O_PEASTEURO_02 = unchecked((int)0x793F36B1),
            M_O_PHARBRON_01 = unchecked((int)0x4E76BDF6),
            M_O_PJERSEY_01 = unchecked((int)0x3A78BA45),
            M_O_STREET_01 = unchecked((int)0xB29788AB),
            M_O_SUITED = unchecked((int)0x0E86251C),
            M_Y_BOHO_01 = unchecked((int)0x7C54115F),
            M_Y_BOHOGUY_01 = unchecked((int)0x0D2FF2BF),
            M_Y_BRONX_01 = unchecked((int)0x031EE9E3),
            M_Y_BUSINESS_01 = unchecked((int)0x5B404032),
            M_Y_BUSINESS_02 = unchecked((int)0x2924DBD8),
            M_Y_CHINATOWN_03 = unchecked((int)0xBB784DE6),
            M_Y_CHOPSHOP_01 = unchecked((int)0xED4319C3),
            M_Y_CHOPSHOP_02 = unchecked((int)0xDF0C7D56),
            M_Y_DODGY_01 = unchecked((int)0xBE9A3CD6),
            M_Y_DORK_02 = unchecked((int)0x962996E4),
            M_Y_DOWNTOWN_01 = unchecked((int)0x47F77FC9),
            M_Y_DOWNTOWN_02 = unchecked((int)0x5971A2B9),
            M_Y_DOWNTOWN_03 = unchecked((int)0x236BB6B2),
            M_Y_GAYYOUNG = unchecked((int)0xD36D1B5D),
            M_Y_GENSTREET_11 = unchecked((int)0xD7A357ED),
            M_Y_GENSTREET_16 = unchecked((int)0x9BF260A8),
            M_Y_GENSTREET_20 = unchecked((int)0x3AF39D6C),
            M_Y_GENSTREET_34 = unchecked((int)0x4658B34E),
            M_Y_HARDMAN_01 = unchecked((int)0xAB537AD4),
            M_Y_HARLEM_01 = unchecked((int)0xB71B0F29),
            M_Y_HARLEM_02 = unchecked((int)0x97EBD0CB),
            M_Y_HARLEM_04 = unchecked((int)0x7D701BD4),
            M_Y_HASID_01 = unchecked((int)0x90442A67),
            M_Y_LEASTSIDE_01 = unchecked((int)0xC1181556),
            M_Y_PBRONX_01 = unchecked((int)0x22522444),
            M_Y_PCOOL_01 = unchecked((int)0xFBB5AA01),
            M_Y_PCOOL_02 = unchecked((int)0xF45E1B4E),
            M_Y_PEASTEURO_01 = unchecked((int)0x298F268A),
            M_Y_PHARBRON_01 = unchecked((int)0x27F5967B),
            M_Y_PHARLEM_01 = unchecked((int)0x01961E02),
            M_Y_PJERSEY_01 = unchecked((int)0x5BF734C6),
            M_Y_PLATIN_01 = unchecked((int)0x944D1A30),
            M_Y_PLATIN_02 = unchecked((int)0xC30777A4),
            M_Y_PLATIN_03 = unchecked((int)0xB0F0D377),
            M_Y_PMANHAT_01 = unchecked((int)0x243BD606),
            M_Y_PMANHAT_02 = unchecked((int)0x7554785A),
            M_Y_PORIENT_01 = unchecked((int)0xEB7CE59F),
            M_Y_PQUEENS_01 = unchecked((int)0x21673B90),
            M_Y_PRICH_01 = unchecked((int)0x509627D1),
            M_Y_PVILLBO_01 = unchecked((int)0x0D55CAAC),
            M_Y_PVILLBO_02 = unchecked((int)0xB5559AAD),
            M_Y_PVILLBO_03 = unchecked((int)0xA2E575D9),
            M_Y_QUEENSBRIDGE = unchecked((int)0x48E8EE31),
            M_Y_SHADY_02 = unchecked((int)0xB73D062F),
            M_Y_SKATEBIKE_01 = unchecked((int)0x68A019EE),
            M_Y_SOHO_01 = unchecked((int)0x170C6DAE),
            M_Y_STREET_01 = unchecked((int)0x03B99DE1),
            M_Y_STREET_03 = unchecked((int)0x1F3854DE),
            M_Y_STREET_04 = unchecked((int)0x3082F773),
            M_Y_STREETBLK_02 = unchecked((int)0xA37B1794),
            M_Y_STREETBLK_03 = unchecked((int)0xD939030F),
            M_Y_STREETPUNK_02 = unchecked((int)0xD3E34ABA),
            M_Y_STREETPUNK_04 = unchecked((int)0x8D1CBD36),
            M_Y_STREETPUNK_05 = unchecked((int)0x51E946D0),
            M_Y_TOUGH_05 = unchecked((int)0xBC0DDE62),
            M_Y_TOURIST_02 = unchecked((int)0x303963D0)
        }


        public static bool AddPoint(int num)
        {
            if (num + Share.POINTs < 0) { return false; }

            Share.POINTs += num;
            SavePoint();
            return true;
        }

        public static void ChangePoint(int num)
        {
            Share.POINTs = num;
            SavePoint();
        }

        public static void SavePoint()
        {
            string fileName = @".\scripts\points.xml";
            XmlTextWriter writer = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(true);
            writer.WriteStartElement("Point");
            writer.WriteElementString("POINT",POINTs.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
 
        }

        public static void LoadPoint()
        {
            string fileName = @".\scripts\points.xml";
            if (File.Exists(fileName))
            {
                XmlTextReader reader = new XmlTextReader(fileName);

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            switch (reader.LocalName)
                            {
                                case "POINT":
                                    POINTs = int.Parse(reader.ReadString());
                                    break;
                            }
                            break;
                    }
                }
                reader.Close();
            }
            else
            {

                ChangePoint(100);
            }
            
        }

    }
}
