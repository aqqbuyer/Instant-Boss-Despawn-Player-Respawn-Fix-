# Instant Boss Despawn (tModLoader)

A quality-of-life mod for tModLoader that prevents respawn softlocks and long delays by instantly clearing active bosses the exact frame all players die.

---

## Problem Statement

In large Terraria modpacks (such as Calamity, Fargo's Souls, etc.), particularly on high-difficulty settings like Masochist Mode (where players have limited respawns per fight), a game-breaking bug can occur upon a team wipe:

* Bosses occasionally teleport to the edge of the map instead of despawning.
* The game continues to register the boss fight as active.
* This causes a 20–30 second delay before player respawn timers start, or completely freezes the respawn process, forcing a manual server restart or world reload.

---

## Solution

This mod detects when the last living player dies and immediately:
1. Stops the ongoing boss encounter.
2. Clears/despawns all active boss entities in the same frame.
3. Syncs the world state with the server to prevent multiplayer desyncs.
4. Triggers the normal player respawn sequence without delay.

---

## Localization / Локализация

The mod supports dual-language documentation:

<details>
<summary><b>Russian (Русский)</b></summary>

### Зачем это нужно:
В крупных сборках (Calamity, Fargo's Souls и др.), особенно на сложности «Мазохист» с ограничением на возрождения, после смерти всех игроков боссы иногда телепортируются на край карты. Игра считает, что бой продолжается, из-за чего запуск таймера респавна задерживается на 20–30 секунд или заклинивает намертво.

### Что делает мод:
Как только погибает последний живой игрок, мод в тот же кадр останавливает бой, стирает боссов и синхронизирует состояние с сервером, мгновенно запуская нормальный респаун.
</details>

---

## Requirements & Compatibility

* tModLoader: v1.4.4+
* Side: Works in both Singleplayer and Multiplayer (Server-side & Client-side required).
* Compatibility: Fully compatible with Calamity, Fargo's Souls, Thorium, and other major content mods.
