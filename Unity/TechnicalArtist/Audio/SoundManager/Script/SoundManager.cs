using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*********************************************************************************
*
* 전체적으로 들리는 사운드를 다루는 매니저가 된다.
* 
*********************************************************************************/

public enum Sound
{
    Bgm,
    Effect,
    MaxCount,  // 아무것도 아님. 그냥 Sound enum의 개수 세기 위해 추가. (0, 1, '2' 이렇게 2개) 
}

public class SoundManager
{
    /// <summary>
    /// Player가 EnumType 만큼있다는것.<br/>
    /// > 1. 배경음악 재생기, <br/>
    /// > 2. 효과음 재생기,
    /// </summary>
    /// <returns></returns>
    AudioSource[] _audioSources = new AudioSource((int)Sound.MaxCount);    

    /// <summary>
    /// 효과음 사운드를 딕셔너리에 보관, Key는 클립의 Path
    /// </summary>
    /// <typeparam name="string"></typeparam>
    /// <typeparam name="AudioClip"></typeparam>
    /// <returns></returns>
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();
    
    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null) 
        {
            root = new GameObject { name = "@Sound" };

            //게임 내내 파괴되지 않고 살아있도록 DontDestroyOnLoad 함수로 인해 보호. 파괴 방지!
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Sound)); // "Bgm", "Effect"
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                //자식에 사운트 타입마다의 오브젝트를 붙일 작업이다.
                GameObject go = new GameObject { name = soundNames[i] }; 
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Sound.Bgm].loop = true; // bgm 재생기는 무한 반복 재생
        }
    }
    
    [System.Obsolete("이걸 해야하나? 쌓여서 나쁠게 있으려나..")]
    public void Clear()
    {
        // 재생기 전부 재생 스탑, 음반 빼기
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        // 효과음 Dictionary 비우기 
        _audioClips.Clear();
    }

    public void PlayByClip(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f)
	{
        if (audioClip == null)
            return;

        AudioSource audioSource;
        switch (type) 
        {
            case Sound.Bgm : 
            {
                audioSource = _audioSources[(int)Sound.Bgm];
			    if (audioSource.isPlaying)
			    	audioSource.Stop();

			    audioSource.pitch = pitch;
			    audioSource.clip = audioClip;
			    audioSource.Play();                
                break;
            }

            case Sound.Effect : 
            {
			    audioSource = _audioSources[(int)Sound.Effect];
			    audioSource.pitch = pitch;
			    audioSource.PlayOneShot(audioClip); // 효과음 중첩 가능
                break;
            }
        }

	}

    public void PlayByPath(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }
    
    private AudioClip GetOrAddAudioClip(string path, Sound type = Sound.Effect)
    {
		if (path.Contains("Sounds/") == false)
			path = $"Sounds/{path}"; // 📂Sound 폴더 안에 저장될 수 있도록

		AudioClip audioClip = null;
        
        switch (type) 
        {
            case Sound.Bgm : 
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                break;
            }
            case Sound.Effect : 
            {
                if (_audioClips.TryGetValue(path, out audioClip) == false)
			    {
			    	audioClip = Managers.Resource.Load<AudioClip>(path);
			    	_audioClips.Add(path, audioClip);
			    }
                break;
            }
        }

		if (audioClip == null)
			Debug.Log($"AudioClip Missing ! {path}");

		return audioClip;
    }
}

