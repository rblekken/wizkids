using System;
using System.Collections.Generic;

namespace Wizkids.Api.DataAccess.Models
{
    public partial class Word
    {
        public long Id { get; set; }
        public string Value { get; set; } = string.Empty;
    }
}
