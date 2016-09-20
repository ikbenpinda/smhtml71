using System;
using System.Collections.Generic;

namespace formsapp2
{
    public class LogEntry
    {
        private string title;
        private string content;
        private DateTime date;
        private int entryNumber;
        private List<Media> attachment;

        public LogEntry(string title, string content)
        {
            this.title = title;
            this.content = content;
            attachment = new List<Media>();
        }

        public string getTitle()
        {
            return this.title;
        }
        public List<Media> getMedia() {
            return this.attachment;
        }

        public string getContent()
        {
            return this.content;
        }

        public override string ToString()
        {
            return "Entry: " + title;
        }


    }
}

