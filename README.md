# Match 3D

###### This project is made with Unity Engine 2019.4.30 (LTS), coded using language C# version 7.3, IDE JetBrain Rider 2020.3 and Blender v2.9 for basic model creation.

![Gameplay](https://user-images.githubusercontent.com/13319261/133035711-394a8bdb-3c9b-4e24-a3a8-0f8d446ac1df.png)

- **Design Pattern:** 
  - Singleton
  - Observer
    -> To Manage Game State Transitions

- **Techniques:**
    - Scriptable Object
        -> To Easily Create New Objects ( Matchable/Pickable ) and maintain existing objects. 

#### Explanation of Scripts:
- **Level Manager.cs:** I use Level Manager for handling the enabling or spawning of levels based on the progress we made. Level Manager is also subscribed with Game Progression Manager in order to respond when state is changed. I.e when level is completed. It will respond to save level progress & execute analytics commands.

- **Game Progression Manager.cs:** A based structure created in observer pattern to help other scripts respond respectively when state is changed.

- **SaveData.cs:** Game values are necessary to store. This script is responsible for storing, loading, deleting values in a JSON format which is encrypted with a hash key. Works on all platforms.
![SaveDataFile](https://user-images.githubusercontent.com/13319261/133035702-c8a76bd2-4a06-4aa0-a63a-d09d9a4724af.png)
![SaveDatamenu](https://user-images.githubusercontent.com/13319261/133035705-e24dd6b8-654b-4a0e-8978-25dcc9e89bd8.png)


- **PlaneScreenSize.cs:** This script automatically resizes the base surface of our game to any mobile screen & creates colliders around the borders.
![ScreenSize](https://user-images.githubusercontent.com/13319261/133035716-c843f96a-b838-4a84-881f-4f8906885d24.png)

- **InputSystem.cs:** The main script in the game which interacts with user’s input and gives output. It allows to move object anywhere in screen.

- **ObjectData.cs (Scriptable Object):** It’s responsibilities is to create scriptable objects of the items we needed in game to match. Containing Prefab, (auto assigned) name, (Validated) Even Numbers, A Custom Tag.
![ScriptableObject](https://user-images.githubusercontent.com/13319261/133035709-422d7090-3753-44a9-a5b0-e87ae94941df.png)

- **SliderBinder:** One of the important role of this script in game is to change the settings with ease without spending extra time.
The purpose of this script is to bind slider easily & efficiently for the QA testers or the Developer itself to make changes and test in real time.

![SliderBinder](https://user-images.githubusercontent.com/13319261/133035718-f02ee2b2-f54b-4bb2-bb49-9c61a4f1b5d4.png)
![Settings](https://user-images.githubusercontent.com/13319261/133035679-7daa0219-bf42-4224-9993-6466338214a9.png)

#### Utilities scripts: 
- **MaterialColorChange:** which helps to change color without creating a material, in renderer stage. It is one of the best solutions to prototype Level Design much faster.
- **Text Mesh pro:** To write Text in 3D world. 
- **Procedural UI Image:** To Create Images without download or making new one outside of unity engine. We can make directly in unity. -Surge: To Tween some movements & rotation.


