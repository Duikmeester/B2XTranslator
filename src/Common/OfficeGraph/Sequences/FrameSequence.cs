﻿using System;
using System.Collections.Generic;
using System.Text;
using DIaLOGIKa.b2xtranslator.StructuredStorage.Reader;

namespace DIaLOGIKa.b2xtranslator.OfficeGraph
{
    public class FrameSequence : OfficeGraphBiffRecordSequence
    {
        public FrameSequence(IStreamReader reader)
            : base(reader)
        {

        }
    }
}