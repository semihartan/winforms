﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Drawing;

namespace Windows.Win32
{
    internal static partial class PInvoke
    {
        public unsafe static int MapWindowPoints<TFrom, TTo>(TFrom hWndFrom, TTo hWndTo, ref RECT lpRect)
            where TFrom : IHandle<HWND>
            where TTo : IHandle<HWND>
        {
            fixed (void* p = &lpRect)
            {
                int result = MapWindowPoints(hWndFrom.Handle, hWndTo.Handle, (Point*)p, cPoints: 2);
                GC.KeepAlive(hWndFrom.Wrapper);
                GC.KeepAlive(hWndTo.Wrapper);
                return result;
            }
        }

        public unsafe static int MapWindowPoints<TFrom, TTo>(TFrom hWndFrom, TTo hWndTo, ref Point lpPoint)
            where TFrom : IHandle<HWND>
            where TTo : IHandle<HWND>
        {
            fixed (void* p = &lpPoint)
            {
                int result = MapWindowPoints(hWndFrom.Handle, hWndTo.Handle, (Point*)p, cPoints: 1);
                GC.KeepAlive(hWndFrom.Wrapper);
                GC.KeepAlive(hWndTo.Wrapper);
                return result;
            }
        }
    }
}
