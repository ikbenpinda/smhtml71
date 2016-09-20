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
        private List<Entry> listEntries;

        public Travelogue(string title)
        {
            this.title = title;
            this.created = DateTime.Now;
            this.updated = DateTime.Now;
            this.listEntries = new List<Entry>();
        }

        public string getTitle()
        {
            return this.title;
        }

        public List<Entry> getEntries()
        {
            return this.listEntries;
        }

        public void addNewEntry(Entry entry)
        {
            this.listEntries.Add(entry);
            this.nrOfEntries++;

        }

        public void removeEntry(Entry entry)
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

