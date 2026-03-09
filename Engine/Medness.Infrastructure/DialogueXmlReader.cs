using Medness.Business.Entities;
using Medness.Business.Interfaces;
using Medness.Business.ValueObjects;
using System.Xml;

namespace Medness.Infrastructure
{
	/// <summary></summary>
	public class DialogueXmlReader
	{
		#region Fields
		private FileStream _fileStream;
		private IRepository<DialogueItem> _dialogueRepository;
		private IRepository<Character> _characterRepository;
		#endregion

		#region Properties
		public IEnumerable<DialogueItem> DialogueItems { get; private set; }
		#endregion

		#region Constructor
		/// <summary>
		/// Creates a new instance of class <see cref="DialogueXmlReader"/>.
		/// </summary>
		/// <param name="filePath">The path of the XML file containing the dialogues.</param>
		/// <param name="dialogueRepository">The dialogues repository.</param>
		/// <param name="characterRepository">The characters repository.</param>
		public DialogueXmlReader(
			string filePath,
			IRepository<DialogueItem> dialogueRepository,
			IRepository<Character> characterRepository)
		{ 
			_fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			_dialogueRepository = dialogueRepository;
			_characterRepository = characterRepository;
		}
		#endregion

		#region Public methods
		public async Task ReadFile()
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			settings.Async = true;

			// DialogueItem properties
			string id = string.Empty;
			Character character;
			string text = string.Empty;
			string dataFile = string.Empty;
			List<DialogueTrigger> triggers;

			// DialogueItemTrigger properties
			string triggerId = string.Empty;
			string triggerObject = string.Empty;


			using (XmlReader reader = XmlReader.Create(_fileStream, settings))
			{
				while (await reader.ReadAsync())
				{
					switch (reader.NodeType)
					{
						case XmlNodeType.Element:
							if (reader.Name == DialogueXmlNames.DialogueItem)
							{
								if (id != string.Empty)
								{
									// Write previously read dialogue item
									_dialogueRepository.Add(new DialogueItem(id, character, text, dataFile, triggers));
								}
								id = reader.GetAttribute(DialogueXmlNames.DialogueItemId) ?? string.Empty;
								character = _characterRepository.Get(reader.GetAttribute(DialogueXmlNames.DialogueItemCharacter));
								text = reader.GetAttribute(DialogueXmlNames.DialogueItemText) ?? string.Empty;
								dataFile = reader.GetAttribute(DialogueXmlNames.DialogueItemDataFile) ?? string.Empty;
								triggers = new List<DialogueTrigger>();
							}
							break;
						default:
							// Empty by design
							break;
					}
				}
			}
		}
		#endregion
	}
}
