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
            var play = _testPlayRepository.GetDummyPlay();

            // Act
            _testPlayRepository.Insert(play);
            _playIds.Add(play.Id);
            var actual = _testPlayRepository.GetById(play.Id);

            // Assert
            Assert.NotNull(actual);
            Assert.AreEqual(play.Description, actual.Description);
            Assert.AreEqual(play.Title, actual.Title);
            Assert.AreEqual(play.Image, actual.Image);
            Assert.AreEqual(play.ScheduledTime, actual.ScheduledTime);
        }

        [Test]
        public void User_Can_Delete_Plays()
        {
            // Arrange
            Play play = _testPlayRepository.GetDummyPlay();

            // Act
            //TODO: this insert should be inside GetDummyPlay()
            _testPlayRepository.Insert(play);
            _testPlayRepository.DeleteById(play.Id);

            // Assert
            var actual = _testPlayRepository.GetById(play.Id);
            Assert.IsNull(actual);
        }

         [Test]
         public void User_Can_Update_Plays()
         {
             // Arrange
             Play play = _testPlayRepository.GetDummyPlay();
             
             // Act
             _testPlayRepository.Insert(play);
             _playIds.Add(play.Id);
             play.Title = "UPDATED Title";
             _testPlayRepository.Update(play);

             // Assert
             var actual = _testPlayRepository.GetById(play.Id);
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
