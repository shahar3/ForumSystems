﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyForum.Model
{
    
    interface Observer
    {
         void update(Notification notification);
    }
}
