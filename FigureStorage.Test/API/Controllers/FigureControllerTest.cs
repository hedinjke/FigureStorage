using System;
using System.Threading.Tasks;
using AutoMapper;
using FigureStorage.API.Controllers;
using FigureStorage.API.Models;
using FigureStorage.DTO;
using FigureStorage.Models;
using FigureStorage.Repo.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FigureStorage.Test.API.Controllers
{
    public class FigureControllerTest
    {
        private void AssertOkResponse(IActionResult result, Figure figure)
        {
            Assert.IsType<OkObjectResult>(result);

            var ok = (OkObjectResult) result;
            Assert.IsType<FigurePostResponse>(ok.Value);

            var response = (FigurePostResponse) ok.Value;
            Assert.Equal(figure.Id, response.Id);
            Assert.False(response.Id == default);
        }

        [Fact]
        public async void PostValidFigureReturnsOkWithId()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();
            var figure1 = new Rectangle(20) as Figure;
            var figure2 = new Triangle(10, 12, 8) as Figure;

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            mockRepo.Setup(e => e.AddAsync(figure1)).Callback(() => figure1.Id = new Random().Next());
            var result1 = await controller.Post(figure1);

            mockRepo.Setup(e => e.AddAsync(figure2)).Callback(() => figure2.Id = new Random().Next());
            var result2 = await controller.Post(figure2);

            AssertOkResponse(result1, figure1);
            AssertOkResponse(result2, figure2);
        }

        [Fact]
        public async void PostNothingReturnsBadRequestMessage()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            var result = await controller.Post(null);

            Assert.IsType<BadRequestObjectResult>(result);
            var response = (BadRequestObjectResult) result;

            Assert.IsType<BadRequestMsgResponse>(response.Value);
            var msgResponse = (BadRequestMsgResponse) response.Value;

            Assert.Equal("Bad request. Can't create any figure from that.", msgResponse.Message);
        }

        [Fact]
        public async void PostNotValidFigureReturnsBadRequestMessage()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();
            Figure figure = new Rectangle {Radius = -15};

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            var result = await controller.Post(figure);

            Assert.IsType<BadRequestObjectResult>(result);
            var response = (BadRequestObjectResult) result;

            Assert.IsType<BadRequestMsgResponse>(response.Value);
            var msgResponse = (BadRequestMsgResponse) response.Value;

            Assert.Equal("Figure is not valid.", msgResponse.Message);
        }

        [Fact]
        public async void GetFigureFoundsRectangle()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();
            var id = 10;
            var rectangle = new Rectangle(10);

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            mockRepo.Setup(e => e.GetAsync(id))
                    .Returns(() => Task.Run<Figure>(() => rectangle));

            mockMapper.Setup(e => e.Map<FigureDTO>(rectangle))
                      .Returns(new RectangleDTO());

            var result = await controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
            var response = (OkObjectResult) result;

            Assert.IsAssignableFrom<FigureDTO>(response.Value);
            Assert.IsType<RectangleDTO>(response.Value);
        }
        
        [Fact]
        public async void GetFigureFoundsTriangle()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();
            var id = 10;
            var triangle = new Triangle(10,8,13);

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            mockRepo.Setup(e => e.GetAsync(id))
                    .Returns(() => Task.Run<Figure>(() => triangle));

            mockMapper.Setup(e => e.Map<FigureDTO>(triangle))
                      .Returns(new TriangleDTO());

            var result = await controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
            var response = (OkObjectResult) result;

            Assert.IsAssignableFrom<FigureDTO>(response.Value);
            Assert.IsType<TriangleDTO>(response.Value);
        }

        [Fact]
        public async void GetFigureFoundsNothing()
        {
            var mockRepo = new Mock<IFigureRepository>();
            var mockMapper = new Mock<IMapper>();
            var id = 10;

            var controller = new FigureController(mockRepo.Object, mockMapper.Object);

            mockRepo.Setup(e => e.GetAsync(id))
                    .Returns(() => Task.Run(() => (Figure) null));

            var result = await controller.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}