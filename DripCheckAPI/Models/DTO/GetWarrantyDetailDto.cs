namespace DripCheckAPI.Models.DTO
{
    public class GetWarrantyDetailDto
    {
        public int ProductOwnerId { get; set; }
        public string OwnerFirstName { get; set; } = "";
        public string OwnerLastName { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public string ExpirationDate { get; set; } = "";
        public string WarrantyStatus { get; set; } = "";
        public int WarrantyDetailId { get; set; }
        public int ReqDuration { get; set; }
        public string ReqReason { get; set; } = "";
        public int LoginId { get; set; }
    }
}
