namespace Inventory.Web
{
    public static class StringExtensions
    {
        public static int ToInt32(this string value)
        {
            int.TryParse(value, out int ret);
            return ret;
        }

        public static decimal ToDecimal(this string value)
        {
            decimal.TryParse(value, out decimal ret);
            return ret;
        }
    }
}