using favouriteAPI.Models;
using favouriteAPI.Repository;
using System;
using System.Collections.Generic;
using Test.InfraSetup;
using Xunit;

namespace Test.Controller
{
    public class FavoriteControllerTest
    {
        [TestCaseOrderer("Test.PriorityOrder", "Test")]
        public class FavControllerTest : IClassFixture<ControllerDbFixture>
        {
            ControllerDbFixture fixture;
            private readonly IFavouriteRepo repository;

            public FavControllerTest(ControllerDbFixture _fixture)
            {
                fixture = _fixture;
                repository = new FavouriteRepo(fixture.context);
            }

            [Fact, TestPriority(3)]
            public void DeleteFavoriteShouldReturnTrue()
            {
                string userId = "Shivansh";
                //string Title = "Lords of the ring2";

                var actual = repository.DeleteFavourite(userId);
                Assert.True(actual);
            }
            [Fact, TestPriority(1)]
            public void GetFavoriteShouldReturnAList()
            {
                string userId = "Shivansh";
                var actual = repository.GetFavourite(userId);

                Assert.IsAssignableFrom<List<Favourite>>(actual);
                Assert.NotEmpty(actual);
            }

            [Fact, TestPriority(2)]
            public void GetFavroitesShouldReturnAll()
            {
                var actual = repository.GetFavourites();

                Assert.NotNull(actual);
                Assert.IsAssignableFrom<List<Favourite>>(actual);
                Assert.NotEmpty(actual);
            }
        }
         internal class TestPriorityAttribute : Attribute
        {
            private readonly int value;
            public TestPriorityAttribute(int value)
            {
                this.value = value;
            }
        }
    }
}
