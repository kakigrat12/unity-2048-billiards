# 2048 Billiards — C# Portfolio Snapshot

A Unity gameplay prototype that combines billiards-style physics with 2048 progression. Players launch balls into an arena; equal-level balls merge, progression events update score and presentation, and win/loss systems react to the evolving board state.

This repository is intentionally code-first. It contains authored C# and minimal Unity/package version metadata, but not scenes, prefabs, artwork, audio, videos, imported SDKs, or build artifacts.

## Engineering highlights

- Physics-driven merge flow through [`Ball`](Assets/Scripts/Ball.cs), [`Merger`](Assets/Scripts/2048%20System/Merger.cs), and [`LevelUpdateEventer`](Assets/Scripts/2048%20System/LevelUpdateEventer.cs).
- Event-driven score, ball-count, win, loss, and presentation updates.
- Tutorial progression represented as an explicit sequence of slide actions in [`PlayerTraining`](Assets/Scripts/PlayerTraining.cs).
- Player progression abstracted behind [`PlayerProgressSaver`](Assets/Scripts/PlayerProgressSaver.cs), with local and platform-oriented implementations.
- Small focused components for spawning, pulling, removal, animation, effects, localization, and UI presentation.

## Code map

```text
Assets/Scripts/
├── 2048 System/       Merge progression, counters, win/loss rules
├── Remove System/     Removal strategies
├── Animation System/  Small animation components
├── Inputs/            Touch input
├── Presentors/        UI-facing event consumers
├── Effects/           Audio/video/volume presentation
├── Languge/           Localization adapters (legacy spelling retained)
├── Yandex/            Authored platform adapter layer only
└── *.cs               Player, puller, spawning, training, persistence
```

## Representative flow

1. [`TouchInput`](Assets/Scripts/Inputs/TouchInput.cs) publishes the completed drag gesture.
2. [`Player`](Assets/Scripts/Player.cs) converts the drag delta into a bounded impulse.
3. [`RandomPuller`](Assets/Scripts/RandomPuller.cs) spawns and launches the next ball.
4. Equal-level balls merge; [`Counter`](Assets/Scripts/2048%20System/Counter.cs) updates score, count, and highest level.
5. [`Win`](Assets/Scripts/2048%20System/Win.cs) and [`Loss`](Assets/Scripts/2048%20System/Loss.cs) react to those state changes.

## Review notes

Legacy spellings such as `Presentor`, `Languge`, `Cheak`, and `Winned` are retained to keep this snapshot faithful to the original authored code. The architecture is deliberately component-oriented and depends on Unity scene wiring. Debug logging and provider-specific adapters remain visible because they are part of the original source. See [SOURCE_SCOPE.md](SOURCE_SCOPE.md) for the exact boundary and limitations.

## Unity version

Created with Unity `2022.3.10f1`. The code can be reviewed directly on GitHub. Reconstructing a playable build requires the omitted scenes, prefabs, media, and third-party SDK.

