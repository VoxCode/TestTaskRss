namespace TestTaskRss.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RssNews
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string NewsUrl { get; set; }

        public int RssSourceId { get; set; }

        public virtual RssSources RssSources { get; set; }
    }
}
