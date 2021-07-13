using System;
public class ArrayScanner
{

    public static string[] Tiles(string[] chunkarray, int layer, int centerinarray, bool fortilerules)
    {
        string[] bleh = null;
        /*
        string chunkarrayname = chunkarray[256];
        string Biomeoords = chunkarrayname.Substring(5);
        string[] bcoords = Biomeoords.Split(',');
        string[] throwaway = bcoords[1].Split('c');
        int biomex = Convert.ToInt32(bcoords[0].Substring(1));
        int biomey = Convert.ToInt32(throwaway[0].Substring(1));
        int chunknum = Convert.ToInt32(throwaway[1]);
        string tl = null;
        string t = null;
        string tr = null;
        string l = null;
        string c = chunkarray[centerinarray];
        string r = null;
        string bl = null;
        string b = null;
        string br = null;

        string[] surrounding = null;
        int layernum = layer * 256;

        if (layer > 0)
        {
            layernum++;
        }

        if (centerinarray>=16+layernum&&centerinarray<=239+layernum)
        {
            bool leftside = false;
            bool rightside = false;
            for (int x = 16; x<=224;x+=16)
            {
                if (x+layernum==centerinarray)
                {
                    leftside = true;
                    break;
                }
            }
            for (int x = 31; x <= 239; x += 16)
            {
                if (x + layernum == centerinarray)
                {
                    rightside = true;
                    break;
                }
            }
            if (leftside)
            {
                t = chunkarray[centerinarray - 16];
                tr = chunkarray[centerinarray - 15];
                r = chunkarray[centerinarray + 1];
                b = chunkarray[centerinarray + 16];
                br = chunkarray[centerinarray + 17];
                if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
                {
                    tl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[centerinarray - 1];
                    l = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[centerinarray + 15];
                    bl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[centerinarray + 31];
                }
                if (chunknum == 2 || chunknum == 3 || chunknum == 4 || chunknum == 6 ||
                    chunknum == 7 || chunknum == 8 || chunknum == 10 || chunknum == 11 ||
                    chunknum == 12 || chunknum == 14 || chunknum == 15 || chunknum == 16)
                {
                    tl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[centerinarray - 1];
                    l = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[centerinarray + 15];
                    bl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[centerinarray + 31];
                }
            }
            else if (rightside)
            {
                t = chunkarray[centerinarray - 16];
                tl = chunkarray[centerinarray - 17];
                l = chunkarray[centerinarray - 1];
                bl = chunkarray[centerinarray + 15];
                b = chunkarray[centerinarray + 16];
                if (chunknum == 1 || chunknum == 2 || chunknum == 3 ||
                    chunknum == 5 || chunknum == 6 || chunknum == 7 ||
                    chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                    chunknum == 13 || chunknum == 14 || chunknum == 15)
                {
                    r = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[centerinarray - 15];
                    br = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[centerinarray + 1];
                    tr = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[centerinarray - 31];
                }
                if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
                {
                    r = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[centerinarray - 15];
                    br = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[centerinarray + 1];
                    tr = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[centerinarray - 31];
                }
            }
            else
            {
                tl = chunkarray[centerinarray - 17];
                t = chunkarray[centerinarray - 16];
                tr = chunkarray[centerinarray - 15];
                l = chunkarray[centerinarray - 1];
                r = chunkarray[centerinarray + 1];
                bl = chunkarray[centerinarray + 15];
                b = chunkarray[centerinarray + 16];
                br = chunkarray[centerinarray + 17];
            }
        }
        else if (centerinarray >= 1 + layernum && centerinarray <= 14 + layernum)
        {
            l = chunkarray[centerinarray - 1];
            r = chunkarray[centerinarray + 1];
            bl = chunkarray[centerinarray + 15];
            b = chunkarray[centerinarray + 16];
            br = chunkarray[centerinarray + 17];
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[centerinarray + 240];
                tl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[centerinarray + 239];
                tr = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[centerinarray + 241];

            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)

            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[centerinarray + 240];
                tl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[centerinarray + 239];
                tr = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[centerinarray + 241];
            }
        }
        else if (centerinarray >= 241 + layernum && centerinarray <= 254 + layernum)
        {
            t = chunkarray[centerinarray - 16];
            l = chunkarray[centerinarray - 1];
            tl = chunkarray[centerinarray - 17];
            r = chunkarray[centerinarray + 1];
            tr = chunkarray[centerinarray - 15];
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 ||
                chunknum == 4 || chunknum == 5 || chunknum == 6 ||
                chunknum == 7 || chunknum == 8 || chunknum == 9 ||
                chunknum == 10 || chunknum == 11 || chunknum == 12)
            {
                bl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[centerinarray - 241];
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[centerinarray - 240];
                br = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[centerinarray - 239];
            }
            if (chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[centerinarray - 240];
                bl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[centerinarray - 241];
                br = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[centerinarray - 239];
            }
        }
        else if (centerinarray == 0 + layernum)
        {
            br = chunkarray[centerinarray + 17];
            b = chunkarray[centerinarray + 16];
            r = chunkarray[centerinarray + 1];

            if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
            {
                if (chunknum != 1)
                {
                    tl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum - 1))[255 + layernum];
                }
                else
                {
                    tl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + (biomey + 1), "CTiles" + 16)[255 + layernum];
                }
                l = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[centerinarray + 15];
                bl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[centerinarray + 31];
            }
            if (chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (chunknum == 2 || chunknum == 3 || chunknum == 4)
                {
                    tl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 11))[255 + layernum];
                }
                else
                {
                    tl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 5))[255 + layernum];
                }
                l = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[centerinarray + 16];
                bl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[centerinarray + 31];
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[240 + layernum];
                tr = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[241 + layernum];
            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[240 + layernum];
                tr = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[241 + layernum];
            }
        }
        else if (centerinarray == 15 + layernum)
        {
            l = chunkarray[centerinarray - 1];
            bl = chunkarray[centerinarray + 15];
            b = chunkarray[centerinarray + 16];
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 5 || chunknum == 6 ||
                chunknum == 7 || chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15)
            {
                if (chunknum == 1 || chunknum == 2 || chunknum == 3)
                {
                    tr = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 13))[240 + layernum];
                }
                else
                {
                    tr = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 3))[240 + layernum];
                }
                r = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[0 + layernum];
                br = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[16 + layernum];
            }
            if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
            {
                if (chunknum == 4)
                {
                    tr = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + (biomey + 1), "CTiles" + 13)[240 + layernum];
                }
                else
                {
                    tr = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 7))[240 + layernum];
                }
                r = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[0 + layernum];
                br = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[16 + layernum];
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[255 + layernum];
                tl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12))[254 + layernum];
            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                t = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[255 + layernum];
                tl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4))[254 + layernum];
            }
        }
        else if (centerinarray == 240 + layernum)
        {
            r = chunkarray[centerinarray + 1];
            t = chunkarray[centerinarray - 16];
            tr = chunkarray[centerinarray - 15];

            if (chunknum == 2 || chunknum == 3 || chunknum == 4 || chunknum == 6 ||
                chunknum == 7 || chunknum == 8 || chunknum == 10 || chunknum == 11 ||
                chunknum == 12 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                tl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[239 + layernum];
                l = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1))[255 + layernum];
                if (chunknum != 16 && chunknum != 15 && chunknum != 14)
                {
                    bl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 3))[15 + layernum];
                }
            }
            if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
            {
                if (chunknum == 13)
                {
                    bl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + (biomey - 1), "CTiles" + 4)[15 + layernum];
                }
                else
                {
                    bl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 7))[15 + layernum];
                }
                tl = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[239 + layernum];
                l = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3))[255 + layernum];
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12)
            {
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[0 + layernum];
                br = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[1 + layernum];
            }
            if (chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (chunknum != 13)
                {
                    bl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 13))[15 + layernum];
                }
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[0 + layernum];
                br = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[1 + layernum];
            }
        }
        else if (centerinarray == 255 + layernum)
        {
            t = chunkarray[239 + layernum];
            l = chunkarray[254 + layernum];
            tl = chunkarray[238 + layernum];
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15)
            {
                tr = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[224];
                r = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1))[240];
                if (chunknum == 13 || chunknum == 14 || chunknum == 15)
                {
                    br = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 11))[0 + layernum];
                }
                else
                {
                    br = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 5))[0 + layernum];
                }
            }
            if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
            {
                if (chunknum == 16)
                {
                    br = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + (biomey - 1), "CTiles" + 1)[0 + layernum];
                }
                else
                {
                    br = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum + 1))[0 + layernum];
                }
                tr = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[224 + layernum];
                r = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3))[240 + layernum];
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12)
            {
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[15 + layernum];
                bl = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4))[14 + layernum];
            }
            if (chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                b = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[15 + layernum];
                bl = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12))[14 + layernum];
            }
        }
        surrounding = new string[8] { tl, t, tr, l, r, bl, b, br };
        if (fortilerules)
        {
            surrounding = new string[9] { tl, t, tr, l, c, r, bl, b, br };
        }
        return surrounding;
    }














    public static string[] ChangeTileRelativeTo(string biometobuild, string[] chunkarray, int layer, int centerinarray, string direction, string newvalue)    //takes a tile in a
                                                                                                                                                          //chunk array as an argument and can modify any chunk adjacent to it with new value

    {
        string chunkarrayname = chunkarray[256];
        string Biomeoords = chunkarrayname.Substring(5);
        string[] bcoords = Biomeoords.Split(',');
        string[] throwaway = bcoords[1].Split('c');
        int biomex = Convert.ToInt32(bcoords[0].Substring(1));
        int biomey = Convert.ToInt32(throwaway[0].Substring(1));
        int chunknum = Convert.ToInt32(throwaway[1]);
        string[] writingchunk = null;
        int layernum = layer * 256;
        if (layernum > 0)
        {
            layernum++;
        }


        if (centerinarray >= 16 && centerinarray <= 239) {
            bool leftside = false;
            bool rightside = false;
            for (int x = 16; x <= 224; x += 16)
            {
                if (x + layernum == centerinarray)
                {
                    leftside = true;
                    break;
                }
            }
            for (int x = 31; x <= 239; x += 16)
            {
                if (x + layernum == centerinarray)
                {
                    rightside = true;
                    break;
                }
            }
            if (leftside)
            {
                if (direction == "t")
                {
                    chunkarray[centerinarray - 16] = newvalue;
                }
                if (direction == "tr")
                {
                    chunkarray[centerinarray - 15] = newvalue;
                }
                if (direction == "r")
                {
                    chunkarray[centerinarray + 1] = newvalue;
                }
                if (direction == "b")
                {
                    chunkarray[centerinarray + 16] = newvalue;
                }
                if (direction == "br")
                {
                    chunkarray[centerinarray + 17] = newvalue;
                }
                if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                        writingchunk[centerinarray - 1] = newvalue;
                    }
                    if (direction == "l")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                        writingchunk[centerinarray + 15] = newvalue;
                    }
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                        writingchunk[centerinarray + 31] = newvalue;
                    }
                }
                if (chunknum == 2 || chunknum == 3 || chunknum == 4 || chunknum == 6 ||
                    chunknum == 7 || chunknum == 8 || chunknum == 10 || chunknum == 11 ||
                    chunknum == 12 || chunknum == 14 || chunknum == 15 || chunknum == 16)
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                        writingchunk[centerinarray - 1] = newvalue;
                    }
                    if (direction == "l")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                        writingchunk[centerinarray + 15] = newvalue;
                    }
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                        writingchunk[centerinarray + 31] = newvalue;
                    }
                }
            }
            else if (rightside)
            {
                if (direction == "t")
                {
                    chunkarray[centerinarray - 16] = newvalue;
                }
                if (direction == "tl")
                {
                    chunkarray[centerinarray - 17] = newvalue;
                }
                if (direction == "l")
                {
                    chunkarray[centerinarray - 1] = newvalue;
                }
                if (direction == "bl")
                {
                    chunkarray[centerinarray + 15] = newvalue;
                }
                if (direction == "b")
                {
                    chunkarray[centerinarray + 16] = newvalue;
                }
                if (chunknum == 1 || chunknum == 2 || chunknum == 3 ||
                    chunknum == 5 || chunknum == 6 || chunknum == 7 ||
                    chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                    chunknum == 13 || chunknum == 14 || chunknum == 15)
                {
                    if (direction == "r")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                        writingchunk[centerinarray - 15] = newvalue;
                    }
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                        writingchunk[centerinarray + 1] = newvalue;
                    }
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                        writingchunk[centerinarray - 31] = newvalue;
                    }
                }
                if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
                {
                    if (direction == "r")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                        writingchunk[centerinarray - 15] = newvalue;
                    }
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                        writingchunk[centerinarray + 1] = newvalue;
                    }
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                        writingchunk[centerinarray - 31] = newvalue;
                    }
                }
            }
            else
            {
                if (direction == "tl")
                {
                    chunkarray[centerinarray - 17] = newvalue;
                }
                if (direction == "t")
                {
                    chunkarray[centerinarray - 16] = newvalue;
                }
                if (direction == "tr")
                {
                    chunkarray[centerinarray - 15] = newvalue;
                }
                if (direction == "l")
                {
                    chunkarray[centerinarray - 1] = newvalue;
                }
                if (direction == "r")
                {
                    chunkarray[centerinarray + 1] = newvalue;
                }
                if (direction == "bl")
                {
                    chunkarray[centerinarray + 15] = newvalue;
                }
                if (direction == "b")
                {
                    chunkarray[centerinarray + 16] = newvalue;
                }
                if (direction == "br")
                {
                    chunkarray[centerinarray + 17] = newvalue;
                }
            }


        }
        else if (centerinarray == 0 + layernum)
        {
            if (direction == "br")
            {
                chunkarray[centerinarray + 17] = newvalue;
            }
            if (direction == "b")
            {
                chunkarray[centerinarray + 16] = newvalue;
            }
            if (direction == "r")
            {
                chunkarray[centerinarray + 1] = newvalue;
            }

            if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
            {
                if (chunknum != 1)
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum - 1));
                        writingchunk[255 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + (biomey + 1), "CTiles" + 16);
                        writingchunk[255 + layernum] = newvalue;
                    }
                }
                if (direction == "l")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                    writingchunk[centerinarray + 15] = newvalue;
                }
                if (direction == "bl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                    writingchunk[centerinarray + 31] = newvalue;
                }
            }
            if (chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (chunknum == 2 || chunknum == 3 || chunknum == 4)
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 11));
                        writingchunk[255 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "tl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 5));
                        writingchunk[255 + layernum] = newvalue;
                    }
                }
                if (direction == "l")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                    writingchunk[centerinarray + 16] = newvalue;
                }
                if (direction == "bl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                    writingchunk[centerinarray + 31] = newvalue;
                }
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[240 + layernum] = newvalue;
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[241 + layernum] = newvalue;
                }
            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {

                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[240 + layernum] = newvalue;
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[241 + layernum] = newvalue;
                }
            }
        }
        else if (centerinarray == 15 + layernum)
        {
            if (direction == "l")
            {
                chunkarray[centerinarray - 1] = newvalue;
            }
            if (direction == "bl")
            {
                chunkarray[centerinarray + 15] = newvalue;
            }
            if (direction == "b")
            {
                chunkarray[centerinarray + 16] = newvalue;
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 5 || chunknum == 6 ||
                chunknum == 7 || chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15)
            {
                if (chunknum == 1 || chunknum == 2 || chunknum == 3)
                {
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 13));
                        writingchunk[240 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 3));
                        writingchunk[240 + layernum] = newvalue;
                    }
                }
                if (direction == "r")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                    writingchunk[0 + layernum] = newvalue;
                }
                if (direction == "br")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                    writingchunk[16 + layernum] = newvalue;
                }
            }
            if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
            {
                if (chunknum == 4)
                {
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + (biomey + 1), "CTiles" + 13);
                        writingchunk[240 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "tr")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 7));
                        writingchunk[240 + layernum] = newvalue;
                    }
                }
                if (direction == "r")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                    writingchunk[0 + layernum] = newvalue;
                }
                if (direction == "br")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                    writingchunk[16 + layernum] = newvalue;
                }
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[255 + layernum] = newvalue;
                }
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[254 + layernum] = newvalue;
                }
            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[255 + layernum] = newvalue;
                }
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[254 + layernum] = newvalue;
                }
            }
        }
        else if (centerinarray == 240 + layernum)
        {
            if (direction == "r")
            {
                chunkarray[centerinarray + 1] = newvalue;
            }
            if (direction == "t")
            {
                chunkarray[centerinarray - 16] = newvalue;
            }
            if (direction == "tr")
            {
                chunkarray[centerinarray - 15] = newvalue;
            }

            if (chunknum == 2 || chunknum == 3 || chunknum == 4 || chunknum == 6 ||
                chunknum == 7 || chunknum == 8 || chunknum == 10 || chunknum == 11 ||
                chunknum == 12 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                    writingchunk[239 + layernum] = newvalue;
                }
                if (direction == "l")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 1));
                    writingchunk[255 + layernum] = newvalue;
                }
                if (chunknum != 16 && chunknum != 15 && chunknum != 14)
                {
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 3));
                        writingchunk[15 + layernum] = newvalue;
                    }
                }
            }
            if (chunknum == 1 || chunknum == 5 || chunknum == 9 || chunknum == 13)
            {
                if (chunknum == 13)
                {
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + (biomey - 1), "CTiles" + 4);
                        writingchunk[15 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 7));
                        writingchunk[15 + layernum] = newvalue;
                    }
                }
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                    writingchunk[239 + layernum] = newvalue;
                }
                if (direction == "l")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex - 1) + ",Y" + biomey, "CTiles" + (chunknum + 3));
                    writingchunk[255 + layernum] = newvalue;
                }
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12)
            {
                if (direction == "b")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4));
                    writingchunk[0 + layernum] = newvalue;
                }
                if (direction == "br")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4));
                    writingchunk[1 + layernum] = newvalue;
                }
            }
            if (chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (chunknum != 13)
                {
                    if (direction == "bl")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 13));
                        writingchunk[15 + layernum] = newvalue;
                    }
                }
                if (direction == "b")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12));
                    writingchunk[0 + layernum] = newvalue;
                }
                if (direction == "br")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12));
                    writingchunk[1 + layernum] = newvalue;
                }
            }
        }
        else if (centerinarray == (255 + layernum))
        {
            if (direction == "t")
            {
                chunkarray[239 + layernum] = newvalue;
            }
            if (direction == "l")
            {
                chunkarray[254 + layernum] = newvalue;
            }
            if (direction == "tl")
            {
                chunkarray[238 + layernum] = newvalue;
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15)
            {
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                    writingchunk[224 + layernum] = newvalue;
                }
                if (direction == "r")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 1));
                    writingchunk[240 + layernum] = newvalue;
                }
                if (chunknum == 13 || chunknum == 14 || chunknum == 15)
                {
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 11));
                        writingchunk[0 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 5));
                        writingchunk[0 + layernum] = newvalue;
                    }
                }
            }
            if (chunknum == 4 || chunknum == 8 || chunknum == 12 || chunknum == 16)
            {
                if (chunknum == 16)
                {
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + (biomey - 1), "CTiles" + 1);
                        writingchunk[0 + layernum] = newvalue;
                    }
                }
                else
                {
                    if (direction == "br")
                    {
                        writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum + 1));
                        writingchunk[0 + layernum] = newvalue;
                    }
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                    writingchunk[224 + layernum] = newvalue;
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + (biomex + 1) + ",Y" + biomey, "CTiles" + (chunknum - 3));
                    writingchunk[240 + layernum] = newvalue;
                }
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4 ||
                chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12)
            {
                if (direction == "b")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4));
                    writingchunk[15 + layernum] = newvalue;
                }
                if (direction == "bl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum + 4));
                    writingchunk[14 + layernum] = newvalue;
                }
            }
            if (chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)
            {
                if (direction == "b")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12));
                    writingchunk[15 + layernum] = newvalue;
                }
                if (direction == "bl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey - 1), "CTiles" + (chunknum - 12));
                    writingchunk[14 + layernum] = newvalue;
                }
            }
        }
        else if (centerinarray >= 1 + layernum && centerinarray <= 14+layernum)
        {
            if (direction == "l")
            {
                chunkarray[centerinarray - 1] = newvalue;
            }
            if (direction == "r")
            {
                chunkarray[centerinarray + 1] = newvalue;
            }
            if (direction == "bl")
            {
                chunkarray[centerinarray + 15] = newvalue;
            }
            if (direction == "b")
            {
                chunkarray[centerinarray + 16] = newvalue;
            }
            if (direction == "br")
            {
                chunkarray[centerinarray + 17] = newvalue;
            }
            if (chunknum == 1 || chunknum == 2 || chunknum == 3 || chunknum == 4)
            {
                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[centerinarray + 240] = newvalue;
                }
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[centerinarray + 239] = newvalue;
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + (biomey + 1), "CTiles" + (chunknum + 12));
                    writingchunk[centerinarray + 241] = newvalue;
                }

            }
            if (chunknum == 5 || chunknum == 6 || chunknum == 7 || chunknum == 8 ||
                chunknum == 9 || chunknum == 10 || chunknum == 11 || chunknum == 12 ||
                chunknum == 13 || chunknum == 14 || chunknum == 15 || chunknum == 16)

            {
                if (direction == "t")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[centerinarray + 240] = newvalue;
                }
                if (direction == "tl")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[centerinarray + 239] = newvalue;
                }
                if (direction == "tr")
                {
                    writingchunk = BData.ReadBData("BiomeX" + biomex + ",Y" + biomey, "CTiles" + (chunknum - 4));
                    writingchunk[centerinarray + 239] = newvalue;
                }
            }
        }
        else if (centerinarray >= 241 + layernum && centerinarray <= 254 + layernum)




        chunkarrayname = writingchunk[256];
        Biomeoords = chunkarrayname.Substring(5);
        bcoords = Biomeoords.Split(',');
        throwaway = bcoords[1].Split('c');
        biomex = Convert.ToInt32(bcoords[0].Substring(1));
        biomey = Convert.ToInt32(throwaway[0].Substring(1));
        chunknum = Convert.ToInt32(throwaway[1]);

        BData.WriteBData("BiomeX"+biomex+",Y"+biomey, "CTiles" + chunknum, writingchunk, null);
        return chunkarray;
        */
        return bleh;
    }


}