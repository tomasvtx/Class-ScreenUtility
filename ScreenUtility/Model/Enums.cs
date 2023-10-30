using System;
using System.Collections.Generic;
using System.Text;

namespace ScreenUtility
{
    internal struct Enums
    {
        /// <summary>
        /// Výčtový typ reprezentující různé vlajky pro konfiguraci zařízení.
        /// </summary>
        internal enum QueryDeviceConfigFlags : uint
        {
            /// <summary>
            /// Vlajka pro získání všech dostupných cest.
            /// </summary>
            QdcAllPaths = 0x00000001,

            /// <summary>
            /// Vlajka pro získání pouze aktivních cest.
            /// </summary>
            QdcOnlyActivePaths = 0x00000002,

            /// <summary>
            /// Vlajka pro použití aktuální konfigurace databáze.
            /// </summary>
            QdcDatabaseCurrent = 0x00000004
        }



        /// <summary>
        /// Výčtový typ MyDisplayConfigVideoOutputTechnology představuje různé technologie výstupu videa.
        /// </summary>
        internal enum MyDisplayConfigVideoOutputTechnology : uint
        {
            /// <summary>
            /// Jiný typ výstupu.
            /// </summary>
            Other = 0xFFFFFFFF,

            /// <summary>
            /// VGA (HD15) výstup.
            /// </summary>
            HD15 = 0,

            /// <summary>
            /// S-Video výstup.
            /// </summary>
            SVideo = 1,

            /// <summary>
            /// Kompozitní video výstup.
            /// </summary>
            CompositeVideo = 2,

            /// <summary>
            /// Komponentní video výstup.
            /// </summary>
            ComponentVideo = 3,

            /// <summary>
            /// DVI výstup.
            /// </summary>
            DVI = 4,

            /// <summary>
            /// HDMI výstup.
            /// </summary>
            HDMI = 5,

            /// <summary>
            /// LVDS (Low Voltage Differential Signaling) výstup.
            /// </summary>
            LVDS = 6,

            /// <summary>
            /// DJPN výstup.
            /// </summary>
            DJPN = 8,

            /// <summary>
            /// SDI (Serial Digital Interface) výstup.
            /// </summary>
            SDI = 9,

            /// <summary>
            /// Externí DisplayPort výstup.
            /// </summary>
            DisplayPortExternal = 10,

            /// <summary>
            /// Vestavěný DisplayPort výstup.
            /// </summary>
            DisplayPortEmbedded = 11,

            /// <summary>
            /// Externí UDI (Unified Display Interface) výstup.
            /// </summary>
            UDIExternal = 12,

            /// <summary>
            /// Vestavěný UDI (Unified Display Interface) výstup.
            /// </summary>
            UDIEmbedded = 13,

            /// <summary>
            /// SDTV Dongle výstup.
            /// </summary>
            SDTVDongle = 14,

            /// <summary>
            /// Miracast výstup.
            /// </summary>
            Miracast = 15,

            /// <summary>
            /// Interní výstup (nemá fyzický port).
            /// </summary>
            Internal = 0x80000000,

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF
        }


        /// <summary>
        /// Výčtový typ MyDisplayConfigScanlineOrdering představuje různé možnosti řazení řádek skenování.
        /// </summary>
        internal enum MyDisplayConfigScanlineOrdering : uint
        {
            /// <summary>
            /// Neurčeno (zobrazení není specifikováno).
            /// </summary>
            Unspecified = 0,

            /// <summary>
            /// Progresivní režim (plstevní postup, všechny řádky jsou vykresleny postupně).
            /// </summary>
            Progressive = 1,

            /// <summary>
            /// Interlaced režim (přeskalované, liché a sudé řádky jsou vykresleny střídavě).
            /// </summary>
            Interlaced = 2,

            /// <summary>
            /// Interlaced režim s lichým polem první.
            /// </summary>
            InterlacedUpperFieldFirst = Interlaced,

            /// <summary>
            /// Interlaced režim se sudým polem první.
            /// </summary>
            InterlacedLowerFieldFirst = 3,

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF
        }

        /// <summary>
        /// Výčtový typ MyDisplayConfigRotation představuje různé možnosti rotace displeje.
        /// </summary>
        internal enum MyDisplayConfigRotation : uint
        {
            /// <summary>
            /// Identity (bez rotace).
            /// </summary>
            Identity = 1,

            /// <summary>
            /// Rotate 90 (otočení o 90 stupňů).
            /// </summary>
            Rotate90 = 2,

            /// <summary>
            /// Rotate 180 (otočení o 180 stupňů).
            /// </summary>
            Rotate180 = 3, 

            /// <summary>
            /// Rotate 270 (otočení o 270 stupňů).
            /// </summary>
            Rotate270 = 4, 

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF 
        }


        /// <summary>
        /// Výčtový typ MyDisplayConfigScaling představuje různé možnosti škálování obrazu na displeji.
        /// </summary>
        internal enum MyDisplayConfigScaling : uint
        {
            /// <summary>
            /// Identity (bez změn, ponechání původního rozlišení).
            /// </summary>
            Identity = 1,

            /// <summary>
            /// Centered (zobrazení je uprostřed obrazovky).
            /// </summary>
            Centered = 2,

            /// <summary>
            /// Stretched (roztažení na celou obrazovku).
            /// </summary>
            Stretched = 3,

            /// <summary>
            /// Aspect Ratio Centered Max (zachování poměru stran a umístění uprostřed s maximálním zobrazením).
            /// </summary>
            AspectRatioCenteredMax = 4,

            /// <summary>
            /// Custom (vlastní nastavení).
            /// </summary>
            Custom = 5,

            /// <summary>
            /// Preferred (nastavení preferované systémové konfigurace).
            /// </summary>
            Preferred = 128,

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF 
        }


        /// <summary>
        /// Výčtový typ MyDisplayConfigPixelFormat reprezentuje různé formáty pixelů pro režim monitoru.
        /// </summary>
        internal enum MyDisplayConfigPixelFormat : uint
        {
            /// <summary>
            /// 8 bitů na pixel (256 barev).
            /// </summary>
            _8Bpp = 1,

            /// <summary>
            /// 16 bitů na pixel (65 536 barev).
            /// </summary>
            _16Bpp = 2,

            /// <summary>
            /// 24 bitů na pixel (16 777 216 barev).
            /// </summary>
            _24Bpp = 3,

            /// <summary>
            /// 32 bitů na pixel (4 294 967 296 barev).
            /// </summary>
            _32Bpp = 4,

            /// <summary>
            /// Formát pixelu pro ne-GDI obsah.
            /// </summary>
            _NonGdi = 5,

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            _ForceUInt32 = 0xFFFFFFFF 
        }



        /// <summary>
        /// Výčtový typ MyDisplayConfigModeInfoType představuje různé typy informací o režimu konfigurace displeje.
        /// </summary>
        internal enum MyDisplayConfigModeInfoType : uint
        {
            /// <summary>
            /// Informace o zdroji (zobrazovaném zařízení).
            /// </summary>
            Source = 1,

            /// <summary>
            /// Informace o cíli (nastavení monitoru).
            /// </summary>
            Target = 2,

            /// <summary>
            /// Vynutí hodnotu na UInt32 (bezznaménkové celé číslo).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF
        }



        /// <summary>
        /// Výčtový typ MyDisplayConfigDeviceInfoType představuje různé typy informací o zařízení v konfiguraci displeje.
        /// </summary>
        internal enum MyDisplayConfigDeviceInfoType : uint
        {
            /// <summary>
            /// Jméno zdroje.
            /// </summary>
            SourceName = 1,

            /// <summary>
            /// Jméno cílového zařízení (obrazovky).
            /// </summary>
            TargetName = 2,

            /// <summary>
            /// Preferovaný režim cílového zařízení.
            /// </summary>
            TargetPreferredMode = 3,

            /// <summary>
            /// Jméno adaptéru nebo zařízení displeje.
            /// </summary>
            AdapterName = 4,

            /// <summary>
            /// Informace o trvalosti (stálosti) cílového zařízení.
            /// </summary>
            TargetPersistence = 5,

            /// <summary>
            /// Základní typ cílového zařízení.
            /// </summary>
            TargetBaseType = 6,

            /// <summary>
            /// Vynucená hodnota typu UInt32 (bezznakového celého čísla).
            /// </summary>
            ForceUInt32 = 0xFFFFFFFF
        }
    }
}
