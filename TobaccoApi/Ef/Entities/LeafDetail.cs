using System;

namespace TobaccoApi.Ef.Entities
{
    public class LeafDetail
    {
        public int LeafDetailId { get; set; }
        public string Url { get; set; }
        public double CCT { get; set; }
        public DateTime Time { get; set; }
        public int LeafId { get; set; }
    }
}
