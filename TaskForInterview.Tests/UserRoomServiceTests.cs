using MainProject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services;
using System.Security.Claims;
using System.Security.Principal;

namespace TaskForInterview.Tests
{
    public class UserRoomServiceTests
    {
        private UserRoomService _userRoomService;
        private UserRoomRepository _userRoomRepository;

        public UserRoomServiceTests()
        {
            var identity = new GenericIdentity("15", "userId");
            var contextUser = new ClaimsPrincipal(identity); //add claims as needed

            var httpContext = new DefaultHttpContext()
            {
                User = contextUser
            };

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            _userRoomRepository = new UserRoomRepository();
            _userRoomService = new UserRoomService(_userRoomRepository, new PlanningPokerIdentity(new HttpContextAccessor()));            
        }

        [Fact]
        public async void JoinRoomTest()
        {
            int roomId = 10;

            Assert.Null(_userRoomRepository.GetUserRoomByRoomId(roomId));

            await _userRoomService.JoinRoomAsync(roomId);

            Assert.NotNull(_userRoomRepository.GetUserRoomByRoomId(roomId));
        }

        [Fact]
        public async void LeaveRoomTest()
        {
            int roomId = 15;

            Assert.Null(_userRoomRepository.GetUserRoomByRoomId(roomId));
            await _userRoomService.JoinRoomAsync(roomId);
            await _userRoomService.LeaveRoomAsync(roomId);
            Assert.Null(_userRoomRepository.GetUserRoomByRoomId(roomId));
        }
    }
}