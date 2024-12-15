namespace c_sharp_delegate
{//hw ex.-3
    using c_sharp_delegate.Entity;
    using System;

    internal class Program
    {
        static void Main()
        {
            CreditCard card = new CreditCard
            (
                cardNumber: "1234567890123456",
                name: "John",
                surname: "Doe",
                patronymic: "Smith",
                PIN: "1234",
                expiryDate: new ExpiryDate(12, 2026),
                moneyBalnce: 100,
                maxLimit: 1001
            );

            // Делегати для обробки подій
            Action<double> accountReplenished = amount => Console.WriteLine($"Account replenished by {amount}. New balance: {card.MoneyBalance}");
            Action<double> fundsWithdrawn = amount => Console.WriteLine($"Funds withdrawn: {amount}. New balance: {card.MoneyBalance}");
            Action creditUsed = () => Console.WriteLine("Credit used.");
            Action creditLimitReached = () => Console.WriteLine("Credit limit reached.");
            Action<string> pinChanged = newPin => Console.WriteLine($"PIN changed to: {newPin}");

            // Виведення інформації про картку
            Console.WriteLine(card);

            // Зміна PIN-коду
            try
            {
                card.ChangePin("5678");
                pinChanged("5678");
                Console.WriteLine($"After changing PIN: {card}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Поповнення рахунку
            card += 200;
            accountReplenished(200);
            Console.WriteLine($"After deposit: {card}");

            // Зняття коштів з рахунку з перевіркою
            WithdrawFunds(card, 50, fundsWithdrawn, creditUsed, creditLimitReached);

            // Використання кредитних коштів з перевіркою
            WithdrawFunds(card, 300, fundsWithdrawn, creditUsed, creditLimitReached);

            // Досягнення ліміту заданої суми грошей з перевіркою
            WithdrawFunds(card, 900, fundsWithdrawn, creditUsed, creditLimitReached);

            
        }

        static void WithdrawFunds(CreditCard card, double amount, Action<double> fundsWithdrawn, Action creditUsed, Action creditLimitReached)
        {
            double remainingBalance = card.MoneyBalance - amount;

            if (remainingBalance >= 0)
            {
                card -= amount;
                fundsWithdrawn(amount);
                Console.WriteLine($"After withdrawal: {card}");
            }
            else if (remainingBalance + card.CreditLimit >= 0)
            {
                card -= amount;
                fundsWithdrawn(amount);
                creditUsed();
                Console.WriteLine($"After withdrawal (using credit): {card}");
            }
            else
            {
                creditLimitReached();
                Console.WriteLine("Credit limit reached. Transaction cannot be completed.");
            }
        }
    }
}
