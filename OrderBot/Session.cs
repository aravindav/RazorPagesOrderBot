using System;

namespace OrderBot
{
    public class Session
    {
        private enum State
        {
            WELCOMING, MEAT_TYPE, MEAT_SIZE, QUANTITY, PHONE, NAME, THANKYOU, PAYMENT, CVV, ORDERCONFIRM
        }

        private State nCur = State.WELCOMING;
        private Order oOrder;
        public string Name {get; set;}

        public Session(string sPhone)
        {
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }

        public List<String> OnMessage(String sInMessage)
        {
            List<String> aMessages = new List<string>();
            switch (this.nCur)
            {
                case State.WELCOMING:
                    aMessages.Add("Hello! Welcome to QuickBox! A B2B ordering platforms for restaurants");
                    aMessages.Add("Select the meat type - chicken , beef, lamb ");
                    this.nCur = State.MEAT_TYPE;
                    break;

                case State.MEAT_TYPE:
                    this.oOrder.MeatType = sInMessage;
                    this.oOrder.Save();
                    aMessages.Add("What size of  " + this.oOrder.MeatType + " do you want?");
                    this.nCur = State.MEAT_SIZE;
                    break;
                case State.MEAT_SIZE:
                    this.oOrder.Size = sInMessage;
                    aMessages.Add("Perfect! You have choosen " +this.oOrder.Size +" size. How much quanity(in kilograms)  you want ?  \n");
                    this.nCur = State.QUANTITY;
                    break;
                case State.QUANTITY:
                    this.oOrder.Quantity = sInMessage;

                    aMessages.Add("Quantity choosen is "+this.oOrder.Quantity+" \n Whats your name?");
                    this.nCur = State.NAME;
                    break;
                case State.NAME:
                    this.oOrder.Name = sInMessage;
                    aMessages.Add($"Thank you {this.oOrder.Name}. What's your contact number?");
                    this.nCur = State.THANKYOU;
                    break;
                
                case State.THANKYOU:
                    aMessages.Add("Please confirm the order items and type \"pay\":");
                    aMessages.Add($"1. Meat Type : {this.oOrder.MeatType} ");
                    aMessages.Add($"2. Size : {this.oOrder.Size}");
                    aMessages.Add($"2. Quantity : {this.oOrder.Quantity}");
                    aMessages.Add("\nYour Personal Details\n");
                    aMessages.Add($"Name : {this.oOrder.Name}\n");
                    aMessages.Add($"Phone Number : {this.oOrder.Phone}\n");

                    this.nCur = State.PAYMENT;
                    break;
                case State.PAYMENT:
                    aMessages.Add("Please enter the credit card details:");
                    this.nCur = State.CVV;
                    break;
                case State.CVV:
                    aMessages.Add("Please enter the credit card cvv details:");
                    this.nCur = State.ORDERCONFIRM;
                    break;
                case State.ORDERCONFIRM:
                    DateTime now = DateTime.Now;
                    DateTime orderConfirmTime = now.AddMinutes(30);
                    aMessages.Add("Thank you for ordering with QuickBox!");
                    aMessages.Add($"Your order will be delivered at {orderConfirmTime.ToString("F")}");
                    break;
            }
            aMessages.ForEach(delegate (String sMessage)
            {

                System.Diagnostics.Debug.WriteLine(sMessage);
            });
            return aMessages;
        }

    }
}
