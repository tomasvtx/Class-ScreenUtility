using System;
using System.Collections.Generic;

namespace ScreenUtility
{
    public struct ScreenUtility
    {
        /// <summary>
        /// Retrieves information about all screens in the system.
        /// </summary>
        /// <returns>An array of `Model.ScreenInfo` representing the screens.</returns>
        public static ScreenInfo[] AllScreens()
        {
            // Vytvoření prázdného seznamu pro ukládání informací o obrazovkách
            List<ScreenInfo> screens = new List<ScreenInfo>();

            // Procházení všech dostupných obrazovek
            foreach (var item in System.Windows.Forms.Screen.AllScreens)
            {
                // Přidání nového objektu ScreenInfo do seznamu
                screens.Add(new ScreenInfo
                {
                    // Nastavení názvu zařízení
                    DeviceName = item.DeviceName,

                    // Počet bitů na pixel na obrazovce
                    BitsPerPixel = item.BitsPerPixel,

                    // Ohraničení obrazovky (rozměry)
                    Bounds = item.Bounds,

                    // Určení, zda-li je obrazovka primární
                    Primary = item.Primary,

                    // Pracovní plocha (klient) obrazovky
                    WorkingArea = item.WorkingArea
                });
            }

            // Vrácení informací o obrazovkách jako pole
            return screens.ToArray();
        }
    }
}
