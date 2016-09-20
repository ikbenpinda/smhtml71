using System;
namespace formsapp2
{
    public class Entry
    {
        private string title;
        private string content;
        private DateTime date;
        private int entryNumber;

        public Entry(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string getTitle()
        {
            return this.title;
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

