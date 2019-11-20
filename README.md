# Final Combat

## Description

You are given a simple RPG world where you, as the player, can walk around and encounter enemy logs who are usually sleeping. As soon as you come in contact with an enemy log, you will be transported to the combat stage where you will need to engage in combat (unless you choose to escape). 

By the end of this exercise, you should be able to optimize CPU performance through object pooling and know how to create a turn based combat system. 

### Grading



### Due Date and Submission Information

This exercise is due Tuesday November 26th at 11:59pm on GitHub Classroom. The master branch as found on your individual exercise repository will be evaluated.


## Stage 1 - Object Pooling

Object pooling is a commonly used optimization pattern within games that requires constant instantiation and destruction of game objects. It is a method used to improve performance and memory usage within games. Instead of allocating memory for each instantiation and freeing them individually, game objects are called from a fixed pool of prescribed objects. Object pooling allows us to grab a large chunk of memory up front and only free it after the game finishes. In the meantime, players are free to use the objects from the allocated pool as they see fit.

There are two Logos (enemy Logs) resting at the Northwest and Southeast corners. Feel free to visit either one to get into combat mode. 

Once you are in combat mode, you will be able to press and hold the "Attack" button to shoot mushrooms and attack the Logos. Look at all those mushrooms being generated. 

*You holding "Attack"*

Your CPU: WHYYYYY

### Part 1.1 - Creating A Pool
Instead of creating and destroying new mushrooms every time the `Attack` button at the top right corner is pressed, we are going to create a large batch of mushrooms and have them be asleep (`inactive`). You task now is to create a new script called `ObjectPooler` and attach it to a persistent game object within the game Hierarchy. 
* Several scripts will need to access the object pool during gameplay so you will need to make sure there is `public static ObjectPooler SharedInstance;` within your script
* Add `using System.Collections.Generic` to your script so that you can use the `List` class
* Add the following serialized fields
  * An object pool list variable to keep track of the list of game objects
  * A game object variable to indicate the game object we want to pool
  * An int variable to keep indicate the amount of Animinis we want to start off with
* Populate the object pool list using the serialized int variable and the game object variable and use `SetActive(bool)` to set all game objects to false in the `Start` function

### Part 1.2 - Time To Dive Into The Pool
Now that you have a pool ready, it’s time to dive in.
* Create a new method that returns a GameObject that is not active in the hierarchy
* Replace the instantiate and destroy code for the mushroom to use the pool instead
  * The instantiate and destroy code is in `Attack.cs`
  * Instantiation should call pool object and set the mushroom to active
  * Destroy should set the mushroom to inactive

### Part 1.3 - Must Have More Mushrooms...
Being the great creator of mushrooms and having a pool of them is great but what if you want to collect more without upsetting your CPU? 

Must have more mushrooms…

Let’s give your pool the capability to expand itself as needed.
* Create a serialized `True` variable that checks whether the pool should be expanded
* If check is true
  * Instantiate a pool game object and set it to inactive
  * Add the instantiated game object to the pool list
  * Return the game object
* Else return nothing

## Stage 2 - Setting Up The Stage For Combat
It's not much fun when there is only just one type of skill and only one character can blast mushrooms. 
### Part 2.1 - Create More Skills
* Create 2 more skills that is not just blasting mushrooms
  * One should be magic type
  * The other should be spirit type
* Make sure your new scripts inherits from `SkillsBase.cs`
* Set the skills to have different damage amounts
### Stage 2.2 - Give Each Character A Different Attribute
Currently, all the characters have the same attributes. That's no fun. Let's make them specifilize in different areas.
* Make a Ninja character who has high agility and health but low vigor
* Make a Monk character who has high vitality but low health and vigor
* Make a Ogre character who has high health and vigor but low agility and vitality
* Make a Hunter character who has medium health, agility, and vigor but low vitality
* Make a Wizard character who has high health and vitality but low agility and vigor

NOTE: Keep the values between 0-100. No limit to what you consider high or low. The values will be used for the combat portion in the next part.

## Stage 3 - Combat Algorithm
Now that you have the characters and their skills ready, it's time to make them battle. But first, we should adjust some of the combat algorithm.

### Part 3.1 - Player Team Gets An Advantage
* Assign the player team characters to be either a Ninja, a mushroom thrower, or a Monk
* Override the `TakeDamage` function within the Ninja, mushroom thrower, and Monk class to calculate the health as:

Health - (damageAmount - RandomAdvantageAmount)

where the random advantage amount is between 0 and half of their vitality
### Part 3.2 - Adjust Damages
Depending on the type of skills, it can have effects on a character's attributes aside from their health.
* Modify the base Attribute class to include the following
  * Agility decreases by 5% and vigor decreases by 2% if the attack type is physical (ie. mushroom)
  * Vitality decreases by 5% and vigor decreases by 2% if the attack type is spiritual
  * Both agility and vitality will decrease by 2% if the attack is magical

### Part 3.3 - Time For Battle
* Use the `BattleActionHandler` class to simulate the combat
* Within `StartBattle` function, display the health of each character in the console (Debug.Log)
* Finish the `DeterminOrderOfAttack` function using a character's agility and vitality where the order will be descending according to the max average of both attributes. 
* Display the winning team in the console when everyone on the opposite team is defeated

## Resources and Hints
