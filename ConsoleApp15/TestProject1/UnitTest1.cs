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
        typingTest = new TypingTest("���� ���� ���� �� ������ �����. � ��� ���� ������ �����, ����� �� ���� ��������� �����. ����� ���������� � �������� � ����. � ���� ����� ���� ������� ������. ��� ���� ���������� � ������ ��������� �� ������. ������� ���� ������. ���������� ���� � �����. ����� �������.",
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
            Assert.That(sw.ToString(), Does.Contain("������ ��������!"));
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