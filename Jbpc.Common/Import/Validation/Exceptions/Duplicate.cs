namespace Jbpc.Common.Import.ValidationExceptions
{
    public class Duplicate : AbstractException
    {
        public Duplicate(string name, string itemType)
        {
            Name = name;
            ItemType = itemType;
        }
        public override bool IsOK => false;
        public string Name { get; }
        public string ItemType { get; }
        public override string ToString() => $"Duplicate name=\"{Name}\", type=\"{ItemType}\"";
    }
}
