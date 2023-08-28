# ECS Rotating Cubes Benchmark

## Very basic benchmark for observing performance difference between programming approach in UNITY Game Engine.

## This benchmark not represent a real game, This benchmark heavily latency bound due to accessing high amount of GameObjects, and NOT ALU bound due to single rotating operation.

## Setup
100_000 cubes with no collider rotates in camera frustum.<br>

## Scenarios <br>
OOP : A spawner spawns cubes, Cubes rotate their self's in update(). <br>
OOP With Manager : A spawner spawns cubes, A Rotator GameObject have references of all cube GameObjects and rotate them. <br>
DOTS_No_ECS : A spawner spawns cubes, A Rotate System that uses Burst compiled IJobParallelForTransform rotate all cubes. <br>
ECS :  A spawner System spawns cubes, A Rotate System that uses Burst compiled IJobEntity rotate all cube Entites. <br>
 
## Results and observations (il2cpp (faster runtime),burst(avx2,performance), dev mode, profiler runs, x64, Ryzen 5500, gtx1660s): <br>

|                       | OOP         | OOP With Manager | DOTS no ECS | DOTS with ECS |
|-----------------------|-------------|------------------|-------------|---------------|
| CPU                   | 75ms        | 58ms             | 56ms        | 3.8ms         |
| Rotate System         | 43ms        | 22ms             | 10ms        | 0.01ms        |
| Main Thread Rendering | 30ms        | 32ms             | 44ms        | 3.7ms         |
| Render Thread         | 28ms        | 35ms             | 33ms        | 0.8ms         |
| Bound by              | Main thread | Main Thread      | Main Thread | GPU           |

### OOP <br>
Standard approach when developing game when using unity <br>
### OOP With Manager <br>
Since c# calls from c++ side are costly, packing processing in update function will result performance benefits. [See](https://xoofx.com/blog/2018/04/06/porting-unity-to-coreclr/#how-unity-is-currently-running-your.net-code)
### DOTS_No_ECS  <br>
like I said in the beginning, this scenario not ALU bound and main bottleneck is accessing high amount of objects, so job system parallelization and burst optimizations doesn't give much;
Also rendering system takes more time, because looks like its need to update itself after transform jobs.
### ECS <br>
from unplayable on pc to VR ready :D since we use Dots transform component, the data we want to access is sequential in memory.
