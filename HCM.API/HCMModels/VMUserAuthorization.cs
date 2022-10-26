namespace HCM.API.HCMModels
{
    public class VMUserAuthorization
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string MenuLink { get; set; }
        public int PMenuID { get; set; }
        public string PMenuName { get; set; }
        public int CMenuID { get; set; }
        public string CMenuName { get; set; }
        public Boolean UserRights { get; set; }
    }
}
