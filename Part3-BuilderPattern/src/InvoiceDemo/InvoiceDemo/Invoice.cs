using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceDemo
{
    public class Invoice
    {

        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string? CustomerPhone { get; }

        public string BillingStreet { get; }
        public string BillingCity { get; }
        public string BillingState { get; }
        public string BillingZipCode { get; }
        public string BillingCountry { get; }

        public string ShippingStreet { get; }
        public string ShippingCity { get; }
        public string ShippingState { get; }
        public string ShippingZipCode { get; }
        public string ShippingCountry { get; }

        public DateTime OrderDate { get; }
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }
        public decimal TaxAmount { get; }
        public decimal TotalAmount { get; }

        private Invoice(InvoiceBuilder b)
        {
            InvoiceId = b.InvoiceIdValue;
            CustomerName = b.CustomerNameValue;
            CustomerEmail = b.CustomerEmailValue;
            CustomerPhone = b.PhoneValue;

            BillingStreet = b.BStreet!;
            BillingCity = b.BCity!;
            BillingState = b.BState!;
            BillingZipCode = b.BZip!;
            BillingCountry = b.BCountry!;

            // shipping = billing if not given
            ShippingStreet = b.SStreet ?? BillingStreet;
            ShippingCity = b.SCity ?? BillingCity;
            ShippingState = b.SState ?? BillingState;
            ShippingZipCode = b.SZip ?? BillingZipCode;
            ShippingCountry = b.SCountry ?? BillingCountry;

            OrderDate = b.OrderDateValue;
            PaymentMethod = b.PaymentMethodValue!;
            Currency = b.CurrencyValue!;
            SubTotal = b.SubTotalValue!.Value;
            DiscountAmount = b.DiscountValue;
            TaxAmount = b.TaxValue;
            TotalAmount = SubTotal - DiscountAmount + TaxAmount;
        }

        // The Builder is nested so it can use the private constructor
        public sealed class InvoiceBuilder
        {
            // required (set in the builder constructor)
            internal readonly string InvoiceIdValue;
            internal readonly string CustomerNameValue;
            internal readonly string CustomerEmailValue;

            // optional
            internal string? PhoneValue;
            internal decimal DiscountValue;
            internal decimal TaxValue;
            internal string? SStreet, SCity, SState, SZip, SCountry;

            // required (checked in Build)
            internal string? BStreet, BCity, BState, BZip, BCountry;
            internal DateTime OrderDateValue = DateTime.Today;
            internal string? PaymentMethodValue, CurrencyValue;
            internal decimal? SubTotalValue;

            public InvoiceBuilder(string invoiceId, string customerName, string customerEmail)
            {
                if (string.IsNullOrWhiteSpace(invoiceId))
                    throw new ArgumentException("InvoiceId is required");
                if (string.IsNullOrWhiteSpace(customerName))
                    throw new ArgumentException("CustomerName is required");
                if (string.IsNullOrWhiteSpace(customerEmail))
                    throw new ArgumentException("CustomerEmail is required");

                InvoiceIdValue = invoiceId;
                CustomerNameValue = customerName;
                CustomerEmailValue = customerEmail;
            }

            public InvoiceBuilder WithPhone(string phone)
            {
                PhoneValue = phone;
                return this;
            }

            public InvoiceBuilder WithBillingAddress(
                string street, string city, string state, string zip, string country)
            {
                BStreet = street; BCity = city; BState = state; BZip = zip; BCountry = country;
                return this;
            }

            public InvoiceBuilder WithShippingAddress(
                string street, string city, string state, string zip, string country)
            {
                SStreet = street; SCity = city; SState = state; SZip = zip; SCountry = country;
                return this;
            }

            public InvoiceBuilder OrderedOn(DateTime date)
            {
                OrderDateValue = date;
                return this;
            }

            public InvoiceBuilder PaidBy(string paymentMethod)
            {
                PaymentMethodValue = paymentMethod;
                return this;
            }

            public InvoiceBuilder InCurrency(string currency)
            {
                CurrencyValue = currency;
                return this;
            }

            public InvoiceBuilder WithSubTotal(decimal subTotal)
            {
                SubTotalValue = subTotal;
                return this;
            }

            public InvoiceBuilder WithDiscount(decimal discount)
            {
                DiscountValue = discount;
                return this;
            }

            public InvoiceBuilder WithTax(decimal tax)
            {
                TaxValue = tax;
                return this;
            }

            public Invoice Build()
            {
                if (string.IsNullOrWhiteSpace(BStreet) || string.IsNullOrWhiteSpace(BCity) ||
                    string.IsNullOrWhiteSpace(BState) || string.IsNullOrWhiteSpace(BZip) ||
                    string.IsNullOrWhiteSpace(BCountry))
                    throw new InvalidOperationException("Billing address is required (call WithBillingAddress)");

                if (string.IsNullOrWhiteSpace(PaymentMethodValue))
                    throw new InvalidOperationException("PaymentMethod is required (call PaidBy)");

                if (string.IsNullOrWhiteSpace(CurrencyValue))
                    throw new InvalidOperationException("Currency is required (call InCurrency)");

                if (SubTotalValue is null)
                    throw new InvalidOperationException("SubTotal is required (call WithSubTotal)");

                if (SubTotalValue < 0 || DiscountValue < 0 || TaxValue < 0)
                    throw new InvalidOperationException("Amounts cannot be negative");

                if (DiscountValue > SubTotalValue)
                    throw new InvalidOperationException("Discount cannot be bigger than SubTotal");

                return new Invoice(this);
            }
        }
    }


}
