using System.Collections.Generic;

namespace HuskyRescue.Core.ViewModel
{
    public class PetFinder_PetRecord
    {
        public PetFinder_PetRecord()
        {
            PictureUrlsFull = new List<string>();
        }
        public string ID { get; set; }
        public string ShelterPetID { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public List<string> PictureUrlsFull { get; set; }
		public List<string> PictureUrlsThumb { get; set; }
		public bool IsMix { get; set; }
        public bool IsAltered { get; set; }
        public bool HasShots { get; set; }
        public bool IsHousebroken { get; set; }
        public bool IsSpecialNeeds { get; set; }
        public bool IsCatFriendly { get; set; }
        public bool IsDogFriendly { get; set; }
        public bool IsKidFriendly { get; set; }
        public bool NeedsFoster { get; set; }
        public string Sex { get; set; }
        public string Size { get; set; }
        public string Age { get; set; }
    }
}