using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using static ScreenUtility.Enums;

namespace ScreenUtility
{
    public struct MonitorEdid
    {
        /// <summary>
        /// Konstanta reprezentující hodnotu úspěšného dokončení operace.
        /// </summary>
        private const int ErrorSuccess = 0;

        /// <summary>
        /// Získá informace o konfiguraci monitorů s aktivními displeji včetně jejich vlastností, jako jsou název, frekvence a rozlišení.
        /// </summary>
        /// <param name="myDisplayConfigAllInfos">Pole obsahující informace o konfiguraci monitorů.</param>
        /// <param name="Error">Chybová zpráva, pokud operace selže.</param>
        /// <returns>True, pokud se získání konfigurace monitorů zdaří; jinak False s chybovou zprávou v parametru Error.</returns>
        public static bool GetActiveMonitorConfigurations(out MyDisplayConfigAllInfo[] myDisplayConfigAllInfos, out string Error)
        {
            myDisplayConfigAllInfos = new MyDisplayConfigAllInfo[0];
            Error = string.Empty;

            try
            {
                // Získání počtu cest a režimů konfigurace monitorů s aktivními displeji.
                uint pathCount, modeCount;
                int error = DllImport.GetDisplayConfigBufferSizes(QueryDeviceConfigFlags.QdcOnlyActivePaths, out pathCount, out modeCount);

                // Kontrola, zda operace proběhla úspěšně, jinak vyvolává výjimku Win32Exception.
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Inicializace pole struktur pro cesty a režimy konfigurace.
                Structs.DisplayConfigPathInfo[] displayPaths = new Structs.DisplayConfigPathInfo[pathCount];
                Structs.DisplayConfigModeInfo[] displayModes = new Structs.DisplayConfigModeInfo[modeCount];

                // Získání informací o cestách a režimech konfigurace monitorů.
                error = DllImport.QueryDisplayConfig(QueryDeviceConfigFlags.QdcOnlyActivePaths, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);

                // Kontrola, zda operace proběhla úspěšně, jinak vyvolává výjimku Win32Exception.
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Inicializace seznamu pro ukládání informací o konfiguraci monitorů.
                List<MyDisplayConfigAllInfo> myDisplayConfig = new List<MyDisplayConfigAllInfo>();

                // Zpracování získaných informací a jejich uložení do seznamu myDisplayConfig.
                for (int i = 0; i < displayPaths.Length; i++)
                {
                    // Pokus o získání VSync frekvence a HSync frekvence, pokud jsou dostupné.
                    double vSyncFreq = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.VSyncFreq.Denominator == 0
          ? 0
          : (double)displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.VSyncFreq.Numerator /
            (double)displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.VSyncFreq.Denominator;

                    double hSyncFreq = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.HSyncFreq.Denominator == 0
                        ? 0
                        : (double)displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.HSyncFreq.Numerator /
                          (double)displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.HSyncFreq.Denominator;

                    // Vytvoření objektu MyDisplayConfigAllInfo a přidání ho do seznamu.
                    myDisplayConfig.Add(new MyDisplayConfigAllInfo
                    {
                        Name = GetMonitorFriendlyName(out string MonitorName, out string Eror, displayPaths[i].SourceInfo.AdapterId, displayPaths[i].TargetInfo.Id) ? MonitorName : Eror,
                        Flags = displayPaths[i].Flags,
                        LowPart = displayPaths[i].SourceInfo.AdapterId.LowPart,
                        HighPart = displayPaths[i].SourceInfo.AdapterId.HighPart,
                        Id = displayPaths[i].TargetInfo.Id,
                        ModeInfoIdx = displayPaths[i].TargetInfo.ModeInfoIdx,
                        OutputTechnology = displayPaths[i].TargetInfo.OutputTechnology,
                        RefreshrateDenominator = displayPaths[i].TargetInfo.RefreshRate.Denominator,
                        RefreshrateNumerator = displayPaths[i].TargetInfo.RefreshRate.Numerator,
                        Refreshrate = (double)displayPaths[i].TargetInfo.RefreshRate.Numerator / (double)displayPaths[i].TargetInfo.RefreshRate.Denominator,
                        Rotation = displayPaths[i].TargetInfo.Rotation,
                        Scaling = displayPaths[i].TargetInfo.Scaling,
                        ScanLineOrdering = displayPaths[i].TargetInfo.ScanLineOrdering,
                        StatusFlags = displayPaths[i].SourceInfo.StatusFlags,
                        TargetAvailable = displayPaths[i].TargetInfo.TargetAvailable,

                        InfoType = displayModes[i].InfoType,
                        PixelFormat = displayModes[i].ModeInfo.SourceMode.PixelFormat,
                        ActiveSize = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize,
                        ActiveSizeX = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cx > 0 ? displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cx : 1,
                        ActiveSizeY = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cy > 0 ? displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cy : 1,
                        StringActiveSize = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cx + "x" + displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize.Cy,
                        VSyncFreq = vSyncFreq,
                        HSyncFreq = hSyncFreq,
                        VideoStandard = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.VideoStandard,
                        PixelRate = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.PixelRate,
                        Height = displayModes[i].ModeInfo.SourceMode.Height,
                        Width = displayModes[i].ModeInfo.SourceMode.Width,
                        PositionX = displayModes[i].ModeInfo.SourceMode.Position.X,
                        PositionY = displayModes[i].ModeInfo.SourceMode.Position.Y,
                        TotalSize = displayModes[i].ModeInfo.TargetMode.TargetVideoSignalInfo.TotalSize
                    });
                }

                myDisplayConfigAllInfos = myDisplayConfig.ToArray();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Získá informace o konfiguraci cest monitorů s aktivními displeji včetně vlastností, jako jsou název, vlajky a technologie výstupu.
        /// </summary>
        /// <param name="myDisplayConfigPathInfo">Pole obsahující informace o konfiguraci cest monitorů.</param>
        /// <param name="Error">Chybová zpráva, pokud operace selže.</param>
        /// <returns>True, pokud se získání konfigurace cest monitorů zdaří; jinak False s chybovou zprávou v parametru Error.</returns>
        public static bool GetActiveMonitorPathConfigurations(out MyDisplayConfigPathInfo[] myDisplayConfigPathInfo, out string Error)
        {
            myDisplayConfigPathInfo = new MyDisplayConfigPathInfo[0];
            Error = string.Empty;

            try
            {
                // Proměnné pro uchování počtu cest a režimů konfigurace monitorů.
                uint pathCount, modeCount;

                // Volání funkce GetDisplayConfigBufferSizes k získání počtu cest a režimů.
                int error = DllImport.GetDisplayConfigBufferSizes(QueryDeviceConfigFlags.QdcOnlyActivePaths, out pathCount, out modeCount);

                // Kontrola, zda operace proběhla úspěšně, jinak vyvolává výjimku Win32Exception.
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Inicializace pole struktur pro cesty a režimy konfigurace monitorů.
                Structs.DisplayConfigPathInfo[] displayPaths = new Structs.DisplayConfigPathInfo[pathCount];
                Structs.DisplayConfigModeInfo[] displayModes = new Structs.DisplayConfigModeInfo[modeCount];

                // Volání funkce QueryDisplayConfig k získání informací o cestách a režimech konfigurace monitorů.
                error = DllImport.QueryDisplayConfig(QueryDeviceConfigFlags.QdcOnlyActivePaths, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);

                // Kontrola, zda operace proběhla úspěšně, jinak vyvolává výjimku Win32Exception.
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Inicializace seznamu pro ukládání informací o konfiguraci cest monitorů.
                List<MyDisplayConfigPathInfo> myDisplayConfig = new List<MyDisplayConfigPathInfo>();

                // Zpracování získaných informací a jejich uložení do seznamu myDisplayConfig.
                foreach (var item in displayPaths)
                {
                    // Vytvoření objektu MyDisplayConfigPathInfo a přidání ho do seznamu.
                    myDisplayConfig.Add(new MyDisplayConfigPathInfo
                    {
                        Name = GetMonitorFriendlyName(out string MonitorName, out Error, item.SourceInfo.AdapterId, item.TargetInfo.Id) ? MonitorName : Error,
                        Flags = item.Flags,
                        LowPart = item.SourceInfo.AdapterId.LowPart,
                        HighPart = item.SourceInfo.AdapterId.HighPart,
                        Id = item.TargetInfo.Id,
                        ModeInfoIdx = item.TargetInfo.ModeInfoIdx,
                        OutputTechnology = item.TargetInfo.OutputTechnology,
                        RefreshrateDenominator = item.TargetInfo.RefreshRate.Denominator,
                        RefreshrateNumerator = item.TargetInfo.RefreshRate.Numerator,
                        Rotation = item.TargetInfo.Rotation,
                        Scaling = item.TargetInfo.Scaling,
                        ScanLineOrdering = item.TargetInfo.ScanLineOrdering,
                        StatusFlags = item.SourceInfo.StatusFlags,
                        TargetAvailable = item.TargetInfo.TargetAvailable
                    });
                }
                myDisplayConfigPathInfo = myDisplayConfig.ToArray();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Získá informace o konfiguraci režimu monitorů s aktivními displeji, včetně jejich parametrů, jako jsou rozlišení a frekvence obnovování.
        /// </summary>
        /// <param name="myDisplayConfigModeInfos">Pole obsahující informace o konfiguraci režimu monitorů.</param>
        /// <param name="Error">Chybová zpráva, pokud operace selže.</param>
        /// <returns>True, pokud se získání konfigurace režimu monitorů zdaří; jinak False s chybovou zprávou v parametru Error.</returns>
        public static bool GetActiveMonitorModeConfigurations(out MyDisplayConfigModeInfo[] myDisplayConfigModeInfos, out string Error)
        {
            myDisplayConfigModeInfos = new MyDisplayConfigModeInfo[0];
            Error = string.Empty;

            try
            {
                // Získání počtu cest a režimů konfigurace displejů
                uint pathCount, modeCount;
                int error = DllImport.GetDisplayConfigBufferSizes(QueryDeviceConfigFlags.QdcOnlyActivePaths, out pathCount, out modeCount);

                // Pokud dojde k chybě, vyvolá se výjimka s chybovým kódem
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Vytvoření pole pro ukládání informací o cestách a režimech
                Structs.DisplayConfigPathInfo[] displayPaths = new Structs.DisplayConfigPathInfo[pathCount];
                Structs.DisplayConfigModeInfo[] displayModes = new Structs.DisplayConfigModeInfo[modeCount];

                // Získání konfigurace displejů
                error = DllImport.QueryDisplayConfig(QueryDeviceConfigFlags.QdcOnlyActivePaths, ref pathCount, displayPaths, ref modeCount, displayModes, IntPtr.Zero);

                // Pokud dojde k chybě, vyvolá se výjimka s chybovým kódem
                if (error != ErrorSuccess)
                {
                    HandleError(error);
                }

                // Vytvoření seznamu pro ukládání vašich vlastních informací o konfiguraci displejů
                List<MyDisplayConfigModeInfo> myDisplayConfig = new List<MyDisplayConfigModeInfo>();

                // Procházení informací o režimech konfigurace displejů a jejich přidání do seznamu
                foreach (var item in displayModes)
                {
                    myDisplayConfig.Add(new MyDisplayConfigModeInfo
                    {
                        Id = item.Id,
                        InfoType = item.InfoType,
                        PixelFormat = item.ModeInfo.SourceMode.PixelFormat,
                        ActiveSize = item.ModeInfo.TargetMode.TargetVideoSignalInfo.ActiveSize,
                        VSyncFreq = item.ModeInfo.TargetMode.TargetVideoSignalInfo.VSyncFreq,
                        HSyncFreq = item.ModeInfo.TargetMode.TargetVideoSignalInfo.HSyncFreq,
                        VideoStandard = item.ModeInfo.TargetMode.TargetVideoSignalInfo.VideoStandard,
                        PixelRate = item.ModeInfo.TargetMode.TargetVideoSignalInfo.PixelRate,
                        Height = item.ModeInfo.SourceMode.Height,
                        Width = item.ModeInfo.SourceMode.Width,
                        HighPart = item.AdapterId.HighPart,
                        LowPart = item.AdapterId.LowPart,
                        PositionX = item.ModeInfo.SourceMode.Position.X,
                        PositionY = item.ModeInfo.SourceMode.Position.Y,
                        ScanLineOrdering = item.ModeInfo.TargetMode.TargetVideoSignalInfo.ScanLineOrdering,
                        TotalSize = item.ModeInfo.TargetMode.TargetVideoSignalInfo.TotalSize
                    });
                }
                myDisplayConfigModeInfos = myDisplayConfig.ToArray();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Získá přátelský název monitoru na základě identifikátoru adaptéru a cíle.
        /// </summary>
        /// <param name="MonitorName">Přátelský název monitoru.</param>
        /// <param name="Error">Chybová zpráva, pokud operace selže.</param>
        /// <param name="adapterId">Identifikátor adaptéru monitoru.</param>
        /// <param name="targetId">Identifikátor cíle monitoru.</param>
        /// <returns>True, pokud se získání názvu monitoru zdaří; jinak False s chybovou zprávou v parametru Error.</returns>
        public static bool GetMonitorFriendlyName(out string MonitorName, out string Error, Structs.MyLuid adapterId, uint targetId)
        {
            MonitorName = string.Empty; Error = string.Empty;
            try
            {
                // Vytvoření instance struktury MyDisplayConfigTargetDeviceName pro uložení informací o zařízení
                Structs.MyDisplayConfigTargetDeviceName deviceName = new Structs.MyDisplayConfigTargetDeviceName();

                // Nastavení velikosti hlavičky struktury
                deviceName.Header.Size = (uint)Marshal.SizeOf(typeof(Structs.MyDisplayConfigTargetDeviceName));

                // Nastavení identifikátoru adaptéru a cíle
                deviceName.Header.AdapterId = adapterId;
                deviceName.Header.Id = targetId;

                // Nastavení typu informací jako TargetName
                deviceName.Header.Type = MyDisplayConfigDeviceInfoType.TargetName;

                // Volání externí funkce pro získání informací o zařízení
                int error = DllImport.GetDisplayConfigDeviceInfo(ref deviceName);

                // Pokud došlo k chybě, vyvolání výjimky Win32Exception s chybovým kódem
                if (error != ErrorSuccess)
                    HandleError(error);

                MonitorName = deviceName.MonitorFriendlyDeviceName;
                return true;
            }
            catch (Exception e) 
            {
                Error = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Zpracuje chybový kód a vyvolá výjimku typu Win32Exception v případě, že kód reprezentuje chybu.
        /// </summary>
        /// <param name="errorCode">Chybový kód k zpracování.</param>
        private static void HandleError(int errorCode)
        {
            if (errorCode != ErrorSuccess)
            {
                throw new Win32Exception(errorCode);
            }
        }
    }
}
