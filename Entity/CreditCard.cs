using System;
using System.Text.RegularExpressions;

namespace c_sharp_delegate.Entity
{
    internal class CreditCard
    {
        private string cardNumber;
        private string name;
        private string surname;
        private string patronymic;
        private ExpiryDate expiryDate;
        private string pin;

        public string CardNumber
        {
            get => cardNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 16)
                {
                    throw new ArgumentException("Card number must be 16 digits.");
                }
                cardNumber = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Name contains invalid characters.");
                }
                name = value;
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Username contains invalid characters.");
                }
                surname = value;
            }
        }

        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (!IsValidName(value))
                {
                    throw new ArgumentException("Patronymic contains invalid characters.");
                }
                patronymic = value;
            }
        }

        public ExpiryDate ExpiryDate
        {
            get => expiryDate;
            set => expiryDate = value ?? throw new ArgumentException("Expiry date cannot be null.");
        }

        public double MoneyBalance { get; set; }

        public double CreditLimit { get; set; }

        public CreditCard(string cardNumber, string name, string surname, string patronymic, string PIN, ExpiryDate expiryDate, double moneyBalnce, double maxLimit)
        {
            CardNumber = cardNumber ?? throw new ArgumentNullException(nameof(cardNumber));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
            pin = PIN ?? throw new ArgumentNullException(nameof(PIN));
            ExpiryDate = expiryDate ?? throw new ArgumentNullException(nameof(expiryDate));
            MoneyBalance = moneyBalnce;
            CreditLimit = maxLimit;
        }

        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }

        public static CreditCard operator +(CreditCard card, double money)
        {
            card.MoneyBalance += money;
            return card;
        }

        public static CreditCard operator -(CreditCard card, double money)
        {
            double remainingBalance = card.MoneyBalance - money;

            if (remainingBalance >= 0)
            {
                // Достатньо коштів на рахунку, зменшуємо баланс
                card.MoneyBalance -= money;
            }
            else if (remainingBalance + card.CreditLimit >= 0)
            {
                // Недостатньо коштів, але можна використовувати кредит
                double usedCredit = money - card.MoneyBalance;
                card.MoneyBalance -= money;
                card.CreditLimit -= usedCredit;

                // Перевірка чи використовуються кредитні кошти
                if (card.MoneyBalance < 0)
                {
                    Console.WriteLine("Credit used.");
                }

                // Перевірка чи досягнуто кредитного ліміту
                if (card.MoneyBalance + card.CreditLimit <= 0)
                {
                    throw new InvalidOperationException("Credit limit reached.");
                }
            }
            else
            {
                // Недостатньо коштів навіть з кредитним лімітом
                throw new InvalidOperationException("Credit limit reached.");
            }

            return card;
        }




        public void ChangePin(string newPin)
        {
            if (newPin.Length != 4 || !Regex.IsMatch(newPin, @"^\d{4}$"))
            {
                throw new ArgumentException("PIN must be exactly 4 digits.");
            }
            pin = newPin;
        }

        public override string ToString()
        {
            return $"Card: {CardNumber}, Name: {Name}, Surname: {Surname}, Patronymic: {Patronymic}, Expiry: {ExpiryDate}, Money: {MoneyBalance}, Credit limit: {CreditLimit}";
        }
    }

    
}
