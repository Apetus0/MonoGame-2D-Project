# Building 2D Games with MonoGame: Dungeon Slime

A comprehensive, step-by-step framework for learning 2D game development using the MonoGame framework and C#. This repository contains the modular architecture and source code developed throughout the tutorial series, culminating in a polished snake-like arcade game titled **Dungeon Slime**.

The primary objective of this project is to establish a solid foundation in 2D engine design, resulting in a suite of decoupled, reusable modules that can jump-start future MonoGame projects.

---

## What Is Being Built

**Dungeon Slime** is a snake-clone with a dark dungeon theme where the player controls a growing chain of slime segments, navigating complex layout environments to harvest bats for points. 

### Core Features Delivered
* Smooth frame-based animated sprites.
* Responsive, multi-device player input handling (Keyboard and Gamepad).
* Dynamic tilemap systems parsing environment layers from source tilesets.
* Built-in collision detection matrices (blocking, triggering, and boundary constraints).
* Comprehensive audio control system for concurrent sound effects and looping background tracks.
* Scalable UI layout scenes built via the Gum UI framework.

---

## Tech Stack & Development Environment

* **Language:** C#
* **Framework:** MonoGame (.NET Cross-Platform Game Framework)
* **IDE Target:** Visual Studio Code / Visual Studio
* **Asset Compilation:** MonoGame Content Pipeline (MGCB Converter)
* **UI Tooling:** Gum UI Integration

---

## Repository & Development Architecture

The engine architecture builds sequentially from raw loops up to an optimized component-driven design pattern. Source files are mapped across the following structural milestones:

### Core Engine Architecture & Asset Rendering
* **Framework Foundation:** Setting up the .NET environment, exploring framework mechanics, and structuring the core initialization loops.
* **Component Class Library:** Extracting boilerplate code into a decoupled, shared class library to support cross-project module reuse.
* **Content Pipeline Optimization:** Managing textures and using a **Texture Atlas** to optimize draw call batches.
* **Sprite Extensions:** Engineering base spatial rendering wrappers and specialized animation classes to handle frame timelines.

### Input Systems & World Simulation
* **Unified Input Management:** Building a state-tracking manager mapping keyboard, mouse, and gamepad actions between frames.
* **Collision Detection:** Implementing axis-aligned bounding box checking alongside resolution behaviors like physics blocking and trigger boundaries.
* **Tilemap Systems:** Constructing layered grid environments out of tileset graphics configuration files.

### Systems Management & UI Polish
* **Audio Engineering:** Building an optimized audio manager tracking mixers, volume thresholds, and resource cleanup loops.
* **Typography & Scene Flow:** Integrating custom fonts and multi-state scene management to handle transitions between Title, Play, and Game Over states.
* **UI Layout Layouts:** Texturing sampler states for scrolling backgrounds and building menus through the Gum UI framework integration.

### Gameplay Mechanics & Deployment
* **Snake Gameplay Mechanics:** Implementing tail segment tracking, movement ticks, and growing chains.
* **Custom Shaders:** Creating visual effects using custom HLSL pixel shaders for post-processing highlights.
* **Distribution Packaging & Publishing:** Packaging binaries cross-platform for Windows, macOS, and Linux alongside configuration guides for hosting builds on itch.io.

---

## Module Blueprint Highlights

Several system classes developed in this project can be directly dragged into new game files:

* **`Sprite` / `AnimatedSprite`:** Manages spatial scaling, rotation matrices, origin anchoring, and frame intervals.
* **`InputManager`:** Provides abstract checks for keys tapped or held down this frame vs. last frame.
* **`Tilemap`:** Automatically parses and clips explicit region dimensions from multi-row tile files.
* **`AudioController`:** Prevents channel bleeding and memory leaks from overlapping audio effects.

---
