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
        private List<Media> attachments;


        public LogEntry(string title, string content)
        {
            this.title = title;
            this.content = content;
            attachments = new List<Media>();
        }
        public LogEntry() {
            attachments = new List<Media>();
        }
        public string getTitle()
        {
            return this.title;
        }

        public List<Media> getMedia() {
            return this.attachments;
        }

        public void addAttachment(Media media)
        {
            this.attachments.Add(media);
        }
        public string getContent()
        {
            return this.content;
        }

        public void setTitle(string title) {
            this.title = title;
        }

        public void setContent(string content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return "Entry: " + title;
        }


    }
}

