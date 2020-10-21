using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    public class NoteParser
    {

        public NoteParser()
        {

        }


        public IEnumerable<NoteGroup> Parse(int noteCount, int size, params int[] noteArr)
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
                    yield return group;
                    group = new NoteGroup();
                    currentValue = 0;
                    continue;
                }

                if (targetValue < currentValue)
                    throw new Exception("Размер ноты слишком большой");
            }

            if (currentValue != 0)
                throw new Exception("Размер ноты слишком маленький");
        }
    }
}
