﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP.Visuals
{
    [Serializable]
    enum BuildType
    {
        Empty,
        CheckIn,
        Conveyor,
        Security,
        Mda,
        DropOff, 
        Delete
    }
}
