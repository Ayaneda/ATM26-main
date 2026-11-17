namespace ATM.ATM.Tests;

using Xunit;
using Xunit.Sdk;

public class AccountTest
{
    [Fact]
    public void AccountHasBalanceTest()
    {
        int testBalanceVal = 5000;
        Account account = new Account(testBalanceVal);
        // Assert.True(account.Balance == 6000, "Expected 6000 but got " + account.Balance);
        Assert.Equal(testBalanceVal, account.Balance);
    }

    [Theory]
    [InlineData(5000,5000)]
    [InlineData(1000, 1000)]
    [InlineData(8000, 8000)]
    [InlineData(12000, 12000)]
    public void GetBalanceTest(int accountBalance, int expectedAccountBalance)
    {
        //Setup
        Account account = new Account(accountBalance);
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        //When
        atm.GetBalance();
        //Then
        int actualAccountBalance = account.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);
        
    }

    [Theory]
    [InlineData(5000, 5000, 0)]
    [InlineData(5000, 100, 4900)]
    [InlineData(5000, 6000, 5000)] // om jag tar ut..
    [InlineData(5000, 0, 5000)]
    [InlineData(5000, -1000, 5000)] //Withraw with negativ will add money instead
    [InlineData(5000, 75, 5000)]   //it shouldnt allow give coins as money(only bill)
    public void WithdrawTest(int accountBalance, int withdraw, int expectedAccountBalance)
    {
        // Setup
        Account account = new Account(accountBalance);
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        // When
        atm.Withdraw(withdraw);
        // Then
        int actualAccountBalance = account.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);
    }

    [Theory]
    [InlineData(5000, 5000, 10000)]
    [InlineData(5000, 100, 5100)]
    [InlineData(5000, 6000, 11000)]
    [InlineData(5000, 0, 5000)]
    [InlineData(5000, -1000, 5000)] //Deposit with negativ will remove money instead
    [InlineData(5000, 75, 5000)]   //it shouldnt allow give coins as money(only bill)
    public void DepositTest(int accountBalance, int deposit, int expectedAccountBalance)
    {
        // Setup
        Account account = new Account(accountBalance);
        Card card = new Card("1234-5678", "1234", account);
        AtmService atm = new AtmService(10000);
        atm.InsertCard(card);
        atm.EnterPin("1234");
        // When
        atm.Deposit(deposit);
        // Then
        int actualAccountBalance = account.GetBalance();
        Assert.Equal(expectedAccountBalance, actualAccountBalance);
    }
}
