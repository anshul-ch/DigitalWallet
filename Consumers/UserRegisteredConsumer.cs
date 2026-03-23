using DigitalWallet.Data;
using DigitalWallet.Models;
using DigitalWallet.Shared.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace DigitalWallet.Consumers;

public class UserRegisteredConsumer : IConsumer<UserRegisteredEvent>
{
    private readonly RewardsDbContext _db;

    public UserRegisteredConsumer(RewardsDbContext db)
    {
        _db = db;
    }

    public async Task Consume(ConsumeContext<UserRegisteredEvent> context)
    {
        var exists = await _db.RewardAccounts.AnyAsync(r => r.UserId == context.Message.UserId);
        if (exists)
        {
            return;
        }

        var account = new RewardAccount();
        account.UserId = context.Message.UserId;
        account.TotalPoints = 0;
        account.Tier = "Silver";

        _db.RewardAccounts.Add(account);
        await _db.SaveChangesAsync();
    }
}
