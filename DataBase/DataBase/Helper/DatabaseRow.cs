using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Helper
{
    public interface DatabaseRow
    {
        List<string> Data { get; set; }
        int RowID { get; set; }
    }
}
