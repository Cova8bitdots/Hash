using System.Text;

/// <summary>
/// http://www.cse.yorku.ca/~oz/hash.html
/// </summary>
public class DJBHash
{
    /// <summary> Hashの初期値 </summary>
    const ulong HASH = 5381;

    const int BIT_SHIFT = 5;// hash = hash * 33 +c の為の定数(らしい)

    /// <summary>
    /// DJB2 によるHash計算アルゴリズム
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ulong Hash( string str )
    {
        ulong hash = HASH;

        for (int i = 0; i < str.Length; i++)
        {
            hash = (( hash << BIT_SHIFT ) + hash) + str[i];
        }

        return hash;
    }

    /// <summary>
    /// Hashの計算(バイナリデータから)
    /// 正直String変換がめちゃくちゃ重いので非推奨
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ulong Hash( byte[] data )
    {
        return Hash( Encoding.UTF8.GetString(data));
    }
}