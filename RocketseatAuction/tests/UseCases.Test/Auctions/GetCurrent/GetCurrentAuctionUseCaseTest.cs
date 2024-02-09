using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contratcts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        ///ARRANGE - INICIALIZAÇÃO/INSTÂNCIA

        var entity = new Faker<Auction>()
            .RuleFor(auction => auction.Id, faker => faker.Random.Number(1,100))
            .RuleFor(auction => auction.Name, faker => faker.Lorem.Word())
            .RuleFor(auction => auction.Starts, faker => faker.Date.Past())
            .RuleFor(auction => auction.Ends, faker => faker.Date.Future())
            .RuleFor(auction => auction.Items, (faker, auction) => new List<Item>
            {
                new Item { 
                    Id = faker.Random.Number(1,100),
                    Name = faker.Commerce.ProductName(),
                    Brand = faker.Commerce.Department(),
                    BasePrice = faker.Random.Decimal(50,1000),
                    Condition = faker.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        var mock = new Mock<IAuctionRepository>();
        mock.Setup(i => i.GetCurrent()).Returns(entity);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);


        ///ACT - AÇÃO
        var auction = useCase.Execute();


        ///ASSERT - TESTE
        auction.Should().NotBeNull();
        auction!.Id.Should().Be(entity.Id);
        auction.Name.Should().Be(entity.Name);

    }

}
