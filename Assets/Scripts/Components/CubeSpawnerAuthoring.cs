using Unity.Entities;
using UnityEngine;

namespace ECS_PlayGround
{
    public class CubeSpawnerAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;
        public int Count;

        public class CubeSpawnerAuthoringBaker : Baker<CubeSpawnerAuthoring>
        {
            public override void Bake(CubeSpawnerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new CubeSpawnerComponentData { CubePrefab = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic), Count = authoring.Count });
            }
        }
    }

    public struct CubeSpawnerComponentData : IComponentData
    {
        public Entity CubePrefab;
        public int Count;
    }
}