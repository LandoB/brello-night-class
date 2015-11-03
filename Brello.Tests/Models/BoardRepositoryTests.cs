using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brello.Models;
using Moq;
using System.Data.Entity;

namespace Brello.Tests.Models
{
    [TestClass]
    public class BoardRepositoryTests
    {
        [TestMethod]
        public void BoardServiceEnsureICanCreateInstance()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board = new BoardRepository(some_context.Object);
            Assert.IsNotNull(board);
        }
        
        [TestMethod]
        public void BoardServiceEnsureICanAddAList()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            BrelloList list = new BrelloList();
            Board board = new Board();

            bool actual = board_repo.AddList(board, list);

            Assert.AreEqual(1, board_repo.GetAllLists().Count);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BoardServiceEnsureThereAreZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            Board board = new Board();
            int expected = 0;
            int actual = board_repo.GetAllLists().Count;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected, board_repo.GetAllLists(board));
        }

        // These tests are telling su to start looking at how to define CRUD operations for Boards
        // Why? Because a List cannot exists without a Board
        [TestMethod]
        public void BoardRepositoryEnsureABoardHasZeroLists()
        {
            var some_context = new Mock<BoardContext>();
            BoardRepository board_repo = new BoardRepository(some_context.Object);
            Board board = new Board();
            int expected = 0;
            Assert.AreEqual(expected, board_repo.GetAllLists(board).Count);
        }

        [TestMethod]
        public void BoardRepositoryCanGetABoard()
        {

        }

        [TestMethod]
        public void BoardReporsitoryCanCreateBoard()
        {
            var mock_context = new Mock<BoardContext>();
            var mock_boards = new Mock<DbSet<Board>>();

            // This is one way to call an Object underneath a Mock:
            //mock_context.Object.Boards();

            // This is a better way to do it:
            mock_context.Setup(m => m.Boards).Returns(mock_boards.Object);

            BoardRepository board_repo = new BoardRepository(mock_context.Object);
            string title = "My Awesome Board";
            ApplicationUser owner = new ApplicationUser();
            Board added_board = board_repo.CreateBoard(title, owner);
            Assert.IsNotNull(added_board);

            mock_boards.Verify(m => m.Add(It.IsAny<Board>()));
            mock_context.Verify(x => x.SaveChanges(), Times.Once());
        }
        
    }
}
