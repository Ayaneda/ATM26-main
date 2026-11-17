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
        
    }

    public void EjectCardTest()
    {
        
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