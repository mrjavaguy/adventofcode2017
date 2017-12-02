namespace Utils.ExtensionMethods
{
    using LaYumba.Functional;
    using static LaYumba.Functional.F;

    public static class CharExtensions
    {
        public static Option<int> ToInteger(this char c)
        {
            int value = (int)(c - '0');
            if (value >= 0 && value <= 9)
                return Some(value);
            else
                return None;
        }
    }
}
