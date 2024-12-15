namespace SE1.Models.dto
{
    public class ViewHistoryDTO
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string printer { get; set; }

        public ViewHistoryDTO() { }

        public ViewHistoryDTO(string startDate, string endDate, string printer)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.printer = printer;
        }
    }
}
