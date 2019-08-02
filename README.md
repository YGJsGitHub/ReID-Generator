# ReID-Generator #

ReID(**Pesron Re-Identification**) Generator is a tool for generating ReID image datasets in GTA V. It's a custom mod of GTAV, written in **C#**.

It can generate images of people with more than 700 original models, 7 weather, 7 lighting, custom angles, multiple scenes, and multiple actions.

You can also add additional character models and generate their image.

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

	The datasets will be saved in path in format:`XXXX/XXXX_CXX_WXX_LXX.jpg`.


	-  `XXXX` is the **ID label**


	-  `CXX` is **camera label**


	-  `WXX` is the **weather label**
		- `W00` : **ExtraSunny**
		- `W01` : **Clouds**
		- `W02` : **Smog**
		- `W03` : **Foggy**
		- `W04` : **Neutral**
		- `W05` : **Blizzard**
		- `W06` : **Snowlight**


	-  `LXX` is the **light label**.
		- `L00` : **Midnight**
		- `L01` : **Dawn**
		- `L02` : **Forenoon**
		- `L03` : **Noon**
		- `L04` : **Afternoon**
		- `L05` : **Dusk**
		- `L06` : **Night**


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
