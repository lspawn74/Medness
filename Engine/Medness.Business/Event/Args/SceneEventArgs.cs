using Medness.Business.Entities;

namespace Medness.Business.Event.Args
{
    public class SceneEventArgs : EventArgs
    {
        public readonly Scene Scene;

        public SceneEventArgs(Scene scene)
        {
            ArgumentNullException.ThrowIfNull(scene, nameof(scene));
            Scene = scene;
        }
    }
}
