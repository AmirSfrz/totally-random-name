## 📂 Project Structure

The project follows a **feature-based file structure**. Instead of organizing files by their _type_ (e.g., one folder for all scripts, one for all prefabs), assets are grouped by the _feature_ they belong to.

This approach makes the project more modular and scalable, as all files related to a single feature (like the main menu or the game itself) are located in one place.

-   **Example:** The `Scenes/Game` folder contains all assets required for the main gameplay scene to function, including its specific scripts, prefabs, visual assets, and scene file.

---

## ⚡ Code Architecture

The game's architecture is primarily **event-based**.

Components are loosely coupled, meaning they don't rely on direct, hard-coded references to each other. Instead, they communicate by emitting events and listening for events they care about. For example, when a card is flipped, it emits a "CardFlipped" event, and a central `GameManager` (or similar system) listens for this event to process the game logic.

This design makes the code cleaner, easier to maintain, and simpler to debug or extend with new features.

---

## 🎨 Art & Visuals

All visual assets used in this game—including the card fronts, card backs, background images, and UI elements—were **generated using AI** and then implemented into the project.

---

## 📹 Gameplay Video

A video demonstrating the game's functionality, animations, and features can be found in the repository at the link below.

[**View Gameplay Video**](./videos/game.mp4)
