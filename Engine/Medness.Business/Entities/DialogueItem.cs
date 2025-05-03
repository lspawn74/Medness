using Medness.Business.Event.Args;
using Medness.Business.Interfaces;
using Medness.Business.Resources;
using Medness.Business.ValueObjects;

namespace Medness.Business.Entities
{
	public class DialogueItem
    {
        /// <summary>Id of the dialogue.</summary>
        public readonly string id;

        /// <summary>Character saying the dialogue item.</summary>
        public readonly Character character;

        private IEnumerable<DialogueTrigger> _triggers;

        public DialogueItem(
            string dialogueId,
            Character sayingCharacter,
            IEnumerable<DialogueTrigger> triggers)
        {
            ArgumentNullException.ThrowIfNull(dialogueId, nameof(dialogueId));
            ArgumentNullException.ThrowIfNull(sayingCharacter, nameof(sayingCharacter));
            ArgumentNullException.ThrowIfNull(triggers, nameof(triggers));

            id = dialogueId;
            character = sayingCharacter;
            _triggers = triggers;
        }

		/// <summary>
		/// Initalizes the dialogue item.
		/// </summary>
		/// <returns>
		/// A <see cref="IResult"/> object containing an error message if any.
		/// In case of success, the returned object flag <see cref="IResult.IsSuccess"> is set to true.
		/// </returns>
		public IResult Initialize()
        {
			// Initialize dialogue triggers
			foreach (DialogueTrigger trigger in _triggers)
			{
				trigger.PlayRequested += Trigger_PlayRequested;
                IResult dispatchResult = trigger.Dispatch();
				if (!dispatchResult.IsSuccess)
                {
                    return dispatchResult;
                }
			}

            return Results.Success;
		}

		#region Events handling
		private void Trigger_PlayRequested(object sender, EventArgs e)
		{
			OnPlayStarted();
		}
        #endregion

        #region Actions
        public void Choose()
        {
            OnChosen();
        }
        #endregion

        #region Events
        public event EventHandler<DialogueItemEventArgs> PlayStarted;
		public event EventHandler<DialogueItemEventArgs> PlayFinished;
		private void OnPlayStarted()
        {
            PlayStarted?.Invoke(this, new DialogueItemEventArgs(this));

			// After dialogue played, we trigger the DialogueFinished event
			PlayFinished?.Invoke(this, new DialogueItemEventArgs(this));
		}

        public event EventHandler Chosen;
        private void OnChosen()
        {
			Chosen?.Invoke(this, new DialogueItemEventArgs(this));
		}
		#endregion

		#region Equality
		public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj is DialogueItem itemObj)
                return id == itemObj.id;

            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
        #endregion
    }
}
