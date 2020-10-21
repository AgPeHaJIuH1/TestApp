using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class ParseNoteResult
    {
        public ParseNoteResult(NoteGroup group)
        {
            IsSuccess = true;
            Group = group;
        }
        public ParseNoteResult(string error)
        {
            IsSuccess = false;
            Error = error;
        }

        public bool IsSuccess { get; }
        public string Error { get; }
        public NoteGroup Group { get; }
    }
}
