# ReID-Generator #

ReID(**Pesron Re-Identification**) Generator is a tool for generating ReID image datasets in GTA V. It's a custom mod of GTAV, written in **C#**.

It can generate images of people with more than 700 original models, 7 weather, 7 lighting, custom angles, multiple scenes, and multiple actions.

You can also add additional character models and generate their image.

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/img1.jpg)

### Request ###

##  ##

- [GTA V](https://grandtheftauto.net/gta5)
- [ScriptHookV](http://www.dev-c.com/gtav/scripthookv/)
- [ScriptHookVDotNet](https://github.com/crosire/scripthookvdotnet/releases)
- [DirectXTK](https://github.com/Microsoft/DirectXTK)
- [Visual Studio 2019](https://visualstudio.microsoft.com/zh-hans/vs/)

	> Attention: The mod must be used in the offline version of GTA V.

### Compilation ###

##  ##

1. Create a folder named `Scripts` under your GTAV root folder.


2. Navigate to ReID Generator directory, open `ReID_Generator.sln` with Visual Studio.


3. Open the project (GCC-Collector) property pages, `General/Windos SDK Version`, select **the latest win10 SDK** existed in your computer.


4. Open `Property`->`Generate event`, add this command in Postgenerative event.

 	`COPY "$(TargetPath)" "Your GTAV fold\scripts"`


5. Select the path where you want to save the image, and copy it in `ReID_Generator.cs` line `474`.

	The datasets will be saved in path in format:`XXXX/XXXX_cXX_wXX_lXX.jpg`.


	-  `XXXX` is the **ID label**


	-  `cXX` is **camera label**


	-  `wXX` is the **weather label**
		- `w01` : **Sunny**
		- `w02` : **Clouds**
		- `w03` : **Overcast**
		- `w04` : **Foggy**
		- `w05` : **Neutral**
		- `w06` : **Blizzard**
		- `w07` : **Snowlight**


	-  `lXX` is the **light label**.
		- `l01` : **Midnight**
		- `l02` : **Dawn**
		- `l03` : **Forenoon**
		- `l04` : **Noon**
		- `l05` : **Afternoon**
		- `l06` : **Dusk**
		- `l07` : **Night**


5. Click `Build Solution`, the script `Re-IDGenerator.dll` will be generated in *../GTAV/Scripts*.

### How to work ###

##  ##

Follow these steps to generate the ReID datasets:

1. Open GTAV in the **offline version**


2. Press `F5` to open the tool menu.


3. Using `8` `2` `5` to choose the function you need.
	* **CaptureAllInOne**:Generate all natural models at once.
	* **Capture**:Generate the images of current models you create.
	* **Weather**:Choose the weather you need.
	* **Hour Forward**:Set the game time an hour forward.
	* **Hour Back**:Set the game time an hour back.
	* **Test**:Added the function you need.


### Appendix ##

##  ##

### 1. Developer Kit ###

[NativeDB](http://dev-c.com/nativedb/)
> This page contains all hash function decompile from GTAV. 

[GTAV Mod](https://www.gta5-mods.com/)
> This page is the StackOverflow of GTAV.

[Tutorial](https://github.com/libertylocked/GTAVMods)
> Some basic mods you can learn from.

### 2. Frequently-used function ###

- Camera
	- CREATE_CAM
	- SET_CAM_COORD
	- RENDER_SCRIPT_CAMS
	- POINT_CAM_AT_COORD
	- DESTROY_ALL_CAMS
- Pedestrian
	- CHANGE_PLAYER_PED
	- SET_ENTITY_COORDS
- Weather
	- SET_WEATHER_TYPE_NOW_PERSIST
- Time
	- SET_CLOCK_TIME
	
### 3. Reid-Generator functional module design ###
The functional module design of Reid-Generator is generally divided into five modules, which are operation interface control module, system parameter management module, camera perspective control module, character model control module and synthetic data generation module.Subdivision functions of each module are as follows:

#### 1. Operation interface control module

Menu rendering module: the built-in function is corresponding to the menu bar button, and the display rendering is carried out through NativeUI. After the user calls out the command, the operation menu is rendered in the upper left corner of the screen for subsequent function selection.

Key binding module: Bind specific operations with keyboard keys, including: F5: operation interface call out 8: move up 2: move down 5: select ESC: back/exit INSERT: refresh/reload WASD: character control, etc.

Top and bottom display module: display rendering through NativeUI, display the current coordinates and orientation of the character at the top, display the current generated data attributes and storage path at the bottom.

#### 2. System parameter management module

This module manages the setup parameters of the REID-GENERATOR uniformly, loading it before it enters the main function and refreshing it continuously after the module is run.Specific parameters are as follows:

Attribute control parameters: game time, light mode, weather mode, surrounding vehicle density, surrounding pedestrian density, story mode parameters, Object interaction parameters

Camera control parameters: camera interval, capture time interval, camera Angle, camera rotation mode, camera update mode, capture location coordinate table

Character model parameters: health, body type character position coordinates, character orientation coordinates, error character HASH table, character model HASH value, generation ID order

Operation interface parameters: key and function table, nativeUI parameter table, local path parameters, interface refresh rate

#### 3. Camera Angle Control Module

Camera control module: place the script camera at the specified coordinates, update the specified script camera, destroy the specified script camera.

View control module: Set the specified script camera's Point of View (POV)

#### 4. Character model control module

Character attribute control module: control the life value, body shape and movement of the character, easy to synthesize data capture.

Character model update module: create/update the character model in the specified location, set the initial character orientation, and record the character model ID and generation order.

#### 5. Synthetic data acquisition module

Single persona generation module: by setting different camera intervals, camera angles, persona attributes, lighting, weather and other parameters, the specified persona is synthesized data generation.

All character generation module: on the basis of single character generation, through the fusion of various module functions, realize the generation of all synthesis data in one button, which generates the synthesis data set GPR700.

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/1.gif)  

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/2.gif)  

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/3.gif)  

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/4.gif)  

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/5.gif)  

![img](https://github.com/YGJsGitHub/ReID-Generator/blob/master/images/6.gif)  
