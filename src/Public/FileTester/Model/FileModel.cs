﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTester.Model
{
    public class FileModel
    {
        public bool IsFolder { get; set; }
        public string Name { get; set; }
        public uint Size { get; set;  }
        public FileTimeModel Times { get; set; }
    }
}