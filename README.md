# InfiniteRealityAssignment

**Describe any important assumptions that you have made in your code.**

I have assumed that the person going through this project will be accessing it on an average computer capable of running the project seamlessly on a Windows system. I have also assumed that the instructions given to me for this task were what was necessary and anything beyond what was told to me was not. I assumed that I was also building for a Windows system. 

**What edge cases have you considered in your code? What edge cases have you yet to handle?**

I handled some edge cases that were strange shapes by simplifying the qualifications of being "inside" of the basket. The object simply needs to touch a trigger collider at the bottom of the basket in order to count for points.

This does run into the issue of some concave shapes though. There are certain shapes that would not seem "inside" of the basket despite touching the bottom of it. To address this, we can calculate the center of the mass or delegate it beforehand as a 2D point. This point can be checked to see if it is within bounds of the trapezoidal shape of the basket.

**What are some things you would like to do if you had more time? Is there anything you would have to change about the design of your current code to do these things? Give a rough outline of how you might implement these ideas.**

There is much I would like to do had my time not been so constrained. I would expand upon the scoring system, maybe putting in special fruits with combos and multipliers. Fortunately, there is not much I have to change the design of my current code to accomplish the calculations of this, as my ScoringModifier system should be able to take care of it. 

In terms of adding more content though, much can be changed. Currently, each fruit is an individual prefab, and the fruit values are hard-coded into the game because of the game's current simplicity. If I were to expand on the gameplay systems and create more fruits, I would need a ScriptableObject setup for each fruit as well as Editor scripts to support it. These Editor scripts could either read in the fruit data (value, weight, collider data, etc.) from a separate database, or they could just make it easier to adjust many fruits at once. 
