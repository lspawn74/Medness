using Medness.Application.Entities;
using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Testing.Common.TestData;
using System;

namespace Medness.UnitTesting
{
	[TestClass]
	public class TestGame
	{
		[TestMethod]
		[DynamicData(nameof(GameData.GetGameArgs), typeof(GameData), DynamicDataSourceType.Method)]
		public void TestGameNull(
			Player player,
			IRepository<Character> characterRepository,
			IRepository<Scene> sceneRepository,
			IRepository<Item> itemRepository,
			IRepository<DialogueItem> dialogueItemRepository)
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Game(player, characterRepository, sceneRepository, itemRepository, dialogueItemRepository));
		}
	}
}
