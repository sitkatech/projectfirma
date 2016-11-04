using System;
using System.IO;
using NUnit.Framework;

namespace LtInfo.Common
{
    [TestFixture]
    public class FileUtilityTest
    {
        private readonly string _testFileName = String.Format("UnitTestFileName-{0}.txt", Guid.NewGuid());
        private readonly string _tempDirFullName = Path.Combine(Path.GetTempPath(), string.Format("TestTemp{0}", Guid.NewGuid()));
        private DirectoryInfo _tempDir;

        [SetUp]
        public void TheSetup()
        {
            _tempDir = Directory.CreateDirectory(_tempDirFullName);
        }

        [TearDown]
        public void TheTearDown()
        {
            _tempDir.Delete(true);
        }

        [Test]
        public void GivenFileInCurrentDirectoryThenCanFind()
        {
            var fileToWriteTo = new FileInfo(Path.Combine(_tempDir.FullName, _testFileName));
            FileUtility.StringToFile("test", fileToWriteTo);

            var foundFile = FileUtility.FirstMatchingFileUpDirectoryTree(_tempDir, fileToWriteTo.Name);
            Assert.That(foundFile.FullName, Is.EqualTo(fileToWriteTo.FullName), "Should have found file");
        }

        [Test]
        public void GivenFileUpLevelsThenCanFind()
        {
            var fileToWriteTo = new FileInfo(Path.Combine(_tempDir.FullName, _testFileName));
            FileUtility.StringToFile("test", fileToWriteTo);

            var tempDirSub1 = _tempDir.CreateSubdirectory("Sub1");

            var foundFile = FileUtility.FirstMatchingFileUpDirectoryTree(tempDirSub1, fileToWriteTo.Name);
            Assert.That(foundFile.FullName, Is.EqualTo(fileToWriteTo.FullName), "Should have found file");
        }

        [Test]
        public void GivenFileUpAndDownLevelsThenCanFind()
        {
            var tempDirSub1 = _tempDir.CreateSubdirectory("Sub1");
            var fileToWriteTo = new FileInfo(Path.Combine(tempDirSub1.FullName, _testFileName));
            FileUtility.StringToFile("test", fileToWriteTo);

            var tempDirSub2 = tempDirSub1.CreateSubdirectory("Sub2");

            var foundFile = FileUtility.FirstMatchingFileUpDirectoryTree(tempDirSub2, Path.Combine(tempDirSub1.Name, fileToWriteTo.Name));
            Assert.That(foundFile.FullName, Is.EqualTo(fileToWriteTo.FullName), "Should have found file");
        }

        [Test]
        public void GivenFileNotThereThenThrowException()
        {
            var fileFullNameRelativePath = string.Format("MyNonExistentTestFile{0}.txt", Guid.NewGuid());
            var exception = Assert.Catch(() => FileUtility.FirstMatchingFileUpDirectoryTree(_tempDir, fileFullNameRelativePath), "Should throw if can't find file");
            Assert.That(exception.Message, Is.StringContaining(_tempDir.FullName), "Exception should mention the directory");
            Assert.That(exception.Message, Is.StringContaining(fileFullNameRelativePath), "Exception should mention the file name");
        }
    }
}