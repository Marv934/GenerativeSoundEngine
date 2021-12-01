# GenerativeSoundEngine for coupled sim
 
# Installation

1. Download [Coupled-Sim Repository](https://github.com/bazilinskyy/coupled-sim).
2. Download this Repository into the Coupled-Sim Assets folder.

# Stucture

* Prefabs
** GSE_DrivableSmart
* Scenes
** GSE_StartScene
* Scripts
** GSE_Mapper

# Elements

## GSE_DrivableSmart

Clone of Coupled-Sim DrivableSmartCommon Prefab. Audio Source and Engine Sound Manager Removed, GSE_Mapper and FMOD Stuido Event Emitter added

## GSE_StartScene

Clone of Coupled-Sim StartScene. DrivableSmartCommon is replaced by GSE_DrivableSmart

## GSE_Mapper

Collects and processes Data to Map to Sound Engine

Mapped Parameters:
* Speed