using System.Runtime.InteropServices;
using static ScreenUtility.Enums;

namespace ScreenUtility
{
    public class Structs
    {
        /// <summary>
        /// Struktura MyLuid představuje jedinečný identifikátor LUID (Locally Unique Identifier).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MyLuid
        {
            /// <summary>
            /// Nízká část hodnoty, reprezentovaná vlastností LowPart.
            /// </summary>
            internal uint LowPart;

            /// <summary>
            /// Vysoká část hodnoty, reprezentovaná vlastností HighPart.
            /// </summary>
            internal int HighPart;
        }


        /// <summary>
        /// Struktura MyDisplayConfigPathSourceInfo představuje informace o zdroji v konfiguraci cesty displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigPathSourceInfo
        {
            /// <summary>
            /// Unikátní identifikátor adaptéru (zobrazovací karty nebo grafického adaptéru).
            /// </summary>
            internal MyLuid AdapterId;

            /// <summary>
            /// Identifikátor režimu zobrazení.
            /// </summary>
            internal uint Id;

            /// <summary>
            /// Index informace o režimu v seznamu režimů.
            /// </summary>
            internal uint ModeInfoIdx;

            /// <summary>
            /// Příznaky (flags) týkající se stavu režimu zobrazení.
            /// </summary>
            public uint StatusFlags;
        }


        /// <summary>
        /// Struktura MyDisplayConfigPathTargetInfo představuje informace o cíli v konfiguraci cesty displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigPathTargetInfo
        {
            /// <summary>
            /// Unikátní identifikátor adaptéru (zobrazovací karty nebo grafického adaptéru).
            /// </summary>
            internal MyLuid AdapterId;

            /// <summary>
            /// Identifikátor režimu zobrazení.
            /// </summary>
            internal uint Id;

            /// <summary>
            /// Index informace o režimu v seznamu režimů.
            /// </summary>
            internal uint ModeInfoIdx;

            /// <summary>
            /// Technologie výstupu zobrazovacího zařízení (např. HDMI, DisplayPort atd.).
            /// </summary>
            internal Enums.MyDisplayConfigVideoOutputTechnology OutputTechnology;

            /// <summary>
            /// Rotace režimu zobrazení (např. otáčení obrazu).
            /// </summary>
            internal Enums.MyDisplayConfigRotation Rotation;

            /// <summary>
            /// Metoda škálování režimu zobrazení (např. zvětšení/zmenšení obrazu).
            /// </summary>
            internal Enums.MyDisplayConfigScaling Scaling;

            /// <summary>
            /// Obnovovací frekvence režimu zobrazení ve formě zlomku.
            /// </summary>
            internal MyDisplayConfigRational RefreshRate;

            /// <summary>
            /// Pořadí scanline (řádků) ve zobrazení.
            /// </summary>
            internal Enums.MyDisplayConfigScanlineOrdering ScanLineOrdering;

            /// <summary>
            /// Zda je cílové zařízení k dispozici.
            /// </summary>
            internal bool TargetAvailable;

            /// <summary>
            /// Příznaky (flags) týkající se stavu režimu zobrazení.
            /// </summary>
            public uint StatusFlags;
        }


        /// <summary>
        /// Struktura MyDisplayConfigRational představuje racionální číslo s čitatelem a jmenovatelem.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigRational
        {
            /// <summary>
            /// Čitatel zlomku, reprezentovaný vlastností Numerator.
            /// </summary>
            internal uint Numerator;

            /// <summary>
            /// Jmenovatel zlomku, reprezentovaný vlastností Denominator.
            /// </summary>
            internal uint Denominator;
        }


        /// <summary>
        /// Reprezentuje informace o konfiguraci cesty pro displej.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DisplayConfigPathInfo
        {
            /// <summary>
            /// Informace o zdrojovém zařízení v konfiguraci cesty.
            /// </summary>
            internal MyDisplayConfigPathSourceInfo SourceInfo { get; set; }

            /// <summary>
            /// Informace o cílovém zařízení v konfiguraci cesty.
            /// </summary>
            internal MyDisplayConfigPathTargetInfo TargetInfo { get; set; }

            /// <summary>
            /// Příznaky (flags) týkající se této cesty.
            /// </summary>
            internal uint Flags { get; set; }
        }

        /// <summary>
        /// Struktura MyDisplayConfig2DRegion představuje 2D oblast v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfig2DRegion
        {
            /// <summary>
            /// Šířka oblasti, reprezentovaná vlastností Cx.
            /// </summary>
            internal uint Cx;

            /// <summary>
            /// Výška oblasti, reprezentovaná vlastností Cy.
            /// </summary>
            internal uint Cy;
        }


        /// <summary>
        /// Struktura MyDisplayConfigVideoSignalInfo představuje informace o videosignálu v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigVideoSignalInfo
        {
            /// <summary>
            /// Hodnota pixelového taktního signálu (pixel rate) zobrazovacího zařízení.
            /// </summary>
            internal ulong PixelRate;

            /// <summary>
            /// Informace o horizontální frekvenci synchronizace (HSync) ve formě zlomku.
            /// </summary>
            internal Structs.MyDisplayConfigRational HSyncFreq;

            /// <summary>
            /// Informace o vertikální frekvenci synchronizace (VSync) ve formě zlomku.
            /// </summary>
            internal Structs.MyDisplayConfigRational VSyncFreq;

            /// <summary>
            /// Aktivní oblast zobrazovacího zařízení ve 2D rovině.
            /// </summary>
            internal MyDisplayConfig2DRegion ActiveSize;

            /// <summary>
            /// Celková oblast zobrazovacího zařízení ve 2D rovině.
            /// </summary>
            internal MyDisplayConfig2DRegion TotalSize;

            /// <summary>
            /// Standard video signálu (např. PAL, NTSC).
            /// </summary>
            internal uint VideoStandard;

            /// <summary>
            /// Pořadí scanline (řádků) ve zobrazení.
            /// </summary>
            internal MyDisplayConfigScanlineOrdering ScanLineOrdering;
        }


        /// <summary>
        /// Struktura MyDisplayConfigTargetMode představuje režim cílového zařízení v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigTargetMode
        {
            /// <summary>
            /// Informace o video signálu cílového zobrazovacího zařízení.
            /// </summary>
            internal MyDisplayConfigVideoSignalInfo TargetVideoSignalInfo;
        }


        /// <summary>
        /// Struktura MyPointL představuje bod s celočíselnými souřadnicemi.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyPointL
        {
            /// <summary>
            /// Horizontální pozice (X-ová souřadnice).
            /// </summary>
            internal int X;

            /// <summary>
            /// Vertikální pozice (Y-ová souřadnice).
            /// </summary>
            internal int Y;
        }

        /// <summary>
        /// Struktura MyDisplayConfigSourceMode představuje režim zdroje v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct MyDisplayConfigSourceMode
        {
            /// <summary>
            /// Šířka zobrazení v pixelech.
            /// </summary>
            internal uint Width;

            /// <summary>
            /// Výška zobrazení v pixelech.
            /// </summary>
            internal uint Height;

            /// <summary>
            /// Formát pixelu použitý pro zobrazení.
            /// </summary>
            internal MyDisplayConfigPixelFormat PixelFormat;

            /// <summary>
            /// Pozice zobrazení na obrazovce.
            /// </summary>
            internal MyPointL Position;
        }


        /// <summary>
        /// Struktura MyDisplayConfigModeInfoUnion představuje unii režimů v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        internal struct MyDisplayConfigModeInfoUnion
        {
            /// <summary>
            /// Tato vlastnost má offset 0 v rámci struktury a může představovat buď režim cílového zařízení (TargetMode) nebo režim zdroje (SourceMode).
            /// </summary>

            [FieldOffset(0)]
            internal MyDisplayConfigTargetMode TargetMode;

            /// <summary>
            /// Tato vlastnost také má offset 0 a může představovat buď režim cílového zařízení (TargetMode) nebo režim zdroje (SourceMode).
            /// </summary>
            [FieldOffset(0)]
            internal MyDisplayConfigSourceMode SourceMode;
        }

        /// <summary>
        /// Struktura MyDisplayConfigModeInfo představuje informace o režimu v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DisplayConfigModeInfo
        {
            /// <summary>
            /// Typ informací o konfiguraci režimu zobrazení.
            /// </summary>
            internal MyDisplayConfigModeInfoType InfoType { get; set; }

            /// <summary>
            /// Identifikátor informací o konfiguraci režimu zobrazení.
            /// </summary>
            internal uint Id { get; set; }

            /// <summary>
            /// Unikátní identifikátor adaptéru (zobrazovací karty nebo grafického adaptéru).
            /// </summary>
            internal Structs.MyLuid AdapterId { get; set; }

            /// <summary>
            /// Informace o konfiguraci režimu zobrazení (může obsahovat různé detaily, například rozlišení, frekvenci atd.).
            /// </summary>
            internal MyDisplayConfigModeInfoUnion ModeInfo { get; set; }
        }


        /// <summary>
        /// Reprezentuje vlajky pro název cílového zařízení v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DisplayConfigTargetDeviceNameFlags
        {
            /// <summary>
            /// Hodnota reprezentující příznaky pro název cílového zařízení.
            /// </summary>
            internal uint Value { get; set; }
        }

        /// <summary>
        /// Reprezentuje záhlaví informací o konfiguraci zařízení pro displej.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct DisplayConfigDeviceInfoHeader
        {
            /// <summary>
            /// Typ informací o konfiguraci zobrazovacího zařízení (např. monitor, adaptér atd.).
            /// </summary>
            internal MyDisplayConfigDeviceInfoType Type { get; set; }

            /// <summary>
            /// Velikost těchto informací (v bajtech).
            /// </summary>
            internal uint Size { get; set; }

            /// <summary>
            /// Unikátní identifikátor adaptéru (zobrazovací karty nebo grafického adaptéru).
            /// </summary>
            internal Structs.MyLuid AdapterId { get; set; }

            /// <summary>
            /// Identifikátor informací o konfiguraci zobrazovacího zařízení.
            /// </summary>
            internal uint Id { get; set; }
        }


        /// <summary>
        /// Struktura MyDisplayConfigTargetDeviceName představuje informace o názvu cílového zařízení v konfiguraci displeje.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct MyDisplayConfigTargetDeviceName
        {
            /// <summary>
            /// Toto je hlavička informací o konfiguraci zobrazovacího zařízení.
            /// </summary>
            internal DisplayConfigDeviceInfoHeader Header;

            /// <summary>
            /// Toto jsou příznaky (flags) informací o konfiguraci zobrazovacího zařízení.
            /// </summary>
            internal DisplayConfigDeviceInfoHeader Flags;

            /// <summary>
            /// Technologie výstupu zobrazovacího zařízení (např. HDMI, DisplayPort atd.).
            /// </summary>
            internal Enums.MyDisplayConfigVideoOutputTechnology OutputTechnology;

            /// <summary>
            /// ID výrobce EDID (rozšířeného identifikačního datového bloku) monitoru.
            /// </summary>
            internal ushort EdidManufactureId;

            /// <summary>
            /// Kód produktu v EDID monitoru.
            /// </summary>
            internal ushort EdidProductCodeId;

            /// <summary>
            /// Unikátní identifikátor konektoru zobrazovacího zařízení.
            /// </summary>
            internal uint ConnectorInstance;

            /// <summary>
            /// Přátelský název monitoru (64 znaků).
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            internal string MonitorFriendlyDeviceName;

            /// <summary>
            /// Cesta k zařízení monitoru (128 znaků).
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string MonitorDevicePath;
        }
    }
}
