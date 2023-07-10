using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS_PlayGround
{
    public partial struct CubeRotator : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }

        public void OnDestroy(ref SystemState state)
        {
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach (var cube in SystemAPI.Query<RefRW<CubeComponentData>, RefRW<LocalTransform>>())
            {
                cube.Item1.ValueRW.Index += 1;
                cube.Item2.ValueRW = cube.Item2.ValueRW.Rotate(quaternion.RotateY(10 * SystemAPI.Time.DeltaTime));
            }
        }
    }
}