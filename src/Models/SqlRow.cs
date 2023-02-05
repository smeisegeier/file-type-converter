using DextersLabor.Helper;
using Hl7.Fhir.Model;

namespace Rki.CancerData.Clinical.TableConverter.App.Models
{
    /// <summary>
    /// Minimal structure for comformance of fhir properties to objects/sqltables.
    /// Id column is omitted here, since autoincrement is added in sql conversion.
    /// Use derived class when Id should be mapped
    /// </summary>
    public class SqlRow
    {
        public required string Code { get; init; }
        public required string Description { get; init; }
        public DateTime CreatedAt { get; init; }


        public override string ToString() => this.ToJson();

        public static implicit operator SqlRow(CodeSystem.ConceptDefinitionComponent concept) => new SqlRow()
        { Code = concept.Code, Description = concept.Display, CreatedAt = DateTime.Now };

        public static implicit operator SqlRow(ValueSet.ConceptReferenceComponent concept) => new SqlRow()
        { Code = concept.Code, Description = concept.Display, CreatedAt = DateTime.Now };

    }

    /// <summary>
    /// Derived structure, adds the Id column if mapping to existing Id in source is needed
    /// </summary>
    public class SqlRowWithSourceId : SqlRow
    {
        /// <summary>
        /// Id can be set 
        /// </summary>
        public int Id { get; init; }

        public static implicit operator SqlRowWithSourceId(CodeSystem.ConceptDefinitionComponent concept) => new SqlRowWithSourceId()
        { Id = 0, Code = concept.Code, Description = concept.Display, CreatedAt = DateTime.Now };

    }


}
