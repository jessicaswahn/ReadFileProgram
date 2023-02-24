
using NUnit.Framework.Internal;
using ReadFileProgram;

namespace ReadFileProgramTest
{
    public class Tests
    {
        private Program _program;


        [SetUp]
        public void Setup()
        {
            _program = new Program();
        }

        [Test]
        public void ReturnsTrueWhenPathIsCorrectAndFileExist()
        {
            // Arrange
            var path = new string[] { "C:\\Projects\\ReadFileProgram\\ReadFileProgram\\bin\\Debug\\net6.0\\test.txt" };

            // Act
            var result = _program.ValidArgument(path);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void ReturnsFalseWhenFileIsNotExist()
        {
            // Arrange
            var path = new string[] { "C:\\Projects\\ReadFileProgram\\ReadFileProgram\\bin\\Debug\\net6.0\\test4.txt" };

            // Act
            var result = _program.ValidArgument(path);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnsFalseWhenArgumentIsMissing()
        {
            // Arrange
            var paths = new string[] { };

            // Act
            var result = _program.ValidArgument(paths);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ReturnsExpectedConsoleOutline()
        {
            StringWriter sw = new StringWriter();

            // Arrange
            var path = new string[] { "C:\\Projects\\ReadFileProgram\\ReadFileProgram\\bin\\Debug\\net6.0\\test.txt" };
            Console.SetOut(sw);

            // Act
            _program.ReadFile(path);

            string expected = "Found 5 'test' in the file named test.txt\r\n";
            Assert.That(sw.ToString(), Is.EqualTo(expected.ToString()));

        }


    }
}