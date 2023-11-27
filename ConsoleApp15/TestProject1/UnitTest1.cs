using NUnit.Framework;
using System;
using System.IO;

[TestFixture]
public class TypingTestTests
{
    private TypingTest typingTest;

    [SetUp]
    public void SetUp()
    {
        typingTest = new TypingTest("Дядя Семён ехал из города домой. С ним была собака Жучка, Вдруг из леса выскочили волки. Жучка испугалась и прыгнула в сани. У дяди Семёна была хорошая лошадь. Она тоже испугалась и быстро помчалась по дороге. Деревня была близко. Показались огни в окнах. Волки отстали.",
            new ConsoleWrapper());
    }

    [Test]
    public void CanPrintTest()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader("John\n"));
            typingTest.PrintTest();
            Assert.IsNotEmpty(sw.ToString());
        }
    }

    [Test]
    public void TimerWorksCorrectly()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader("John\n")); 
            typingTest.PrintTest();
            Assert.That(sw.ToString(), Does.Contain("Таймер завершен!"));
        }
    }

    [Test]
    public void CorrectInputUpdatesIndexChar()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader("J")); 
            typingTest.PrintTest();
            Assert.AreEqual(typingTest.IndexChar, 1);
        }
    }

    [Test]
    public void IncorrectInputDoesNotUpdateIndexChar()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader("X")); 
            typingTest.PrintTest();
            Assert.AreEqual(typingTest.IndexChar, 0);
        }
    }

    [Test]
    public void InputEscapeKeyExitsTest()
    {
        using (StringWriter sw = new StringWriter())
        {
            Console.SetOut(sw);
            Console.SetIn(new StringReader($"{(char)27}")); 
            typingTest.PrintTest();
            Assert.Pass(); 
        }
    }
}