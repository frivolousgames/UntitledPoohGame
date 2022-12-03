using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTexts : MonoBehaviour
{
    public static string speechText;
    string tempSpeech;
    string[] speech;

    bool intro;
    bool p1;
    bool p2;

    public GameObject poohPanel;
    public GameObject oppPanel;

    public static bool nextScene;

    //Scene 1 Piglet
    string s1;
    string s2;
    string s3;
    string s4;
    string s5;
    string s6;
    string s7;
    string s8;
    string s9;
    string s10;
    string s11;
    string s12;
    string s13;
    string s14;
    string s15;
    string s16;
    string s17;
    string s18;
    string s19;
    string s20;
    string s21;
    string s22;
    string s23;
    string s24;
    string s25;
    string s26;
    string s27;

    //Scene 2 Eeyore
    string s28;
    string s29;
    string s30;
    string s31;
    string s32;
    string s33;
    string s34;
    string s35;
    string s36;
    string s37;
    string s38;
    string s39;
    string s40;
    string s41;
    string s42;
    string s43;

    //Scene 3 Rabbit
    string s44;
    string s45;
    string s46;
    string s47;
    string s48;
    string s49;
    string s50;
    string s51;
    string s52;
    string s53;
    string s54;
    string s55;
    string s56;
    string s57;
    string s58;
    string s59;
    string s60;
    string s61;
    string s62;
    string s63;
    string s64;

    //Scene 4 Owl
    string s65;
    string s66;
    string s67;
    string s68;
    string s69;
    string s70;
    string s71;
    string s72;
    string s73;
    string s74;
    string s75;
    string s76;
    string s77;
    string s78;
    string s79;
    string s80;
    string s81;
    string s82;
    string s83;
    string s84;
    string s85;
    string s86;
    string s87;
    string s88;
    string s89;
    string s90;
    string s91;
    string s92;
    string s93;
    string s94;
    string s95;
    string s96;
    string s97;
    string s98;
    string s99;
    string s100;
    string s101;
    string s102;
    string s103;
    string s104;
    string s105;
    string s106;
    string s107;
    string s108;
    string s109;
    string s110;
    string s111;
    string s112;
    string s113;
    string s114;
    string s115;
    string s116;
    string s117;
    string s118;
    string s119;
    string s120;
    string s121;
    string s122;
    string s123;
    string s124;
    string s125;
    string s126;
    string s127;
    string s128;
    string s129;
    string s130;
    string s131;
    string s132;
    string s133;
    string s134;
    string s135;
    string s136;
    string s137;
    string s138;
    string s139;
    string s140;
    string s141;
    string s142;
    string s143;
    string s144;
    string s145;
    string s146;

    //Scene 7 Chris
    string s147;
    string s148;
    string s149;
    string s150;
    string s151;
    string s152;
    string s153;
    string s154;
    string s155;
    string s156;
    string s157;
    string s158;
    string s159;
    string s160;
    string s161;
    string s162;
    string s163;
    string s164;
    string s165;
    string s166;
    string s167;
    string s168;
    string s169;
    string s170;
    string s171;

    //Scene 8 Piggles 2
    string s172;
    string s173;
    string s174;
    string s175;
    string s176;
    string s177;
    string s178;
    string s179;
    string s180;
    string s181;
    string s182;
    string s183;
    string s184;
    string s185;
    string s186;
    string s187;
    string s188;
    string s189;
    string s190;
    string s191;
    string s192;
    string s193;
    string s194;
    string s195;
    string s196;
    string s197;
    string s198;
    string s199;
    string s200;
    string s201;

    public static bool switchPanels;

    private void Awake()
    {
        speech = new string[]
        {

        //Scene 1 Piggles
        s1 = "Pooh, you look ill, are you feeling ok?",
        s2 = "No piggles, I'm not feeling very well at all. I just received some very grim news from Dr. Racoon.",
        s3 = "I have been declared HIV positive. My life is in ruins.",
        s4 = "Oh my! How did such a thing come to pass?",
        s5 = "Well, as you are no doubt aware, I have amassed a\nplethora of lovers over the years.",
        s6 = "Being a pan/\npolyamorous/gender-\nqueer/trans-species/\nfish-curious/\nhoneysexual/poopkin, my sexual appetite knows no bounds.",
        s7 = "As you surely recall, I have even stooped so low as to allow your Q-tarded ass entrance into my cavities from time to time.",
        s8 = "It is true, I am not worthy of your affection.",
        s9 = "That is quite the understatement...",
        s10 = "I believe the disease was passed to me during a drug-hazed romp at last week's forest friends block party.",
        s11 = "Early in the evening, I performed felatio on a flying squirrel in return for several doses of mescaline and ecstasy.",
        s12 = "Due to the\ncompounding effects from mixing the twain substances, my awareness dimmed considerably.",
        s13 = "What followed can only be described as pure sexual\ndecadence.",
        s14 = "Unfortunately, I can't recall who-or what-was involved.",
        s15 = "My memories are\nsparse beyond a blur of anonymous fallaces and clitoraty.",
        s16 = "I am both puzzled and exhilarated by your tale. What course of action will you pursue henceforth?",
        s17 = "Well, my\nsmooth-brained friend,",
        s18 = "I must find and accost all possible lovers whom'st may have injected me with their poisonous fluids.",
        s19 = "Please be careful Pooh, some wild beasts attack when they are cornered.",
        s20 = "Also, this could all be a psyop\nperpetrated by the Illuminati or perhaps the ghost of JFK Jr.",
        s21 = "Enough with your inane alt-right\nconspiracies Piggles! I have real problems to attend to.",
        s22 = "It is time to embark upon my quest to find and punish the fiend responsible for my eternal\nsickness.",
        s23 = "Farewell my dull-witted friend!",
        s24 = "Farewell and good luck Pooh! May God light your path!",
        s25 = "God?? You podunk fool! Science is my only god. Now I must be off. There is a protest I want to attend before my voyage.",
        s26 = "It seems some bigot principal won't allow a 4 year old trans student to attend school wearing only fishnets and assless chaps.",
        s27 = "Tata!",

        //Scene 2 Eeyore
        s28 = "Eeyore did you attend the block party last weekend?",
        s29 = "I was totally zooted on mescaline and ecstasy and only remember bits and pieces.",
        s30 = "It seems I contracted HIV after having sexual intercourse with someone but I can't recall whom.",
        s31 = "Was it you by chance?",
        s32 = "That's quite an\nunfortunate diagnosis Pooh, I'm truly sorry.",
        s33 = "However, I was at home self-medicating last weekend and therefore could not be your mysterious sexual partner.",
        s34 = "I did catch a glimpse out of my window of you cuddling up to Rabbit behind the dumpster in back of the forest co-op.",
        s35 = "You really had your hands-and mouth-full at the time.",
        s36 = "Perhaps it was xey who impregnated you with this vile disease?",
        s37 = "Hm what an\ninteresting turn of events. I will seek out Rabbit and ask him if he is the culprit at once.",
        s38 = "How dare you!",
        s39 = "You know damn well that Rabbit's pronouns are they/them,\nxe/xem, ze/zim, bim/bam, fiddle/faddle... ",
        s40 = "bricka/bracka,\nfire/cracker,\nsis/boom/ba, \njeepers/creepers...",
        s41 = "potato/potahto,\ntomato/tomahto, peepee/poopoo, pickle jar, and Ron!",
        s42 = "For the horrific,\nholocaust-equaling offense of\nmisgendering xer, I now sentence you to death!",
        s43 = "Pooh, you have\ndefeated me. I beckon you, please show mercy on me old friend.",

        //Scene 3 Rabbit
        s44 = "Good Day Rabbit! I am on a quest for enlightenment\nconcerning the recent block party.",
        s45 = "Before zis untimely demise, Eyeore\ninformed me that xer witnessed us sharing a moment of intimacy.",
        s46 = "The night is quite foggy in my memory.",
        s47 = "Remind me, did we end up having sexual intercourse?",
        s48 = "Alas, no, we did not consumate on that eve.",
        s49 = "You ended up pissing and shitting \nyourself-which, of course, I was very into.",
        s50 = "But then you passed out and I moved on to other endeavors.",
        s51 = "Last I saw, Owl was fondling your genitals as you slumbered.",
        s52 = "Perhaps xi has further insight into the situation.",
        s53 = "Thank you Rabbit, I will indeed question Owl about this.",
        s54 = "One more thing...I've been meaning to\ninquire about your leather. Does it chafe?",
        s55 = "Chafe??",
        s56 = "CHAFE?!?!?!",
        s57 = "I'll have you know that I use a very eco-friendly mix of oils and lubricants, ",
        s58 = "which keep my leather shiny and moist to avoid any discomfort.",
        s59 = "As a leather-kin, I find your inquiry very offensive and discriminatory to my people.",
        s60 = "For you to assume such a thing is an offense on par only with atrocities such as",
        s61 = "slavery, white\nsupremacy, the rape of Nan King, and dead-naming.",
        s62 = "Prepare to be\ncancelled!",
        s63 = "Ugh, you have beaten me into submission. I underestimated your dominance.",
        s64 = "I only ask that you leave me alive so that I may incorporate this lesson into my journey of personal betterment.",

        //Scene 4 Owl
        s65 = "Hello Owl!",
        s66 = "I heard through the grapevine that you were fondling my unconscious body during the block party last weekend.",
        s67 = "I am trying to track down any and all sexual partners from that night,",
        s68 = "in an effort to discover who impregnated me with the virus known as HIV.",
        s69 = "Might it have been you?",//
        s70 = "My dear sweet Pooh, do you honestly\nbelieve that I would take advantage of you in such a meager state?",
        s71 = "Don't be absurd!",
        s72 = "As anyone who knows me will attest, I can only perform sexually when my partner is a corpse.",
        s73 = "Otherwise, I cannot achieve a proper erection.",
        s74 = "I left for the cemetery shortly after you began to stir.",
        s75 = "Last I saw, Kanga and her mentally impaired dwarf friend Roo were attempting to nurse you back to health.",
        s76 = "I mean that quite literally, for you were feeding furiously from Kanga's supple teat.",//
        s77 = "Thank you for this enlightening\ninformation Owl.",
        s78 = "I will indeed have a confab with Kanga and Roo and hopefully get to the bottom of this matter.",//
        s79 = "I'm afraid you won't get the chance Pooh.",
        s80 = "For you see, I am a serial killer in the vain of Jeffrey Dahmer and Edmund Kemper.",
        s81 = "I was interrupted at the party by those two meddling fools, but I shalln't be denied again!",
        s82 = "I will delight in exploring every hole on your cold, lifeless body-even those not yet created!",
        s83 = "Prepare to meet your untimely doom!",
        s84 = "Heaven help me I have been bested.",
        s85 = "I know I deserve no pity, but I beg of you Pooh, please, spare my life.",

        //Scene 5 Kanga
        s86 = "Goodmorrow Kanga and Roo!",
        s87 = "May I query you about the time we shared during the recent block party?",
        s88 = "I was experiencing a drug-fueled fugue state and can't seem to recall the events in question.",
        s89 = "I received the most dasterdly of STDs, but from whom I\ncannot say.",
        s90 = "Did we engage in the act of love\nmaking-specifically anal or vaginal\npenetration?",//
        s91 = "Pooh, I must confess that sadly there was no penetration on that evening.",
        s92 = "You merely drained my udders for\nsustainance and sexual pleasure whilst Roo masturbated furiously.",
        s93 = "Of course there were the anal beads...",
        s94 = "But I assume you are speaking of\nflesh-to-flesh insertion, of which there was none.",
        s95 = "Something peculiar did occur shortly after our moist\nencounter though.",//
        s96 = "Oh?",//
        s97 = "Christopher Robin appeared suddenly and whisked you away in xiis Prius.",//
        s98 = "That is not such an odd occurrence.",
        s99 = "We oft find each other after a long night of individual debauchery,",
        s100 = "and fornicate in the back seat of his Prius to relieve our mushrooming\nsexual tensions.",//
        s101 = "Yes, we have all espied you two from afar. Roo has\nmasturbated many times to your dancing silhouettes.",
        s102 = "But that was not the unusual thing I speak of.",//
        s103 = "Oh? What then?",//
        s104 = "Christopher Robin was covered in what I can only describe as...bloody lesions.",//
        s105 = "Oh my....it was zim all along.",
        s106 = "Thank you for steering my path in the correct direction my friends.",
        s107 = "I must now confront xer and put an end to the misery zey have spread.",//
        s108 = "I'm afraid we can't let you do that Pooh.",
        s109 = "Although Christopher is very guilty and should be punished severely for vehhs crimes,",
        s110 = "it just so happens that xeir is our sole merchant for the procurement of ketamine.",
        s111 = "I fear we are both stricken with an addiction to the drug and cannot\nfathom missing a dose.",
        s112 = "Plus, it's helping with Roo's anxiety problems. And his public masturbation...",
        s113 = "more so the anxiety I'm afraid.",
        s114 = "I'll be damned if I'll let you interrupt xerz progress! Roo, attack!",
        s115 = "Oh cruel fate, you have forsaken us!",
        s116 = "Pooh, take my life but spare poor Roo, for xeeh hasn't the intellect to fully comprehend zerrs own actions.",

        //Scene 6 Tegro
        s117 = "Sup Tegro, my supa fresh homeboy.",
        s118 = "I am currently on the lookout for\nChristopher Robin.",
        s119 = "I have quite a bone to pick with xihm. Have you any\ninformation on zhhiis possible whereabouts?",//
        s120 = "I may have the insights you desire. Might I first ask your intentions?",
        s121 = "Chris and I are very close allies and his safety is paramount to me.",//
        s122 = "Well, you see,\nChristopher has passed HIV onto me during a firm\n\"dicking down\".",
        s123 = "I played the unwitting fool in qihssz deadly game of sexual Russian roulette.",
        s124 = "Now I must ask for...I must DEMAND\nretribution! Will you help me old friend?",
        s125 = "Let me remind you it was I who\nspearheaded the local chapter of Orange Lives Matter.",
        s126 = "Who was on the front lines throwing jugs full of urine at passing pedestrians?",
        s127 = "Who prompted the chant \"ACAB!\" during officer Giraffe's hero funeral?",
        s128 = "I know an individual of your...",
        s129 = "persuasion...can do absolutely no wrong, so I implore you, please help me!",//
        s130 = "...",
        s131 = "What Chris has done is implorable and there is no excuse available that can justify such a heinous act.",
        s132 = "However, he and I are bossom-buddies, which creates a\nconundrum of sorts...",
        s133 = "If you can best me at a game of basketball,",
        s134 = "I shall do as you wish and point you in Christopher's direction.",
        s135 = "If you lose, your journey ends here. The game is afoot!",
        s136 = "You've won Pooh, I almost can't believe it.",
        s137 = "Your athletic prowess is hidden beneath your bloated, doughy exterior.",
        s138 = "I shall hold up my end of the bargain.",
        s139 = "Christopher is in exile in a cottage on the banks of Lake Gigglepuss.",
        s140 = "You may exact your vengance upon him without interference from me.",
        s141 = "Be forewarned, Chris may prove a cunning and resourceful foe.",
        s142 = "Good luck Pooh. You shall need it!",

        //Scene 7 Chris
        s143 = "Christopher, I know it was you.",
        s144 = "How could you carry out such a depraved act? I believed us compatriots as well as casual lovers.",
        s145 = "You have soiled our relationship and soiled my immune system.",
        s146 = "I am forever doomed to a sexual life filled only with bug-chasers,\nmiscreants, and true degenerates.",
        s147 = "What have you to say?",//
        s148 = "Oh shut the hell up Pooh! Your voice makes me sick to my stomach!",
        s149 = "You believed us\ncompatriots? Ha!",
        s150 = "Did you not notice how I avoided you until I was 6 bells to the wind?",
        s151 = "And when we\ncopulated, did you not feel my hatred and\nresentment of you in every violent pump?",//
        s152 = "I believed you a passionate lover...",//
        s153 = "Oh my passion runs deep, as deep as a knife wound to your still-beating heart!",//
        s154 = "Oh Chris, I am so confused...",//
        s155 = "You passed confused and crossed the line into delusional long ago, Pooh.",
        s156 = "There is no special place for you in my heart.",
        s157 = "We don't share one tittle of comradery between us.",
        s158 = "You are but a clump of excrement clinging to the treads of my boot and it's high time I scraped you off.",
        s159 = "Bid farewell to this earthly plane Pooh, your judgment is nigh!",
        s160 = "I have been bested. And yet I feel no regret for my actions whatsoever.",
        s161 = "You claim confusion about why I despise you so?",
        s162 = "Let me unburden\nmyself of my reasoning before I shed my mortal flesh and enter the void of nothingness,",
        s163 = "a fate all atheists eventually share.",
        s163 = "My hatred for you stems from an incident several years past.",
        s164 = "Tegro and I had stolen a Trump 2020 flag from some inbred imbecile's porch,",
        s165 = "and we were taking turns shitting and pissing on it.",
        s166 = "Whence your turn came, you refused, citing a bout of constipation.",
        s167 = "I knew from that moment on that you, Pooh, we're a racist, sexist Nazi,",
        s168 = "who would ruthlessly slay all trans and pocs given the slightest window of opportunity.",
        s169 = "Do as you will with me, for I will perish knowing that I have fought the good fight,",
        s170 = "and that I was most definitely on the right side of herstory.",
        s171 = "Fare xhee well, bigot!",

        //Scene 8 Piggles 2
        s172 = "Pooh you have\nreturned! Were your efforts fruitful?",//
        s173 = "Yes Piggles, my mission was a success. I vanquished the evil forces that dwelled deep in the forest.",
        s174 = "My adversary,\nChristopher Robin, is no more.",
        s175 = "As I bathed in and drank the sweet ichor of revenge, my anger subsided.",
        s176 = "I can finally move on with my life.",//
        s177 = "Such splendid news! What future endeavors shall you pursue?",//
        s178 = "I'm turning over a new leaf, Piggles. Gone are the days filled with debauchery and bukakery.",
        s179 = "I shall bury myself in my studies. Reading, writing, and arithmetic are my new lovers.",
        s180 = "I'm joking of course. Why endure the agony of a life devoid of the occasional semen-drenching?",//
        s181 = "I wholeheartedly agree. May I query you something?",//
        s182 = "Ask away my stunted friend.",//
        s183 = "Now that the majority of the forest is empty, perhaps you and I could...",
        s184 = "Oh forget it...",//
        s185 = "Quit wasting time and make your plea!",//
        s186 = "I was just wondering if...maybe we...could walk off into the sunset...together?",//
        s187 = "You and I?? Lovers in arms?? Ha! The absurdity is almost frightening.",
        s188 = "You have the brain of a lemming and the body of an aborted fetus, absent the joy of the actual abortion",
        s189 = "I think not Piggles, the \"bads\" far\noutweigh the \"goods\" in such a scenario.",//
        s190 = "I understand Pooh. It was silly for me to even entertain such delusions.",
        s191 = "Loneliness and\nrejection are my eternal\nbedfellows.",//
        s192 = "Yes it seems so.",//
        s193 = "Might we at least share a cold and meaningless shag over in the bushes?",
        s194 = "I promise to not make eye contact.",//
        s195 = "Well...I suppose.",//
        s196 = "Oh happy day!",//
        s197 = "If you don't mind contracting the HIV virus of course.",//
        s198 = "I would consider it an honor and a privilege.",
        s199 = "And I shall return the favor with a bit of bukakery of my own. If it pleases you?",//
        s200 = "That'll do pig, that'll do.",
        s201 = " "

        };

        //Set intro and outro bool. True means first texts are loaded, false means post-fight texts are loaded.
        if(PlayerPrefs.GetInt("intro", 1) == 0)
        {
            intro = true;
        }
        else
        {
            intro = false;
        }
        if (PlayerPrefs.GetInt("p1", 0) == 0)
        {
            p1 = true;
        }
        else
        {
            p1 = false;
        }
        //PlayerPrefs.SetInt("speechText", 27); // Temp speech setter


    }

    private void Start()
    {
        //intro = false; //Temp reset for first piggles
        //p1 = true; //Temp reset for first piggles
        SetCharacter(TalkScenenManager.oppName);
        tempSpeech = speech[PlayerPrefs.GetInt("speechText", 0)]; // Temp speech setter
        SetSpeech();
        
    }

    private void Update()
    {
        tempSpeech = speech[PlayerPrefs.GetInt("speechText", 0)]; // Temp speech setter
        Debug.Log("Temp: " + speechText);
        
    }

    public void SetSpeech()
    {

        for (int i = 0; i < speech.Length; i++)
        {
            if(speech[i] == tempSpeech)
            {
                //Debug.Log("speech[]i: " + speech[i]);
                speechText = speech[i];
                NextSpeech();
                break;
            }
            if (speech[i] == s1 ||
                speech[i] == s3 ||
                speech[i] == s4 ||
                speech[i] == s7 ||
                speech[i] == s8 ||
                speech[i] == s15 ||
                speech[i] == s16 ||
                speech[i] == s18 ||
                speech[i] == s20 ||
                speech[i] == s23 ||
                speech[i] == s24 ||
                speech[i] == s31 ||
                speech[i] == s36 ||
                speech[i] == s37 ||
                speech[i] == s47 ||
                speech[i] == s52 ||
                speech[i] == s54 ||
                speech[i] == s69 ||
                speech[i] == s76 ||
                speech[i] == s78 ||
                speech[i] == s90 ||
                speech[i] == s95 ||
                speech[i] == s96 ||
                speech[i] == s97 ||
                speech[i] == s100 ||
                speech[i] == s102 ||
                speech[i] == s103 ||
                speech[i] == s104 ||
                speech[i] == s107 ||
                speech[i] == s119 ||
                speech[i] == s121 ||
                speech[i] == s129 ||
                speech[i] == s147 ||
                speech[i] == s151 ||
                speech[i] == s152 ||
                speech[i] == s153 ||
                speech[i] == s154 ||
                speech[i] == s172 ||
                speech[i] == s176 ||
                speech[i] == s177 ||
                speech[i] == s180 ||
                speech[i] == s181 ||
                speech[i] == s182 ||
                speech[i] == s184 ||
                speech[i] == s185 ||
                speech[i] == s186 ||
                speech[i] == s189 ||
                speech[i] == s191 ||
                speech[i] == s192 ||
                speech[i] == s194 ||
                speech[i] == s195 ||
                speech[i] == s196 ||
                speech[i] == s197 ||
                speech[i] == s199
                )
            {
                switchPanels = true;
            }
            else
            {
                switchPanels = false;
            }
            if(speech[i] == s26 ||
               speech[i] == s41 ||
               speech[i] == s42 ||
               speech[i] == s61 ||
               speech[i] == s63 ||
               speech[i] == s82 ||
               speech[i] == s84 ||
               speech[i] == s113 ||
               speech[i] == s115 ||
               speech[i] == s134 ||
               speech[i] == s141 ||
               speech[i] == s158 ||
               speech[i] == s170 ||
               speech[i] == s199 
               
               )
            {
                nextScene = true;
            }
            else
            {
                nextScene = false;
            }
        }
    }

    void SetCharacter(string name)
    {
        switch (name)
        {
            case "Piggles":
                {
                    if(p1 == true)
                    {
                        SetIntroOutro(intro, 0, 0);
                        PlayerPrefs.SetInt("p1", 1);
                    }
                    else
                    {
                        SetIntroOutro(intro, 171, 171);
                        PlayerPrefs.SetInt("p1", 0); //Temp reset p1 bool to set first instance of Piggles
                    }

                    break;
                }
            case "Eeyore":
                {
                    SetIntroOutro(intro, 27, 42);
                    break;
                }
            case "Rabbit":
                {
                    SetIntroOutro(intro, 43, 62);
                    break;
                }
            case "Owl":
                {
                    SetIntroOutro(intro, 64, 83);
                    break;
                }
            case "Kanga":
                {
                    SetIntroOutro(intro, 85, 114);
                    break;
                }
            case "Tegro":
                {
                    SetIntroOutro(intro, 116, 136);
                    break;
                }
            case "Chris":
                {
                    SetIntroOutro(intro, 142, 159);
                    break;
                }
            case null:
                {
                    Debug.Log("Its null OOPSY!");
                    break;
                }
            default:
                {
                    Debug.Log("Default OOPSY!");
                    break;
                }
        }
    }

    void SetIntroOutro(bool intro, int sceneNumber1, int scenenumber2)
    {
        if(intro == true)
        {
            PlayerPrefs.SetInt("speechText", sceneNumber1);
            PlayerPrefs.SetInt("intro", 1);
            poohPanel.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("speechText", scenenumber2);
            PlayerPrefs.SetInt("intro", 0);
            oppPanel.SetActive(true);
        }
    }

    public void NextSpeech()
    {
        int i = PlayerPrefs.GetInt("speechText", 0);
        PlayerPrefs.SetInt("speechText", i + 1);
    }

}
