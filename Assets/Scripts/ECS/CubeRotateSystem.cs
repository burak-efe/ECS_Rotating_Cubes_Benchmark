using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace RotatingCubes
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

    }
}