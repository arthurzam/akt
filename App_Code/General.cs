using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public static class General
{
    /// <summary>
    /// all the month string
    /// </summary>
    public readonly static string[] monthText = { "ינואר", "פברואר", "מרץ", "אפריל", "מאי", "יוני", "יולי", "אוגוסט", "סבטמבר", "אוקטובר", "נובמבר", "דצמבר" };

    /// <summary>
    /// get the last ok month number
    /// (the amount of month number)
    /// </summary>
    /// <returns>the amount of month number</returns>
    public static int getTheReadyMonth()
    {
        int last = DateTime.Today.Month - 1;
        if (DateTime.Today.Day < 15)
            --last;
        if (last == -1)
            return 12;
        return last;
    }

    public static int getTheReadyYear()
    {
        if (getTheReadyMonth() == 12)
            return DateTime.Now.Year - 1;
        return DateTime.Now.Year;
    }
}