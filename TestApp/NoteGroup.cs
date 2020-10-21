using System.Collections.Generic;

namespace TestApp
{
   public  class NoteGroup
    {
        public NoteGroup()
        {
            Notes = new List<Note>();
        }

        public List<Note> Notes { get; set; }
    }
}