namespace vpn.Shared.Country
{
    public class Country
    {
        public string Name { get; }
        public string FlagCode { get; }

        public Country(string name, string flagCode)
        {
            Name = name;
            FlagCode = flagCode;
        }
    }
}
