using System.Collections.Generic;

namespace Universal.Import.ValidationExceptions
{
    public class SpecifiedItemDoesNotExist : AbstractException
    {
        public SpecifiedItemDoesNotExist(string name, string itemType)
        {
            Name = name;
            ItemType = itemType;
        }
        public override bool IsOK => false;
        public string Name { get; }
        public string ItemType { get; }
        public override string ToString() => $"Specified item does not exist, item=\"{Name}\" item type=\"{ItemType}\"";
    }
}
