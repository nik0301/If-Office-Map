namespace OfficeMap.Lync
{
    public class LyncData
    {
        private readonly Config config;

        public LyncData(Config config)
        {
            this.config = config;
        }

        public virtual string GetAvailability(string email)
        {
            var status = config.LyncManager.GetPeopleStatus(email);

            return status.Availability;
        }

        public byte[] GetPhoto(string email)
        {
            var photo = config.LyncManager.GetPeoplePhoto(email);

            return photo;
        }
    }

}
