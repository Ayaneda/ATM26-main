namespace ATM.ATM.Tests;

using System.Xml.Serialization;
using Xunit;
using Xunit.Sdk;

public class AtmServiceTest
{
    [Fact]
    public void AtmServiceBalanceTest()
    {
        int testAtmBalanceVal = 10000;
        AtmService atmService = new AtmService(testAtmBalanceVal);
        Assert.Equal(testAtmBalanceVal, atmService.AtmBalance);
    }

    [Fact]
    public void InsertCardTest()
    {
        // setup
        Account account = new Account(5000);
        // given
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(5000);
        // when
        atm.InsertCard(card);
        // then
        Assert.True(atm.HasCardInserted);
    }

    [Fact]
    public void EjectCardTest()
    {
        //setup
        Account account = new Account (5000);
        //given
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(5000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        //when
        atm.EjectCard();
        //then
        Assert.False(atm.HasCardInserted);
    }
    public void EnterPinTest()
    {
        
    }
    public void GetBalanceTest()
    {
        
    }
    public void WithdrawTest()
    {
        
    }
    public void DepositTest()
    {
        
    }
    public void EnsureAuthenticatedTest()
    {
        
    }
}