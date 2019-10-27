namespace Jbpc.Common.Import
{
    public interface IValidate<in TExtractedAttributes> where TExtractedAttributes : ExtractedAttributes
    {
        ValidationResult ValidateAttributes(TExtractedAttributes attributes);
    }
}
