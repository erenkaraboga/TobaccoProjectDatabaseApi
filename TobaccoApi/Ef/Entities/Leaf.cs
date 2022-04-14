using System.Collections.Generic;
using TobaccoApi.Ef.Entities;

namespace TobaccoApi.Entities
{
    public class Leaf
    {
        public int LeafId { get; set; }
        public string Name { get; set; }
        public ICollection<LeafDetail> LeafDetails { get; set; }

    }
}
