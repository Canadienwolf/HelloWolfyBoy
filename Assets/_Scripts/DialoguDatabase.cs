using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.String;

public class DialoguDatabase : MonoBehaviour
{
    ///See ref: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2
    
    
    //Dictionary for all NPC instances
    Dictionary<string, Dictionary<string, string>> NPC_Dictionary;

    //DIctionaries for holding dialogues
    Dictionary<string, string> butcher_Dictionary;
    Dictionary<string, string> wolf_Dictionary;

    // Start is called before the first frame update
    void Start()
    {
        //Make the DIctionary
        NPC_Dictionary = new Dictionary<string, Dictionary<string, string>>();

        //Fill it with shit
        butcher_Dictionary = new Dictionary<string, string>();
        butcher_Dictionary.Add("Welcome", "Hey fellow adventurer, welcome to the meat jungle!");
        butcher_Dictionary.Add("Second", "Blablablablabla some generic text");
        butcher_Dictionary.Add("Last", "Bye fellow adventurer");

        wolf_Dictionary = new Dictionary<string, string>();
        wolf_Dictionary.Add("Welcome", "Hey little girl. Welcome to my humble cave...");
        wolf_Dictionary.Add("Second", "blablablabla some wolfy language... proceedes to eat you...");
        wolf_Dictionary.Add("Second Last", "Are you tasty?!");
        wolf_Dictionary.Add("Last", "You tasted good! mmm bye!");


        NPC_Dictionary.Add("Butcher", butcher_Dictionary);
        NPC_Dictionary.Add("Wolf", wolf_Dictionary);

    }

    // Update is called once per frame
    void Update()
    {
        //string element to show on UI
        string textToShow = string.Empty;

        //Make a temp dictionary to hold the npc reference text in
        Dictionary<string, string> tmp_Dictionary;

        if (NPC_Dictionary.TryGetValue("Wolf", out tmp_Dictionary)) 
        {
            //List every key-value pair in the Dictionary
            foreach (var item in tmp_Dictionary)
            {
                print(Format("Key {0}\nValue: {1}",item.Key, item.Value));
            }

            //Find a specific key-value pair withing the iterated dictionary
            if (tmp_Dictionary.TryGetValue("Second Last", out textToShow)) 
            {
                print("Parsing succeeded!");
                print(textToShow);      //Show the text you searched for...
            }
            else print("Parsing did not succeed :(");
        }
        else print("You suck, it didnt work...");
        
    }
}
