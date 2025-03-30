using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MemosApplication.Models
{
    public class MemoListsContext: DbContext
    {
        public DbSet<MemoList> MemoLists { get; set; }
    }
}