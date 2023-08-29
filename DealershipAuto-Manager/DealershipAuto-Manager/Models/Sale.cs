using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipAuto_Manager.Models
{
    public class Sale
    {
        public Guid Id { get; set; }

        [ForeignKey("CarId")]
        public Guid CarId { get; set; }
        public Car Car { get; set; }

        [ForeignKey("ClientId")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public DateTime Date { get; set; }
        public double FinalPrice { get; set; }
    }
}
