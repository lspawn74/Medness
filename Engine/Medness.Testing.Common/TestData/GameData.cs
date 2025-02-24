﻿using Medness.Application.Entities;
using Medness.Business.Entities;
using Medness.Business.Enums;
using Medness.Testing.Common.Repositories;
using System.Collections.Generic;

namespace Medness.Testing.Common.TestData
{
	public class GameData
	{
		#region Objects test data
		public Game testGame;

		public GameData()
		{
			testGame = new Game(
				new Player(PlayerIdentity.Computer),
				new CharacterRepository(),
				new SceneRepository(),
				new ItemRepository(),
				new DialogueItemRepository());
		}
		#endregion

		#region Arguments test data
		public static IEnumerable<object[]> GetGameArgs()
		{
			yield return new object[] { null, new CharacterRepository(), new SceneRepository(), new ItemRepository(), new DialogueItemRepository() };
			yield return new object[] { new Player(PlayerIdentity.Computer), null, new SceneRepository(), new ItemRepository(), new DialogueItemRepository() };
			yield return new object[] { new Player(PlayerIdentity.Computer), new CharacterRepository(), null, new ItemRepository(), new DialogueItemRepository() };
			yield return new object[] { new Player(PlayerIdentity.Computer), new CharacterRepository(), new SceneRepository(), null, new DialogueItemRepository() };
			yield return new object[] { new Player(PlayerIdentity.Computer), new CharacterRepository(), new SceneRepository(), new ItemRepository(), null };
		}
		#endregion

	}
}
