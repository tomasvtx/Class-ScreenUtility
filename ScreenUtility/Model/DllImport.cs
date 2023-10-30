using System;
using System.Runtime.InteropServices;
using static ScreenUtility.Enums;

namespace ScreenUtility
{
    internal struct DllImport
    {
         /// <summary>
        /// Získá velikost bufferu pro informace o konfiguraci displeje.
        /// </summary>
        /// <param name="flags">Vlajky dotazu konfigurace zařízení.</param>
        /// <param name="numPathArrayElements">Počet prvků v poli PathInfoArray.</param>
        /// <param name="numModeInfoArrayElements">Počet prvků v poli ModeInfoArray.</param>
        /// <returns>Kód chyby (ERROR_SUCCESS znamená úspěch).</returns>
        [DllImport("user32.dll")]
        internal static extern int GetDisplayConfigBufferSizes(
            QueryDeviceConfigFlags Flags,
            out uint NumPathArrayElements,
            out uint NumModeInfoArrayElements
        );


        /// <summary>
        /// Získá informace o konfiguraci displeje pro zadaný režim.
        /// </summary>
        /// <param name="flags">Vlajky dotazu konfigurace zařízení.</param>
        /// <param name="numPathArrayElements">Počet prvků v poli PathInfoArray.</param>
        /// <param name="pathInfoArray">Pole obsahující informace o cestách v konfiguraci displeje.</param>
        /// <param name="numModeInfoArrayElements">Počet prvků v poli ModeInfoArray.</param>
        /// <param name="modeInfoArray">Pole obsahující informace o režimech v konfiguraci displeje.</param>
        /// <param name="currentTopologyId">Identifikátor aktuální topologie (může být null).</param>
        /// <returns>Kód chyby (ERROR_SUCCESS znamená úspěch).</returns>
        [DllImport("user32.dll")]
        internal static extern int QueryDisplayConfig(
            QueryDeviceConfigFlags Flags,
            ref uint NumPathArrayElements,
            [Out] Structs.DisplayConfigPathInfo[] PathInfoArray,
            ref uint NumModeInfoArrayElements,
            [Out] Structs.DisplayConfigModeInfo[] ModeInfoArray,
            IntPtr CurrentTopologyId
        );


        /// <summary>
        /// Získá informace o zařízení v konfiguraci displeje.
        /// </summary>
        /// <param name="deviceName">Struktura obsahující informace o cílovém zařízení.</param>
        /// <returns>Kód chyby (ERROR_SUCCESS znamená úspěch).</returns>
        [DllImport("user32.dll")]
        internal static extern int GetDisplayConfigDeviceInfo(ref Structs.MyDisplayConfigTargetDeviceName deviceName);
    }
}
