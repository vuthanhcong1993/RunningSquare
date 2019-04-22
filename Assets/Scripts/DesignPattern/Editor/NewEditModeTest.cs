using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewEditModeTest
{

    [Test]
    public void NewEditModeTestSimplePasses()
    {
        // Use the Assert class to test conditions.
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator NewEditModeTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }


   
}

[TestFixture]
public class AccountTest
{
    [Test]
    public void TransferFunds()
    {
        //Account source = new Account();
        //source.Deposit(200m);

        //Account destination = new Account();
        //destination.Deposit(150m);

        //source.TransferFunds(destination, 100m);

        //Assert.AreEqual(250m, destination.Balance);
        //Assert.AreEqual(100m, source.Balance);
    }
}
public class Account
{
    private decimal balance;

    public void Deposit(decimal amount)
    {
        balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        balance -= amount;
    }

    public void TransferFunds(Account destination, decimal amount)
    {
    }

    public decimal Balance
    {
        get { return balance; }
    }
}



