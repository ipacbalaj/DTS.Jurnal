namespace DTS.Common.DatabaseServer.EntitiesModel.Local
{
    public class LocalUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AppInfo { get; set; }
        public string SavePath { get; set; }
        public string ImagePath { get; set; }        
    }
}
