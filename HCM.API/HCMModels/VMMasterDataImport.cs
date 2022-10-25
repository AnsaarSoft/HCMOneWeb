namespace HCM.API.HCMModels
{
    public class VMMasterDataImport
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class VMGradeMasterDataImport
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }

        
    }
    public class VMAttendanceMasterDataImport
    {
        public int Id { get; set; }
        public string FkempId { get; set; }
        public DateTime PunchedDate { get; set; }
        public string PunchedTime { get; set; }
        public string InOut { get; set; }


    }

    public class VMMonthlyOTImport
    {
        public int Id { get; set; }
        public string EmpCode { get; set; }
        public string OverTimeType { get; set; }
        public decimal TotalHours { get; set; }


    }
}
