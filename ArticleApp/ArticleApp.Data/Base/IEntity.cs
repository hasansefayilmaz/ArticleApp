using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleApp.Data.Base
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime CreatedDate { get; set; }
        byte Status { get; set; }
    }
}
