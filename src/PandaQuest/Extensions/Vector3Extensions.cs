using SystemVector3 = System.Numerics.Vector3;
using MonoGameVector3 = Microsoft.Xna.Framework.Vector3;

namespace PandaQuest.Extensions;

public static class Vector3Extensions
{
    public static SystemVector3 ToSystemVector3(this MonoGameVector3 vector)
    {
        return new SystemVector3(vector.X, vector.Y, vector.Z);
    }

    public static MonoGameVector3 ToMonoGGameVector3(this MonoGameVector3 vector)
    {
        return new MonoGameVector3(vector.X, vector.Y, vector.X);
    }
}
