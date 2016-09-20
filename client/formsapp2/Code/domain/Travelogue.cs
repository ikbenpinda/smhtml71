using System;
using System.Collections.Generic;

namespace formsapp2
{
    public class Travelogue
    {
        private string title;
        private int nrOfEntries;
        private DateTime created;
        private DateTime updated;
        private string space = "  ";
        private List<LogEntry> listEntries;

        public Travelogue(string title)
        {
            this.title = title;
            this.created = DateTime.Now;
            this.updated = DateTime.Now;
            this.listEntries = new List<LogEntry>();
        }

        public string getTitle()
        {
            return this.title;
        }

        public List<LogEntry> getEntries()
        {
            return this.listEntries;
        }

        public void addNewEntry(LogEntry entry)
        {
            this.listEntries.Add(entry);
            this.nrOfEntries++;

        }

        public void removeEntry(LogEntry entry)
        {
            this.listEntries.Remove(entry);
            this.nrOfEntries--;
        }
        public override string ToString()
        {
            return "Title: " + title + space + "Entries: " + nrOfEntries.ToString();// + space + "Created: "+ Created+ space+ "Updated: "+ Updated;
        }

    }
}

