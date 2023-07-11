using Unity.Entities;
using UnityEngine;

namespace ECS_PlayGround
{
    public class CubeSpawnerAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;

        public class CubeSpawnerAuthoringBaker : Baker<CubeSpawnerAuthoring>
        {
            public override void Bake(CubeSpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CubeSpawnerComponentData { CubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic) });
            }
        }
    }

    public struct CubeSpawnerComponentData : IComponentData
    {
        public Entity CubePrefab;
    }
}