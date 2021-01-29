using System;
using System.Collections.Generic;

namespace Bingo.Api.Models
{
    public partial class Messages
    {
        public int MessageId { get; set; }
        public string Message { get; set; }
        public string EmptyMessage { get; set; }
        public DateTime? Date { get; set; }
    }
}
