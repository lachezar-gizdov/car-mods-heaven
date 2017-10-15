using CarModsHeaven.Data.Models.Abstracts;

namespace CarModsHeaven.Data.Models
{
    public class ContactEmail : BaseDataModel
    {
        public string SenderName { get; set; }

        public string SenderEmail { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
