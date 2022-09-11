using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Netpower.Migrations.Entities;

namespace Netpower.Contracts.Models
{
    public static class EdmModelBuilder
    {
        public static IEdmModel Build()
        {
            // create OData builder instance
            var builder = new ODataConventionModelBuilder();

            // map the entityset which is the type returned
            // from the endpoint onto the OData pipeline
            // the string parameters is the name of the controller
            // which supplies the data of type HeroModel in this case

            builder
                .EntitySet<Product>("Products")
                .EntityType.HasKey(x => x.Id);

            builder
                .EntitySet<Category>("Categorys")
                .EntityType.HasKey(x => x.Id);

            builder
                .EntitySet<Supplier>("Suppliers")
                .EntityType.HasKey(x => x.Id);

            // Adding FUNCTIONS
            builder.Namespace = "ProductService";
            builder.EntityType<Product>().Collection
                .Function("MostExpensive")
                .Returns<decimal>();

            builder.Function("GetSalesTaxRate")
                .Returns<double>()
                .Parameter<int>("PostalCode");

            // Adding ACTIONS
            builder.EntityType<Product>()
                .Action("Rate")
                .Parameter<int>("Rating");

            // return the fully configured builder model
            // on which the OData library shall be built

            return builder.GetEdmModel();
        }
    }
}