Anime girl, in a typical post Soviet Union setting
Shooting hordes of Gopniks

IMPORTANT:
If filter is cached it would apply only to entities, which was spawned first and simultaneous
On build disable logs
Store only value types in a component?
Logs are eating lots of performance still
PC only? I don't think that a mobile GPU can handle such 3D

TODO:

Optimizations:
Portrait orientation 
LOD (with impostors)
Animate only near-by
Narrow camera view angle
Spawn ~150 enemies MAX
Fake shadows (https://forum.unity.com/threads/which-is-more-cpu-expensive-blob-shadows-or-the-default-shadows.514830/)
Adaptive performance (Working only on A11+)

(
Switch to next wave
Upgrades between waves
OR
Spawn endlessly, upgrades on level up
)

Upgrades (pause ecs)

Collect bottles of vodka/Energy drinks to heal

Shop (skins)

Enemies:
Melee (Explode, attack up close, run into the player)
Range (Different fire rate, projectile size, projectile speed, attack range)

Models (Use VRM importer to import an anime model
https://github.com/vrm-c/UniVRM
https://github.com/simplestargame/SimpleURPToonLitOutlineExample

Animations

Ref
https://www.youtube.com/watch?v=gwE0FdWF-SA
https://www.youtube.com/watch?v=Ph3wh84vWD4

Done:
Top down camera follow
Walk with joystick
Move using character controller
Health/Damage
Health Bar (OnPlayerDamageSystem, Inject player UI controller? )
AI detection (detect range, follow range, attack range)
Enemy Attack
ROTATE TOWARDS MOVEMENT DIRECTION
Enemy shoot projectile at player
Player shoot projectiles at enemies
Player shoot the closest in range
Player projectile ignore player
Enemies death
Player controller + state machine
Bullets ignore each other
Player stats service (Fire rate (cooldown), damage)
Waves (Enemies prefabs, time before spawn, enemies count)
Waves spawner
Player attack system allow to shoot up and down
Enemy running animation
Since the game is 3d a jump can be added to dodge projectiles/ or maybe not jump but float (Jump system, right after gravity)