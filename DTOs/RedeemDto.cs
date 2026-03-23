using System.ComponentModel.DataAnnotations;

namespace DigitalWallet.DTOs;

public class RedeemDto
{
    [Required]
    public Guid ItemId { get; set; }
}
