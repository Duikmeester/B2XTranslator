﻿/*
 * Copyright (c) 2008, DIaLOGIKa
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *     * Redistributions of source code must retain the above copyright
 *        notice, this list of conditions and the following disclaimer.
 *     * Redistributions in binary form must reproduce the above copyright
 *       notice, this list of conditions and the following disclaimer in the
 *       documentation and/or other materials provided with the distribution.
 *     * Neither the name of DIaLOGIKa nor the
 *       names of its contributors may be used to endorse or promote products
 *       derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY DIaLOGIKa ''AS IS'' AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL DIaLOGIKa BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace DIaLOGIKa.b2xtranslator.DocFileFormat
{
    public class ShadingDescriptor
    {
        public enum ShadingPattern
        {
            Automatic = 0,
            Solid,
            Percent_5,
            Percent_10,
            Percent_20,
            Percent_25,
            Percent_30,
            Percent_40,
            Percent_50,
            Percent_60,
            Percent_70,
            Percent_75,
            Percent_80,
            Percent_90,
            DarkHorizontal,
            DarkVertical,
            DarkForwardDiagonal,
            DarkBackwardDiagonal,
            DarkCross,
            DarkDiagonalCross,
            Horizontal,
            Vertical,
            ForwardDiagonal,
            BackwardDiagonal,
            Cross,
            DiagonalCross,
            Percent_2_5,
            Percent_7_5,
            Percent_12_5,
            Percent_15,
            Percent_17_5,
            Percent_22_5,
            Percent_27_5,
            Percent_32_5,
            Percent_35,
            Percent_37_5,
            Percent_42_5,
            Percent_45,
            Percent_47_5,
            Percent_52_5,
            Percent_55,
            Percent_57_5,
            Percent_62_5,
            Percent_65,
            Percent_67_5,
            Percent_72_5,
            Percent_77_5,
            Percent_82_5,
            Percent_85,
            Percent_87_5,
            Percent_92_5,
            Percent_95,
            Percent_97_5,
            Percent_97
        }

        /// <summary>
        /// 24-bit foreground color
        /// </summary>
        public Int32 cvFore;

        /// <summary>
        /// Foreground color.<br/>
        /// Only used if cvFore is not set
        /// </summary>
        public Color.ColorIdentifier icoFore;

        /// <summary>
        /// 24-bit background color
        /// </summary>
        public Int32 cvBack;

        /// <summary>
        /// Background color.<br/>
        /// Only used if cvBack is not set.
        /// </summary>
        public Color.ColorIdentifier icoBack;

        /// <summary>
        /// Shading pattern
        /// </summary>
        public ShadingPattern ipat;

        /// <summary>
        /// Creates a new ShadingDescriptor with default values
        /// </summary>
        public ShadingDescriptor()
        {
            setDefaultValues();
        }

        /// <summary>
        /// Parses the bytes to retrieve a ShadingDescriptor.
        /// </summary>
        /// <param name="bytes">The bytes</param>
        public ShadingDescriptor(byte[] bytes)
        {
            if (bytes.Length == 10)
            {
                //it's a Word 2000/2003 descriptor
                this.cvFore = System.BitConverter.ToInt32(bytes, 0);
                this.cvBack = System.BitConverter.ToInt32(bytes, 4);
                this.ipat = (ShadingPattern)System.BitConverter.ToUInt16(bytes, 8);
            }
            else if (bytes.Length == 2)
            {
                //it's a Word 97 SPRM
                byte val = bytes[1];
                this.icoFore = (Color.ColorIdentifier)(val & 0x001F);
                this.icoBack = (Color.ColorIdentifier)((val & 0x03e0) >> 5);
                this.ipat = (ShadingPattern)((val & 0xFC00) >> 10);
            }
            else
            {
                throw new ByteParseException("SHD");
            }
        }

        private void setDefaultValues()
        {
            this.cvBack = 0;
            this.cvFore = 0;
            this.ipat = 0;
        }
    }
}