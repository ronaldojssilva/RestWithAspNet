﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
