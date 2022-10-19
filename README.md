# Game AI in Unity Editor mode
This is a skelton of real-time simulation game and a playing algorithm of it.
You can play the game in Play mode, besides that, there is Auto Play button in the inspector of GameManager object.

## Terminology
* Player ... the blue ball in the game scene
* Enemy ... the red ball
* Gold ... yellow cubes

## Game Mechanics
The objective of the game is to collect all the Gold fragments, while running from Enemy.
Player moves toward the point where you click on.

## Architecture
This software has 3 layers: Data, Logic, and View.
On starting the game, View creates Logic and Data instances and correlate the Data instances with corresponding Logic instances (mainly in GameManager#Init.)
Logic layer instances all have `IIntelligent` interface and algorithm to control their responsible objects.
Player and Enemy have their corresponding Logic.

When Auto Play is started, an extra Logic `PlayerAI` will be instantiated and start working.
It decides where to move toward in place of your click.

# License
MIT
