Planning for Tests for existing Code.

The first thing I do is to check all the methods/functions in the code, minimizing them inside VisualStudio to get a quicker overview for what kind of method I want to test and what methods actually are worth testing for this assignment.

What is critical to test?

 1. Method TransferMoney() is a very important part to test, so that the money goes to the correct user and correct Bank-account.
    what can go wrong? Well you might be able to send more money than you actually have? especially in this fictional BankApplication.
    The accounts that receive the "money" must be checked so it that the transfer actually happened.
    
 2. I also want to test the CurrencyRates so it calculates correctly when the used Rate has been changed or not changed.
    What can go wrong? Well if the rate isnt updated correctly in the system, then you either loose money or earn money. and the same for the recipient.
    Ofcourse we want the rate to be up to date and working.
    
 3. I want to test the InternationalTransfer Method so it Calculates correctly with the CurrencyRate that is Active.
    I believe this is a crucial part when doing international transfers. 
    
   
Let the testing begin!
