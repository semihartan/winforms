﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;

internal partial class Interop
{
    internal partial class Comdlg32
    {
        [DllImport(Libraries.Comdlg32, SetLastError = true, ExactSpelling = true)]
        public unsafe static extern BOOL ChooseFontW(ref CHOOSEFONTW lpcf);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct CHOOSEFONTW
        {
            public uint lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hDC;
            public LOGFONTW* lpLogFont;
            public int iPointSize;
            public CF Flags;
            public int rgbColors;
            public IntPtr lCustData;
            public void* lpfnHook;
            public char* lpTemplateName;
            public IntPtr hInstance;
            public char* lpszStyle;
            public ushort nFontType;
            public ushort ___MISSING_ALIGNMENT__;
            public int nSizeMin;
            public int nSizeMax;
        }
    }
}
