using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System;

namespace ScreenUtility
{
    public struct ScreenInfo
    {
        /// <summary>
        /// Počet bitů na pixel v režimu zobrazení.
        /// </summary>
        internal int BitsPerPixel { get; set; }

        /// <summary>
        /// Ohraničení zobrazení ve formě obdélníka.
        /// </summary>
        internal Rectangle Bounds { get; set; }

        /// <summary>
        /// Název zobrazovacího zařízení.
        /// </summary>
        internal string DeviceName { get; set; }

        /// <summary>
        /// Zda se jedná o primární zobrazovací zařízení.
        /// </summary>
        internal bool Primary { get; set; }

        /// <summary>
        /// Statická vlastnost reprezentující primární zobrazovací zařízení.
        /// </summary>
        internal static ScreenInfo PrimaryScreen { get; set; }

        /// <summary>
        /// Pracovní plocha (working area) zobrazovacího zařízení ve formě obdélníka.
        /// </summary>
        internal Rectangle WorkingArea { get; set; }
    }
}