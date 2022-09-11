using System;
using System.Collections.Generic;

#nullable disable

namespace Netpower.Migrations.Entities
{
    public partial class ProductRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}
