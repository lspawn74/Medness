using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medness.Business.ValueObjects
{
	public class DialogueItem
	{
		/// <summary>Text of the dialogue.</summary>
		public readonly string text;

		/// <summary>Path to the audio data.</summary>
		public readonly string audioPath;

		public DialogueItem(string textValue, string audioPathValue)
		{
			ArgumentNullException.ThrowIfNull(textValue, nameof(textValue));
			ArgumentNullException.ThrowIfNull(audioPathValue, nameof(audioPathValue));
			text = textValue;
			audioPath = audioPathValue;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj is DialogueItem itemObj)
				return text == itemObj.text && audioPath == itemObj.audioPath;

			return false;
		}

		public override int GetHashCode()
		{
			return text.GetHashCode() ^ audioPath.GetHashCode();
		}
	}
}
