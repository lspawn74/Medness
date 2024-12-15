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
			ICharacterRepository characterRepository,
			ISceneRepository sceneRepository,
			IItemRepository itemRepository,
			IDialogueItemRepository dialogueItemRepository)
		{
			Assert.ThrowsException<ArgumentNullException>(() => new Game(player, characterRepository, sceneRepository, itemRepository, dialogueItemRepository));
		}
	}
}
