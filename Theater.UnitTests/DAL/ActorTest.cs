using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Theater.DAL;
using Theater.DAL.Entities;

namespace Theater.UnitTests.DAL
{
    [TestFixture]
    public class ActorTest
    { 
        [Test]
        public void User_Can_Get_List_Of_All_Actors()
        {
            //Arrange
            IList<Actor> ActorList;

            //Act
            using (var _unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                ActorList = _unitOfWork.ActorRepository.GetAll();
            }

            //Assert
            Assert.NotNull(ActorList);
            Assert.IsNotEmpty(ActorList);
        }

    }
}
