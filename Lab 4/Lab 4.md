


Dynamics for Games and Animation
======================================================
# Task 4 Report - Dynamics Critique
Student Name: Khang Trinh

Student ID: 102118468

======================================================
# Resources Used
> List (with names/titles) any websites/links that you found useful/helpful - don’t include things like search engines

- **Source video:** [Tesla Cannon from Overwatch](https://youtu.be/I6rMn2fwucc)
- **Reference video:** How the [Old Tesla Cannon](https://youtu.be/JNJ42WCOxV0) used to look
- **SmarterEveryDay:** [Real life Tesla Cannon](https://youtu.be/_fTC_Ud_k3U)
- **GabrielAguiarProd:** Different ways to make [Lightning FX in Unity](https://youtu.be/ewC_c6aHbf8)
- **LiveScience:** How [Tesla Coils](https://www.livescience.com/46745-how-tesla-coil-works.html) work ([Graphic info included](https://cdn.mos.cms.futurecdn.net/Rw8B5fxsFtb3uqxMNjVReM.jpg))
- **Weather Geek:** Facts about [lightning](https://weathergeeks.org/true-facts-about-lightning/) (mainly for colors)

======================================================
# Task Details
## Scene/Video Description
> Describe what is going on in the video, in a literal sense (i.e. provide a text description of what is literally happening in the video as it plays).

There video is broken down into 6 sections, showing different behaviours of the FX of the Tesla Cannon

**1. Shooting at the wall:** 

The cannon shoots 1 beam of lightning that consistently hits in the general vicinity of the cursor's position while 1 to 2 other beams of lightning occasionally shoots out in a much wider radius. The beam starts with a huge size with a large frequency of , then gradually gets more stable with the lightning coming off with a much smaller frequency. There are tiny sparks coming out of the lightning hitting a surface. There are also slightly larger sparks coming from the gun but isn't big enough to touch the surface, so they just look like small forks of lightning. There seem to be anywhere from 1 to 4 beams at any one time

**2. Shooting at the air:** 

As the cannon shoots at the air, it seems to only shoots the 1 consistent beam of lightning, the occasional beams becomes a lot less frequent if they even appear at all.

**3. Shooting at the wall but with a target in range:**

The character takes a step back and continue shooting the cannon. The cannon is still shooting at the wall, not directly at the target, but the target seems to be in range now (it seems that the range of the cannon looks like a cone), since the lightning beams are "curving" to hit it. Not all beams curve to the target though. As the target's being hit there's also lightning coming off of the target, however the sparks from impact seen from the first part is not seen on the body of the target (it seems that because the lightning targets the center of the model, the sparks will be found there, if the model ever becomes invisible). The number of lightning beams seems to stay the same.

**4. Shooting directly at the target:** This seems to display the same behaviour as 3.

**5. Shooting between multiple targets:** This seems to display the same behaviour as 3. However the number of lightning beams increased to anywhere from 3 to 7 beams.

**6. Shooting at the air but with ground in range and target moving into range:**

The cannon is aimed at a wall out of range, meaning it's essentially shooting at the air, but because there's a wall inside the range, the lightning curves from the cannon to the ground to hit it. There's still a lot less occasional beams compared to when it was aiming at the wall, but more frequent than 2. since there are other objects/surfaces in range for the lightning beams to hit.

As the target moving into and away from hitting range, a number of lightning beams also curves to follow the target.

## Optimisation and Performance
> How ‘heavy’ or ‘expensive’ do you think are the systems in what you were critiquing? Why are they heavy/light?

I don't think the system is particularly heavy. It shouldn't be heavy because it's used very frequently in game, and there will be 11 other players whose characters will also have their own dynamic systems, and having 12 heavy fx's constantly taking up big chunks of computing time is quite taxing for the game. 

## Dynamic Systems
> Identify any dynamic systems you can see. This does not need to be 'accurate' to the original file (if the video is from another student): write what you might use yourself, to achieve the same result. Explain/justify.
> If applicable, discuss other potential systems that could be used as well.

**1. Lightning FX:**
- This is most likely a particle emitter that can emits prefabs
	- The shape of the emitter would be a cone, since if you were close to the target, but not shooting directly at it, it wouldn't hit, but if you took a step back like the video, it hits.
- The prefab could be a long plane/line renderer with many subdivisions (which should allow it to curve like in the video)
	- There also seems to be 2 different kinds of beam, one straight and one looking like a wave, so one basic line renderer and one with an animated shader
![enter image description here](https://media.discordapp.net/attachments/713735780412948554/835836580601135144/unknown.png)

		Fig 1. Anatomy of the lightning beam
- The animation of the lightning seems to be looping. This means it's either created using an animated shader or sprite sheets. It's more likely that former was used since the animation lasts for a long time before reaching the beginning again, and using an animated shader is more efficient than using sprite sheets (1 small shader file vs 1 large image).
![Alt Text](https://i.pinimg.com/originals/84/32/a0/8432a099f67299cb3a227bdff2c00d10.gif)

	Fig 2. Examples of animated shaders ([link to gif](https://i.pinimg.com/originals/84/32/a0/8432a099f67299cb3a227bdff2c00d10.gif))
- Should a beam of lightning intersects with a surface (not hitbox, since the character can collide with certain objects, but it seems that the beam only affects a certain number of targets and surfaces), there is also a particle system emitting sprites of impacting sparks at the point of intersection

**2. Lightning FX from the cannon's barrel:**
- This is most likely also a particle emitter, but it would emit sprites with randomized orientation instead.

**3. Impact FX:**
- Also most likely a particle emitter, but has to emitters, 1 for the impact sprites, and 1 for the sparks. This exists at the end of the lightning where there's an interaction between the beam and a surface.

## Forces, Movement, and Randomization
> Similar as above. Identify potential force objects that are used, or that you might use should you try to achieve the same result. Explain/justify.

There seems to be no forces applied involved in this fx.

For randomization, these are the randomizations that were noted:

**1. Lightning FX:**
- Amount of beams at any one time (this seems to be a range than a number since a minimum amount was observed to be increased) 
- Where the lightning beams initially strikes
- Their lifetimes

**2. Lightning FX from the cannon's barrel:**
- Which sprite to use
- Rotation
- Lifetime

**3. Impact FX:**
- Rotation of the impact sprite
- Amount of particles for the sparks

For movement, it seems that if a qualified object (the cannon possibly had a list of object types that it could interact with) moves into range, some of the beams would target the center and make a curve and stretch from the barrel to the center of that object.

## Physics Phenomena Discussion
> On a more theoretical level, identify and discuss physical phenomena that you think is being addressed (and how well/deeply it is being shown) in the video.
> Also identify what phenomena is not being addressed very well, that could/should be shown, or made more prominent.
> Reference links to footage/phenomena/wiki articles will be useful here too.

Since the weapon is called the Tesla Cannon, it's safe to assume that the fx it's trying to replicate is from the Tesla Coil.
![Alt Text](https://thumbs.gfycat.com/DarlingImpressiveBlackwidowspider-size_restricted.gif)

Fig 3. How the lightning fx from the Tesla Cannon should look like ([link to gif](https://thumbs.gfycat.com/DarlingImpressiveBlackwidowspider-size_restricted.gif))

Here are the things that it failed to replicate:
1. The fx's lightning doesn't fork like real lightning, and the shape of the beam moves forward like oscillating soundwaves, which is not at all how lightning behaves.


![enter image description here](https://external-preview.redd.it/DD3GYbaSmtgrDoAoj5D2vmqZnAEjDmSM0kG6svruaZw.gif?s=62bb040155be78d38c00179f0fae01cf55197446)
	
- [Link to gif](https://external-preview.redd.it/DD3GYbaSmtgrDoAoj5D2vmqZnAEjDmSM0kG6svruaZw.gif?s=62bb040155be78d38c00179f0fae01cf55197446)
  	
    - Real lightning doesn't move its shape forward, but it creates its shape as the electrons find their way to ground. So the fx should look static, rather than moving.
	- Each beam in the fx consists of a straight beam and a "wave" beam, but real lightning only has 1 beam, it starts as 1 sharp, zig zag beam (sharper than how the wave beam looks, and also moves a lot quicker), and branches out multiple times as it travels in the air.

2. Lightning *does* bend to hit surfaces, but it doesn't always do that like how the connecting beams on the cannon always do (gif below). 
	- If a path to an object clearly poses the most efficient way to ground, electrons wouldn't fork off, so there would only be 1 constant beam between the cannon and the object (refer to [this part](https://youtu.be/_fTC_Ud_k3U?t=541) in SmarterEveryDay's video). This part the cannon does right.
	- But if there are points on the path where electrons find another more efficient path, they would still branch from it (refer to [this part](https://youtu.be/_fTC_Ud_k3U?t=481)). Throughout that entire process, electrons would still "zig zag" its way towards the object due to air molecules constantly moving, affecting the most efficient path.

		![enter image description here](https://obhsdunnz16113.files.wordpress.com/2016/05/tesla-inventions-tesla-coil.gif)
		
        [Link to gif](https://obhsdunnz16113.files.wordpress.com/2016/05/tesla-inventions-tesla-coil.gif)
3. Extensive googling hasn't shown an object continuously being struck with lightning to have lightning exists around it (there's also no sparks if the impact material is highly conductive). This is most likely a juice fx added to make the entire fx more extravagant, which fits for a video game wanting to have extra flairs.

4. The color of the lightning was accurately represented. Blue and white is from nitrogen gas (has the most amount in the atmostphere, meaning it's common for lightning to have this color) being excited by energy (refer to the article for [lightning colors](https://weathergeeks.org/true-facts-about-lightning/))

======================================================
# Insights/Questions/Comments
##### Q: Technical Critique - What sorts of things do you think could be focused on to make the motion/physics better? What would you do to make the scenario/video better?
A: Even after analysing and critiquing the fx, I wouldn't make any adjustment to the fx due to the aspects of UX design in game design and the need to give the player clear feedback on their actions. Looking at the old Tesla Cannon's design, it probably did a better job at replicating the fx than the new one, but it definitely looked a lot less exciting than the new fx, which in my opinion is the focus for making VFX for games, making things look interesting, rather than making them 100% physically accurate.

##### Q: If applicable, how much discussion did you have with the author of the video you were critiquing, for this report? What sorts of information was helpful to discuss?
A: I would pay $10,000 to fly over to Blizzard HQ in the US to talk to the VFX designers for Overwatch if there's ever an opportunity to do so.

##### Q: How did you find the experience of having to critique a piece of work, rather than creating your own?
A: It definitely helped consolidating my workflow of analysing a real life fx to find small details that I need to focus, while also thinking about what features I can keep and what to enhance/throw away for the sake of juice/performance.

##### Q: What was easier/harder in this task than you expected? Why?
A:

##### Q: Any other comments/feedback/ideas?
A:
