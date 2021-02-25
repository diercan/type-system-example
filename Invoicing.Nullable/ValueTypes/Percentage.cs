﻿namespace Invoicing
{
    public record Percentage
    {
        public decimal Value { get; }

        private Percentage(decimal percentage)
        {
            Value = percentage;
        }

        public static Percentage? Parse(decimal value)
        {
            if(value>=0 && value <= 100)
            {
                return new Percentage(value);
            }
            else
            {
                return null;
            }
        }

        public static readonly Percentage Default = new Percentage(0);
    }
}
