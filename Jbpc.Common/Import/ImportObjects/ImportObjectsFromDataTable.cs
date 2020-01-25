using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jbpc.Common.Import
{
    public abstract class ImportObjectsFromDataTable<TExtractedAttributes> : IImportObjectsFromDataTable
        where TExtractedAttributes : ExtractedAttributes
    {
        protected readonly IImportLogger logger;
        protected ImportObjectsFromDataTable(IImportLogger logger)
        {
            this.logger = logger;
        }
        public List<ObjectImportResult> ImportObjects(DataTable dataTable)
        {
            return new ImportObjects(ImportStepsConfiguration).Import(dataTable);
        }
        public List<IObjectImportResult> ImportResults(DataTable dataTable)
        {
            var typedResults = new ImportObjects(ImportStepsConfiguration).Import(dataTable);

            return typedResults.Cast<IObjectImportResult>().ToList();
        }
        public abstract ImportStepsConfiguration<TExtractedAttributes> ImportStepsConfiguration { get; }
        public abstract string[] ColumnLabels();
        public override string ToString() => $"Importer={GetType().Name}, attributes={string.Join(", ", ColumnLabels())}";
    }
}
