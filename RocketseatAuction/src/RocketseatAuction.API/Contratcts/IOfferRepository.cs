using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Contratcts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
