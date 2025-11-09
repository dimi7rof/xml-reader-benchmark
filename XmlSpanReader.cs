namespace XmlBenchmark;

internal class XmlSpanReader
{
    public static List<string> ExtractDbValues(string xml)
    {
        ReadOnlySpan<char> Open = "<DB>".AsSpan();
        ReadOnlySpan<char> Close = "</DB>".AsSpan();

        var span = xml.AsSpan();
        var result = new List<string>(512);

        int idx = 0;
        while (true)
        {
            // Find next <DB>
            int startTag = span[idx..].IndexOf(Open);
            if (startTag < 0) break;

            startTag += idx;               // absolute index
            int contentStart = startTag + Open.Length;

            // Find next </DB>
            int endTag = span[contentStart..].IndexOf(Close);
            if (endTag < 0) break;

            endTag += contentStart;

            // Extract the value
            var value = span[contentStart..endTag].ToString();
            if (value.Length != 0) result.Add(value);

            // Continue after </DB>
            idx = endTag + Close.Length;
        }

        return result;
    }
    public static List<string> ExtractDbValuesV2(string xml)
    {
        const string Open = "<DB>";
        const string Close = "</DB>";
        var span = xml.AsSpan();
        var result = new List<string>(512);
        int idx = 0;
        int spanLength = span.Length;
        int openLen = Open.Length;
        int closeLen = Close.Length;

        while (idx < spanLength)
        {
            // Find next <DB>
            int startTag = span[idx..].IndexOf(Open);
            if (startTag < 0) break;

            int contentStart = idx + startTag + openLen;

            // Find next </DB>
            int endTag = span[contentStart..].IndexOf(Close);
            if (endTag < 0) break;

            int contentEnd = contentStart + endTag;

            // Extract the value - avoid ToString() for empty check
            if (contentEnd > contentStart)
            {
                result.Add(new string(span[contentStart..contentEnd]));
            }

            // Continue after </DB>
            idx = contentEnd + closeLen;
        }

        return result;
    }
}
