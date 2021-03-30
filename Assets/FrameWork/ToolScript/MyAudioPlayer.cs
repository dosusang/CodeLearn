using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace QFramework.Example {
    public class MyAudioPlayer : MonoSingleton<MyAudioPlayer> {

        private string path_prefix = GameDefine.Instance.AudioPathPrefix;
        public void PlayVoice(string path) {
            AudioKit.PlayVoice(path_prefix+path);
        }

        public void PlayMusic(string path) {
            AudioKit.PlayMusic(path_prefix+path);
        }
        public void PlaySound(string path) {
            AudioKit.PlaySound(path_prefix+path);
        }
    }
}

