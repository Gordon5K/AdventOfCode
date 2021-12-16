using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AOC._2021.Day16;

namespace AOC._2021
{
    public class Day16 : TestClass, ITestClass
    {
        private const byte LiteralValueId = 4;
        private const char EndOfPacketId = '0';
        private const char LengthTypeId15 = '0';

        public record Segment(int Index, int Length);

        private readonly Segment _versionSegment = new(0, 3);
        private readonly Segment _typeIdSegment = new(3, 3);

        private readonly string _bits;

        public Day16()
        {
            _input = @"A20D74AFC6C80CEA7002D4009202C7C00A6830029400F500218080C3002D006CC2018658056E7002DC00C600E75002ED6008EDC00D4003E24A13995080513FA309482649458A054C6E00E6008CEF204BA00B080311B21F4101006E1F414846401A55002F53E9525B845AA7A789F089402997AE3AFB1E6264D772D7345C6008D8026200E41D83B19C001088CB04A294ADD64C0129D818F802727FFF3500793FFF9A801A801539F42200DC3801A39C659ACD3FC6E97B4B1E7E94FC1F440219DAFB5BB1648E8821A4FF051801079C379F119AC58ECC011A005567A6572324D9AE6CCD003639ED7F8D33B8840A666B3C67B51388440193E003413A3733B85F2712DEBB59002B930F32A7D0688010096019375300565146801A194844826BB7132008024C8E4C1A69E66108000D39BAD950802B19839F005A56D9A554E74C08028992E95D802D2764D93B27900501340528A7301F2E0D326F274BCAB00F5009A737540916D9A9D1EA7BD849100425D9E3A9802B800D24F669E7691E19CFFE3AF280803440086C318230DCC01E8BF19E33980331D631C593005E80330919D718EFA0E3233AE31DF41C67F5CB5CAC002758D7355DD57277F6BF1864E9BED0F18031A95DDF99EB7CD64626EF54987AE007CCC3C4AE0174CDAD88E65F9094BC4025FB2B82C6295F04100109263E800FA41792BCED1CC3A233C86600B48FFF5E522D780120C9C3D89D8466EFEA019009C9600A880310BE0C47A100761345E85F2D7E4769240287E80272D3CEFF1C693A5A79DFE38D27CCCA75E5D00803039BFF11F401095F714657DC56300574010936491FBEC1D8A4402234E1E68026200CC5B8FF094401C89D12E14B803325DED2B6EA34CA248F2748834D0E18021339D4F962AB005E78AE75D08050E10066114368EE0008542684F0B40010B8AB10630180272E83C01998803104E14415100623E469821160";
            _bits = _input.ReadHexToBits();
        }

        public object Task1()
        {
            int index = 0;
            var packet = ReadPacket(_bits, ref index);

            return packet.VersionSum;
        }

        public object Task2()
        {
            int index = 0;
            var packet = ReadPacket(_bits, ref index);

            return packet.Value;
        }

        private Packet ReadPacket(ReadOnlySpan<char> bits, ref int index)
        {
            Segment versionSegment = SegmentFromIndex(_versionSegment, index);
            Segment typeIdSegment = SegmentFromIndex(_typeIdSegment, index);

            byte version = (byte)bits.ExtractSegment(versionSegment);
            byte typeId = (byte)bits.ExtractSegment(typeIdSegment);

            index = typeIdSegment.Index + typeIdSegment.Length;
            if (typeId == LiteralValueId)
            {
                long literalValue = ReadLiteralPacket(bits, ref index);
                return new Packet(version, literalValue);
            }
            else
            {
                Packet newPacket = new(version, typeId);
                int subPacketTypeId = bits.Slice(index++, 1)[0];
                if (subPacketTypeId == LengthTypeId15)
                {
                    //15
                    int subPacketLength = (int)bits.ExtractSegment(new Segment(index, Length: 15));
                    index += 15;

                    int startIndex = index;

                    while (index - startIndex < subPacketLength)
                    {
                        var subPacket = ReadPacket(bits, ref index);
                        newPacket.AddPacket(subPacket);
                    }
                }
                else
                {
                    //11
                    int subPacketCount = (int)bits.ExtractSegment(new Segment(index, Length: 11));
                    index += 11;

                    for (int packetCount = 0; packetCount < subPacketCount; packetCount++)
                    {
                        var subPacket = ReadPacket(bits, ref index);
                        newPacket.AddPacket(subPacket);
                    }
                }

                newPacket.Value = newPacket.CalculatePacketValue();
                return newPacket;
            }
        }

        private static long ReadLiteralPacket(ReadOnlySpan<char> bits, ref int index)
        {
            bool endOfPacket = false;
            var sb = new StringBuilder();
            while (!endOfPacket)
            {
                endOfPacket = bits.Slice(index, 1)[0] == EndOfPacketId;
                sb.Append(bits.Slice(index + 1, 4));
                index += 5;
            }

            return ((ReadOnlySpan<char>)sb.ToString()).ExtractSegment();
        }

        private static Segment SegmentFromIndex(Segment segment, int index)
        {
            return segment with { Index = segment.Index + index };
        }

        public class Packet
        {
            public Packet(byte version, byte typeId) : this(version, -1)
            {
                TypeId = typeId;
            }

            public Packet(byte version, long value)
            {
                Version = version;
                VersionSum = version;
                Value = value;
                SubPackets = new();
            }

            public byte Version { get; init; }

            public byte TypeId { get; private set; }

            public long Value { get; set; }

            public List<Packet> SubPackets { get; }

            public int VersionSum { get; set; }

            public void AddPacket(Packet packet)
            {
                SubPackets.Add(packet);
                VersionSum += packet.VersionSum;
            }
        }
    }

    public static class Day16BitExtensions
    {
        private static readonly Dictionary<char, string> _charMap = new()
        {
            ['0'] = "0000",
            ['1'] = "0001",
            ['2'] = "0010",
            ['3'] = "0011",
            ['4'] = "0100",
            ['5'] = "0101",
            ['6'] = "0110",
            ['7'] = "0111",
            ['8'] = "1000",
            ['9'] = "1001",
            ['A'] = "1010",
            ['B'] = "1011",
            ['C'] = "1100",
            ['D'] = "1101",
            ['E'] = "1110",
            ['F'] = "1111"
        };

        public static string ReadHexToBits(this string hex)
        {
            var sb = new StringBuilder();
            foreach (char c in hex)
            {
                sb.Append(_charMap[c]);
            }
            return sb.ToString();
        }

        public static long ExtractSegment(this ReadOnlySpan<char> bits, Segment segmentDetails = null)
        {
            if (segmentDetails == null) segmentDetails = new Segment(0, bits.Length);
            return ReadBitCharsToInt(bits.Slice(segmentDetails.Index, segmentDetails.Length));
        }

        private static long ReadBitCharsToInt(this ReadOnlySpan<char> bits)
        {
            long result = 0;
            foreach (char bit in bits)
            {
                result <<= 1;
                result += (bit == '1' ? 1 : 0);
            }
            return result;
        }
    }

    public static class Day16PacketExtensions
    {
        public static long CalculatePacketValue(this Packet packet)
        {
            return packet.TypeId switch
            {
                0 => packet.SubPackets.Sum(x => x.Value),
                1 => packet.SubPackets.Aggregate(seed: (long)1, (x, y) => x * y.Value),
                2 => packet.SubPackets.Min(x => x.Value),
                3 => packet.SubPackets.Max(x => x.Value),
                5 => packet.SubPackets[0].Value > packet.SubPackets[1].Value ? 1 : 0,
                6 => packet.SubPackets[0].Value < packet.SubPackets[1].Value ? 1 : 0,
                7 => packet.SubPackets[0].Value == packet.SubPackets[1].Value ? 1 : 0,
                _ => 0
            };
        }
    }
}
