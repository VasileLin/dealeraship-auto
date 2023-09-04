using System.ComponentModel.DataAnnotations.Schema;

namespace DealershipAuto_Manager.Models
{
    public class Sale
    {
        public Guid Id { get; set; }

        public Car Car { get; set; }
        public Client Client { get; set; }

        public DateTime Date { get; set; }
        public double FinalPrice { get; set; }
    }
}
