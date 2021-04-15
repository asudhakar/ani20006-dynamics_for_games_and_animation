

Dynamics for Games and Animation
======================================================
# Task 3 Report - Multiple Systems
Student Name: Khang Trinh
Student ID: 102118468

======================================================
# Resources Used
> List (with names/titles) any websites/links that you found useful/helpful - don’t include things like search engines

References

Making a campfire in unity https://youtu.be/G0R7MIbX3MU

Rendering water
How real-time fluid simulation works https://youtu.be/tzc0Iq9Zgt4
A 2D way of achieving this FX https://youtu.be/_8v4DRhHu2g
Intro to raymarching https://youtu.be/Cp5WWtMoeKg
All about raymarching http://jamie-wong.com/2016/07/15/ray-marching-signed-distance-functions/#the-raymarching-algorithm
https://www.scratchapixel.com/lessons/3d-basic-rendering/introduction-to-ray-tracing/how-does-it-work
Signed distance function cheat sheet https://iquilezles.org/www/articles/distfunctions/distfunctions.htm
Smooth min for intersection https://www.iquilezles.org/www/articles/smin/smin.htm

Basics of writing shaders (HLSL) https://youtu.be/bR8DHcj6Htg
An overview of compute shaders https://youtu.be/9RHGLZLUuwc
How to write basic compute shaders https://youtu.be/BrZ4pWwkpto
Full tutorial on writing HLSL for raymarching https://www.youtube.com/playlist?list=PL3POsQzaCw53iK_EhOYR39h1J9Lvg-m-g
> Which software did you use for this task?

Unity
Photoshop

======================================================
# Task Details
## Scene Design/Vision
> Describe what scenario you were aiming to create, and what 'events/interactions' would be occurring, include reference images to help describe the look you were aiming for (include references/source links).

**Event summary:** A campfire starting and being extinguished by water.
**Video References:**
- Overview of the entire FX: https://youtu.be/0O3Bj8JFcTc
- FX in Slowmo: https://youtu.be/yGbodsAV03M
- Campfire on loop: https://youtu.be/qsOUv9EzKsg

**Specific interactions:**

**Phase 1 - Starting the fire**
 - Fire burning wood: 
	 - Flame has more yellow colors than red
	 - Very light grey smoke (amount dependent on firewood material)
	 - Embers (amount/frequency dependent on firewood material)

![enter image description here](https://www.rei.com/dam/van_dragt_041117_campfire_structure_types_composite.jpg)
Fig 1. Campfire reference image

**Phase 2 - Extinguishing the fire**
 - Fire being extinguished by water 
	 - Flame shrinks overtime as more water is poured into the wood
	 - Rate of embers emitting reduces as more water is poured
	 - Just before the flame disappears, a lot more smokes will be emitted (they also seem to have a much longer lifetime as well. Wind also seem have a huge effect on it)
 - Water splashes from being poured into the firewood
	 - Has a certain viscosity level (friction with the surface and other water particles)
  - There might have been water droplets being vaporized after touching the flame, but in the video this wasn't noticeable. So, while it might have happened, I won't be replicating this aspect to save performance.
 
![enter image description here](https://www.rei.com/dam/van_dragt_041117_0216_extinguishing.jpg)
Fig. 2 How much smoke can be emitted from extinguishing a campfire with water

## Dynamic Systems and Forces
> Referring to the physics phenomena behind the interactions of your scenario, are there any real-world interactions you were trying to mimic?
What composition of forces did you put together to achieve more complex movement? 
Describe/explain, and use diagrams/reference images to support.

Fire being extinguished by pouring water over it
Turbulence to make fire rises more erratically


## Scene Composition Overview
> As a summary/overview, list and describe the objects you have used/created in your software/file (i.e. "what is it, why is it there, what is it for?")
> Include a screenshot showing the composition in the software editor (showing force icons, object tree, names of objects, etc...)


## Systems Used
> What systems did you use (rigid body, particles, cloth, hair/fur, etc…), and what are some key parameters/settings did you use/why?
Describe/explain, and use diagrams/reference images to support.

For the flame, smoke and embers, I used the shuriken particle system.
For the water, I couldn't use the shuriken so I had to go the old way of duplicating multiple individual particles to create the simulation (more discussed below).
Rigid bodies and colliders
## Other Objects and Concepts
> List/explain any extra things you have added to your scene that aren't addressed in other parts of your report that you want to highlight.

Campfire model for realism
Invisible ramp to transfer water particles (making it transparent didn't make sense, might as well not have it visible)
Flickering light - realism

======================================================
# Insights/Questions/Comments
##### Q: Did you attempt any new dynamic systems not covered in the unit so far (i.e.anything other than rigid bodies and particles)? What motivated you to try/use it (or not try them)?
A:

##### Q: Did you run into any issues with any processes you did in this task? List/explain what you tried/how/if/ you solved it or not.
A:

##### Q: What was easier in this task than you expected? Why?
A: Making fire

##### Q: If you had extra time what would you want to improve on?
A: Actually making water look like water

##### Q: Any other comments/feedback/ideas?
A:
