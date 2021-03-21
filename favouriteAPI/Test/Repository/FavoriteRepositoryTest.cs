using favouriteAPI.Models;
using favouriteAPI.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Test.InfraSetup;
using Xunit;

namespace Test.Repository
{
    public class FavoriteRepositoryTest
    {
        [TestCaseOrderer("Test.PriorityOrder", "Test")]
        public class FavRepoTest : IClassFixture<FavoriteDbFixture>
        {
            FavoriteDbFixture fixture;
            private readonly IFavouriteRepo repository;

            public FavRepoTest(FavoriteDbFixture _fixture)
            {
                this.fixture = _fixture;
                repository = new FavouriteRepo(fixture.context);
            }

            [Fact, TestPriority(2)]
            public void DeleteFavouriteShouldReturnTrue()
            {
                string Id = "Shivansh";
                var actual = repository.DeleteFavourite(Id);
                Assert.True(actual);
            }
            [Fact, TestPriority(1)]
            public void GetFavouritesShouldReturnAList()
            {
              

                var actual = repository.GetFavourites();

                Assert.IsAssignableFrom<List<Favourite>>(actual);
                Assert.NotEmpty(actual);
            }

            //[Fact, TestPriority(3)]
            //public void GetFavouriteShouldReturnFavourite()
            //{
            //    string id = "Shivansh";
            //    var actual = repository.GetFavourite(id);

            //    Assert.NotNull(actual);
            //    Assert.IsAssignableFrom<List<Favourite>>(actual);
            //    Assert.NotEmpty(actual);
            //}
        }
    }
}
