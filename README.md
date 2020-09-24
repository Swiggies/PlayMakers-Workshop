# PlayMakers-Workshop
Source code for PlayMakers workshop.

### This was made on 2019.3
Downloading it is not necessary unless you want to see exactly how everything is done.
The main files of interest are:

The meat of the project. The Service Locator acts as a singleton in memory, there is no presence of the Service Locator and any Service in the scenes making it easy to manage.

[ServiceLocator](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/ServiceLocator.cs)

The PlayerManage, PlayerController and CameraTargetController are a good example of how you can completely decouple your code and reduce time setting your scenes up. You can drop the PlayerController and CameraTargetController into any scene and they will work with no extra setup.

[PlayerManager](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/PlayerManager.cs)

[PlayerController](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/PlayerController.cs)

[CameraTargetController](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/CameraTargetController.cs)

The ScoreManager, CollectableContoller and UIController show good examples of how to add UI to your game. Like the Player and the Camera, these should all work with no extra setup when you drop them into a scene. This series of scripts shows how you can use Events to update your UI without having to make expensive calls.

[ScoreManager](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/ScoreManager.cs)

[CollectableController](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/CollectableController.cs)

[UIController](https://github.com/Swiggies/PlayMakers-Workshop/blob/master/Assets/Scripts/UIController.cs)
