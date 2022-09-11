# Documentation: Generic API to handle report Data

### 1. OData

- https://www.odata.org/getting-started/
- https://referbruv.com/blog/working-with-odata-integrating-an-existing-aspnet-core-3x-api/

### OData Advanced
1.  OData - Pagination:
    - Client-driven paging
    - Server-driven paging


### 2. Api Versioning

- https://www.c-sharpcorner.com/article/api-versioning-in-asp-net-core-web-api/
- https://www.infoworld.com/article/3562355/how-to-use-api-versioning-in-aspnet-core.html
- OData with apiVersion: https://devblogs.microsoft.com/odata/api-versioning-extension-with-asp-net-core-odata-8/


### 3. Swagger

- https://referbruv.com/blog/integrating-aspnet-core-api-versions-with-swagger-ui/
- https://docs.microsoft.com/vi-vn/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-5.0
- https://docs.microsoft.com/vi-vn/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio-code
- https://www.c-sharpcorner.com/article/how-to-implement-swagger-in-asp-net-core-web-api/


### 4. EF Core, and DB First Approach

- https://code-maze.com/asp-net-core-web-api-with-ef-core-db-first-approach/
- https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
- https://dev.to/renukapatil/supercharging-aspnet-60-with-odata-crud-batching-pagination-12np

Script Migrations

```
Scaffold-DbContext 'Data Source=VN-LINHQUACH\NEWSQL1;Initial Catalog=ProductStore;User ID=sa;Password=admin@2022;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities
```
