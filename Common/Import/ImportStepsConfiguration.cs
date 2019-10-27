using System;
using System.Data;
using Jbpc.Common.Import.ValidationExceptions;

namespace Jbpc.Common.Import
{
    public class ImportStepsConfiguration<TExtractedAttributes> : IImportDataRow 
        where TExtractedAttributes : ExtractedAttributes
    {
        private readonly IExtractAttributes<TExtractedAttributes> extractAttributes;
        private readonly IValidate<TExtractedAttributes> validate;
        private readonly InstantiateObject<TExtractedAttributes> instantiateObject;

        public ImportStepsConfiguration(IExtractAttributes<TExtractedAttributes> extractAttributes, IValidate<TExtractedAttributes> validate, InstantiateObject<TExtractedAttributes> instantiateObject)
        {
            this.extractAttributes = extractAttributes;
            this.validate = validate;
            this.instantiateObject = instantiateObject;
        }
        public ObjectImportResult Import(DataRow dataRow, int nthRow)
        {
            TExtractedAttributes extractedAttributes;
            ValidationResult validationResult;

            try
            {
                extractedAttributes = extractAttributes.Extract(dataRow, nthRow);
            }
            catch (Exception ex)
            {
                return new ObjectImportResult(dataRow, new ValidationResult(new ExtractAttributesException(ex)) );
            }

            try
            {
                validationResult = validate.ValidateAttributes(extractedAttributes);
            }
            catch (Exception ex)
            {
                return new ObjectImportResult(dataRow, new ValidationResult(new ValidationException(ex)));
            }

            if (!validationResult.IsOk)
            {
                return new ObjectImportResult(dataRow, validationResult);
            }

            try
            {
                instantiateObject.Instantiate(extractedAttributes);
            }
            catch (Exception ex)
            {
                validationResult.Add(new instantiationException(ex));

                return new ObjectImportResult(dataRow, validationResult);
            }

            return new ObjectImportResult(dataRow, validationResult);
        }
    }
}
