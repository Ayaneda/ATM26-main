namespace ATM.ATM.Tests;

using Xunit;
using Xunit.Sdk;

public class CardTest
{
    [Fact]
    public void MatchesPinTest()
    {
        // Setup
        Account account = new Account(5000);
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        //When
        atm.EnsureAuthenticated();
        //Then
        Assert.True(atm.IsAuthenticated);
    }
}