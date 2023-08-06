using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace RotatingCubes
{
    public partial struct CubeSpawnerSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var rand = new Random(19191919);
            foreach (RefRW<CubeSpawnerComponentData> spawner in SystemAPI.Query<RefRW<CubeSpawnerComponentData>>())
            {
                ProcessSpawner(ref state, spawner,ref rand);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
        
        private void ProcessSpawner(ref SystemState state, RefRW<CubeSpawnerComponentData> spawner,ref Random rand)
        {
            if (spawner.ValueRO.Count == 0)
            {
                return;
            }
            for (int i = 0; i < spawner.ValueRO.Count; i++)
            {
                // Spawns a new entity and positions it at the spawner.
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.CubePrefab);
                // LocalPosition.FromPosition returns a Transform initialized with the given position.
                var pos = rand.NextFloat3(-20, 20);
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));

            }

            spawner.ValueRW.Count = 0;


        }
    }

    
}