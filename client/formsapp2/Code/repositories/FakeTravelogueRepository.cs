using System.Collections.Generic;

namespace formsapp2
{
	class FakeTravelogueRepository : ITravelogueRepository
	{
        private static List<Travelogue> listLog = new List<Travelogue>();

        private static FakeTravelogueRepository instance;

        private FakeTravelogueRepository() { }

        public static FakeTravelogueRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FakeTravelogueRepository(); 
                    //-----------TEST DATA-------------------------------------------
                    Travelogue test = new Travelogue("test");
                    Travelogue test1 = new Travelogue("LifeOfPietje");
                    test1.addNewEntry(new formsapp2.LogEntry("Day one", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.In hendrerit risus eget leo commodo, in tempus nisi suscipit.Integer odio ante, consequat eget molestie at, lobortis vel dolor.Vivamus bibendum urna ac est cursus euismod.Sed aliquam ante quis massa rutrum laoreet.Vivamus elementum interdum lacus at semper.Vivamus eleifend quis est sit amet elementum.Etiam justo enim, interdum vel ipsum nec, maximus molestie odio. "));
                    test1.addNewEntry(new formsapp2.LogEntry("Graduation", "Sed non metus vel orci fermentum venenatis. Morbi nunc turpis, volutpat mattis lacus sit amet, accumsan semper magna. Proin quis commodo risus, eu gravida lacus. In hendrerit volutpat ante. Cras lacinia elit sit amet sodales tempus. Aenean non justo in ipsum aliquet luctus vel id velit. Vestibulum nec semper enim. "));
                    test1.addNewEntry(new formsapp2.LogEntry("Holidays over", "Phasellus scelerisque libero quis nibh sodales tincidunt. Vestibulum et gravida nisl. Proin eu sagittis mi, eu malesuada leo. Curabitur porta lorem sem, vel rutrum nibh aliquam ac. Fusce feugiat justo sit amet eleifend laoreet. Nam quis vehicula ligula, congue pulvinar leo. Mauris et pretium sapien, in semper felis. Fusce efficitur interdum nisl id vulputate. "));
                    //----------------------------------------------------------------

                    listLog.Add(test);
                    listLog.Add(test1);
                }
                return instance;
            }
        }

        public List<string> getTableItems()
        {
            List<string> tableitems = new List<string>();
            foreach (Travelogue log in listLog)
            {
                tableitems.Add(log.ToString());
            }
        return tableitems;
        }

        public List<Travelogue> getTravelList()
        {
            return listLog;
        }

        public void addTravelogue(Travelogue log)
        {
            listLog.Add(log);
        }

        public void removeTravelogue(Travelogue log)
        {
            listLog.Remove(log);
        }
}
}