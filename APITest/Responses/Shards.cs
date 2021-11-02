﻿using System;

namespace APITest.Responses
{
    [Serializable]
    public class Shards
    {
        public int total { get; set; }
        public int successful { get; set; }
        public int skipped { get; set; }
        public int failed { get; set; }
    }
}
