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
    public Rigidbody2D fireBall;
    // private GameObject WaterAura;

    public float maxMana;
    public float currentMana;
    public float manaRegen;
    float manaRegenTick = 0f;

    public GameObject waterBall;
    public GameObject activeWaterBall;
    [SerializeField] int numberOfBalls;
    [SerializeField] float spellRadius = 1.5f;
    Dictionary<string, int> spellCost = new Dictionary<string, int>();
    void Start()
    {
        spellCost.Add("fire", 10);
        actions.Add("fire", FireAttack);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        if (spellCost[speech.text] <= currentMana)
        {
            actions[speech.text].Invoke();
            currentMana -= spellCost[speech.text];
        }
    }
    void WaterAttack()
    {
        Instantiate(waterBall, transform.position, Quaternion.identity, gameObject.transform);

    }
    void FireAttack()
    {
        // int fireBallNumber = 5;
        for (int i = 0; i < numberOfBalls; i++)
        {
            // Rigidbody2D fireBall = fireBalls[i];
            var angle = 360 / numberOfBalls;
            var rot = Quaternion.Euler(0, 0, (angle * i)); //угол на который будет повёрнут фаербол
            var distance = transform.position + (rot * new Vector3(spellRadius, 0f, 0f));

            // Debug.Log(distance);
            var fireballInsantiate = Instantiate(fireBall, distance, rot) as Rigidbody2D;
            fireballInsantiate.AddForce(rot * new Vector2(1f, 0f) * 300f);
            //объект, текущее положение игрока + угол умноженный на X , разворот относительно спрайта
        }
    }
    void Healing()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.Find("waterball(Clone)"))
        {
            // gameObject.transform.Find("waterball(Clone)").Rotate(0, 0, Time.deltaTime);
            gameObject.transform.Find("waterball(Clone)").transform.Translate(Time.deltaTime * 5f, Time.deltaTime * 5f, Time.deltaTime);
            gameObject.transform.Find("waterball(Clone)").transform.Rotate(0, 0, Time.deltaTime * 500f);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            WaterAttack();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireAttack();
            // int piMultiplier = 1;

        }
        if(Time.time>manaRegenTick)
            {
            if (currentMana < maxMana)
            {
                if (currentMana + manaRegen < maxMana)
                    currentMana += manaRegen;
                else
                    currentMana = maxMana;
                manaRegenTick = Time.time + 1f;
            } 
        }
    }
}
