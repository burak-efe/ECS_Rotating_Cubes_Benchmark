using Unity.Burst;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;

namespace RotatingCubes.DOTS_No_ECS

{
    public class DotsNoECS_Rotator : MonoBehaviour
    {
        [SerializeField] private int _cubeCount = 100_000;
        [SerializeField] private GameObject _cubePrefab;
        private JobHandle _jobHandle;
        private TransformAccessArray _transformAccessArray;
        
        private void Start()
        {
            SpawnCubes();
        }
        private void SpawnCubes()
        {
            var spacing = 20.0f;
            _transformAccessArray = new TransformAccessArray(_cubeCount);
            for (var cubeIndex = 0; cubeIndex < _cubeCount; cubeIndex++)
            {
                var position = new Vector3(Random.Range(-spacing, spacing), Random.Range(-spacing, spacing), Random.Range(-spacing, spacing));
                var cube = Instantiate(_cubePrefab, position, Quaternion.identity);
                _transformAccessArray.Add(cube.transform);
            }
        }
 
        private void Update()
        {
            var job = new CubeSpinJob() { DeltaTime = Time.deltaTime, };
            _jobHandle = job.Schedule(_transformAccessArray);
        }
 
        private void LateUpdate()
        {
            _jobHandle.Complete();
        }
 
        private void OnDestroy()
        {
            _transformAccessArray.Dispose();
        }
        
        [BurstCompile]
        private struct CubeSpinJob : IJobParallelForTransform
        {
            public float DeltaTime;
            public void Execute(int i, TransformAccess trs)
            {
                var q = trs.rotation;
                var rot= math.mul(q, quaternion.RotateY(10 * DeltaTime));

                trs.rotation = rot;
            }
        }
    }
}
