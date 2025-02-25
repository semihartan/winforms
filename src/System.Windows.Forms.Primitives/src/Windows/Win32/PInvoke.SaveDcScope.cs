﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Windows.Win32
{
    internal static partial class PInvoke
    {
        /// <summary>
        ///  Helper to scope lifetime of a saved device context state.
        /// </summary>
        /// <remarks>
        ///  <para>
        ///  Use in a <see langword="using" /> statement. If you must pass this around, always pass by <see langword="ref" />
        ///  to avoid duplicating the handle and risking a double restore.
        ///
        ///  The state that is saved includes ICM (color management), palette, path drawing state, and other objects
        ///  that are selected into the DC (bitmap, brush, pen, clipping region, font).
        ///
        ///  Ideally saving the entire DC state can be avoided for simple drawing operations and relying on restoring
        ///  individual state pieces can be done instead (putting back the original pen, etc.).
        ///  </para>
        /// </remarks>
        public readonly ref struct SaveDcScope
        {
            public HDC HDC { get; }
            private readonly int _savedState;

            /// <summary>
            ///  Saves the device context state using <see cref="SaveDC(HDC)"/>.
            /// </summary>
            /// <param name="hdc"></param>
            public SaveDcScope(HDC hdc)
            {
                _savedState = SaveDC(hdc);
                HDC = hdc;
            }

            public void Dispose()
            {
                if (_savedState != 0)
                {
                    RestoreDC(HDC, _savedState);
                }
            }
        }
    }
}
