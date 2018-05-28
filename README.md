# Swingame-Rover

## C# Swingame Rover Game

### The Objective

The Objective was to create a simulation in which we could have a Rover explore a seemingly empty environment. This environment contained invisible Specimens. The objective of the Rover is to collect these specimens with the help of its devices and without losing all the charge in its batteries.

This was a task given to OOP Students and hence required an OOP Design.

### Controls

- **TAB:** Selects next rover, Selected rover indicated by red outline
- **Number (1-9):** Selects corresponding device, Selected device indicated by blue text
- **R:** Outputs rover status, including attached devices and extracted specimens, to the console.
- **A:** Attaches selected device to best available battery
- **D:** Dettaches selected device from its battery
- **Space:** Uses selected device


### Opening / Running

I'm using the most recent (as of 10th May 2018) MacOS build of [Swingame](http://www.swingame.com/ "Swingame's Homepage") to implement the gui, I'm fairly certain for Linux/Windows you'd have to create your own project file with a compatable Swingame Install and import the c# files in yourself.

**Program.cs** - You can create the size of the environment and the amount of Rovers/Specimens

```cs
//Open the game window                      Width, Height, Rovers, Specimens
            Environment theEnvironment = new Environment(800,800,1,10);
```

**Environment.cs** - AddRovers() Currently randomly generates Rovers in random positions across the Environment. If you wanted custom names for those rovers that has to be hard coded

```cs
Random rnd = new Random ();
int randX = 0;
int randY = 0;

for (int i = 0; i < amount; i++)
{
    randX = rnd.Next (20);
    randY = rnd.Next (20);
    _rovers.Add (new Rover (randX, randY, 30, "Rover " + (i + 1), this));
}
```

The same goes for specimens in AddSpecimens()

```cs
Random rnd = new Random();
if (amount < 1) { amount = 1; }

_specimens = new List<Specimen>();

for (int i = 0; i < amount; i++)
{
    _specimens.Add (new Specimen ("Scientist " + i, rnd.Next (19), rnd.Next (19), rnd.Next (30), "Specimen " + i, this));
    Console.WriteLine (_specimens [i].Scientist + ": " + _specimens [i].Name + " Created");
}
```

### Output

This game both displays a gui and gives feedback to your actions in the console. Upon running you're met with the game screen.

#### Interface

![GameScreen](Documentation/GameScreen.png?raw=true "Game Screen")

The Grid is the actual Environment being displayed with the red squares being the Rovers. To the right is the Sidebar where your actions are displayed.

- Selected Devices : Blue
- Attached Devices : Green with name of Attached Battery
- Non-Attached Devices : Red
- Battery Charge : Green filled rectangles showing a percentage of charge left
- Statistics on the amount of Specimens remaining

![Gameplay](Documentation/Gameplay.png?raw=true "Gameplay")

#### Console Output

Every action is logged in the console. It provides messages letting you know whether the Drill is usable, if the Battery you're trying to use is out of charge etc.

Upon Startup it displays all the Rovers and Specimens that are loaded into the Environment

```txt
Scientist 0: Specimen 0 Created
Scientist 1: Specimen 1 Created
Scientist 2: Specimen 2 Created
Scientist 3: Specimen 3 Created
Scientist 4: Specimen 4 Created
Scientist 5: Specimen 5 Created
Scientist 6: Specimen 6 Created
Scientist 7: Specimen 7 Created
Scientist 8: Specimen 8 Created
Scientist 9: Specimen 9 Created

Rover 1 Created
Rover 1: Battery 1 Created
Rover 1: Battery 2 Created
Rover 1: Drill Created
Rover 1: Downward Motor Created
Rover 1: Upward Motor Created
Rover 1: Leftward Motor Created
Rover 1: Rightward Motor Created
Rover 1: Location Radar Created
Rover 1: Size Radar Created
Rover 1: Name Radar Created
Rover 1: Solar Panel Created

Rover 2 Created
Rover 2: Battery 1 Created
Rover 2: Battery 2 Created
Rover 2: Drill Created
Rover 2: Downward Motor Created
Rover 2: Upward Motor Created
Rover 2: Leftward Motor Created
Rover 2: Rightward Motor Created
Rover 2: Location Radar Created
Rover 2: Size Radar Created
Rover 2: Name Radar Created
Rover 2: Solar Panel Created
```

This is really good for letting the player know that all devices have loaded into the game properly.

A typical output log will look like this, showing all previous commands and how they've affected the player.

```txt
Rover 1 Selected
Rightward Motor Selected
Rightward Motor Attached
Rightward Motor: Successful Use
Rightward Motor: Successful Use
Rightward Motor: Successful Use
Rightward Motor: Successful Use
Location Radar Selected
Location Radar Attached
Location Radar: Successful Use
Solar Panel Selected
Solar Panel Attached
Drill Selected
Drill Attached
Upward Motor Selected

Rover 2 Selected
Upward Motor Selected
Upward Motor Attached
Upward Motor: Successful Use
Upward Motor: Successful Use
Upward Motor: Successful Use
Upward Motor: Successful Use
Location Radar Selected
Location Radar Attached
Location Radar: Successful Use
Name Radar Selected
Name Radar Attached
Speciments found: 
	Specimen Name: Specimen 8
	Specimen Name: Specimen 9
Name Radar: Successful Use
Solar Panel Selected
Solar Panel Attached
Solar Panel: Successful Use
Solar Panel: Successful Use
Solar Panel: Successful Use
Solar Panel: Successful Use

Rover 1 Selected
Drill Selected
Specimen 3 extracted
Upward Motor Selected
Upward Motor is not attached
```

Lastly, for a status update on the currently selected Rover, pressing **R** will output this to the terminal.

```txt
Rover 1 Status:
    Position: 12,15
    Battery 1: 20%
    Battery 2: 80%
    Attached Devices:
        Drill (95%)
        Solar Panel
    Extracted Specimens:
        Specimen 3
```

---

### The Task

This was a project for my OOP unit of my Computer Science Degree at Swinburne University. We were given the following tasksheet to work with:

![Tasksheet](Documentation/Tasksheet.png?raw=true "Tasksheet")

Based on this we were to design a program which would implement all these features then create it.

#### UML Class Diagram

##### Initial Design

Before actually starting to code my first class diagram looked like this, I used this to model what I now have.

This was actually before I decided on how I was going to do a UI so things like more indepth drawing methods were not considered in this iteration.

![InitialUML](Documentation/InitialUML.jpg?raw=true "Initial UML")

Currently am working on an updated version as of course I didn't get it perfect the first time and had to update it as I progressed.

##### Design Changes

I actually worked in the wrong order. I implemented the initial design into my program and right away begun working on fixes and improvements before actually designing them. I made a copy of the UML diagram and used Preview to mark it up and make quick changes. That quickly got messy.

![MarkedUML](Documentation/MarkedUML.png?raw=true "Marked UML")

Instead of continuing this and marking this copy of the UML I decided to keep a text file outlining the changes. This was far more simpler to actually see what was being added, deleted and modified. Below is an example of what that looked like.

![DrillChanges](Documentation/DrillChanges.png?raw=true "Drill Changes")

You can see the full list of changes in the 'Documentation' folder of this repo.

##### Current Design

As I previously mentioned I worked backwards after the initial design, I made changes then annotated them in my list of what would need to be changed to the UML Diagram in order to keep it current.

Due to the addition of SwinGame as a UI there were a lot of things to like, a lot of extra fields and properties to get location on screen right and things like that.

Below is the current UML Diagram:

![CurrentUML](Documentation/CurrentUML.jpg?raw=true "Current UML")