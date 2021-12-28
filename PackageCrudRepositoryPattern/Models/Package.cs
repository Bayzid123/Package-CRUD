namespace PackageCrudRepositoryPattern.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PackageType { get; set; }
        public float PackagePrice { get; set; }
    }
}
