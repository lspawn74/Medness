namespace Medness.StateMachine.GameVariables
{
    public abstract class GameVariable
    {
        public string Name { get; }

        public GameVariable(string name)
        {
            Name = name;
        }
    }
}
