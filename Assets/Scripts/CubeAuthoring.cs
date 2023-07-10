using Unity.Entities;
using UnityEngine;

namespace ECS_PlayGround
{
    public class CubeAuthoring : MonoBehaviour
    {
        public int Index;

        public class CubeAuthoringBaker : Baker<CubeAuthoring>
        {
            public override void Bake(CubeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CubeComponentData { Index = authoring.Index });
            }
        }
    }

    public struct CubeComponentData : IComponentData
    {
        public int Index;
    }
}