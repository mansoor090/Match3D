MATCH 3D 
(Interview Test, taken by Leyla, Fauna Entertainment)


This project is made with Unity Engine 2019.4.30 (LTS), coded using language C#.
 
 

Design Pattern Used:
	- Singleton
- Observer -> To Manage Game State Transitions

Unity Techniques Used:
	- Scriptable Object -> To Easily Create New Objects ( Matchable/Pickable ) and maintain existing objects. 
Explanation of Scripts:

- Level Manager.cs: I use Level Manager for handling the enabling or spawning of levels based on the progress we made. Level Manager is also subscribed with Game Progression Manager in order to respond when state is changed. I.e when level is completed. It will respond to save level progress & execute analytics commands.
- Game Progression Manager.cs: A based structure created in observer pattern to help other scripts respond respectively when state is changed.

- SaveData.cs: Game values are necessary to store. This script is responsible for storing, loading, deleting values in a JSON format which is encrypted with a hash key. Works on all platforms. 

 
 

⦁	PlaneScreenSize.cs : 
 
This script automatically resizes the base surface of our game to any mobile screen & creates colliders around the borders. 

-InputSystem.cs: The main script in the game which interacts with user’s input and gives output. It allows to move object anywhere in screen. 

-ObjectData.cs (Scriptable Object):  It’s responsibilities is to create scriptable objects of the items we needed in game to match. Containing Prefab, (auto assigned) name, (Validated) Even Numbers, A Custom Tag. 

 

- SliderBinder: One of the important role of this script in game is to change the settings with ease without spending extra time.
 
 

The purpose of this script is to bind slider easily & efficiently for the QA testers or the Developer itself to make changes and test in real time 

There are other scripts i.e MaterialColorChange which helps to change color without creating a material, in renderer stage. It is one of the best solutions to prototype Level Design much  faster. 

Other Utilities:  Text Mesh pro : To write Text in 3D world.
- Procedural UI Image: To Create Images without download or making new one outside of unity engine. We can make directly in unity.
-Surge: To Tween some movements & rotation.  
