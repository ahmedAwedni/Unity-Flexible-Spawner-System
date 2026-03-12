# Unity Flexible Spawner System

A lightweight, highly configurable spawner system for Unity. It handles randomized prefab selection, area-based spawning, and automatic population capping without requiring any custom scripts on your prefabs.

---

## ✨ Features

* **Visual Editor Gizmos:** See exactly where your objects will spawn with a built-in green radius sphere drawn in the Scene view.
* **Auto-Cleanup:** The spawner automatically detects when a spawned object is destroyed and frees up capacity for new spawns.
* **Randomized Selection:** Supply an array of multiple prefabs, and the spawner will pick one at random for each spawn cycle.
* **Zero Boilerplate:** You don't need to attach any specific interfaces or scripts to the prefabs you want to spawn. Just drag, drop, and play.

---

## 🧠 Design Notes

This system is designed around **Self-Management**. By using a standard "List<GameObject>" and a "RemoveAll(item => item == null)" lambda expression in the "Update" loop, the Spawner gracefully handles the lifecycle of its children. 

If an enemy dies or a particle effect destroys itself, the spawner immediately knows it has room to spawn another, keeping your active entity count perfectly balanced. It also flattens the "Y" axis on spawn to prevent objects from spawning floating in the air or buried underground.

---

## 🧩 How To Use

1. **Create the Spawner:** Create an Empty GameObject in your scene and attach the "Spawner.cs" script to it.
2. **Assign Prefabs:** In the Inspector, expand the "Prefabs To Spawn" array and add one or more prefabs (Enemies, Coins, Trees, etc.).
3. **Configure Limits:** Set your "Spawn Interval" (seconds between spawns) and "Max Active Spawns" (the cap).
4. **Adjust Area:** Tweak the "Spawn Radius". Select the Spawner in the hierarchy to see a transparent green sphere indicating the spawn zone.
5. **Run:** Start the game and watch the spawner populate the area automatically!

---

## 🚀 Possible Extensions

* **Object Pooling:** For massive amounts of projectiles or enemies, replace the "Instantiate" and "Destroy" logic with an Object Pool pattern to save memory.
* **Wave System:** Add a "Wave" array that changes the "spawnInterval" and "maxActiveSpawns" over time.
* **Weighted Spawning:** Instead of pure random selection, assign percentage weights to your prefabs (e.g., 90% chance to spawn a Goblin, 10% chance to spawn an Orc).

---

## 🛠 Unity Version

* **Minimum Version:** Unity 2021.3 LTS
* **Recommended:** Unity 2022.3 LTS or newer.
* **Render Pipelines:** Compatible with Built-In, URP, and HDRP.

---

## 📜 License

MIT
