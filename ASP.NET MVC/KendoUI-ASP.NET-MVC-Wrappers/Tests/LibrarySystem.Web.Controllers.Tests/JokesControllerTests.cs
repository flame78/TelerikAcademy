//namespace LibrarySystem.Web.Controllers.Tests
//{
//    using Moq;

//    using LibrarySystem.Data.Models;
//    using LibrarySystem.Services.Data;
//    using LibrarySystem.Web.Infrastructure.Mapping;
//    using LibrarySystem.Web.ViewModels.Home;

//    using NUnit.Framework;

//    using TestStack.FluentMVCTesting;

//    [TestFixture]
//    public class JokesControllerTests
//    {
//        [Test]
//        public void ByIdShouldWorkCorrectly()
//        {
//            var autoMapperConfig = new AutoMapperConfig();
//            autoMapperConfig.Execute(typeof(BooksController).Assembly);
//            const string JokeContent = "SomeContent";
//            var jokesServiceMock = new Mock<IJokesService>();
//            jokesServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
//                .Returns(new Joke { Content = JokeContent, Category = new JokeCategory { Name = "asda" } });
//            var controller = new BooksController(jokesServiceMock.Object);
//            controller.WithCallTo(x => x.ById("asdasasd"))
//                .ShouldRenderView("ById")
//                .WithModel<BookViewModel>(
//                    viewModel =>
//                        {
//                            Assert.AreEqual(JokeContent, viewModel.Content);
//                        }).AndNoModelErrors();
//        }
//    }
//}
