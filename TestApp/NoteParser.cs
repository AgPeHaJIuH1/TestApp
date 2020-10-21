using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class NoteParser
    {
        internal const string NOTE_BIG_SIZE_ERROR = "Размер ноты слишком большой";
        internal const string NOTE_SMALL_SIZE_ERROR = "Размер ноты слишком маленький";


        public NoteParser()
        {

        }


        public IEnumerable<ParseNoteResult> Parse(int noteCount, int size, params int[] noteArr)
        {
            decimal targetValue = noteCount / (decimal)size;
            List<Note> list = noteArr.Select(q => new Note(q)).ToList();

            NoteGroup group = new NoteGroup();
            decimal currentValue = 0;
            foreach (Note note in list)
            {
                currentValue += note.Value;
                group.Notes.Add(note);

                if (targetValue == currentValue)
                {
                    yield return new ParseNoteResult(group);
                    group = new NoteGroup();
                    currentValue = 0;
                    continue;
                }

                if (targetValue < currentValue)
                {
                    yield return new ParseNoteResult(NOTE_BIG_SIZE_ERROR);
                    group = new NoteGroup();
                    currentValue = 0;
                    continue;
                }
            }

            if (currentValue != 0)
                yield return new ParseNoteResult(NOTE_SMALL_SIZE_ERROR);
        }
    }
}
