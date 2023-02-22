using System.Text;

namespace Acc.Api.Utils;

public static class PasswordGenerator
{
    public static string Generate()
    {
        const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&";
        StringBuilder res = new StringBuilder();
        Random rnd = new Random();
        var length = rnd.Next(8, 16);
        while (0<length--)
        {
            res.Append(valid[rnd.Next(valid.Length)]);
        }
        return res.ToString();
    }
    
}