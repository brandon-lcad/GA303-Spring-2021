﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistortionManager : MonoBehaviour
{

    private Dictionary<string,Sprite> distortionDictionary = new Dictionary<string,Sprite>();
    private Dictionary<string,ParticleSystem> particleDictionary = new Dictionary<string,ParticleSystem>();
    private Dictionary<string,Character> characterDictionary = new Dictionary<string,Character>();

    public Sprite outerVignette;
    public Sprite innerVignette;
    public Sprite boilingpot;
    public ParticleSystem slowBubbles;
    public ParticleSystem fastBubbles;

    public Character alexis;
    public Character creepyDude;

    private int distortionLevel;

    void Start()
    {
      distortionDictionary.Add("OuterVignette", outerVignette);
      distortionDictionary.Add("InnerVignette", innerVignette);
      distortionDictionary.Add("BoilingPot", boilingpot);
      particleDictionary.Add("SlowBubbles", slowBubbles);
      particleDictionary.Add("FastBubbles", fastBubbles);
      characterDictionary.Add("Alexis", alexis);
      characterDictionary.Add("CreepyDude", creepyDude);

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
    }

    public Sprite[] GetVignetteEffects()
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
        return ParticleHalf();
      }
    }

    public Sprite GetPortrait(string characterName)
    {
      Character activeCharacter = null;
      if (characterDictionary.TryGetValue(characterName, out activeCharacter))
      {
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

    public Sprite[] VignetteNone()
    {
      Sprite[] distortionVignettes = new Sprite[0];
      return distortionVignettes;
    }

    public Sprite[] VignetteHalf()
    {
      Sprite[] distortionVignettes = new Sprite[1];
      Sprite vignette_to_add = null;
      if (distortionDictionary.TryGetValue("OuterVignette", out vignette_to_add))
      {
        distortionVignettes[0] = vignette_to_add;
        return distortionVignettes;
      }
      return null;
    }

    public Sprite[] VignetteFull()
    {
      Sprite[] distortionVignettes = new Sprite[3];
      Sprite vignette_to_add = null;
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

    IEnumerator FadeTo(float aValue, float aTime)
{
    float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
    for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
    {
        Color newColor = new Color(1, 1, 1, $$anonymous$$athf.Lerp(alpha, aValue, t));
        transform.GetComponent<SpriteRenderer>().material.color = newColor;
        yield return null;
    }
}
}
