# Plinko Burger!

***Plinko Burger is a digital fast food plinko machine that players control using a drive thru headset and a set of condement squeezy bottles to *hopefully* serve food to their hungry customers***

## Plinko Burger, A Game People Played!

*"This looks insane"*

On Sunday, November 14 2021, 100+ real people played Plinko Burger! At the 4th annual [Whaaat!? Festival](https://whaaat.io/) Pliko Burger set up shop, confusing and delighting many players at the festival. We laughed, cried when things almost didn't work, and celebrated many hilarious orders that players submitted. With a reigning high score of 174 points, the festival-goers took the silliness in stride and really gave Plinko Burger a chance to shine. 

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/StartScreen.JPG" width="30%"> <img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/EndScreen.JPG" width="30.6%"> <img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/caddy-bottles.jpg" width="33%">

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PB-player1.jpeg" width="48%"> <img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PB-player2.jpeg" width="48%">

In all seriousness we learned a lot from the day, including that a few things could be reworked, like: our preliminary points system, the cue to know when an order is coming up due so you don't miss it, input/output audio where only the person playing can hear any of the fun sounds, and a number of small fixes like peas not actually giving you any points (whoops!). 

But fear not! The fun doesn't stop here. We will be implenting some of these changes to make the game better as we prepare to submit Plinko Burger to GDC alt control! We will be working diligently (probably) to get the game up to snuff and finish preparing all of the materials and documentation of the game. Stay tuned for more Plinko Burger updates!

## Plinko Burger, Coming Soon!

*Is that a fire!?*

Somehow this update both makes things simpler, and adds more complexity and options for interactions! The whole serving bins situation got overhauled so that the orders go through faster and with less issues. Each individual order now has a timer and an accompanying unique audio clip of someone ordering. With 30+ orders! Sticky notes will appear on the receipt printer with tips, including if the player hasn't spoken anything to the plinko machine. Also, different words will now trigger the plinko machine to shake, catch on fire, spit out confetti and more! A number of other small updates and optimizations have been made to the backend of how the game is running, but those are pretty boring so I will just let you guess what that even means and move on lol. Below is a short gif of some of the events that can be initiated by different words like "what" "oh my god" "shit" and "sorry" in the machine. 

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PlinkoBurger-Chaos.gif" width="80%">


## Welcome to Plinko Burger!

*Would you like your receipt?*

This next iteration of Plinko Burger mainly involved some aesthetic upgrades and an opperational ordering system. We decided to go back to a single, central order bin after figuring out that two bins was two times, too many. Players can also see the missed ingredients fall to their deaths through transparent shoots out the back. The entire plinko machine got a *glow* update which gives a nice cool diner vibe to the whole experience.

The unmentioned elephant in the room (now mentioned) is definitely the orderering and score system which now allows players to see the receipt of an order that they need to make on the left hand side of the plinko burger machine. After an order is sent out, another receipt will print while the audio of the customer ordering said meal can be heard over the headset. The game always starts with a simple Plinko Burger order to allow the player to ease into the experience. After that, who knows what someone might order!.

I wish we had the time and resources to hook up and *actual* receipt printer to the game, which printed out *actual* receipts that the players had to compare to but... ¯\_(ツ)_/¯ I guess we'll see if that happens...

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PlinkoBurger-Glow.gif" width="80%">

## Plinko Burger, Order Up

*Bins, buns, battlestar galactica!*

Lots of functional updates *distant cheering* including moving order bins, propulsion ketchup/mustard controls, and a mystery box full of random ingredients!? The prototype will also now be controlled with a pair of force sensitive resistor squeezy bottle which will propel the bumper in either direction. The actual motion of the bumper could definitely be more slippery, which should happen in the next update. 

The mystery box is full of random food items which will fall at on command, including: pineapple, french fries, and even pumpkins? And once the ingredients have been collected in the correct bin, players can ship off the order and watch the food fall into a container below and send off to be scored. 

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PlinkoBurger-Bins.gif" width="90%">


## A Plinko Burger Prototype!

*Welcome to Plinko Burger, home of the plinko burger, may I take your order?*

The newest plinko prototype has some super snazzy updates! Now with voice controls for ordering each ingredient to fall from their respective bins at the top, players can call out what they need and attempt to build thier burger. The bins at the top also light up and ding when the machine recognizes the players request. Pressing the spacebar sends the order off through the bin at the bottom and so you can start on the next one. 

Our next task will be to have specific orders, scoring, and a physical spatula controller for the paddle at the bottom. Other fun options include a headset with a mic that you can yell the orders you are hearing, out to the plinko machine. 


<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/PlinkoBurger-Prototype.gif" width="80%">


## Burger Plinko (*nomnomnom*)

*Is that a burger???*

Moving forward with this prototype, we wanted to try out some basic interactivity on the unity side and reskin the idea. 

The 3 equivalent bins have been replaced with trash bins on the outside and a central collection bin, where you can see your items after they have passed through the plinko machine. There are now ingredients for burgers falling from the top and both the item dumper and player paddle at the bottom are controlled with left and right keyboard inputs. 

There isn't any formal goal built into this version of the prototype but attempting to get things into and *not* into the central bin is pretty fun. Plus seeing your collected ingredents at the bottom is an added bonus. 

Also a quick thanks to the people who made [these cute low-poly burger assets](https://assetstore.unity.com/packages/3d/props/food/low-poly-burger-pack-110019) on the unity store, they are so adorable and worked great to add some flare to this version of the prototype. (And not having me sucked into modeling them for fun and taking hours lol) ((sometimes you gotta spend $5 on digital burgers))

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/TrashPlinko-BurgerPrototype.gif" width="60%">    <img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/TrashPlinko-CreatureCreator-Sketch.jpg" width="30%">

The sketch next to the prototype image has the vision for both a one and two player version of this set up. 

The removable peg controller idea seems a little tough, and potentially not what we want the interaction to look like, so there will be updates on the physical side of the game coming soon.


## A Plinko Prototype!

The goal of this first prototype is to get a version of the 'game' plinko up and running inside of unity with working physics and a decent organizational scheme. I accidentally made the perfect 2000's era desktop screen saver but ¯\_(ツ)_/¯

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/TrashPlinko-TrashPrototype.gif" width="60%">

## A Trash Game Idea:

For the next project, we will be pushing it a bit farther with more thorough development and fabrication. 

My project idea is for a trash machine plinko game where players can remove physical pegs and replace them with tricked out ones that help move the falling items around to sort them. The initial concept for this involves 3 bins, one for trash, one for compost and one for recycling.

The goal of the game is to correctly sort the most materials before the time runs out, and players will recieve tickets for how well they accomplish this. 

Below are some basic sketches of this idea.

<img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/TrashPlinko-IdeaSketch.jpg" width="45%">  <img src="https://github.com/zSpaceSheikh/AltArcadeInterfaces/blob/main/Alt-Redemption/Alt_Redemption_Media/TrashPlinko-IdeaSketch2.jpg" width="50%">
