using Unity.Entities;
using UnityEngine;

namespace RotatingCubes
{
    public class CubeAuthoring : MonoBehaviour
    {


        public class CubeAuthoringBaker : Baker<CubeAuthoring>
        {
            public override void Bake(CubeAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CubeComponentData { });
            }
        }
    }

    public struct CubeComponentData : IComponentData
    {
    }
}