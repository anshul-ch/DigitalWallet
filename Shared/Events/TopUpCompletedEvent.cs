namespace DigitalWallet.Shared.Events;
public record TopUpCompletedEvent(Guid UserId, decimal Amount);