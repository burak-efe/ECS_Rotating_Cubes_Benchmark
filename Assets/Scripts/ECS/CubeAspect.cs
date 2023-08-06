using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace RotatingCubes
{
    public readonly partial struct CubeAspect : IAspect
    {
        // An Entity field in an Aspect gives access to the Entity itself.
        // This is required for registering commands in an EntityCommandBuffer for example.
        public readonly Entity Self;

        // Aspects can contain other aspects.

        // A RefRW field provides read write access to a component. If the aspect is taken as an "in"
        // parameter, the field behaves as if it was a RefRO and throws exceptions on write attempts.
        readonly RefRW<LocalTransform> Transform;
        readonly RefRW<CubeComponentData> CannonBall;

        // Properties like this aren't mandatory. The Transform field can be public instead.
        // But they improve readability by avoiding chains of "aspect.aspect.aspect.component.value.value".
        public float3 Position
        {
            get => Transform.ValueRO.Position;
            set => Transform.ValueRW.Position = value;
        }
        
        public quaternion Rotation
        {
            get => Transform.ValueRO.Rotation;
            set => Transform.ValueRW.Rotation = value;
        }
    }
}