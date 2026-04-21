namespace api_infor_cell.src.Shared.DTOs
{
    public class RequestDTO
    {
        public string CompanyId {get;set;} = string.Empty;
        public string CreatedBy {get;set;} = string.Empty;
        public string UpdatedBy {get;set;} = string.Empty;
        public string DeletedBy {get;set;} = string.Empty;
    }
}