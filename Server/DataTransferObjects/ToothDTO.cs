namespace DentistryManagement.Server.DataTransferObjects
{
    public class ToothDTO
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Category { get; set; }

        public int Number { get; set; }

        public int Order { get; set; }

        public bool HasDiseases { get; set; }
    }
}
