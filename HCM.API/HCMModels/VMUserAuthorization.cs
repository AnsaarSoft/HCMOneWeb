namespace HCM.API.HCMModels
{
    public class VMUserAuthorization
    {
        public int PMenuID { get; set; }
        public string PMenuName { get; set; }
        public int CMenuID { get; set; }
        public string CMenuName { get; set; }
        public Boolean UserRights { get; set; }
    }
}
