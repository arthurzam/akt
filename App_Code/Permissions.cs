public class Permissions
{
    /// <remarks>
    /// flag 0 - menashe editted
    /// flag 1 - efraim editted
    /// flag 2 - binyamin editted
    /// flag 3 - jerusalem editted
    /// flag 4 - yehuda editted
    /// flags 5-7 - for future need
    /// </remarks>
    private bool[] list = new bool[8];

    public Permissions(int permission)
    {
        list = ByteToBit((byte)permission);
    }

    public Permissions(bool[] list)
    {
        int i = 0;
        for (; i < System.Math.Min(list.Length, 8); i++)
            this.list[i] = list[i];
        for (; i < 8; i++)
            this.list[i] = false;
    }

    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="permission">format of 8 digits of 0 or 1</param>
    public Permissions(string permission)
    {
        for (int i = 0; i < 8; i++)
            list[i] = (permission[i] == '1' ? true : false);
    }

    /// <summary>
    /// convert a byte to 8 bit (bool) array
    /// </summary>
    /// <param name="b">the from byte</param>
    /// <returns>the 8 bit array</returns>
    private static bool[] ByteToBit(byte b)
    {
        bool[] result = { false, false, false, false, false, false, false, false };
        if (b >= 128) { b -= 128; result[7] = true; }
        if (b >= 64) { b -= 64; result[6] = true; }
        if (b >= 32) { b -= 32; result[5] = true; }
        if (b >= 16) { b -= 16; result[4] = true; }
        if (b >= 8) { b -= 8; result[3] = true; }
        if (b >= 4) { b -= 4; result[2] = true; }
        if (b >= 2) { b -= 2; result[1] = true; }
        if (b == 1) { b -= 1; result[0] = true; }
        return result;
    }

    private static byte BitToByte(bool[] b)
    {
        byte result = 0;
        for (int i = 0; i < 8; i++)
        {
            result += (byte)(System.Math.Pow(2, i) * (b[i] ? 1 : 0));
        }
        return result;
    }

    public byte ToByte()
    {
        return BitToByte(list);
    }

    public override string ToString()
    {
        string r = "";
        for (int i = 0; i < 8; i++)
            r += (list[i] ? "1" : "0");
        return r;
    }

    public bool canEditMenashe
    {
        get
        {
            return list[0];
        }
    }

    public bool canEditEfraim
    {
        get
        {
            return list[1];
        }
    }

    public bool canEditBinyamin
    {
        get
        {
            return list[2];
        }
    }

    public bool canEditJerusalem
    {
        get
        {
            return list[3];
        }
    }

    public bool canEditYehuda
    {
        get
        {
            return list[4];
        }
    }
}