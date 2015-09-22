// Written by jopojelly, adapted from XNBSoundConverter(youtube.com/gameking008)
using System;
using System.IO;
using System.Diagnostics;

//namespace WAVToXNBSoundConverter
//{
//    class WAVToXNBSoundConverter
//    {
//    }
//}



class WAVToXNBSoundConverter
{
    static void Main(string[] args)
    {
        string[] paths;
        if (args.Length < 1)
        {
            try
            {
                paths = Directory.GetFiles(Environment.CurrentDirectory, "*.wav");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name + ": " + e.Message);
                Console.ReadKey(true);
                return;
            }
        }
        else paths = args;
        if (paths.Length < 1)
        {
            string filename = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            Console.WriteLine("No WAV files to convert.\nDrag and drop WAV files onto " + filename + " or execute " + filename + " with no arguments to convert all WAV files in the current directory.");
            Console.ReadKey(true);
            return;
        }
        foreach (string s in paths)
        {
            Console.WriteLine("Converting " + Path.GetFileNameWithoutExtension(s) + "...");
            Console.WriteLine(ConvertToXnb(s, Path.ChangeExtension(s, "xnb")));
        }
        Console.ReadKey(true);
    }

    static string ConvertToXnb(string wavFile, string xnbFile)
    {
        ushort wFormatTag;
        ushort nChannels;
        uint nSamplesPerSec;
        uint nAvgBytesPerSec;
        ushort nBlockAlign;
        ushort wBitsPerSample;

        int dataChunkSize;
        byte[] waveData;

        using (Stream fs = File.OpenRead(wavFile))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                //bw.Write("RIFF".ToCharArray());
                string format = new string(br.ReadChars(4));
                if (format != "RIFF") return "Invalid file format: " + format;

                //bw.Write(dataChunkSize + 36);
                uint fileLength = br.ReadUInt32();
                if (fileLength != fs.Length-8) return "File length mismatch: " + fileLength + " - should be " + fs.Length;

                //bw.Write("WAVE".ToCharArray());
                format = new string(br.ReadChars(4));
                if (format != "WAVE") return "Problem 1";

                //bw.Write("fmt ".ToCharArray());
                format = new string(br.ReadChars(4));
                if (format != "fmt ") return "Problem 2";

                //bw.Write(16);
                int a = br.ReadInt32();
                if (a != 16) return "Problem 3";

                //bw.Write(wFormatTag);
                if ((wFormatTag = br.ReadUInt16()) != 1) return "Unimplemented wav codec (must be PCM)";

                //bw.Write(nChannels);
                nChannels = br.ReadUInt16();

                //bw.Write(nSamplesPerSec);
                nSamplesPerSec = br.ReadUInt32();

                //bw.Write(nAvgBytesPerSec);
                nAvgBytesPerSec = br.ReadUInt32();

                //bw.Write(nBlockAlign);
                nBlockAlign = br.ReadUInt16();

                //bw.Write(wBitsPerSample);
                wBitsPerSample = br.ReadUInt16();

                //bw.Write("data".ToCharArray());
                format = new string(br.ReadChars(4));
                if (format != "data") return "Problem 4";

                //bw.Write(dataChunkSize);
                //bw.Write(waveData);
                if (nAvgBytesPerSec != (nSamplesPerSec * nChannels * (wBitsPerSample / 8))) return "Average bytes per second number incorrect";
                if (nBlockAlign != (nChannels * (wBitsPerSample / 8))) return "Block align number incorrect";
            //    br.ReadUInt16();
                waveData = br.ReadBytes(dataChunkSize = br.ReadInt32());


                ////char platform = br.ReadChar();
                ////if (platform != 'w') return "Invalid platform: " + platform;
                //int xnaVersion = br.ReadByte();
                //if (xnaVersion != 5) return "Unimplemented XNA version: " + xnaVersion;
                //byte profile = br.ReadByte();
                //if (profile != 0) return "Unimplemented profile: " + profile;
                //uint fileLength = br.ReadUInt32();
                //if (fileLength != fs.Length) return "File length mismatch: " + fileLength + " - should be " + fs.Length;
                //uint typeCount = (uint)Read7BitEncodedInt(br);
                //if (typeCount != 1) return "Too many types: " + typeCount;
                //// Should be in a for loop but I'm too lazy to add support for multiple types.
                //string type = br.ReadString();
                //if (type != "Microsoft.Xna.Framework.Content.SoundEffectReader") return "Wrong type reader name: " + type;
                //int typeReaderVersion = br.ReadInt32();
                //if (typeReaderVersion != 0) return "Wrong type reader version: " + typeReaderVersion;
                //uint sharedResourcesCount = (uint)Read7BitEncodedInt(br);
                //if (sharedResourcesCount != 0) return "Too many shared resources: " + sharedResourcesCount;
                //if (Read7BitEncodedInt(br) != 1) return "???";
                //// WAVE format
                //uint formatChunkSize = br.ReadUInt32();
                //if (formatChunkSize != 18) return "Wrong format chunk size: " + formatChunkSize;
                //if ((wFormatTag = br.ReadUInt16()) != 1) return "Unimplemented wav codec (must be PCM)";
                //nChannels = br.ReadUInt16();
                //nSamplesPerSec = br.ReadUInt32();
                //nAvgBytesPerSec = br.ReadUInt32();
                //nBlockAlign = br.ReadUInt16();
                //wBitsPerSample = br.ReadUInt16();
                //if (nAvgBytesPerSec != (nSamplesPerSec * nChannels * (wBitsPerSample / 8))) return "Average bytes per second number incorrect";
                //if (nBlockAlign != (nChannels * (wBitsPerSample / 8))) return "Block align number incorrect";
                //br.ReadUInt16();
                //waveData = br.ReadBytes(dataChunkSize = br.ReadInt32());

                //string format = new string(br.ReadChars(3));
                //if (format != "XNB") return "Invalid file format: " + format;
                //char platform = br.ReadChar();
                //if (platform != 'w') return "Invalid platform: " + platform;
                //int xnaVersion = br.ReadByte();
                //if (xnaVersion != 5) return "Unimplemented XNA version: " + xnaVersion;
                //byte profile = br.ReadByte();
                //if (profile != 0) return "Unimplemented profile: " + profile;
                //uint fileLength = br.ReadUInt32();
                //if (fileLength != fs.Length) return "File length mismatch: " + fileLength + " - should be " + fs.Length;
                //uint typeCount = (uint)Read7BitEncodedInt(br);
                //if (typeCount != 1) return "Too many types: " + typeCount;
                //// Should be in a for loop but I'm too lazy to add support for multiple types.
                //string type = br.ReadString();
                //if (type != "Microsoft.Xna.Framework.Content.SoundEffectReader") return "Wrong type reader name: " + type;
                //int typeReaderVersion = br.ReadInt32();
                //if (typeReaderVersion != 0) return "Wrong type reader version: " + typeReaderVersion;
                //uint sharedResourcesCount = (uint)Read7BitEncodedInt(br);
                //if (sharedResourcesCount != 0) return "Too many shared resources: " + sharedResourcesCount;
                //if (Read7BitEncodedInt(br) != 1) return "???";
                //// WAVE format
                //uint formatChunkSize = br.ReadUInt32();
                //if (formatChunkSize != 18) return "Wrong format chunk size: " + formatChunkSize;
                //if ((wFormatTag = br.ReadUInt16()) != 1) return "Unimplemented wav codec (must be PCM)";
                //nChannels = br.ReadUInt16();
                //nSamplesPerSec = br.ReadUInt32();
                //nAvgBytesPerSec = br.ReadUInt32();
                //nBlockAlign = br.ReadUInt16();
                //wBitsPerSample = br.ReadUInt16();
                //if (nAvgBytesPerSec != (nSamplesPerSec * nChannels * (wBitsPerSample / 8))) return "Average bytes per second number incorrect";
                //if (nBlockAlign != (nChannels * (wBitsPerSample / 8))) return "Block align number incorrect";
                //br.ReadUInt16();
                //waveData = br.ReadBytes(dataChunkSize = br.ReadInt32());

                //Console.WriteLine("A?? " + br.ReadInt32());
                //Console.WriteLine("B?? " + br.ReadInt32());
                //Console.WriteLine("C?? " + br.ReadInt32());
                //Console.WriteLine("nSamplesPerSec " + nSamplesPerSec);
                //Console.WriteLine("nBlockAlign " + nBlockAlign);
                //Console.WriteLine("wBitsPerSample " + wBitsPerSample);
                //Console.WriteLine("nChannels " + nChannels);
                //Console.WriteLine("dataChunkSize " + dataChunkSize);
            }
        }

        using (Stream fs = File.Create(xnbFile))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                //bw.Write("RIFF".ToCharArray());
                //bw.Write(dataChunkSize + 36);
                //bw.Write("WAVE".ToCharArray());
                //bw.Write("fmt ".ToCharArray());
                //bw.Write(16);
                //bw.Write(wFormatTag);
                //bw.Write(nChannels);
                //bw.Write(nSamplesPerSec);
                //bw.Write(nAvgBytesPerSec);
                //bw.Write(nBlockAlign);
                //bw.Write(wBitsPerSample);
                //bw.Write("data".ToCharArray());
                //bw.Write(dataChunkSize);
                //bw.Write(waveData);

                // Format identifier
                bw.Write("XNB".ToCharArray());
                // TargetPlatform Windows
                bw.Write("w".ToCharArray());
                // XNB format version
                bw.Write((byte)5);
                // Flag bits: 
                bw.Write((byte)0);
                // File Size TODO
                bw.Write(dataChunkSize + 105); //??  61?
                // Type Reader count
                Write7BitEncodedInt(bw, 1);
                // bw.Write((byte)1);
                // String reader name
                bw.Write("Microsoft.Xna.Framework.Content.SoundEffectReader");
                // reader version number
                bw.Write(0);
                // shared Resource Count
                bw.Write((byte)0);
                // Object Primary asset data....?
                {
                    bw.Write((byte)1);
                    // Format size
                    bw.Write(18);
                    // Format
                    {
                        // WORD wFormatTag;
                        bw.Write((ushort)wFormatTag);
                        //     ushort wFormatTag;
                        // WORD nChannels;
                        // ushort nChannels;
                        bw.Write((ushort)nChannels);
                        // DWORD nSamplesPerSec;
                        // uint nSamplesPerSec;
                        bw.Write((uint)nSamplesPerSec);
                        //  DWORD nAvgBytesPerSec;
                        //  uint nAvgBytesPerSec;
                        bw.Write((uint)nAvgBytesPerSec);
                        // WORD nBlockAlign;
                        //  ushort nBlockAlign;
                        bw.Write((ushort)nBlockAlign);
                        //  WORD wBitsPerSample;
                        //  ushort wBitsPerSample;
                        bw.Write((ushort)wBitsPerSample);
                        // WORD cbSize;
                        bw.Write((ushort)0);
                    }
                    // Uint32 Data Size
                    bw.Write(dataChunkSize);
                    // Byte[data size] data
                    bw.Write(waveData);

                    // int32 loop start
                    bw.Write(0);
                    // int32 loop length
                    bw.Write(dataChunkSize / nBlockAlign);
                    // Console.WriteLine("Loop?? " + 1);

                    // int32 duration
                    bw.Write((int)(1000 * dataChunkSize / (nChannels * wBitsPerSample * nSamplesPerSec / 8)));
                }
            }
        }
        return "Successfully converted " + Path.GetFileNameWithoutExtension(wavFile);
    }

    static int Read7BitEncodedInt(BinaryReader br)
    {
        int num = 0;
        int num2 = 0;
        while (num2 != 35)
        {
            byte b = br.ReadByte();
            num |= (int)(b & 127) << num2;
            num2 += 7;
            if ((b & 128) == 0)
            {
                return num;
            }
        }
        throw new FormatException("Failed to read a Microsoft 7-bit encoded integer");
    }

    static void Write7BitEncodedInt(BinaryWriter bw, int value)
    {
        // Write out an int 7 bits at a time. The high bit of the byte,
        // when on, tells reader to continue reading more bytes.
        uint v = (uint)value; // support negative numbers
        while (v >= 0x80)
        {
            bw.Write((byte)(v | 0x80));
            v >>= 7;
        }
        bw.Write((byte)v);
    }

}