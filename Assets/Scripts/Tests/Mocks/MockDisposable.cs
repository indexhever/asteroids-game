using UnityEngine;
using System.Collections;
using System;

namespace Tests
{
    public class MockDisposable : IDisposable
    {
        public bool IsDisposed { get; internal set; }

        public void Dispose()
        {
            IsDisposed = true;
        }
    }
}