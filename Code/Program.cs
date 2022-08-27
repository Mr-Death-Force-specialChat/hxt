using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace hxt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Please specifiy a file in a0 it can be '-h' for help");
                return;
            }
            string fn = args[0];
            bool io = true;
            string mfn = fn + ".hd";
            if (fn == "-h")
            {
                Console.WriteLine("a0 fileName [required]: tell the internal stuff what is the file\na1 mode [optional]: tell the internal stuff to write to a .hd file\na2 modeFile [optional]: where to output the file contents as hex");
                return;
            }
            if (args.Length >= 2)
            {
                string a = args[1];
                if (a == "1")
                    io = false;
                else if (a == "0")
                    io = true;
            }
            if (args.Length >= 3)
            {
                mfn = args[2];
            }
            Program p = new Program();
            p.main(fn, io, mfn);
        }
        void main(string fn, bool io, string mfn)
        {
            long offset = 0;
            string masterOut = "";
            if (!io)
            {
                FileStream fs = new FileStream(fn, FileMode.OpenOrCreate);
                BinaryReader br = new BinaryReader(fs);
                FileStream wfs = new FileStream(mfn, FileMode.OpenOrCreate);
                StreamWriter bw = new StreamWriter(wfs);
                while (true)
                {
                    byte[] chunk = new byte[0];
                    try
                    {
                        chunk = br.ReadBytes(16);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    if (chunk.Length == 0)
                    {
                        break;
                    }
                    string text = "";
                    foreach (byte b in chunk)
                    {
                        text += ByteToString(b) + " ";
                    }
                    int idx = 0;
                    string bats = ByteArrayToString(chunk);
                    bats = StripUnicodeCharactersFromString(bats);
                    foreach (char chr in text)
                    {
                        if (!isPrint(chr))
                        {
                            try
                            {
                                bats = bats.Remove(idx, idx);
                            }
                            catch (Exception)
                            {

                            }
                        }
                        idx++;
                    }
                    bats = bats.Replace("\n", ".");
                    bats = bats.Replace("\r", ".");
                    bats = bats.Replace("\b", ".");
                    bats = bats.Replace("\t", ".");
                    bats = bats.Replace(0.ToString(), ".");
                    bats = bats.Replace(1.ToString(), ".");
                    bats = bats.Replace(2.ToString(), ".");
                    bats = bats.Replace(3.ToString(), ".");
                    bats = bats.Replace(4.ToString(), ".");
                    bats = bats.Replace(5.ToString(), ".");
                    bats = bats.Replace(6.ToString(), ".");
                    bats = bats.Replace(7.ToString(), ".");
                    bats = bats.Replace(8.ToString(), ".");
                    bats = bats.Replace(9.ToString(), ".");
                    bats = bats.Replace(10.ToString(), ".");
                    bats = bats.Replace(11.ToString(), ".");
                    bats = bats.Replace(12.ToString(), ".");
                    bats = bats.Replace(13.ToString(), ".");
                    bats = bats.Replace(14.ToString(), ".");
                    bats = bats.Replace(15.ToString(), ".");
                    bats = bats.Replace(16.ToString(), ".");
                    bats = bats.Replace(17.ToString(), ".");
                    bats = bats.Replace(18.ToString(), ".");
                    bats = bats.Replace(19.ToString(), ".");
                    bats = bats.Replace(20.ToString(), ".");
                    bats = bats.Replace(21.ToString(), ".");
                    bats = bats.Replace(22.ToString(), ".");
                    bats = bats.Replace(23.ToString(), ".");
                    bats = bats.Replace(24.ToString(), ".");
                    bats = bats.Replace(25.ToString(), ".");
                    bats = bats.Replace(26.ToString(), ".");
                    bats = bats.Replace(27.ToString(), ".");
                    bats = bats.Replace(28.ToString(), ".");
                    bats = bats.Replace(29.ToString(), ".");
                    bats = bats.Replace(30.ToString(), ".");
                    bats = bats.Replace(31.ToString(), ".");
                    bats = bats.Replace(172.ToString(), ".");
                    bats = bats.Replace(0x070D0A.ToString(), ".");
                    text = add(text);
                    text += bats;
                    string output = LongToString(offset) + ": ";
                    output += text;
                    masterOut += output + "\n";
                    Console.WriteLine(output);
                    offset+=16;
                }
                bw.Write(masterOut);
                bw.Flush();
                bw.Close();
                bw.Dispose();
                br.Close();
                br.Dispose();
            }
            else
            {
                FileStream fs = new FileStream(fn, FileMode.OpenOrCreate);
                BinaryReader br = new BinaryReader(fs);
                while (true)
                {
                    byte[] chunk = new byte[0];
                    try
                    {
                        chunk = br.ReadBytes(16);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    if (chunk.Length == 0)
                    {
                        break;
                    }
                    string text = "";
                    foreach (byte b in chunk)
                    {
                        text += ByteToString(b) + " ";
                    }
                    int idx = 0;
                    string bats = ByteArrayToString(chunk);
                    bats = StripUnicodeCharactersFromString(bats);
                    foreach (char chr in text)
                    {
                        if (!isPrint(chr))
                        {
                            try
                            {
                                bats = bats.Remove(idx, idx);
                            }
                            catch (Exception)
                            {

                            }
                        }
                        idx++;
                    }
                    bats = bats.Replace("\n", ".");
                    bats = bats.Replace("\r", ".");
                    bats = bats.Replace("\b", ".");
                    bats = bats.Replace("\t", ".");
                    bats = bats.Replace(0.ToString(), ".");
                    bats = bats.Replace(1.ToString(), ".");
                    bats = bats.Replace(2.ToString(), ".");
                    bats = bats.Replace(3.ToString(), ".");
                    bats = bats.Replace(4.ToString(), ".");
                    bats = bats.Replace(5.ToString(), ".");
                    bats = bats.Replace(6.ToString(), ".");
                    bats = bats.Replace(7.ToString(), ".");
                    bats = bats.Replace(8.ToString(), ".");
                    bats = bats.Replace(9.ToString(), ".");
                    bats = bats.Replace(10.ToString(), ".");
                    bats = bats.Replace(11.ToString(), ".");
                    bats = bats.Replace(12.ToString(), ".");
                    bats = bats.Replace(13.ToString(), ".");
                    bats = bats.Replace(14.ToString(), ".");
                    bats = bats.Replace(15.ToString(), ".");
                    bats = bats.Replace(16.ToString(), ".");
                    bats = bats.Replace(17.ToString(), ".");
                    bats = bats.Replace(18.ToString(), ".");
                    bats = bats.Replace(19.ToString(), ".");
                    bats = bats.Replace(20.ToString(), ".");
                    bats = bats.Replace(21.ToString(), ".");
                    bats = bats.Replace(22.ToString(), ".");
                    bats = bats.Replace(23.ToString(), ".");
                    bats = bats.Replace(24.ToString(), ".");
                    bats = bats.Replace(25.ToString(), ".");
                    bats = bats.Replace(26.ToString(), ".");
                    bats = bats.Replace(27.ToString(), ".");
                    bats = bats.Replace(28.ToString(), ".");
                    bats = bats.Replace(29.ToString(), ".");
                    bats = bats.Replace(30.ToString(), ".");
                    bats = bats.Replace(31.ToString(), ".");
                    bats = bats.Replace(172.ToString(), ".");
                    bats = bats.Replace(0x070D0A.ToString(), ".");
                    text = add(text);
                    text += bats;
                    string output = LongToString(offset) + ": ";
                    output += text;
                    Console.WriteLine(output);
                    offset += 16;
                }
                br.Close();
                br.Dispose();
            }
        }
        string ByteToString(byte b)
        {
            StringBuilder hex = new StringBuilder(2);
            hex.AppendFormat("{0:X2}", b);
            return hex.ToString();
        }
        string ByteArrayToString(byte[] ba)
        {
            string s = "";
            foreach (byte b in ba)
            {
                s += (char)b;
            }
            return s;
        }
        string LongToString(long l)
        {
            StringBuilder hex = new StringBuilder(8);
            hex.AppendFormat("{0:x8}", l);
            return hex.ToString();
        }
        string StripUnicodeCharactersFromString(string inputValue)
        {
            return Regex.Replace(inputValue, @"[^\u0000-\u007F]", ".");
        }
        bool isPrint(char chr)
        {
            UnicodeCategory[] nrc = new UnicodeCategory[] {
                        UnicodeCategory.Control,
                        UnicodeCategory.OtherNotAssigned,
                        UnicodeCategory.Surrogate };

            var isPrintable = Char.IsWhiteSpace(chr) ||
            !UniCatContains(Char.GetUnicodeCategory(chr), nrc);
            return isPrintable;
        }
        bool UniCatContains(UnicodeCategory cat, UnicodeCategory[] catl)
        {
            foreach (var catg in catl)
            {
                if (cat == catg)
                    return true;
            }
            return false;
        }
        string add(string v)
        {
            string r = v;
            string w = "                                                          ";
            while (r.Length < w.Length)
            {
                r += " ";
            }
            return r;
        }
    }
}
