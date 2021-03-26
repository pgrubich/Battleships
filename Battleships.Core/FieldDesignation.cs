using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleships.Core
{
    public enum FieldDesignation
    {
        [Description("o")]
        NotVisited,
        [Description("x")]
        Visited,
        [Description("H")]
        Hit,
        [Description("S")]
        Sunk
    }
}
