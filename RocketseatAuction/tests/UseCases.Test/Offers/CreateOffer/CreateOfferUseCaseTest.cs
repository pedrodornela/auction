using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Contratcts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Servicos;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        ///ARRANGE - INICIALIZAÇÃO/INSTÂNCIA

        var request = new Faker<RequestCreateOfferJson>()
            .RuleFor(request => request.Price, faker => faker.Random.Decimal(1, 100)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);


        ///ACT - AÇÃO
        var act = () => useCase.Execute(itemId, request);


        ///ASSERT - TESTE
        act.Should().NotThrow();

    }
}
