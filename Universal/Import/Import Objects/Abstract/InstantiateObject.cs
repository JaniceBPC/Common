namespace Universal.Import
{
    public abstract class InstantiateObject<TExtractedAttributes> 
        where TExtractedAttributes : ExtractedAttributes
    {
        public abstract void Instantiate(TExtractedAttributes extractedAttributes);
    }
}
