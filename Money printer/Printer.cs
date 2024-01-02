namespace Money_printer;

public static class Printer
{
    private const int TableWidth = 73;

    public static void PrintLine()
    {
        Console.WriteLine(new string('-', TableWidth));
    }

    public static void PrintRow(params string[] columns)
    {
        int width = (TableWidth - columns.Length) / columns.Length;
        string row = columns.Aggregate("|", (current, column) => current + (AlignCentre(column, width) + "|"));
        Console.WriteLine(row);
    }

    static string AlignCentre(string text, int width)
    {
        text = text.Length > width ? text[..(width - 3)] + "..." : text;
        return string.IsNullOrEmpty(text) ? new string(' ', width) : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
    }
}