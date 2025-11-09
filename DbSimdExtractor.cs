using System.Numerics;
using System.Text;

namespace XmlBenchmark;

public static class DbSimdExtractor
{
    private static readonly byte L1 = (byte)'<';
    private static readonly byte D = (byte)'D';
    private static readonly byte B = (byte)'B';
    private static readonly byte GT = (byte)'>';

    private static readonly byte SL = (byte)'<';
    private static readonly byte SLASH = (byte)'/';
    private static readonly byte GT2 = (byte)'>';

    private static readonly byte[] OpenTag = "<DB>".Select(b => (byte)b).ToArray();
    private static readonly byte[] CloseTag = "</DB>".Select(b => (byte)b).ToArray();

    public static List<string> Extract(ReadOnlySpan<byte> utf8)
    {
        var results = new List<string>(64);

        int i = 0;
        int len = utf8.Length;

        while (i < len)
        {
            // ---- FIND <DB> ---------------------------------------------------
            int start = FindTagSimd(utf8, i, OpenTag);
            if (start < 0) break;

            int contentStart = start + OpenTag.Length;

            // ---- FIND </DB> --------------------------------------------------
            int end = FindTagSimd(utf8, contentStart, CloseTag);
            if (end < 0) break;

            // ---- Extract value -----------------------------------------------
            ReadOnlySpan<byte> slice = utf8.Slice(contentStart, end - contentStart);
            results.Add(Encoding.UTF8.GetString(slice));

            i = end + CloseTag.Length;
        }

        return results;
    }

    private static int FindTagSimd(ReadOnlySpan<byte> span, int start, ReadOnlySpan<byte> tag)
    {
        byte first = tag[0];
        int len = span.Length;
        int tlen = tag.Length;

        if (start > len - tlen)
            return -1;

        // Decide whether to use SIMD
        if (Vector.IsHardwareAccelerated && len - start >= Vector<byte>.Count)
        {
            int i = start;
            int simdWidth = Vector<byte>.Count;

            var vfirst = new Vector<byte>(first);

            for (; i <= len - simdWidth - tlen; i += simdWidth)
            {
                var block = new Vector<byte>(span.Slice(i, simdWidth));
                var eq = Vector.Equals(block, vfirst);

                if (!eq.Equals(Vector<byte>.Zero))
                {
                    // Check each matching lane
                    for (int lane = 0; lane < simdWidth; lane++)
                    {
                        if (eq[lane] == 0) continue;

                        int pos = i + lane;
                        if (pos + tlen <= len &&
                            span.Slice(pos, tlen).SequenceEqual(tag))
                            return pos;
                    }
                }
            }

            // tail
            for (; i <= len - tlen; i++)
            {
                if (span[i] == first &&
                    span.Slice(i, tlen).SequenceEqual(tag))
                    return i;
            }

            return -1;
        }
        else
        {
            // Scalar fallback
            for (int i = start; i <= len - tlen; i++)
            {
                if (span[i] == first &&
                    span.Slice(i, tlen).SequenceEqual(tag))
                    return i;
            }

            return -1;
        }
    }
}
