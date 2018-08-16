using Moq;
using NUnit.Framework;

public class ClientTest
{
    [Test]
    [TestCase("I have new message.")]
    [TestCase("-1223232323232323233333323232323243355")]
    [TestCase(" ")]
    [TestCase(null)]
    public void SendMessageOfTweet_SendMessageInRepoTwintter_VirifyGetMessageRepoTwintter(string message)
    {
        Mock<IRepoTwitter> repoTwitter = new Mock<IRepoTwitter>();
        Mock<IWritter> writter = new Mock<IWritter>();

        var client = new Client(repoTwitter.Object, writter.Object);

        client.SendMessageOfTweet(message);

        repoTwitter.Verify(r => r.GetMessage(message), Times.Once);
    }

    [Test]
    [TestCase("I have new message.")]
    [TestCase("-1223232323232323233333323232323243355")]
    [TestCase(" ")]
    [TestCase(null)]
    public void PrintMessage_SentMessageWritter_CallMethodOnWritterWriteLine(string message)
    {
        Mock<IRepoTwitter> repoTwitter = new Mock<IRepoTwitter>();
        Mock<IWritter> writter = new Mock<IWritter>();

        var client = new Client(repoTwitter.Object, writter.Object);

        client.PrintMessage(message);

        writter.Verify(w => w.WriteLine(message), Times.Once);
    }
}

