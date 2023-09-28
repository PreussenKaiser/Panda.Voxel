using Microsoft.Xna.Framework;
using PandaQuest.States;

namespace PandaQuest.Input.Movement;

public interface IMovement
{
    Vector3 GetInput(PlayerState playerState);
}
