using System;
using System.IO;
using Xunit;
using OrderBot;

namespace OrderBot.tests
{
    public class OrderBotTest
    {
        [Fact]
        public void Test1()
        {

        }
        [Fact]
        public void TestWelcome()
        {
            Session oSession = new Session("12345");
            String sInput = oSession.OnMessage("Hello!")[0];
            Assert.True(sInput.Contains("QuickBox"));
        }
        
        [Fact]
        public void TestMeatType()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");

            String sInput = oSession.OnMessage("chicken")[0];
            String sOutput =  $"What size of {sInput} do you want?";
            Assert.True(sOutput.Contains(sInput));
        }
    
        [Fact]
        public void TestSize()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");

            String sInput = oSession.OnMessage("large")[0];
            String sOutput =  $"Perfect! You have choosen {sInput} size. How much quanity(in kilograms)  you want ? ";
            Assert.True(sOutput.Contains(sInput));
        }

          [Fact]
        public void TestQuantity()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");
            oSession.OnMessage("large");

            String sInput = oSession.OnMessage("10")[0];
                               
            String sOutput =  $"Quantity choosen is {sInput} \n Whats your name?";
            Assert.True(sOutput.Contains(sInput));
        }
        
        [Fact]
        public void TestName()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");
            oSession.OnMessage("large");
            oSession.OnMessage("10");

            String sInput = oSession.OnMessage("aravind")[0];
                               
            String sOutput =  $"Thank you {sInput}. What's your contact number?";
            Assert.True(sOutput.Contains(sInput));
        }

         [Fact]
        public void TestPhone()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");
            oSession.OnMessage("large");
            oSession.OnMessage("10");
            oSession.OnMessage("aravind");

            String sInput = oSession.OnMessage("8989898989")[0];
                              
            String sOutput = $"Phone Number : {sInput}";
            Assert.True(sOutput.Contains(sInput));
        }

        [Fact]
        public void TestCardDetails()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");
            oSession.OnMessage("large");
            oSession.OnMessage("10");
            oSession.OnMessage("aravind");
            oSession.OnMessage("8989898989");

            String sInputCard = oSession.OnMessage("4512345678123456")[0];
         
            String sOutput = $"1. Card Details : {sInputCard}";
            Assert.True(sOutput.Contains(sInputCard));
        }
      
        [Fact]
        public void TestCardDetailsCVV()
        {
            Session oSession = new Session("12345");
            oSession.OnMessage("Hello!");
            oSession.OnMessage("chicken");
            oSession.OnMessage("large");
            oSession.OnMessage("10");
            oSession.OnMessage("aravind");
            oSession.OnMessage("8989898989");
            oSession.OnMessage("4512345678123456");

            String sInputCardCVV = oSession.OnMessage("123")[0];
         
            String sOutput = $"1. CVV : {sInputCardCVV}";
            Assert.True(sOutput.Contains(sInputCardCVV));
        }
    }
}
