﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyCrawler.Interface
{
    public interface IUrlOut
    {
        void To(IUrlIn to);
    }
}
