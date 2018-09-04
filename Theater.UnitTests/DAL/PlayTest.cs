using NUnit.Framework;
using System;
using System.Collections.Generic;
using Theater.DAL;
using Theater.DAL.Entities;
using Theater.UnitTests.Repositories;

namespace Theater.UnitTests.DAL
{
    [TestFixture]
    public class PlayTest
    {
        private IList<int> _playIds;
        private TestPlayRepository _testPlayRepository;

        public PlayTest()
        {
             _playIds = new List<int>();
             _testPlayRepository = new TestPlayRepository();
        }

        [Test]
        public void User_Can_Add_New_Play_To_DB()
        {
            // Arrange
            var play = _testPlayRepository.InsertDummyPlay();

            // Act
            _playIds.Add(play.PlayId);
            var actual = _testPlayRepository.GetById(play.PlayId);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(play.Description, actual.Description);
            Assert.AreEqual(play.Title, actual.Title);
            Assert.AreEqual(play.ImagePath, actual.ImagePath);
            Assert.AreEqual(play.ScheduledTime, actual.ScheduledTime);
        }

        [Test]
        public void User_Can_Delete_Plays()
        {
            // Arrange
            Play play = _testPlayRepository.InsertDummyPlay();

            // Act
            _testPlayRepository.DeleteById(play.PlayId);

            // Assert
            var actual = _testPlayRepository.GetById(play.PlayId);
            Assert.IsNull(actual);
        }

         [Test]
         public void User_Can_Update_Plays()
         {
             // Arrange
             Play play = _testPlayRepository.InsertDummyPlay();
             
             // Act
             _playIds.Add(play.PlayId);
             play.Title = "UPDATED Title";
             _testPlayRepository.Update(play);

             // Assert
             var actual = _testPlayRepository.GetById(play.PlayId);
             Assert.AreNotEqual(actual.Title, play.Title);
             Assert.AreEqual(actual.Description, play.Description);
             Assert.AreEqual(actual.ScheduledTime, play.ScheduledTime);
         }

        [TearDown]
        public void CleanUp()
        {
            _testPlayRepository.Clean(_playIds);
        }
    }
}
