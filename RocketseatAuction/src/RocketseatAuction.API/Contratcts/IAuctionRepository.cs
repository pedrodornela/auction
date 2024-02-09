using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratcts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
