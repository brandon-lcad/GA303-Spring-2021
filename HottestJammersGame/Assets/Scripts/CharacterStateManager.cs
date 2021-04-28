using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateManager : MonoBehaviour
{
    public static CharacterStateManager CSMInstance;

    private Dictionary<string,Character> characterDictionary = new Dictionary<string,Character>();

    public Character alexis;
    public Character creepyDude;
    public Character izzy;
    public Character player;
    public Character playerThoughts;

    void Awake()
    {
        if (CSMInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            CSMInstance = this;
        }
        else if (CSMInstance != this)
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        characterDictionary.Add("Alexis", alexis);
        characterDictionary.Add("Creepy Dude", creepyDude);
        characterDictionary.Add("Izzy", izzy);
        characterDictionary.Add("Player", player);
        characterDictionary.Add("Player Thoughts", playerThoughts);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
