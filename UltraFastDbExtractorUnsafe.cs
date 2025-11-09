using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace XmlBenchmark;

public static unsafe class UltraFastDbExtractorUnsafe
{
    private static readonly char* OpenPtr;
    private static readonly int OpenLen;
    private static readonly char* ClosePtr;
    private static readonly int CloseLen;

    static UltraFastDbExtractorUnsafe()
    {
        fixed (char* p = "<DB>")
        {
            OpenPtr = p;
            OpenLen = 4;
        }
        fixed (char* p = "</DB>")
        {
            ClosePtr = p;
            CloseLen = 5;
        }
    }

    public static List<string> ExtractDbValuesUnsafe(string xml)
    {
        var list = new List<string>(256);

        fixed (char* pXml = xml)
        {
            char* end = pXml + xml.Length;
            char* cur = pXml;

            while (true)
            {
                // Find <DB>
                char* open = Find(pXml: cur, end, OpenPtr, OpenLen);
                if (open == null)
                    break;

                char* contentStart = open + OpenLen;

                // Find </DB>
                char* close = Find(pXml: contentStart, end, ClosePtr, CloseLen);
                if (close == null)
                    break;

                int length = (int)(close - contentStart);
                if (length > 0)
                {
                    list.Add(new string(contentStart, 0, length));
                }

                // Continue after </DB>
                cur = close + CloseLen;
            }
        }

        return list;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static char* Find(char* pXml, char* end, char* match, int matchLen)
    {
        char first = *match;
        int remaining = (int)(end - pXml) - matchLen + 1;

        for (int i = 0; i < remaining; i++)
        {
            if (pXml[i] == first)
            {
                if (MemoryEquals(pXml + i, match, matchLen))
                    return pXml + i;
            }
        }
        return null;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool MemoryEquals(char* a, char* b, int len)
    {
        for (int i = 0; i < len; i++)
        {
            if (a[i] != b[i])
                return false;
        }
        return true;
    }
}
