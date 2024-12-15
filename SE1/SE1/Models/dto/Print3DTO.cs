namespace SE1.Models.dto
{
    public class Print3DTO
    {
        public string pageRange { get; set; }
        public int numberOfCopies { get; set; }
        public string orientation { get; set; }
        public string paperSize { get; set; }
        public string printedSides { get; set; }
        public string color { get; set; }

        public Print3DTO() { }

        public Print3DTO(string pageRange, int numOfCopies, string orientation, string paperSize, string printedSides, string color)
        {
            this.pageRange = pageRange;
            this.numberOfCopies = numberOfCopies;
            this.orientation = orientation;
            this.paperSize = paperSize;
            this.printedSides = printedSides;
            this.color = color;
        }
    }
}
