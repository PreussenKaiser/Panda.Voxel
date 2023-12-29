using Microsoft.Xna.Framework;
using Panda.Voxel.States;

namespace Panda.Voxel.Input.Movement;

public interface IMovement
{
    Vector3 GetInput(PlayerState playerState);
}
