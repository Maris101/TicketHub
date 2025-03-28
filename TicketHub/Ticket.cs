using System.ComponentModel.DataAnnotations;

namespace TicketHub
{
    public class Ticket
    {
        public int concertId { get; set; } = 0;

        [MaxLength(10, ErrorMessage = "Name must be less than 10 characters.")]
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int quantity { get; set; } = 0;

        [Required(ErrorMessage = "Credit card is required")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Invaild Credit Card Format")]
        public string creditCard { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiration field is required")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Expiration date must be in MM/YY format.")]
        public string expiration { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security Code is required")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Invalid security code. It must be 3 or 4 digits.")]
        public string securityCode { get; set; } = "01/26";

        [Required(ErrorMessage = "Address is required")]
        [MaxLength(20, ErrorMessage = "Address must be less than 30 characters.")]
        public string address { get; set; } = "123 Main St";

        [Required(ErrorMessage = "City is required")]
        [MaxLength(20, ErrorMessage = "City must be less than 20 characters.")]
        public string city { get; set; } = "Halifax";

        [Required(ErrorMessage = "Province is required")]
        [MaxLength(20, ErrorMessage = "Province must be less than 20 characters.")]
        public string province { get; set; } = "Nova Scotia";

        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Invalid postal code format. Use format A1A 1A1.")]
        public string postalCode { get; set; } = "B3P 1C4";

        [Required(ErrorMessage = "Country is required")]
        [MaxLength(20, ErrorMessage = "Country must be less than 20 characters.")]
        public string country { get; set; } = "Canada";
    }
}
