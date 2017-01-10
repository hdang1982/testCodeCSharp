using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CodeGraphParseTest.Enums
{
    public enum CodeGraphEnum
    {
        [Display(Description = "row", Name = "Code Graph Row")]
        ROW = 1,
        [Display(Description = "graph", Name = "Code Graph Graph")]
        GRAPH = 2,
        [Display(Description = "both", Name = "Code Graph Both")]
        BOTH = 3
    }
}
