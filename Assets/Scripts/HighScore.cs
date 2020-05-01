using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public GameObject HighscoreNameText;
    public GameObject HighscoreScoreText;
    public InputField NameText;
    public Text ScoreText;
    public Button SubmitButton;
    public GameObject CheckMarkImage;
    private const string highScoreUrl = "https://scoreboard.canu.cool/api/score";
    private const string hashKey = "fVlgFveBo0WlPbeDNAlyiVQCyCW0DI9L757wpHRB3Ouak85oRJ";

    // Start is called before the first frame update
    void Start()
    {
        if (!string.IsNullOrWhiteSpace(GameData.PlayerName))
        {
            NameText.text = GameData.PlayerName;
        }
        StartCoroutine(UpdateHighScores());
    }

    public void SubmitHighScore()
    {
        SubmitButton.interactable = false;
        StartCoroutine(SubmitHighScoreCoroutine());
    }


    IEnumerator SubmitHighScoreCoroutine()
    {
        string name;
        if (!string.IsNullOrWhiteSpace(NameText.text))
        {
            GameData.PlayerName = NameText.text;
            name = NameText.text;
        }
        else
        {
            name = "Anonymous";
        }

        var hash = string.Empty;
        using (var sha256Hash = SHA256.Create())
        {
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(name + hashKey + ScoreText.text));
            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            hash = builder.ToString();
        }

        var body = new SubmitHighScoreBody
        {
            key = hash,
            name = name,
            score = int.Parse(ScoreText.text)
        };

        var request = UnityWebRequest.Put(highScoreUrl, JsonUtility.ToJson(body));
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            SubmitButton.interactable = true;
        }
        else
        {
            CheckMarkImage.SetActive(true);
            yield return UpdateHighScores();
        }
    }

    IEnumerator UpdateHighScores()
    {
        var request = UnityWebRequest.Get(highScoreUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Unity json utility can't parse directly json array, it needs a root object
            var scores = JsonUtility.FromJson<HighScoreItems>("{\"scores\":" + request.downloadHandler.text + "}")
                .scores
                .OrderByDescending(x => x.score)
                .Take(8);

            for (int i = 0; i < this.transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            foreach (var score in scores)
            {
                var nameText = Instantiate(HighscoreNameText, this.gameObject.transform);
                nameText.GetComponent<Text>().text = score.name;
                var scoreText = Instantiate(HighscoreScoreText, this.gameObject.transform);
                scoreText.GetComponent<Text>().text = score.score.ToString();
            }
        }
    }
}


[Serializable]
public class SubmitHighScoreBody
{
    public string name;
    public int score;
    public string key;
}



[Serializable]
public class HighScoreItems
{
    public ScoreItem[] scores;
}


[Serializable]
public class ScoreItem
{
    public string name;
    public int score;
}