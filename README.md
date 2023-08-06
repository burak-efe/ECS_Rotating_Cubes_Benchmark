# ECS_Rotating_Cubes_Benchmark

## Very basic benchmark for observing performance difference between programming approachs in UNITY Game Engine.

## This benchmark not represent a real game, This benchmark heavily latency bound due to accesing high amount of Gameobjects, and NOT ALU bound due to single rotating operation.

## Setup
100_000 cubes with no collider rotates in camera frustrum.<br>

## Sceneraios <br>
OOP : A spawner spawns cubes, Cubes rotate their selfs in update(). <br>
OOP With Manager : A spawner spawns cubes, A Rotate System have referances of all cube gameobjects and roate them. <br>
DOTS_No_ECS : A spawner spawns cubes, A Rotate System that uses Burst compiled IJobParallelForTransform rotate all cubes. <br>
ECS :  A spawner System spawns cubes, A Rotate System that uses Burst compiled IJobEntity rotate all cube Entites. <br>
 
## Results and observations (il2cpp, build, dev mode, profiler runs, x64, ryzen 2400g): <br>

### OOP : total 140 ms, rotating cubes 60ms, rendering 45ms  <br>
Standart approach when devbeloping game when using unity <br>
### OOP With Manager : total 90 ms, rotating cubes 42ms, rendering 45ms <br>
Since c# calls from c++ side are costly, packing processing in update function will result performance benefits. [See](https://xoofx.com/blog/2018/04/06/porting-unity-to-coreclr/#how-unity-is-currently-running-your.net-code)
### DOTS_No_ECS  : total 80 ms, rotating cubes 10ms, rendering 65ms <br>
like I said in the beginning this sceneria not ALU bound and main hothpath is accesing high amount of object so job system paralellization and burst optimizations doesnt give much;
Also rendering system take more because looks like its need to update itself after transform jobs.
### ECS : total 5.5 ms, rotating cubes 0.02ms, rendering 5ms <br>
from unplayable on pc to VR ready :D since we use Dots transform component, the data we want to acces is sequental in memory.
