using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ArticleApp.Data.Base
{
    [Serializable]
    public class Entity : IEntity<int>
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte Status { get; set; }
    }
}
