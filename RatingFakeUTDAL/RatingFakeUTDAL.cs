using InterfaceLib;

namespace FakeDAL
{
    public class RatingFakeUTDAL : IRatingContainer
    {
        private readonly IRatingContainer Container;
        private readonly List<RatingDTO> store;

        public RatingFakeUTDAL(IRatingContainer container)
        {
            Container = container;
        }

        public void AddRating(int id, int waarde)
        {
            store.Add(new RatingDTO())
        }

        public int GemRatingBijOutfit(int id)
        {
            foreach (RatingDTO rating in store)
            {
                if (rating.OutfitID == id)
                {
                    return store.Count;
                }
            }
        }
    }
}