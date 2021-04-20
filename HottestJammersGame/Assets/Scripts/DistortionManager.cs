using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistortionManager : MonoBehaviour
{
    public static DistortionManager DMInstance;

    public Canvas distortionUI;

    private Dictionary<string,Image> distortionDictionary = new Dictionary<string,Image>();
    private Dictionary<string,ParticleSystem> particleDictionary = new Dictionary<string,ParticleSystem>();
    // TODO Moved to CharacterStateManager
    private Dictionary<string,Character> characterDictionary = new Dictionary<string,Character>();

    public Image outerVignette;
    public Image innerVignette;
    public Image boilingpot;
    public ParticleSystem slowBubbles;
    public ParticleSystem fastBubbles;

    // TODO Moved to CharacterStateManager
    public Character alexis;
    public Character creepyDude;
    public Character izzy;
    public Character player;
    public Character playerThoughts;

    private Character currentActiveCharacter;
    private Sprite currentPortrait;
    private Sprite currentShadowPortrait;
    private Image[] activeVignettes;
    private ParticleSystem[] activeParticleSystems;
    private GameObject uiController;
    private GameObject CharacterStateManager;

    private int distortionLevel;

    void Awake()
    {
      if (DMInstance == null)
      {
          DontDestroyOnLoad(gameObject);
          DMInstance = this;
      }
      else if (DMInstance != this)
      {
          Destroy(gameObject);
      }
    }

    void Start()
    {
      distortionDictionary.Add("OuterVignette", outerVignette);
      distortionDictionary.Add("InnerVignette", innerVignette);
      distortionDictionary.Add("BoilingPot", boilingpot);
      particleDictionary.Add("SlowBubbles", slowBubbles);
      particleDictionary.Add("FastBubbles", fastBubbles);
      // TODO Moved to CharacterStateManager
      characterDictionary.Add("Alexis", alexis);
      characterDictionary.Add("CreepyDude", creepyDude);
      characterDictionary.Add("Izzy", izzy);
      characterDictionary.Add("Player", player);
      characterDictionary.Add("PlayerThoughts", playerThoughts);

        // Turn everything off
        // We're the only ones with references
        // Could be turned off via Unity UI to start
      outerVignette.enabled = false;
      innerVignette.enabled = false;
      boilingpot.enabled = false;
      slowBubbles.Stop();
      fastBubbles.Stop();

      uiController = GameObject.Find("Dialogue Manager");

      distortionLevel = GlobalChoiceRecorder.GCRInstance.globalDistortionLevel;
    }

    public void UpdateDistortionLevel(int distortionAmount)
    {
      distortionLevel += distortionAmount;
      if (distortionLevel < 0)
      {
        distortionLevel = 0;
      }
      else if (distortionLevel > 25)
      {
        distortionLevel = 25;
      }
      updateCurrents();
    }

    public void UpdateCurrentCharacter(Character newCharacter)
    {
      currentActiveCharacter = newCharacter;
      updateCurrents();
    }

    public void updateCurrents()
    {
      currentPortrait = GetPortrait(currentActiveCharacter.characterName);
      currentShadowPortrait = GetShadowPortrait(currentActiveCharacter.characterName);
      activeVignettes = GetVignetteEffects();
      activeParticleSystems = GetParticle();
      bool isMindReading = GetMindReading();
      Debug.Log("updateCurrents successful");

      // Send current actives to UIManager/Dialogue Manager
      // Portrait
      uiController.SendMessage("updatePortrait", currentPortrait);


      uiController.SendMessage("updateShadowPortrait", currentShadowPortrait);

      // TODO - CCheck
      // Mind Reading t/f
      uiController.SendMessage("updateMindReading", isMindReading);

      // Vignettes
      uiController.SendMessage("updateActiveVignettes", activeVignettes);

      //ParticleSystems
      uiController.SendMessage("updateActiveParticleSystems", activeParticleSystems);

      // Save to globalDistortionLevel
      SaveDistortionLevel();

    }

    private bool GetMindReading(){
      if (distortionLevel >= 10){
        return true;
      }
      return false;
    }

    public Image[] GetVignetteEffects()
    {
      if (distortionLevel <= 5)
      {
        return VignetteNone();
      }
      else if (distortionLevel >= 20)
      {
        return VignetteFull();
      }
      else
      {
        return VignetteHalf();
      }
    }

    public ParticleSystem[] GetParticle()
    {
      if (distortionLevel <= 5)
      {
        return ParticleNone();
      }
      else if (distortionLevel >= 20)
      {
        return ParticleFull();
      }
      else
      {
        Debug.Log("return ParticleHalf successful");
        return ParticleHalf();
      }
    }

    public Sprite GetPortrait(string characterName)
    {
      Character activeCharacter = null;
      if (characterDictionary.TryGetValue(characterName, out activeCharacter))
      {
        Debug.Log("ACTIVE SPRITES: " + activeCharacter.characterSprites.Length.ToString());
        if (distortionLevel <= 5)
        {
          return activeCharacter.characterSprites[0];
        }
        else if (distortionLevel >= 20)
        {
          return activeCharacter.characterSprites[2];
        }
        else
        {
          return activeCharacter.characterSprites[1];
        }
      }
      Debug.LogError("No portrait to show, character name does not exist in CharacterDictionary");
      return null;
    }

    public Sprite GetShadowPortrait(string characterName)
    {
      Character activeCharacter = null;
      if (characterDictionary.TryGetValue(characterName, out activeCharacter))
      {
        Debug.Log("ACTIVE SPRITES: " + activeCharacter.shadowSprites.Length.ToString());
        if (distortionLevel <= 5)
        {
          return activeCharacter.shadowSprites[0];
        }
        else if (distortionLevel >= 20)
        {
          return activeCharacter.shadowSprites[2];
        }
        else
        {
          return activeCharacter.shadowSprites[1];
        }
      }
      Debug.LogError("No portrait to show, character name does not exist in CharacterDictionary");
      return null;
    }

    public Image[] VignetteNone()
    {
      Image[] distortionVignettes = new Image[0];
      return distortionVignettes;
    }

    public Image[] VignetteHalf()
    {
      Image[] distortionVignettes = new Image[1];
      Image vignette_to_add = null;
      if (distortionDictionary.TryGetValue("OuterVignette", out vignette_to_add))
      {
        distortionVignettes[0] = vignette_to_add;
        return distortionVignettes;
      }
      return null;
    }

    public Image[] VignetteFull()
    {
      Image[] distortionVignettes = new Image[3];
      Image vignette_to_add = null;
      if (distortionDictionary.TryGetValue("OuterVignette", out vignette_to_add))
      {
        distortionVignettes[0] = vignette_to_add;
      }
      if (distortionDictionary.TryGetValue("InnerVignette", out vignette_to_add))
      {
        distortionVignettes[1] = vignette_to_add;
      }
      if (distortionDictionary.TryGetValue("BoilingPot", out vignette_to_add))
      {
        distortionVignettes[2] = vignette_to_add;
        return distortionVignettes;
      }
      return null;
    }

    public ParticleSystem[] ParticleNone()
    {
      ParticleSystem[] distortionParticles = new ParticleSystem[0];
      return distortionParticles;
    }

    public ParticleSystem[] ParticleHalf()
    {
      ParticleSystem[] distortionParticles = new ParticleSystem[1];
      ParticleSystem particles_to_add = null;
      if (particleDictionary.TryGetValue("SlowBubbles", out particles_to_add))
      {
        distortionParticles[0] = particles_to_add;
        Debug.Log("ParticleHalf activated");
        return distortionParticles;
      }
      return null;
    }

    public ParticleSystem[] ParticleFull()
    {
      ParticleSystem[] distortionParticles = new ParticleSystem[2];
      ParticleSystem particles_to_add = null;
      if (particleDictionary.TryGetValue("SlowBubbles", out particles_to_add))
      {
        distortionParticles[0] = particles_to_add;
      }
      if (particleDictionary.TryGetValue("FastBubbles", out particles_to_add))
      {
        distortionParticles[1] = particles_to_add;
        return distortionParticles;
      }
      return null;
    }

    public void SaveDistortionLevel()
    {
      GlobalChoiceRecorder.GCRInstance.globalDistortionLevel = distortionLevel;
    }
}
