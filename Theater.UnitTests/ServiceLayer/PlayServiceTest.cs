﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL.DTO;
using Theater.DAL.Entities;
using Theater.DAL.Views;
using Theater.Service.PlayService;
using Theater.UnitTests.Repositories;

namespace Theater.UnitTests.ServiceLayer
{
    [TestFixture]
    class PlayServiceTest
    {
        private IList<int> _playIds;
        private TestPlayRepository _testPlayRepository;
        private PlayService _playService;

        public PlayServiceTest()
        {
            _testPlayRepository = new TestPlayRepository();
            _playService = new PlayService();
            _playIds = new List<int>();
        }

        [Test]
        public void User_Can_Get_All_Plays()
        {
            //Arrange
            IList<Play> dummyPlays = new List<Play>();
            for (int i=0; i<5; i++)
            {
                dummyPlays.Add(_testPlayRepository.InsertDummyPlay());
                _playIds.Add(dummyPlays[i].PlayId);
            }
            IList<PlayView> allPlays;

            //Act
            allPlays = _playService.GetAllPlays();

            //Assert
            Assert.IsNotEmpty(allPlays);
            Assert.IsNotNull(allPlays);
        }

        [Test]
        public void User_Can_Get_Play_By_Id()
        {
            //Arrange
            var play = _testPlayRepository.InsertDummyPlay();

            //Act
            var actual = _playService.GetPlay(play.PlayId);
            _playIds.Add(play.PlayId);

            //Assert
            Assert.NotNull(actual);
            Assert.AreEqual(play.PlayId, actual.PlayId);
            Assert.AreEqual(play.Description, actual.Description);
        }

        [Test]
        public void User_Can_Add_New_Play()
        {
            //Arrange
            var play = new PlayWithActors
            {
                Description = "description",
                Title = "The title",
                StartDate = DateTime.Today,
                ImageVirtualPath = "whatever",
                ImageType = "whateverrr",
                ImagePath = "gghjkjbj"
            };

            //Act
            var playId = _playService.CreatePlay(play);
            _playIds.Add(playId);
            var actual = _testPlayRepository.GetById(playId);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(playId, actual.PlayId);
            Assert.AreEqual(play.Title, actual.Title);
        }

        [Test]
        public void User_Can_Delete_By_Id()
        {
            //Arrange
            var play = _testPlayRepository.InsertDummyPlay();

            //Act
            _playService.DeletePlayById(play.PlayId);
            var actual = _testPlayRepository.GetById(play.PlayId);

            //Assert
            Assert.IsNull(actual);
        }

        [TearDown]
        public void CleanUp()
        {
            _testPlayRepository.Clean(_playIds);
        }
    }
}
