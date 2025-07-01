namespace AFH_Locations_Project.Models
{
    public class AFHOfficeFeedModel
    {
        
            public required string Name { get; set; }
            public required string Address1 { get; set; }
            public string? Address2 { get; set; }
            public required string City { get; set; }
            public required string PostCode { get; set; }
    }
}
