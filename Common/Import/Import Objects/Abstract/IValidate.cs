namespace Jbpc.Common.Import
{
    public interface IValidate<in TExtractedAttributes> where TExtractedAttributes : ExtractedAttributes
    {
        ValidationResultCollection ValidateAttributes(TExtractedAttributes attributes);
    }
}
