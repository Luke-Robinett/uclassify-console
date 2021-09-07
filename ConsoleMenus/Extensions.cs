using System.Text;

namespace ConsoleMenus
{
    public static class Extensions
    {
        public static byte[] ToByteArray(this string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
