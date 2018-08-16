using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class TwitterTest
{
    [Test]
    [TestCase("I have new message.")]
    [TestCase("-1223232323232323233333323232323243355")]
    [TestCase(" ")]
    [TestCase(null)]
    public void GetMessage_AddListMessages_AddOneElementInListMessages(string message)
    {
        IRepoTwitter repoTwitter = new RepoTwitter();

        repoTwitter.GetMessage(message);

        FieldInfo field = typeof(RepoTwitter).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(f => f.FieldType == typeof(List<string>));

        List<string> messages = (List<string>)field.GetValue(repoTwitter);

        Assert.AreEqual(message, messages[0]);
    }
}

