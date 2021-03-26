using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistortionManager : MonoBehaviour
{

    private Dictionary<string,Image> distortionDictionary = new Dictionary<string,Image>();
    private Dictionary<string,ParticleSystem> particleDictionary = new Dictionary<string,ParticleSystem>();
    private Dictionary<string,Character> characterDictionary = new Dictionary<string,Character>();

    public Image outerVignette;
    public Image innerVignette;
    public Image boilingpot;
    public ParticleSystem slowBubbles;
    public ParticleSystem fastBubbles;

    public Character alexis;
    public Character creepyDude;
    public Character izzy;
    public Character player;

    public Character currentActiveCharacter;
    private Sprite currentPortrait;
    private Image[] activeVignettes;
    private ParticleSystem[] activeParticleSystems;
    private GameObject dialogueManager;

    public int distortionLevel;

    void Start()
    {
      distortionDictionary.Add("OuterVignette", outerVignette);
      distortionDictionary.Add("InnerVignette", innerVignette);
      distortionDictionary.Add("BoilingPot", boilingpot);
      particleDictionary.Add("SlowBubbles", slowBubbles);
      particleDictionary.Add("FastBubbles", fastBubbles);
      characterDictionary.Add("Alexis", alexis);
      characterDictionary.Add("CreepyDude", creepyDude);
      characterDictionary.Add("Izzy", izzy);
      characterDictionary.Add("Player", player);

      // Turn everything off
      // We're the only ones with references
      // Could be turned off via Unity UI to start
      outerVignette.enabled = false;
      innerVignette.enabled = false;
      boilingpot.enabled = false;
      slowBubbles.Stop();
      fastBubbles.Stop();

      dialogueManager = GameObject.Find("Dialogue Manager");

      distortionLevel = 0;
    }

    public void UpdateDistortionLevel(int distortionAmount)
    {
      distortionLevel += distortionAmount;
      if (distortionLevel < 0)
      {
        distortionLevel = 0;
      }
      else if (distortionLevel > 5)
      {
        distortionLevel = 5;
      }
      updateCurrents();
    }

    public void UpdateCurrentCharacter(Character newCharacter)
    {
      if (newCharacter != player){
        currentActiveCharacter = newCharacter;
        updateCurrents();
      }
    }

    public void updateCurrents()
    {
      currentPortrait = GetPortrait(currentActiveCharacter.characterName);
      activeVignettes = GetVignetteEffects();
      activeParticleSystems = GetParticle();
      Debug.Log("updateCurrents successful");

      // Send current actives to UIManager/Dialogue Manager
      // Portrait
      dialogueManager.SendMessage("updatePortrait", currentPortrait);


      // Vignettes
      dialogueManager.SendMessage("updateActiveVignettes", activeVignettes);

      //ParticleSystems
      dialogueManager.SendMessage("updateActiveParticleSystems", activeParticleSystems);

    }

    public Image[] GetVignetteEffects()
    {
      if (distortionLevel <= 2)
      {
        return VignetteNone();
      }
      else if (distortionLevel >= 4)
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
      if (distortionLevel <= 2)
      {
        return ParticleNone();
      }
      else if (distortionLevel >= 4)
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
        if (distortionLevel <= 2)
        {
          return activeCharacter.characterSprites[0];
        }
        else if (distortionLevel >= 4)
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
}
