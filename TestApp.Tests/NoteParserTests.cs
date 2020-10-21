using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace TestApp.Tests
{
    public class NoteParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Parse_GroupCount_2()
        {
            NoteParser parser = new NoteParser();

            List<ParseNoteResult> list = parser.Parse(2, 4, 4, 4, 8, 8, 8, 8).ToList();

            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void Parse_GroupCount_3()
        {
            NoteParser parser = new NoteParser();

            List<ParseNoteResult> list = parser.Parse(2, 4, 4, 4, 8, 8, 4, 8, 4, 8).ToList();

            Assert.AreEqual(3, list.Count);
        }

        [Test]
        public void Parse_Exception_SmallSize()
        {
            NoteParser parser = new NoteParser();

            Exception exception = Assert.Throws<Exception>(() => parser.Parse(2, 4, 4, 4, 8, 8).ToList());

            Assert.That(exception.Message == NoteParser.NOTE_SMALL_SIZE_ERROR);
        }

        [Test]
        public void Parse_Exception_BigSize()
        {
            NoteParser parser = new NoteParser();

            Exception exception = Assert.Throws<Exception>(() => parser.Parse(2, 4, 4, 4, 8, 8, 8, 4).ToList());

            Assert.That(exception.Message == NoteParser.NOTE_BIG_SIZE_ERROR);
        }
    }
}