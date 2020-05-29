using System;

namespace GameStory
{
    [Serializable]
    public class Location
    {
        public string locationName;

        public Location(string locationName)
        {
            this.locationName = locationName;
        }


        public static implicit operator Location(string locationName)
        {
            return new Location(locationName);
        }
    }
}