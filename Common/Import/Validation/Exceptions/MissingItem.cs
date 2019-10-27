using System.Collections.Generic;

namespace Jbpc.Common.Import.ValidationExceptions
{
    public class MissingItem : AbstractException
    {
        public MissingItem(string itemType)
        {
            ItemType = itemType;
        }
        public override bool IsOK => false;
        public string ItemType { get; }
        public override string ToString() => $"Missing item ype=\"{ItemType}\"";
    }
}
