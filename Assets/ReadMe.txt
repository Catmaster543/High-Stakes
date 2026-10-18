# Note
To anyone else finding this - this ain't no AI written stuff, it's me writing this to my fellow.. co-worker could one say?
It's mainly to make their (and possibly mine too if I ever forget) life easier.
 - Coworker here who read it, thank you :]

# System - not needed for now.
Each day is its own scene, binded on the days "The manager" nextscene binding.
In case of rewinding the current scene is reloaded, which saves me a whole lotta trouble.

# Characters
Each character is a separate game object of type "2D sprite asset", with the "Speaker" script attached, where the correct values NEED to be set. 
The exception is "Emo Sprites" and "Speakers obj", both of which were/are meant to be used in the future, thus nothing has to be assigned.

# Dialogue
Manageable on "The manager" object.
I do NOT reccomend messing with anything in any of the "References" categories unless neccesarry, or curious, stuff can and most likely break.
The "day" setting just sets the day of that scene, used on rewinds. Changing it to smth else for now will prevent rewinds from working correctly.
## Lines
TLDR: 
Add a line into the list using the + button.
The "type" setting decides how the script will treat that line, if "line" is chosen, everything set in the Line type settings will be done, with the exception of "TextSpeed" that I had no time left to mess with.
The ActiveSpeaker - just drag the characters game object into the field and unity will fill it out by itself. It needs the script mounted on the character obj.
If "choices" is chosen, you can add in the choices using their list right under the title for their settings.
Each choice contains:
- Name = what text will be on the choice button
- Reply = just another line, is the reaction to clicking on that choice's button. I have ONLY tested the reply to be "Line" type, I have no idea and maybe don't want to know what would happen otherwise. //// ah that explains it. Welp it doesn't work when the reply is a choice :[
- isBad = if selected, this becomes the "bad" choice, which will display the reply and then forcefully take you to the rewind sequence.
## Other Line settings
The "Characters to spawn" and "despawn" - add in any of the characters GameObject and upon reaching that line they will appear/disappear.
Note that characters that will "spawn" at some point are automatically hidden on start, pretty neat? No? Rly? Are u sure? ///Are you talking to the walls again :[ ? [jk xd]
The scene settings work similar to character spawning - once that line is reached the bg (background) and fg (foreground) are changed to whatever sprite you've selected. If nothing is selected, then the current bg/fg is kept.



Notes from coworker
- I have no clue how to make the fg work
- Why was there a PINK OVERLAY EVERYWHERE????? IT LOOKED SO FUGLY TH?? Also the original bg T-T???
- The chat gets stuck if a reply is another choice
- The characters name wont show when they first spawn.