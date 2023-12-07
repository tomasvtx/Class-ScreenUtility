# Class-ScreenUtility
Třída pro zjištění připojených monitorů a jejich EDID

.NET Framework 2.0

<!DOCTYPE html>
<html lang="cs">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Popis Použití Knihovny pro Zpracování Obrázků</title>
</head>
<body>
    <p>Tato knihovna poskytuje možnost získání informací o konfiguraci monitorů, cest a režimů. 📊</p>

    <h2>👨‍💻 Příklad 1: Získání informací o konfiguraci monitorů</h2>
    <pre>
        <code>
ScreenUtility.MyDisplayConfigAllInfo[] monitorConfigurations;
string error;

if (ScreenUtility.MonitorEdid.GetActiveMonitorConfigurations(out monitorConfigurations, out error))
{
    foreach (var monitorConfig in monitorConfigurations)
    {
        Console.WriteLine($"Monitor: {monitorConfig.Name}, Resolution: {monitorConfig.Width}x{monitorConfig.Height}, Refresh Rate: {monitorConfig.Refreshrate} Hz");
    }
}
else
{
    Console.WriteLine($"Error: {error}");
}
        </code>
    </pre>

    <h2>👣 Příklad 2: Získání informací o konfiguraci cest monitorů</h2>
    <pre>
        <code>
ScreenUtility.MyDisplayConfigPathInfo[] pathConfigurations;
string error;

if (ScreenUtility.MonitorEdid.GetActiveMonitorPathConfigurations(out pathConfigurations, out error))
{
    foreach (var pathConfig in pathConfigurations)
    {
        Console.WriteLine($"Monitor: {pathConfig.Name}, Flags: {pathConfig.Flags}, Output Technology: {pathConfig.OutputTechnology}");
    }
}
else
{
    Console.WriteLine($"Error: {error}");
}
        </code>
    </pre>

    <h2>🎮 Příklad 3: Získání informací o konfiguraci režimů monitorů</h2>
    <pre>
        <code>
ScreenUtility.MyDisplayConfigModeInfo[] modeConfigurations;
string error;

if (ScreenUtility.MonitorEdid.GetActiveMonitorModeConfigurations(out modeConfigurations, out error))
{
    foreach (var modeConfig in modeConfigurations)
    {
        Console.WriteLine($"Monitor: {modeConfig.Id}, Resolution: {modeConfig.Width}x{modeConfig.Height}, Refresh Rate: {modeConfig.Refreshrate} Hz");
    }
}
else
{
    Console.WriteLine($"Error: {error}");
}
        </code>
    </pre>

</body>
</html>
