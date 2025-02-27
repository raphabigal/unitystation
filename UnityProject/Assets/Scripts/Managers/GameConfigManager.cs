﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Managers;
using UnityEngine.Events;

namespace GameConfig
{
	/// <summary>
	/// Config for in game stuff
	/// </summary>
	public class GameConfigManager : SingletonManager<GameConfigManager>
	{
		private GameConfig config;

		public static GameConfig GameConfig
		{
			get
			{
				return Instance.config;
			}
		}

		public override void Awake()
		{
			base.Awake();

			//Load in awake so other scripts can get data in their start.
			AttemptConfigLoad();
		}

		private void AttemptConfigLoad()
		{
			var path = Path.Combine(Application.streamingAssetsPath, "config", "gameConfig.json");

			if (File.Exists(path))
			{
				config = JsonUtility.FromJson<GameConfig>(File.ReadAllText(path));
			}
		}
	}

	[Serializable]
	public class GameConfig
	{
		public bool RandomEventsAllowed;
		public bool SpawnLavaLand;
		public int MinPlayersForCountdown;
		public int MinReadyPlayersForCountdown;
		public float PreRoundTime;
		public float RoundEndTime;
		public int RoundsPerMap;
		public string InitialGameMode;
		public bool RespawnAllowed;
		public int ShuttleDepartTime;
		public bool GibbingAllowed;
		public bool ShuttleGibbingAllowed;
		public bool AdminOnlyHtml;
		public int MalfAIRecieveTheirIntendedObjectiveChance;
		public int CharacterNameLimit;
		public bool ServerShutsDownOnRoundEnd;
		public int PlayerLimit;
	}
}