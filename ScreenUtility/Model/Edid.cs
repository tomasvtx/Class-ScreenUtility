using static ScreenUtility.Enums;

namespace ScreenUtility
{
    /// <summary>
    /// Základní třída pro konfiguraci obrazovky
    /// </summary>
    public class MyDisplayConfigBase
    {
        ///Identifikátor
        internal uint Id { get; set; }

        /// <summary>
        /// Dolní část
        /// </summary>
        internal uint LowPart { get; set; }

        /// <summary>
        /// Horní část
        /// </summary>
        internal int HighPart { get; set; }

        /// <summary>
        /// Typ řádkování
        /// </summary>
        internal Enums.MyDisplayConfigScanlineOrdering ScanLineOrdering { get; set; }

        /// <summary>
        /// Dostupnost cíle
        /// </summary>
        internal bool TargetAvailable { get; set; }

        /// <summary>
        /// Vlajky
        /// </summary>
        internal uint Flags { get; set; } 
    }

    /// <summary>
    /// Třída obsahující kompletní informace o konfiguraci obrazovky
    /// </summary>
    public class MyDisplayConfigAllInfo : MyDisplayConfigBase
    {
        /// <summary>
        /// Aktivní šířka obrazovky
        /// </summary>
        internal uint ActiveSizeX { get; set; }

        /// <summary>
        /// Aktivní výška obrazovky
        /// </summary>
        internal uint ActiveSizeY { get; set; }

        /// <summary>
        /// Typ informace o režimu obrazovky
        /// </summary>
        internal MyDisplayConfigModeInfoType InfoType { get; set; }

        /// <summary>
        /// Pixelová rychlost obrazovky
        /// </summary>
        internal ulong PixelRate { get; set; }

        /// <summary>
        /// Horizontální synchronizační frekvence obrazovky
        /// </summary>
        internal double HSyncFreq { get; set; }

        /// <summary>
        /// Vertikální synchronizační frekvence obrazovky
        /// </summary>
        internal double VSyncFreq { get; set; }

        /// <summary>
        /// Řetězec reprezentující aktivní velikost obrazovky
        /// </summary>
        internal string StringActiveSize { get; set; }

        /// <summary>
        /// Aktivní velikost obrazovky v 2D
        /// </summary>
        internal Structs.MyDisplayConfig2DRegion ActiveSize { get; set; }

        /// <summary>
        /// Celková velikost obrazovky v 2D
        /// </summary>
        internal Structs.MyDisplayConfig2DRegion TotalSize { get; set; }

        /// <summary>
        /// Video standard obrazovky
        /// </summary>
        internal uint VideoStandard { get; set; }

        /// <summary>
        /// Název obrazovky
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Index informace o režimu obrazovky
        /// </summary>
        internal uint ModeInfoIdx { get; set; }

        /// <summary>
        /// Vlajky stavu obrazovky
        /// </summary>
        internal uint StatusFlags { get; set; }

        /// <summary>
        /// Technologie výstupu obrazovky
        /// </summary>
        internal Enums.MyDisplayConfigVideoOutputTechnology OutputTechnology { get; set; }

        /// <summary>
        /// Otočení obrazovky
        /// </summary>
        internal Enums.MyDisplayConfigRotation Rotation { get; set; }

        /// <summary>
        /// Škálování obrazovky
        /// </summary>
        internal Enums.MyDisplayConfigScaling Scaling { get; set; }

        /// <summary>
        /// Čitatel obnovovací frekvence obrazovky
        /// </summary>
        internal uint RefreshrateNumerator { get; set; }

        /// <summary>
        /// Jmenovatel obnovovací frekvence obrazovky
        /// </summary>
        internal uint RefreshrateDenominator { get; set; }

        /// <summary>
        /// Obnovovací frekvence obrazovky
        /// </summary>
        internal double Refreshrate { get; set; }

        /// <summary>
        /// Šířka obrazovky
        /// </summary>
        internal uint Width { get; set; }

        /// <summary>
        /// Výška obrazovky
        /// </summary>
        internal uint Height { get; set; }

        /// <summary>
        /// Formát pixelu obrazovky
        /// </summary>
        internal Enums.MyDisplayConfigPixelFormat PixelFormat { get; set; }

        /// <summary>
        /// Pozice X obrazovky
        /// </summary>
        internal int PositionX { get; set; }

        /// <summary>
        /// Pozice Y obrazovky
        /// </summary>
        internal int PositionY { get; set; }

    }

    /// <summary>
    /// Třída obsahující informace o cestě pro konfiguraci obrazovky
    /// </summary>
    public class MyDisplayConfigPathInfo : MyDisplayConfigBase
    {
        /// <summary>
        /// Název
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Index informace o režimu
        /// </summary>
        internal uint ModeInfoIdx { get; set; }

        /// <summary>
        /// Vlajky stavu
        /// </summary>
        internal uint StatusFlags { get; set; }

        /// <summary>
        /// Technologie výstupu obrazovky
        /// </summary>
        internal Enums.MyDisplayConfigVideoOutputTechnology OutputTechnology { get; set; }

        /// <summary>
        /// Otočení
        /// </summary>
        internal Enums.MyDisplayConfigRotation Rotation { get; set; }

        /// <summary>
        /// Škálování
        /// </summary>
        internal Enums.MyDisplayConfigScaling Scaling { get; set; }

        /// <summary>
        /// Čitatel obnovovací frekvence
        /// </summary>
        internal uint RefreshrateNumerator { get; set; }

        /// <summary>
        /// Jmenovatel obnovovací frekvence
        /// </summary>
        internal uint RefreshrateDenominator { get; set; } 
    }

    /// <summary>
    /// Třída obsahující informace o režimu konfigurace obrazovky
    /// </summary>
    public class MyDisplayConfigModeInfo : MyDisplayConfigBase
    {
        /// <summary>
        /// Typ informace o režimu
        /// </summary>
        internal MyDisplayConfigModeInfoType InfoType { get; set; }

        /// <summary>
        /// Pixelová rychlost
        /// </summary>
        internal ulong PixelRate { get; set; }

        /// <summary>
        /// Horizontální synchronizační frekvence
        /// </summary>
        internal Structs.MyDisplayConfigRational HSyncFreq { get; set; }

        /// <summary>
        /// Vertikální synchronizační frekvence
        /// </summary>
        internal Structs.MyDisplayConfigRational VSyncFreq { get; set; }

        /// <summary>
        /// Aktivní velikost v 2D
        /// </summary>
        internal Structs.MyDisplayConfig2DRegion ActiveSize { get; set; }

        /// <summary>
        /// Celková velikost v 2D
        /// </summary>
        internal Structs.MyDisplayConfig2DRegion TotalSize { get; set; }

        /// <summary>
        /// Video standard
        /// </summary>
        internal uint VideoStandard { get; set; }

        /// <summary>
        /// Šířka
        /// </summary>
        internal uint Width { get; set; }

        /// <summary>
        /// Výška
        /// </summary>
        internal uint Height { get; set; }

        /// <summary>
        /// Formát pixelu
        /// </summary>
        internal Enums.MyDisplayConfigPixelFormat PixelFormat { get; set; }

        /// <summary>
        /// Pozice X
        /// </summary>
        internal int PositionX { get; set; }

        /// <summary>
        /// Pozice Y
        /// </summary>
        internal int PositionY { get; set; }
    }
}
