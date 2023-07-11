using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace ECS_PlayGround
{
    public partial struct CubeRotateSystem : ISystem
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
            // foreach (var (cube , transform)
            //          in SystemAPI.Query<RefRW<CubeComponentData>, RefRW<LocalTransform>>())
            // {
            //     cube.ValueRW.Index += 1;
            //     transform.ValueRW = transform.ValueRW.Rotate(quaternion.RotateY(10 * SystemAPI.Time.DeltaTime));
            // }

            var job = new CubeRotateJob() { Delta = SystemAPI.Time.DeltaTime };
            job.ScheduleParallel();
        }
        
        [BurstCompile]
        partial struct CubeRotateJob : IJobEntity
        {
            public float Delta;
            void Execute(CubeAspect cube)
            {
                var q = cube.Rotation;
                var i= math.mul(q, quaternion.RotateY(10 * Delta));
                cube.Rotation = i;
            }
        }

        private void Rotate((RefRW<CubeComponentData>, RefRW<LocalTransform>) cube)
        {
            cube.Item1.ValueRW.Index += 1;
            cube.Item2.ValueRW = cube.Item2.ValueRW.Rotate(quaternion.RotateY(10));
        }
    }
}