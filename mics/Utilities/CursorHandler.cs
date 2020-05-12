using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MICS.Utilities
{
    class CursorHandler:IDisposable
    {
        Cursor savedCursor;
        public CursorHandler()
        {
            savedCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
        }

        ~CursorHandler()
        {
            Restore();
        }

        public void Dispose()
        {
            Restore();
            GC.SuppressFinalize(this);
        }

        private void Restore()
        {
            Cursor.Current = savedCursor;
        }

    }
}
