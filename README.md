# Unity Flexible Spawner System

A lightweight, highly configurable spawner system for Unity. It handles weighted randomized prefab selection, area-based spawning, and automatic population capping without requiring any custom scripts on your prefabs.

---

## ✨ Features

* **Weighted Spawning:** Assign arbitrary weights to your prefabs (e.g., Goblin = 100, Orc Boss = 5). The system dynamically calculates the exact odds, allowing you to easily balance rarity without calculating hard percentages.
* **Visual Editor Gizmos:** See exactly where your objects will spawn with a built-in green radius sphere drawn in the Scene view.
* **Auto-Cleanup:** The spawner automatically detects when a spawned object is destroyed and frees up capacity for new spawns.
* **Zero Boilerplate:** You don't need to attach any specific interfaces or scripts to the prefabs you want to spawn. Just drag, drop, and play.

---

## 🧠 Design Notes

This system is designed around **Self-Management**. By using a standard "List<GameObject>" and a "RemoveAll(item => item == null)" lambda expression in the "Update" loop, the Spawner gracefully handles the lifecycle of its children. 

If an enemy dies or a particle effect destroys itself, the spawner immediately knows it has room to spawn another, keeping your active entity count perfectly balanced. 

Furthermore, by replacing pure random selection with a **Weighted Algorithm**, designers can easily add new entities to the spawn pool without having to re-calculate a percentage that equals exactly 100.

---

## 🧩 How To Use

1. **Create the Spawner:** Create an Empty GameObject in your scene and attach the "Spawner.cs" script to it.
2. **Assign Prefabs & Weights:** In the Inspector, expand the "Prefabs To Spawn" array. Add your prefabs and assign a weight to each (higher numbers mean they spawn more frequently).
3. **Configure Limits:** Set your "Spawn Interval" (seconds between spawns) and "Max Active Spawns" (the cap).
4. **Adjust Area:** Tweak the "Spawn Radius". Select the Spawner in the hierarchy to see a transparent green sphere indicating the spawn zone.
5. **Run:** Start the game and watch the spawner accurately populate the area based on your assigned rarity weights!

---

## 🚀 Possible Extensions

* **Wave System:** Add a "Wave" array that changes the "spawnInterval", "maxActiveSpawns", and the available prefabs over time.
* **Object Pooling Integration:** Swap out "Instantiate" for a call to an Object Pool manager to heavily optimize performance in games with rapid spawning and dying (like Bullet Hell shooters).
* **Spawn Constraints:** Add layer masking so the spawner checks if the random position is inside a wall before actually spawning the object.

---

## 🛠 Unity Version

* **Minimum Version:** Unity 2021.3 LTS
* **Recommended:** Unity 2022.3 LTS or newer.
* **Render Pipelines:** Compatible with Built-In, URP, and HDRP.

---

## 📜 License

MIT
