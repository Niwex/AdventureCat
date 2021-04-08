using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
public class CastSpells : MonoBehaviour
{
  // Start is called before the first frame update
  private KeywordRecognizer keywordRecognizer;

  private Dictionary<string, Action> actions = new Dictionary<string, Action>();
  public Rigidbody2D[] fireBalls;
  public float spellRadius = 1.5f;
  void Start()
  {
    actions.Add("penis", FireAttack);
    keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
    keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
    keywordRecognizer.Start();
  }
  private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
  {
    Debug.Log(speech.text);
    actions[speech.text].Invoke();
  }
  void FireAttack()
  {
    // int fireBallNumber = 5;
    for (int i = 0; i < fireBalls.Length; i++)
    {
      Rigidbody2D fireBall = fireBalls[i];
      var rot = Quaternion.Euler(0, 0, (45 * i)); //угол на который будет повёрнут фаербол
      var distance = transform.position + (rot * new Vector3(spellRadius, 0f, 0f));

      // Debug.Log(distance);
      var fireballInsantiate = Instantiate(fireBall, distance, rot) as Rigidbody2D;
      fireballInsantiate.AddForce(rot * new Vector2(1f, 0f) * 100f);
      //объект, текущее положение игрока + угол умноженный на X , разворот относительно спрайта
    }
  }
  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Mouse0))
    {
      FireAttack();
      // int piMultiplier = 1;

    }
  }
}
