# Final Combat

## Description

You are given a simple RPG world where you, as the player, can walk around and encounter enemy logs who are usually sleeping. As soon as you come in contact with an enemy log, you will be transported to the combat stage where you will need to engage in combat (unless you choose to escape). 

By the end of this exercise, you should be able to optimize CPU performance through object pooling and know how to create a turn based combat system in a RPG style game. 

#### What is Object Pooling?
Object pooling is a commonly used optimization pattern within games that requires constant instantiation and destruction of game objects. It is a method used to improve performance and memory usage within games. Instead of allocating memory for each instantiation and freeing them individually, game objects are called from a fixed pool of prescribed objects. Object pooling allows us to grab a large chunk of memory up front and only free it after the game finishes. In the meantime, players are free to use the objects from the allocated pool as they see fit.

Here are some additional reference that may help solidify this concept:
* http://gameprogrammingpatterns.com/object-pool.html 
* https://learn.unity.com/search?k=%5B%22q%3Aobject%20pooling%22%5D
* https://unity3d.college/2017/05/11/unity3d-object-pooling/

#### What is RPG?
RPG stands for role playing games. Currently, there are two types of RPGS. One is the Western RPG and the other is the Japanese RPG. Even though both have the name RPG in there, each type have their own take on how an RPG is played. While JRPG focuses more on the combat system, leveling system, and story line, WRPG tends to be focused on character customization and world exploration. From a developer point of view, JRPGs tend to have crafted stories that curates player experiences whereas WRPGs tend to have crafted worlds that let's the player build their own experience. To learn more about the difference between JRPG and WRPG, here is a great [video series](https://www.youtube.com/watch?v=l_rvM6hubs8) from Extra Credits.

For this assignment, we will be focused on a JRPG style turn-based combat system. 

### Helpful Document Description
The scripts are organized as such:
* The SetUp folder contains files that help create the interactions of the given game world such as character transporting into the battle ground
* The ToDo folder contains the files you will either reference or modify to finish the assignment

Here is a brief description of some helpful files for your assignment.
* Within The SetUp Folder
  * `Attack.cs` - this file is only used for Stage 1 to do object pooling
  * `BattleHandler.cs` - this file generates the players and enemies within the combat and assigns the base attributes and skills (you will be changing this file later on)
  * `CollisionController.cs` - this file is attached to each player and enemy prefab. It is used to detect any projectiles and destroys them on impact. You will be modifying this file to make it work for this assignment
* Within The ToDo Folder
  * `BattleAction.cs` - this is where the combat simluation will happen (you will be editing this a lot)
  * `PhysicalSkill.cs` - this is a class that inherits from SkillsBase and serves as an example that you can use to create additional skills
  * Within Base Folder
    * `AttackBase.cs` - this file produces the animation for shooting the type of attack from a character to another
    * `AttributeBase.cs` - this file contains all the base elements of attributes a character has
    * `SkillsBase.cs` - this file contains all the base elements of skills a character has

You will find that there are some TODOs sprinkled in some of the files. Those are there to help you in case you get stuck. 

### Grading
Your project will be score according to the following 70 point system:

| Stage | Points |
|:-----:|:------:|
|  1.1  |   5    |
|  1.2  |   5    |
|  2.1  |   10   |
|  2.2  |   10   |
|  3.1  |   5    |
|  3.2  |   10   |
|  3.3  |   25   |

The remaining 30 points will be based on your peer review of a classmate's programming exercise submission.


### Due Date and Submission Information

This exercise is due Tuesday November 26th at 11:59pm on GitHub Classroom. The master branch as found on your individual exercise repository will be evaluated.


## Stage 1 - Object Pooling
There are two Logos (enemy Logs) resting at the Northwest and Southeast corners. Feel free to visit either one to get into combat mode. 

Once you are in combat mode, you will be able to press and hold the "Attack" button to shoot mushrooms and attack the Logos. Look at all those mushrooms being generated. 

*You holding "Attack"*

Your CPU: WHYYYYY

### Stage 1.1 - Creating A Pool
Instead of creating and destroying new mushrooms every time the `Attack` button at the top right corner is pressed, we are going to create a large batch of mushrooms and have them be asleep (`inactive`). You task now is to create a new script called `ObjectPooler` and attach it to a persistent game object within the game Hierarchy. 

You are responsible for the following:
* Several scripts will need to access the object pool during gameplay so you will need to make sure there is `public static ObjectPooler SharedInstance;` within your script
* Add `using System.Collections.Generic` to your script so that you can use the `List` class
* Add the following serialized fields
  * An object pool list variable to keep track of the list of game objects
  * A game object variable to indicate the game object we want to pool
  * An int variable to keep indicate the amount of mushrooms we want to start off with
* Populate the object pool list using the serialized int variable and the game object variable and use `SetActive(bool)` to set all game objects to false in the `Start` function

### Stage 1.2 - Time To Dive Into The Pool
Now that you have a pool ready, it’s time to dive in.

You are responsible for the following:
* Create a new method that returns a GameObject that is not active in the hierarchy
* Replace the instantiate and destroy code for the mushroom to use the pool instead
  * The instantiate and destroy code is in `Attack.cs`
  * Instantiation should call pool object and set the mushroom to active
  * Destroy should set the mushroom to inactive

## Stage 2 - Setting Up The Stage For Combat
There are 2 teams at combat with each other. Each team has 3 characters and each character should have a different specialization in terms of attributes and skills. 

A skill is like a weapon, it defines a type of attack that a character can have. For example, the given skill is mushroom throwing which is a physical type of skill. 

### Stage 2.1 - Create More Skills
It's not much fun when there is only just one type of skill and only one character can blast mushrooms. So, we will create more.

You are responsible for the following:
* Modify the two scripts `SpiritualSkill` and `MagicSkill` to have different damage amounts

### Stage 2.2 - Give Each Character A Different Attribute
Attributes are similar to classes of a character. For example, in [Destiny 2](https://d2.destinygamewiki.com/wiki/Classes), you can choose to be a Titan, a Hunter, or a Warlock. Each has their own special attributes that differentiate themselves from each other. There are also subclasses in Destiny 2 but we wouldn't be getting into that.

Currently, all the characters have the same attributes. That's no fun. Let's make them specifilize in different areas.

You are responsible for the following:
* Make a Ninja character who has high agility and health but low vigor
* Make a Monk character who has high vitality but low health and vigor
* Make a Ogre character who has high health and vigor but low agility and vitality
* Make a Hunter character who has medium health, agility, and vigor but low vitality
* Make a Wizard character who has high health and vitality but low agility and vigor
* Modify the `CollisionController` script in the SetUp folder to call the TakeDamage function based on the Attribute script that is attached to game object

NOTE: Keep the values between 0-100. No limit to what you consider high or low. The values will be used for the combat portion in the next part.

## Stage 3 - Combat Algorithm
Now that you have the characters and their skills ready, it's time to make them battle. 

### Stage 3.1 - Player Team Gets An Advantage
But first, we should adjust some of the combat algorithm.

You are responsible for the following:
* Go into the `BattleHandler.cs` file and comment out lines 44, 45, 60, and 61 which are codes that add the AttributeBase and SkillsBase scripts to the players and enemies
* Within `BattleHandler`, assign the player team characters to be either a Ninja, a mushroom thrower (AttributeBase), or a Monk and the enemy to each have one of the other 3 attributes
* Override the `TakeDamage` function within the Ninja, mushroom thrower, and Monk class to calculate the health as:

Health - (damageAmount - RandomAdvantageAmount)

where the random advantage amount is between 0 and half of their vitality
### Stage 3.2 - Attribute Adjustment
Depending on the type of skills, it can have effects on a character's attributes aside from their health.

You are responsible for the following:
* Modify the base Attribute class to include the following
  * When the attack type is physical (ie. mushroom), decrease agility by 5% and vigor by 2%
  * When the attack type is spiritual, decrease vitality by 5% and vigor by 2%
  * When the attack type is magical, decrease both agility and vitality by 2%

### Stage 3.3 - Time For Battle
Now it's finally time to simulate the battle.

You are responsible for the following:
* Use the `BattleActionHandler` class to simulate the combat
  * Determine the order of attack based on max(average(vitality, agility))
  * For each character within the attack order queue
    * Give a random set of skills 
    * Give a random target on the opposite team
    * Calculate damage according to the skill of the character and target 
    * Have target take the damage 
    * Change the health bar
    * Set a delay timer so that the animation can finish before going to the next character 
    * Rotate a character 90 degrees as if it has been killed when their health reaches zero or below

Here is a helpful diagram of the combat system:
![alt text](https://github.com/dr-jam/ObjectPoolRPG-Exercise/blob/master/Combat%20Loop.png "Combat System Diagram")

## Resources and Hints
