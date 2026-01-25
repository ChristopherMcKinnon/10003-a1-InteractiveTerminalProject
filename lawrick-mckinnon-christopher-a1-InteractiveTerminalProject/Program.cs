// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;
using System.Runtime.InteropServices;

// /\ /\ /\ This stuff came with the project, i'm not sure if I can remove it without random things breaking yet so i'm leaving it in

/*
 
For this programming I was allotted the use of "goto" as a nessesary way of structuring my game.
I tried to keep the broader scope of programming techniques to a minimum, to keep the challenge of using something just 
variables, input, output, and logical operations.

DateTime.Now was referenced in "Module 1b - Parsing strings as other variable types", so I thought it fair game to use

Nothing about this project involved AI,
and the ascii images are technically mine as they are free of licensing constraints and I made the alterations myself!

I hope you enjoy!

 */




// Initializing variables

int playerInput;
int roomTracker; // Tracks floors with bad interactions
int badDecisions = 0; // Tracks amount of bad decision for dialogue additives

bool getEvidencePhotograph = false;
bool getEvidenceCrib = false;
bool getEvidenceShrine = false;
bool getEvidenceAll = false;

string errorMessage = "You messed up an input and promptly died, start again";
string credits = "A game made by Christopher David Alexander Lawrick-McKinnon for a college assignment at Mohawk College. 1/24/2025\n\nPress enter to close:";

// Setting Dialogue

// Bad Decision Additives
string badDecision1Dialogue = "Your stomach is UNEASY..";
string badDecision2Dialogue = "Your stomach is in KNOTS..";
string badDecision3Dialogue = "Your stomach TWISTS..";
string badDecision4Dialogue = "You feel like VOMITING..";
string noBadDecisionsLeftDialogue = "This place now NO LONGER MAKES YOU ANXIOUS..";

string currentBadDecisionDialogue = "currentBadDecisionDialogue"; // Placeholder and init

// Evidence Dialogues
string evidencePhotographDialogue = "You holster your gun and awkwardly lower yourself down and lift the plant pot revealing a photograph.\nIt's hard to make out, but you can see a dark corridor lined with brick walls. At the end of the hallway is a room, but something seems to be climbing out of the room.\nSomething ill exudes from this image. You probably shouldn't make any noise if this is what awaits you inside.\nEVIDENCE COLLECTED\n\nPress enter to continue:";
string evidenceCribDialogue = "Leaning over the crib, you spot with your flashlight a brand new plushie basking in layers of dust, and well prepared sheets.\nDeep down you know what this means, and the academy tried to train you to avoid any instance with these beings.\nTo leave the house now would only further the cycle. You should have left while you could.\nThe caller should be left here if you can escape, they lured you here after all.\nEVIDENCE COLLECTED\n\nPress enter to continue:";
string evidenceShrineDialoguePre = "You turn the corner heading to the back of the room. The darkness seems to creep up your spine, but you're trained for this. You turn into the room.\n\nPress enter to continue:";
string evidenceShrineDialogue = "A set of candles greet your cool face. A photograph with a small stand, and a wooden cross sit atop a small table. Taking a step in and examining the photograph shows an ultrasound of a baby.\nDespite the warmth of the dying candles, the room isn't any less unwelcoming or foreboding. Someone has been here, and spent much time here.\nEVIDENCE COLLECTED\n\nPress enter to continue:";
string allEvidenceDialogue = "A weight seems to have been lifted from the house, you can leave safely now.\n\nPress enter to continue:";

// Ending Dialogue)
string ending1Dialogue = "You took too long.\n\nA flurry of footsteps and groaning can be heard.\n\nPress enter to continue:";
string ending1Dialogue2 = "Something rushes to you from another room in the house in mere seconds.\nYour gun and flashlight aren't enough to calm your nerves at this point.\nAs it turns the corner, your last thoughts consist only of how suprisingly hideous the thing before you truly is.\n\nENDING 1: STOMACH\n\nPress enter to continue:";

string ending2Dialogue = "You call in the report as false and head back to the station.\nDespite normally refraining from guilt, your gut turns as you drive away from the house.\n\nENDING 2: REPENTANCE\n\nPress enter to continue:";
string ending3Dialogue = "You walk over to the closet. Your insides are screaming. Looking up with your flashlight renewed the dread you had hoped was unfounded. The raw appearance of the thing was enough to put you into shock, and you passed out hitting the floor.\nYou were never found again.\n\nENDING 3: CLOSET\n\nPress enter to continue:";
string ending4DialoguePre = $"You're not sympathetic enough to check on the woman locked in the bathroom.\nFinding yourself back in the cruiser parked on the long dirt road, the dashboard reads {DateTime.Now}.\nFatigued, you head back to the station to end your shift.\nAfter arriving back in your bed however, your mind is restless. You try to rack your brain about the sudden guilt you feel, but come to no conclusions. It's then that you see it.\n\nPress enter to continue:";
string ending4Dialogue = "Sitting by the doorway is a figure you seem to recognize. Your heart jumps, its the figure from the photograph.\n\nENDING 4: REMORSE\nPress enter to continue";

string ending5DialoguePre = "You knock on the door. Looking to your right down the hall the bedroom still fills you with chills. No response.\n\nPress enter to continue:";
string ending5Dialogue = "Reassuring the woman of her safety that the horrid thing was gone, there was still no response. Breaching the door, you find that you we're still too late.\nDespite all of your harrowing attempts at rescue, thinking that you might still have some empathy for the people in this world, there she lay, dead in the tub, just to spite you;\nA choice she'd rather have over facing you, let alone that thing she brought into this wretched house.\nAll you can think about at this point is sleeping. Walking out to your car, you call-in the situation, then head back to the station to end your shift. Your sleep that night is nothing short of nightmarish. In the days that followed, you submitted your resignation from the police force of Westcrow County.\n\nENDING 5: SOLITUDE\n\nPress enter to continue:";

// Ending Tips
string stomachTip = "Next time, try recognizing when you get anxious.\n\nPress enter to continue:";
string repentanceTip = "Next time, try playing more of the game.\n\nPress enter to continue:";
string closetTip = "Next time, try picking up on scene clues to avoid death.\n\nPress enter to continue:";
string remorseTip = "Next time, try finding the secret ending!\n\nPress enter to continue:";
string solitudeTip = "Congratulations, you found the secret 5th ending. - Chris\n\nPress enter to continue:";

// Scene Dialogue
string intro = "You are a new police officer Evan Ross answering a reported break in and home intrusion in Westcrow County.\nThe station being short on manpower however, has sent you out alone.\nThe caller has locked herself up in a bathroom within the house.\n\nPress enter to continue:";
string introWarning = " - You mustn't waste your time.\n\n - Collect 3 pieces of evidence\n\nPress enter to continue:";
string scene1Dialogue = $"The dashboard reads {DateTime.Now}. \nYou identify the house number and park your police cruiser thirty feet away. \nGetting out of the car you notice the air is still, and a small pain forming near the back of your neck.\n\n(1) Search the perimeter of the house\n(2) Walk to the door";
string scene1_1Dialogue = "With your flashlight on you walk on the unstable path surrounding the house.\nYou spot no points of entry or open windows. The house is quiet.\n\n(1) Walk to the front door\n(2) Leave";
string scene2Dialogue = "You walk up the front steps of the weathered one-story house.\nSomething white sticks out underneath the plant pot by your feet.\nYour gun and flashlight are at the ready.\n\n(1) Call the intruder to come out\n(2) Open the door slowly\n(3) Look under the plant pot";
// Scene 2_1 Dialogue handled by BadDecisionsHandler;
// Scene 2_1_1 Dialogue handled by BadDecisionsHandler;
string scene3Dialogue = "Testing the door you find that it is unlocked. You slowly creak the handle attempting to make the least possible noise, pointing your flashlight and gun. Press enter to continue:";
string scene3Dialogue2 = "The light switches don't seem to function. You are greeted with a dark hallway, and basement stairs to your right. Several closed doors line the hallway in front of you.\n\n(1) Search the basement\n(2) Search the bathroom\n(3) Search the bedroom\n(4) Leave";
string scene4Dialogue = $"Pointing your flashlight down the basement stairs you find its reflection in the gas pipes that line its barren walls. You tread down carefully and quietly.\nThe basement was clearly more of a workshop to someone, fitted with metal shelves, a sink, lathe, and a toolbench. Everything is empty besides some pen blanks however, and hasn't been used in a long time.\nTo your left lies a small room with a stench.\nPeeking around the corner to your right you see another doorway at the back of the room, with a flickering light emanating from within.\n\n(1) Go left\n(2) Go right\n(3) Go back";
string scene4_1Dialogue = "Turning the corner to your left you encounter a small, unmaintained sauna room. A bad smell reeks from the unstable boxes this room was improperly used to hold.\n\n(1) Investigate the boxes further\n(2) Go back";
// Scene 4_1_1 Dialogue handled by BadDecisionsHandler
string scene5Dialogue = "The door is locked. This is likely the bathroom that the caller was locked in.\n\n(1) Knock on the door\n(2) Go back";
// Scene 4_1 Dialogue handled by BadDecisionsHandler
string scene6Dialogue = "A feeling of impending dread beats in your chest...\nYou can feel you will regret going here.\n\n(1) Enter the bedroom\n(2) Go back";
// Scene 6_1 Dialogue handled by BadDecisionsHandler
string scene6_1_1Dialogue = "Collapsing down swiftly, you peer underneath the bed. Nothing notable but some cobwebs and packed away boxes of diapers.\nPress enter to continue";
// Scene 6_1_2 Dialogue handled by BadDecisionsHandler

// Images
string corridorImg = "                                                                                                    \n ::::::::::::--:----::::-----..:-------------------------::::---------:-----:::-------:--:::-::---- \n ::::::::::::::::-:------::-----:::---:::::-:-:-::-----------:---------:----::------:-:----=---:-:: \n ::::-:::::-::-:--::-----:--:---::--------------:----:---------------:-::::::-------::------------- \n -:::::::::----:------:::-------:-----:---------------------------:::--:-:-:--:-------------------- \n ---:::-------:::-------------:---:-----------:-::::::::::::::----:::-::--:::---------------------- \n ::----:::::--:-:-:::------:--=---:::::::::::::::::::::::::::::::::::-------:---------------------- \n -:::--::::::::::---:----:::----------------------==-=====--=--------------::-----:----====-------- \n ==-::::-----:::::----:::---------:--------=--==--==---=======----------=--:--------===-------=-=-= \n --=+==-:::---------:-----:-----:----:--:::.:::::::::::::::::::::::::::-:::::==----========+*#**+=- \n -:-++++++:-::-::-------:-----=+=---:--::::::..:.........::::.:----:-------:-----=========+**  -*+= \n :::--+**+:=+-:--:--------====+++-=-:::--::::-=-----------=----:::-:---=---:-=========+*#*- .  +*+= \n ::::. .:-:+#+---------=-==-===++:==:-------==========------:----:::-----=-:=====-==+**+: *@*  *+== \n -::---::::..:--------=====-=+=+#:==:-:-=======+===+=++==+==-==---::----:=-:-=====++=:::- %@:  @#+= \n ::::::-:--------::--=====+==+=+*:==:-:-+=+**++***********++====--:----=-+-:-======-::--- @@. .@%*= \n ::-::-#.:--------:==-==++*##%%@%++=:::=++#%@@@@@@@@@@@%%%%*+-=-:-::-=---=::-====+::----- @@  -@#*: \n ::--::@.:::::::--:====-..       .+--::=*.                  *-==---:-----=--===--+:--=--: @@  -@%%  \n :---:.@=:-----:--:-===-::---:-::-*--::=*:.:.......:::::---.#-==:-::-----=-:=+===+------:.@@  +@%# =\n -::-:.%+.:----:--:-==+=::-----::=%--:--#-=++*#%%**+====--:.%-=----:----==-:=====+----==::@@  %@@# %\n :::-: ##.::::::--:-=-+=::::::--:-%--:-:%-.:.        .-----.#-=-::::--=:=+:-++====--==+=:-@@  @@@* @\n :-:-: +%.:-------:-==++.:------:-%-=:::%-:::=%%@@@@@------.%-=:-::::-=:++:-=====+=--==-:*@%  @@%* @\n :::--.=@:.--:-:--:-+=++::------:=@:=:--@::::=##%%@%#.----:.#-=:---::==.++:-+======--+==.#@*  @@%= @\n -:--:.:@-:-----:-:-++=+::---:-:.-@:-:-:@::::=%+*%%**.-----:#-=:---::=+.*+:-+===++---=-=.%@:  @%%: @\n :::--::@=.-::-::--:+=+*.:-::--::=@--.::@-.:.+%+=++++.-----.#-=::--:-=+.#+::++====-=====.@@. .@%%  @\n -----..%=.--------:==+*:.-----:.:@-=:::@-:::*#=-+===.----:.#-=::--:-=+ @=::+=====::::-:-@@  -@#*  @\n -----:.%#.------:-:===*:.--::::.:@=:.:.@-:::*+=:====:-===-.#-=::::::=+ @=--+==++**##*=:=@@  *@#* .@\n ---:-:.*% :-------:=++*-         @=:.-.@-.:-*+=:==--.:::::.#==:--:--=*.@==-*+++++++*#%##@*  @@*+ .@\n ---:-:.+@.:--------===+*%@@@@@@@@@*:::.@=.::*+=.=---::::.. #==:-::::=+ @===++=++++******@+  @%*= -@\n ---:--.=@.:-------:==+==+++++****@*.:-.@=.:-++:.=-----***=+*==:--:-:+* @==-++=+=++*++***@-  @%#= +@\n ---:-:::@-.-----:-:=+++++++++****@*.:-.@+.:-++=:=----:=+==#++--:-:::+# @===+==++=**++***@. .@#   @@\n -----:::@+.-----:---+====++++++**%%..-.@+.:=+=:::::::--++=*=+-:--:-:** @===++=++=*+*****@  .@@:. @#\n ---:---.#*.-----:---+===++++++*##%%..-.@+.::..:::::::.:-=+#=*-::::-:++.@-==++=+++**+++**#  =@@-. @=\n ---:---.*% :------:-+=+=++++++***%@..: @+ ::---------:.:--+-=-::::-:*+.@===++++++*+++++*%@+    . @:\n ---:---.=@.:-------:+==++=++++++*%%:.: @* :-----------:.-=+-+-::-:-:*=:@-==+=++++++++*++**%@%-   @.\n -----:-.-@.:-----:-:++==++++++***#@:.-.@+ -------------:.-++*=---:-:#=:@-==++=++++++++++++++*##* @ \n -------.-@-:-------:+===++++=+*+**@:.-.#-.--------------:.....:-::-:#=-%===+==+=++++++++==+=++++-  \n ------::.%=:-------:+=====+=++++*#@-.-.:::----------------:::---::::#--#===+=+++++++++++++======-- \n -----:-::#+.---::--:======+++++++*%-.--:------------------------::::#-=#=--+=++=+===========+==+-- \n :-:-::-:.*+:----:--:--===-==+=+++*#=.-::------------------------::::*:=*-===+++=+++++=++====+===-- \n :---::-::+*:=-:::---:-===========+#=.-:::::-:::::-:::::-:-::-------:*-++-===========+========-:--= \n ::::---::::::::-:-::===+=+++*++=++#+.:-----------:----------::---:::+-=+---+===========+====--==== \n ::::--:---:::---:--:::::::.::-====*+.::::::::-::::::::------------:-+-++==================-=---::: \n :::::::-:-:::---:--:-::::::... . ....:-:--------------:-:::--------::..  .-=++======+==-===----:-- \n ::::::-::::::---:-:-----:::-------:------::-------------------:-:-::::-:::..============--====---- \n --::::----::-------::::---=---:--------------=-------:------=-------------::.:+=----=-=-------:--- \n :---:--:-::------:--:-:----:---------------:--:::--:----:::::::::--------:-::..====-=------------: \n :::-::--::----::-:---------:------------------::::------=-==--===-----===--=::::===---------:---:: \n :::-:--:----:-----------===-==--============-=========--=---=-=====+====----=-.:.:=-:------:    :- \n :-:-:-::--:---:-------------=======+===========+++====++=+=+===-----========-=-:::----:      @@  : \n :-:-::::-----------------===========---=======-=--------====+===-===----------=-::::-=--@  @@@@@ - \n --:----:--------------=---=----=-++++=-======++++=++++*+++=+====-=----------------::::   @@#@@   - \n --:::--:-----------:------=-==-=-----===++==================--=--=----=------------::. @@@@@. @@ : \n :::-:::---:-------------=-------====--=======+=--=-----=++=-===--==-----------------:.+@@@.     .: \n :-:-::-:---:-:::---------------------=-====----==---=------====-===-===----------:---.     .----:- \n                                                                                                    \n";
string followedYouHomeImg = "                                                                                                    \n                    ..            ..     . .                                                        \n  .        ..                            .                                                   ..     \n  *=.                  ....    . .   ... .  .......          ....   ....  .   ...            . ...  \n .==-.                  ....  ..                                            ......  .          .... \n --:-++.         ....  .....  ..          ..                 .       .     .......    .      . .... \n -:::-==.        . ..  .....          ...       . .   ........      ..  . ...........          .... \n -::..-*==                 .......   ...... ... . .          .    ..       .............   .   .... \n +....--=*:.               .......      ....                             .. ............       .... \n.::.....:--+:          .   ...........  .......                    .   . ................      .... \n.::......::=-.             ...........  .......   .   .......    . .   . ................  ........ \n.:.........:-+=.    ..................      .....                                       .......     \n.-...........:*+-   ..................      .....            ..    .          ....      ........... \n.... ..........:=..    ..................   ......       ...    ....          ..    ............... \n...............::+=: .  ............................     ...               ..................:..... \n.................::=..     ...... ............. ....   ...       .................................:.\n.................:.:+=..   ...................  ................................................... \n....................--:...  ......      ....    ................................................... \n:. ..................=-+-.                ...................       ....  ... ..................... \n:.     ..       ......::+:.       ........ .                           ....................:.....::.\n................: .....--.         ...      :..::...................................................\n...............       ..-.                  ..............................::::........:.:..:......  \n.......  ......         -.                  ..::.................................................   \n........:::....         -.                  ..::.................................................   \n.......   .  ..        .-                   .. ...................................................  \n...............        .-                   :...................... ..............................  \n      .........        ..                   :............... .....................................  \n...............        ..                   -.....................................................  \n...... ........        ..                   -.............................................::....... \n.--:........ ..        ..                   :...................................................... \n.-:::::::::....        :.                **+=:.............. ...................................... \n  .:-=+::--::..        ..             .=+-   :*-..............................................:.... \n      :=-=+----::      :.            :=+.      -:.................................................  \n         ..-==--=-:.                .-+: :  %-:*+: ......:......:::.................................\n           ....-+==*+-==            -=+-       ==. ......:......................................... \n               :*=++-===           :++=:.--+::-#+-........ . ..................... .................\n ....... .  ..=%@#**++==       .-+#%**#*:   .#@%+-..................................................\n   .  ...        .=##+==      -#*+*****#%*+%%#+==-...::...............................::........... \n                     .==  .+#%##*********===+*+--:.:.::......................:........::........... \n                       -..-*************#****==::::::::...............................:::.......... \n   ...                 ..-##******+++++++++**+=--:.:::..::..........................:::::.......... \n   ...                 .-=*++++++++++++++===-==--:::::..::..........................:::............ \n   ....   . .          .%%@*####%%@@@#***+++- -=::::--::::.......................::-:.:.............\n                                ..+++#######-.-+--::------:::....................::----=:...........\n                                                 . ...----::-:::::::.........::::::.:--::::-::..... \n                                                .. ...----::::::::::...::....:::::...:.:-:--.:.:::. \n                                                ::=-------::-::::::::::::::::::::::::---::--::.::.: \n                                                ::=---+++-::-==--::::::-::::::-::::-----::--:::..:. \n                                                -+####***####+*+----::::::-::.:::::--:::-------::.:.\n       .                                        *#%***####*****#*=--:::::::-:--------==-===-::-=--:.\n       . ..     .                             ..=*#***#*******#*#=-:::::-:.::-====:---+=+==--------:\n       .           .                         .:-..******++++=**##=-----:...:::=--==-===++-:---===-=:\n                                               ...+*****++-+*=+++---=----:::::==-===-=++*++=:::==--.\n                                                . ...#+=-:  -::=++-::::::::::.:::---:-::+-=::::---:.\n\n";
string basementStairsImg = "                                                                                                    \n\n\n\n                                .   .                      .:.  ; .. .x;   :  ;    .  ;x  x.:    x$ \n                                                          ;  .+  ;: + ;x$ +: . $   ;+ .: +:  :;+    \n                                                     :;;. ...::;  ; ;  ..      +.        ; .    :x; \n                                                       .. . .  X  :::..X; ;&++  ::  :  ..  .xx  :   \n                          .                            .;   .. : .:  . :: .  ;:.  ..:. .  .:+  .X:$ \n                       ..  .::.                         :. . ;: .++; :x.  :; .; $      . &  x  . ++ \n           .           ::..    ....::::::: .. ..    ..  :  .  :; :;+: . ::+: :+ X;  .;X  &          \n        ..                ....          .:.    .            ;:   :::&x  .. x&$   ;+$   .+X. .; . :. \n                  .::   ..    ..    .:.           :.   :::. ..x  x+ $$: & :    .x:. ;x  ;  ..  + .. \n        .   ..:  ..                              .   .     .. ; ;:+. ;X: .. ; +...  ;..   :  ..;    \n      .        .       ....                                 .:.+ :;; .x.;:+.&; .+ : +.$:;  ;;  .    \n      ..     .....  .;    :::.  .    ....:... .. ..      . .;: .: ++;X. .$.:+&;.&   :  .x: ::: :.   \n       ... ::  . .     .          .       .    .  . .  . ;  :X. ;. :;:.+:::     x: .xx.. :  .   ..  \n        ..      ...:;;;;              ....  ..    ..   .  : .: ; x& &.: +:&x&:.;+ x .  : &; .;  .;+ \n     ..   .;;;;.:       ;X: :  .... .         ...  .;;     ;  x ..X;  +;& ::+:; +:$X  ;  .: ;+&   . \n   ....  ..         .;...::    ...   .  ...     :      :.   . .x; ;:& &:x;.x;:  + .  +;;  : .  +x:  \n ....           ... .  ..   .:..    .        .. . . . .. .     x: X+& : +..+.+&;;    +     +..xX:&. \n       .:   .+X+:..      .:.   .   ..     .. .... :   :  ;   . xx:: ;x.$x+.+:+.& :+x  ;:. .: .  . x \n          :;:  ..    $X.    .       .  ..      .. .  :::::x  .  :++ X;: XX+  ;$.  +$;.  $ . .:    . \n     ::.. :....       .+;..     ...  .  ..:. .   .        .x     ;;.xx$x .&.Xx   :$$;&    ..: & ; . \n  ..... .     .;XX$;  ...     ... ..  .... ..::::;::   +&   .. ...x:.x; + :+X  :&$ ; .X: ; ;X:x &+  \n     ....::;:.    ..     ..:.. ...  .::. .:.:..  . ;.  .X: :.   .  &+   :  .  +.   :  ;;X   ;  .. . \n .   .      .;+...::     :. ....::::.  :.:;....;::..:  ::X.   ..    &x ;&$    .;x+x.; :;$x .Xx .    \n  ...             .    .::. .:....::.:;+:    .         .x; + +$  .  +;x;+;&X.  x+;. x  :; &: . . .. \n        .    :: .       :.       ...:.   ;Xx;;+..;+;x+:  .   $&&  .  +: :.:+;: +++ :$:.:;.$.  +;+   \n  ..:+:;:;:;+;:.  :  :   :;x+:;x+  .;x        xxxXxXX$&&&   .      . :X;.;++X:;  :x+ :; ;; . ; :$Xx \n  .      .   .  ..  ++;  . :.+   +XXX;X&&&&++ ;Xx;::      x: .:   ..;  &; :x;;X$  ;x+:+:  ;:XxX: :  \n    .:... :;.  .   .x+;  &&&&&x+;;+   ;     ;$&X&$&&&&&&&&&&.  . ..:   :$  .+++;x  ;++:.:.;++. &;   \n ::  :. :: . ..   :. ;+.       :;x$.;$&&&&$:+&&x   +         +   x&     ;&x :; .:;  .x ::... ::x+.; \n   .....:: .    .Xx;.:;+&&+$&&&&&&$+;;        .;X&&XXX&&&&&&&&&   X      $   +:.:+; .+.+.:++:+X:    \n  .:.::  ..... x+. ++   x: .      .+XX&&&&&&&&&&$ x&&X$&&&&&&&&xx:& $X+    :: :;xx.  : .+;:;:x   ;x \n ....:. :     ;; ::  x$$XXX$&&&&&&&&&&  .:+x&&&&X+&&&&$$           $   .. .:X .+; :X  +X+$..  X:+$x \n   .   .  .  ;::;;+; &XxxxxxX&$&&&&&&&&& ;  ;++        .$&&&&&&&&&&+&       :: ;.;;;+    x;. :.:    \n     ::  .  :;::;:: .&X$&&&&$XX:         $&&&&&&&&&&&&&&&&&&&&&&&&&$:&x  ;  :;; .;+;;:.:  ;.;; +;:. \n  .;:.  .  ;:::;;    .         :xX&&X&&&&&&&&&&&&&&&&&&&&&&&&&&x&. + .&X   &+..; ;;.X:+:    .x .++x \n ;:.  .. .:. :::: xXXXX$&&&&&&&&&&&&X&&&&&&&&&&&&&&   $:        &$x&:   ;:     ;: .+.;$+: ;x: + :$x \n :  ... ....:... .$XXxX$&&&&&&&&&&&&&&&&&;  X&$&       :$&&  .      X&X:... $&  .   : .;;   + :+  . \n    ...  ..:;;;: $&&&&&&&&&&$         ;;.+&&x    :$&&&&&&&&&&&&&&&&&&&&&&& .X&+...:   +;.::.; :;. . \n   .. ..  :::  : && .&.      :$&&&&&&+ ;&&&&&&&&&&&&&&&&&&&&&&&&&X$X$X$&&&& ..   .::; .: :+. :: ++  \n                         .;+xxX$&&$$$&&&Xx+x++++++++++++++++;+;;+x;                                 \n\n";
string photographImg = "                                                                                                    \n ........:.::::::::::  ............................................................................ \n ....::::::::.:::::::..:..:.............:.......................................................... \n ..:  .... .:;::::::::.:..:......:............................:.................................... \n  .+;.  .  ...;;;;::::.::...:::....:......................................:..:..::::............... \n ..+++x;;+;      .;++;.:.::........:........:.....:.::::.::::::::::::::::::::.:..:.:...:........... \n . ;;;;:;;+++.    .  .:::.....:.......::::::::.::::.:::::::::::::::::::::::::..::::................ \n . +;;;;;;;;;+x+;.  ...:.::.......:.....:::::::::::::.:::::::::::..::::::::::::.:...::.:.:......... \n . ++;;;;;;;;::;;;:;...::..:::..:...::..:.:::::::::::..::::::::..::::::.::::::::..:..............:: \n  .xx+;::;;:;:;;;;;:x;.::.:...:..::....::....:...::.:::....:..:.::::::::::::::::::::::::..:....::.: \n ..;+$XXx;;;;+x+;:;.:; .::..::::.......::::::::::::::::::::;:::;:::::::.......................:::.. \n  ..   .:xXXX ..:::.++::;::.....:.::............. .....................................:.......:.:. \n .     .        . . ;+ .;...:.......:..................................................::.:......:: \n x;:$+ ..;      .....;..;..:::.:..............::........................................:......:::. \n xXx+x;.: &&XX::..     .+...........;.:....:...;........................................:.. .:..::. \n +++++x .  X+x;xxxX+ x  +.:..:::......:........;........................................ +.+;;:.... \n +xx++x .: x;++;+;++;x+ ;..::....:.;:....:.....;....................................... :; ;....... \n +xxx+x .: $++++;;+;+++.;:...:......:.:.:....:.;.......................................:;:+ ....... \n x+;XX$;.: &xXXx$X+;;++:;;...:::....;.:.;....:.+.......................................: .; :...... \n &&&+ &;.. X+;x .;; :;; ::::.:::.::.;.: ;.:..:.+.............   ......................:+ &  ..::::. \n       .:;.:: .       ;.::.:.:......:.. +....  ;............ ;&  ..:...................: ;...::.... \n    +.       .;.:   :.;:.;...:......:.: ;... +       .......  && ..:......:...................::::: \n &&x..:X;:  ;X+.;XX+;..x.:..::.:....;.:.;...;x$&&&&&;........  &.............................:..::: \n $&X +xxXX& &xx;+++x  .x.:...::::.:.:.: ;... X       .........   ............................:..:.: \n x$   &xx;; $xxxx++;X..+.:..::......:...;...   .  ...........................................::.::: \n X&.  &$X:+xx;+.;;;:+  x+:...:.::::.:.:.;.......................................................:.: \n X$   &&x;;Xxx+++;;++x .:::..:......:.:.;.....::........................................:....:.:::. \n &&   Xx;$;X$$X$&&&+.:.. ::....::::...:.;.....::.....................................:..........::: \n &x   :&+&$&.$&.       +;.;::.::..:...: :......:.......................................:.:..::::::: \n  ;:  :&&$      ;XX$$+ ;; :...::.:...:..:.....::..................................................: \n ..:        $&&$X+;;++;;+ ;.:.::....:...:.....::.........................................:......... \n ::: &&&&x$ +$+x+;+;;;;;+ ;.....:::.:::..;....::................................................... \n ..   X&X&&  X+;x+++;;;:x ::..::..........:....:................................................... \n    &&&XX+$.;$x+x++++++;;::;:.:........:.......:................................:.................. \n &&&$:XXxx$ :&XxXXxX++.:x.::.::.::...::........:................................................... \n +xXX$$XX$&  &X:&.   .;.+;.:..:..:..::..::...:::................................................... \n xxXx$$$. +  .     x++: ++.;...:::.:.....:.....:................................................... \n xX&&&&&&&&     &$xx;;: :+ :.:.::::...::.:....::..::............................................... \n &&$.       .:;xx+;;;+; :x ;::.:...:..:..:....:::.......................:.......................... \n .     .  ;XxXxx+;;+;+: :+ ;..:..:.....:......:.......................................:............ \n  ..:::;  .X++;+;;;;+:.: ..::.:::...:.........:::...........................:...................... \n :::... ;&X+;;;+++Xx;  ::+:.:.::....:.....:....:................................................... \n .    . .X;;++x$X :   +++;:.:..........:...:...:................................................... \n   X$ . +&;+XXx      ;+;:; .::.:....:..........:................:.................................. \n x$:&  . X+X:     :XX+;;:;:.:.:..:.............:......................::........................... \n +++&  . $xx  . .X++;;;;;+:::.::::..::.....:::..::::::::::...................::.................... \n ;;;X; . X+  :.x:x+;;;;;:. ....:.:...................::.........:::::...............:.............. \n ;;+X; .    :. $+;::;;;; .;;.:...:...:::.................:....:........::.......................... \n ;;xx:;. : :;. .+;::;: ;;.;;.........:..:.::.:::.....:::..:::......:.......:....................... \n ++:    ;+X+: . x+;x. .x .:;.:..:........:::::.:::.::::.::..:.:::....::......:..................... \n ;     xx:;...: +.;: X+;  ;;...:...:::.:.::::::::::::..::::::::.....:.....:.:.......:.............. \n                                                                                                    \n";


// Scene Setup

// Introduction ==========================================================================================================

Console.WriteLine(intro);
Console.ReadLine();
Console.WriteLine(introWarning);
Console.ReadLine();

// Scene 1 - Out of the cruiser ==========================================================================================================
Console.WriteLine(scene1Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Search the house perimeter
{
    goto HousePerimeter;
} else if (playerInput == 2) // Go to house entrance
{
    goto HouseEntrance;
}
else // Input was an int, but not the right one
{
    goto ProgramEnd;
}

// Scene 1_1 - House Perimeter ==========================================================================================================

HousePerimeter:;

Console.WriteLine(scene1_1Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Go to house entrance
{
    goto HouseEntrance;
}
else if (playerInput == 2) // Leave
{
    goto EndingRepentance;
}
else
{
    goto ProgramEnd;
}
// Scene 2 - House Entrance ==========================================================================================================

HouseEntrance:;

roomTracker = 1;

Console.WriteLine(scene2Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Call intruder out (BAD DECISION)
{
    badDecisions += 1;
    //Console.ForegroundColor = ConsoleColor.Red; // Temp, I don't think this is allowed 
    goto BadDecisionsHandler;
}
else if (playerInput == 2) // Open the door slowly
{
    Console.WriteLine(scene3Dialogue);
    goto MainFloor;
}
else if (playerInput == 3) // Plant pot (PHOTOGRAPH EVIDENCE)
{

    getEvidencePhotograph = true;
    Console.WriteLine(photographImg);
    Console.WriteLine(evidencePhotographDialogue);
    Console.ReadLine();
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine) // The player collects all three evidence
    {
        getEvidenceAll = true; // Mostly set for bug fixing
        Console.WriteLine(allEvidenceDialogue);
        Console.ReadLine();
    }
    goto HouseEntrance;
}
else
{
    goto ProgramEnd;
}

// Scene 2.1 - Call the intruder to come out (BAD DECISION) ==========================================================================================================

CallIntruderOut:;
roomTracker = 2;

// This room's dialogue has already been played from the previous room + bad decisions handler
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Kick open the front door (BAD DECISION)
{
    badDecisions += 1;
    goto BadDecisionsHandler;
}
else if (playerInput == 2) // Open the door slowly 
{
    Console.WriteLine(scene3Dialogue);
    goto MainFloor;
}
else if (playerInput == 3) // Plant pot (PHOTOGRAPH EVIDENCE) (Alt route)
{
    getEvidencePhotograph = true;
    Console.WriteLine(photographImg);
    Console.WriteLine(evidencePhotographDialogue);
    Console.ReadLine();
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine) // The player collects all three evidence
    {
        getEvidenceAll = true;
        Console.WriteLine(allEvidenceDialogue);
        Console.ReadLine();
    }
    Console.WriteLine("You call the intruder to come out unarmed. No response.\n\n(1) Kick open the door\n(2) Open the door slowly\n(3) Look under the plant pot");
    goto CallIntruderOut;
}
else
{
goto ProgramEnd;
}

// Scene 3 - Main Floor ==========================================================================================================

MainFloor:;

Console.WriteLine(corridorImg);
Console.WriteLine(scene3Dialogue2);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Basement
{
    goto Basement;
}
else if (playerInput == 2) // Bathroom
{
    goto Bathroom;
}
else if (playerInput == 3) // Bedroom
{
    goto BedroomCorridor;
}
else if (playerInput == 4) // Leave
{
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine) // The player leaves with all three evidence.
    {
        goto EndingRemorse;
    }
    else // The player tries to leave without all three evidence
    {
        Console.WriteLine("You can't leave yet. Not now.\n\nPress enter to continue:");
        Console.ReadLine();
        goto MainFloor;
    }
}
else
{
    goto ProgramEnd;
}

// Scene 4 - The basement ==========================================================================================================

Basement:;

Console.WriteLine(basementStairsImg);
if (getEvidencePhotograph) // More context to the scene if the player has found the photograph
{

    scene4Dialogue = $"Pointing your flashlight down the basement stairs you find its reflection in the gas pipes that line its barren walls. You tread down carefully and quietly.\nThe basement was clearly more of a workshop to someone, fitted with metal shelves, a sink, lathe, and a toolbench. Everything is empty besides some pen blanks however, and hasn't been used in a long time.\nTo your left lies a small room with flickering light emanating from within.\nPeeking around the corner to your right you see another doorway at the back of the room, the same one from the photograph you found outside..\n\n(1) Go left\n(2) Go right\n(3) Go back";

}
Console.WriteLine(scene4Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Go left
{
    goto SaunaRoom;
}
else if (playerInput == 2) // Go right (SHRINE EVIDENCE)
{
    getEvidenceShrine = true;
    Console.WriteLine(evidenceShrineDialoguePre);
    Console.ReadLine();
    Console.WriteLine(evidenceShrineDialogue);
    Console.ReadLine();
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine) // The player collects all three evidence
    {
        getEvidenceAll = true;
        Console.WriteLine(allEvidenceDialogue);
        Console.ReadLine();
    }
    goto Basement;
}
else if (playerInput == 3) // Go back
{
    goto MainFloor;
}
else
{
    goto ProgramEnd;
}

// Scene 4_1 The sauna ==========================================================================================================

SaunaRoom:;

roomTracker = 3;

Console.WriteLine(scene4_1Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Investigate the boxes further (BAD DECISION)
{
    badDecisions += 1;
    goto BadDecisionsHandler;
}
else if (playerInput == 2) // Go back
{
    goto Basement;
}
else
{
    goto ProgramEnd;
}
// Scene 5 - Bathroom ==========================================================================================================

Bathroom:;

roomTracker = 4;

Console.WriteLine(scene5Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Knock on the door with all evidence
{
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine)
    {
        goto EndingSolitude;
    }
    else // Knock on the door without all evidence (BAD DECISION)
    {
        badDecisions += 1;
        goto BadDecisionsHandler;
    }
}
else if (playerInput == 2) // Go back
{
    goto MainFloor;
}
else
{
    goto ProgramEnd;
}


// Scene 6 - Bedroom corridor ==========================================================================================================

BedroomCorridor:;

roomTracker = 5;

Console.WriteLine(scene6Dialogue);
playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Enter the bedroom (BAD DECISION)
{
    badDecisions += 1;
    goto BadDecisionsHandler;
}
else if (playerInput == 2) // Go back
{
    goto MainFloor;
}
else
{
    goto ProgramEnd;
}
// Scene 6_1 Bedroom (BAD DECISION (still nessesary)) ==========================================================================================================

Bedroom:;

roomTracker = 6;

playerInput = int.Parse(Console.ReadLine());

if (playerInput == 1) // Check the closet
{
    if (getEvidenceAll)
    {
        Console.WriteLine("Theres nothing here anymore.\n\nPress enter to continue:");
        Console.ReadLine();
        // Bad decision handler requires the dialogue to be played again here
        Console.WriteLine("The room is cold. A thick set of blinds covers the window. Moon and stars hang from the ceiling. A baby's room. Shifting your flashlight to the half-open closet door, shadows seem to slink around the beam of light. Is it the headache?\n\n(1) Check the closet\n(2) Check under the bed\n(3) Look inside the crib\n(4) Go back");
        goto Bedroom;
    }
    else
    {
        goto EndingCloset;
    }
}
else if (playerInput == 2) // Check under the bed
{
    Console.WriteLine(scene6_1_1Dialogue);
    Console.ReadLine();
    // Bad decision handler requires the dialogue to be played again here
    Console.WriteLine("The room is cold. A thick set of blinds covers the window. Moon and stars hang from the ceiling. A baby's room. Shifting your flashlight to the half-open closet door, shadows seem to slink around the beam of light. Is it the headache?\n\n(1) Check the closet\n(2) Check under the bed\n(3) Look inside the crib\n(4) Go back");
    goto Bedroom;
}
else if (playerInput == 3) // Look inside the crib (CRIB EVIDENCE)
{
    getEvidenceCrib = true;
    Console.WriteLine(evidenceCribDialogue);
    Console.ReadLine();
    if (getEvidencePhotograph && getEvidenceCrib && getEvidenceShrine) // The player collects all three evidence
    {
        getEvidenceAll = true;
        Console.WriteLine(allEvidenceDialogue);
        Console.ReadLine();
    }
    // Bad decision handler requires the dialogue to be played again here
    Console.WriteLine("The room is cold. A thick set of blinds covers the window. Moon and stars hang from the ceiling. A baby's room. Shifting your flashlight to the half-open closet door, shadows seem to slink around the beam of light. Is it the headache?\n\n(1) Check the closet\n(2) Check under the bed\n(3) Look inside the crib\n(4) Go back");
    goto Bedroom;
}
else if (playerInput == 4) // Go back (BAD DECISION)
{
    badDecisions += 1;
    goto BadDecisionsHandler;
}
else
{
    goto ProgramEnd;
}



// Endings
Console.WriteLine("If you got here, something messed up in the code.");
// Ending 1 - Stomach ==========================================================================================================

EndingStomach:;
Console.WriteLine(ending1Dialogue);
Console.ReadLine();
Console.WriteLine(ending1Dialogue2);
Console.ReadLine();
Console.WriteLine(stomachTip); // Write a tip for the player for next time
Console.ReadLine();
goto Credits;


// Ending 2 - Repentance ==========================================================================================================

EndingRepentance:; // Reference to the binding of isaac?
Console.WriteLine(ending2Dialogue);
Console.ReadLine();
Console.WriteLine(repentanceTip);
Console.ReadLine();
goto Credits;

// Ending 3 - Closet ==========================================================================================================

EndingCloset:;
Console.WriteLine(ending3Dialogue);
Console.ReadLine();
Console.WriteLine(closetTip);
Console.ReadLine();
goto Credits;

// Ending 4 - Remorse ==========================================================================================================

EndingRemorse:;
Console.WriteLine(ending4DialoguePre);
Console.ReadLine();
Console.WriteLine(followedYouHomeImg);
Console.WriteLine(ending4Dialogue);
Console.ReadLine();
Console.WriteLine(remorseTip);
Console.ReadLine();
goto Credits;
// Ending 5 - Solitude ==========================================================================================================

EndingSolitude:;
Console.WriteLine(ending5DialoguePre);
Console.ReadLine();
Console.WriteLine(ending5Dialogue);
Console.ReadLine();
Console.WriteLine(solitudeTip);
Console.ReadLine();
goto Credits;


// Bad decision handler
BadDecisionsHandler:;
if (badDecisions == 1 && !getEvidenceAll) // Handle Dialogue
{
    currentBadDecisionDialogue = badDecision1Dialogue;
}
else if (badDecisions == 2 && !getEvidenceAll) {
    currentBadDecisionDialogue = badDecision2Dialogue;
}
else if (badDecisions == 3 && !getEvidenceAll) {
    currentBadDecisionDialogue = badDecision3Dialogue;
}
else if (badDecisions == 4 && !getEvidenceAll) {
    currentBadDecisionDialogue = badDecision4Dialogue;
}
else if (badDecisions >= 5 && !getEvidenceAll) {
    goto EndingStomach;
}
else if (getEvidenceAll)
{
    currentBadDecisionDialogue = noBadDecisionsLeftDialogue;
}
else
{
    Console.WriteLine("Something went wrong with the bad decision handler!");
    goto Credits;
}

// Find where to go back, and add the bad decision text

if (roomTracker == 1) // Call intruder out
{
    Console.WriteLine($"You call the intruder to come out unarmed. No response.\n{currentBadDecisionDialogue}\n\n(1) Kick open the door\n(2) Open the door slowly\n(3) Look under the plant pot"); // Scene 2_1
    goto CallIntruderOut;
}
else if (roomTracker == 2) // Kick open door
{
    Console.WriteLine($"You kick open the door breaking the silence once again.\n{currentBadDecisionDialogue}\n\nPress enter to continue:");
    Console.ReadLine();
    goto MainFloor;
}
else if (roomTracker == 3) // Investigate boxes further
{
    Console.WriteLine($"As soon as you step into the room you trip slightly on a protruding mop. Reaching your hands out you push over a stack of cardboard boxes. They were Christmas decorations. When the ornaments hit the floor and broke, a deep groaning could be heard from a room upstairs. You back out of the room.\n{currentBadDecisionDialogue}\n\nPress enter to continue:");
    Console.ReadLine();
    goto Basement;
}
else if (roomTracker == 4) // Bathroom knock w/o all evidence
{
    Console.WriteLine($"You knock heavily on the door, asking the victim if they are safe. No response.\n{currentBadDecisionDialogue}\n\nPress enter to continue:");
    Console.ReadLine();
    goto MainFloor;
}
else if (roomTracker == 5) // Enter the bedroom
{
    Console.WriteLine($"The room is cold. A thick set of blinds covers the window. Moon and stars hang from the ceiling. A baby's room. Shifting your flashlight to the half-open closet door, shadows seem to slink around the beam of light. Is it the headache?\n{currentBadDecisionDialogue}\n\n(1) Check the closet\n(2) Check under the bed\n(3) Look inside the crib\n(4) Go back");
    goto Bedroom;
}
else if (roomTracker == 6) // Leave the bedroom
{
    Console.WriteLine($"The wind begins to howl outside as you leave the room. You should leave soon.\n{currentBadDecisionDialogue}\nPress enter to continue:");
    Console.ReadLine();
    goto MainFloor;
}



// Program ending
ProgramEnd:;
Console.WriteLine(errorMessage);

// Credits
Credits:;
Console.WriteLine(credits);
Console.ReadLine();