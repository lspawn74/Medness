﻿using Medness.Business.Entities;

namespace Medness.Business.Event.Args
{
	public class CharacterEventArgs : EventArgs
    {
        public readonly Character Character;

        public CharacterEventArgs(Character character)
        {
            ArgumentNullException.ThrowIfNull(character, nameof(character));
            Character = character;
        }
    }
}
