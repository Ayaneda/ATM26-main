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
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(5000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        //when
        atm.EjectCard();
        //then
        Assert.False(atm.HasCardInserted);
    }

    [Fact]
    public void EnterPinTest()
    {
        //setup
        string pinTest = "2345";
        Account account = new Account (5000);
        Card card = new Card("1234-5678", pinTest, account);
        AtmService atm = new AtmService(5000);
        atm.InsertCard(card);
        //when
        atm.EnterPin(pinTest);
        //then
        Assert.True(atm.IsAuthenticated);

    }

    [Theory]
    [InlineData(3000, 3000)]
    [InlineData(1000, 1000)]
    [InlineData(8000, 8000)]
    [InlineData(12000, 12000)]
    public void GetBalanceTest(int accountBalance, int expectedAccountBalance)
    {
        //setup
        Account account = new Account (accountBalance);
        Card card = new Card("1234-5678", "2345", account);
        AtmService atm = new AtmService(5000);
        atm.InsertCard(card);
        atm.EnterPin("2345");
        //when
        atm.GetBalance();
        //then
        int actualAccountBalance = atm.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);

    }
    /*
    public void WithdrawTest()
    {
        
    }
    /*
    public void DepositTest()
    {
        
    }
    /*
    public void EnsureAuthenticatedTest()
    {
        
    }*/
}