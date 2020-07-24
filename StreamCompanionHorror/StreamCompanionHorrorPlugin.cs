using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StreamCompanionHorror.Horrors;
using StreamCompanionTypes.DataTypes;
using StreamCompanionTypes.Enums;
using StreamCompanionTypes.Interfaces;
using StreamCompanionTypes.Interfaces.Services;
using StreamCompanionTypes.Interfaces.Sources;

namespace StreamCompanionHorror
{
    // ReSharper disable once UnusedMember.Global
    public class StreamCompanionHorrorPlugin : IPlugin, ISettingsSource, IOutputPatternGenerator, IDisposable
    {
        #region metadata
        public string Description { get; } = "A horror plugin for StreamCompanion.";
        public string Name { get; } = "StreamCompanion Horror";
        public string Author { get; } = "LewisTehMinerz";
        public string Url { get; } = "";
        public string UpdateUrl { get; } = "";
        public string SettingGroup { get; } = "StreamCompanion Horror";
        #endregion

        protected ISettings Settings;
        protected ILogger Logger;
        private HorrorConfiguration _configuration;
        private StreamCompanionHorrorSettings _horrorSettings;
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private bool _horrorLock;

        private readonly Random _horrorRandom = new Random();

        private List<KeyValuePair<string, IToken>> _liveTokens;
        private IToken _missToken;

        private readonly List<IHorror> _horrors = new List<IHorror>();

        private List<KeyValuePair<string, IToken>> Tokens
        {
            get => _liveTokens;
            set
            {
                _missToken = value.FirstOrDefault(t => t.Key == "miss").Value;
                _liveTokens = value;
            }
        }

        private readonly ConfigEntry _configEntry = new ConfigEntry("SCHorrorConfig", "{}");

        public StreamCompanionHorrorPlugin(ILogger logger, ISettings settings)
        {
            Settings = settings;
            Logger = logger;
            LoadConfiguration();
            logger.Log("Loading horrors", LogLevel.Debug);

            LoadHorrors("StreamCompanionHorror.Horrors.Audio");
            LoadHorrors("StreamCompanionHorror.Horrors.Visual");
            LoadHorrors("StreamCompanionHorror.Horrors.Special");

            Task.Run(async () => { await UpdateTokens(); });
        }

        public void LoadHorrors(string @namespace)
        {
            var horrors = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => string.Equals(t.Namespace, @namespace))
                .ToArray();

            foreach (var horror in horrors)
            {
                if (horror.Name == "<>c") continue;
                Logger.Log($"Loading horror {horror.FullName}", LogLevel.Debug);
                var instantiatedHorror = (IHorror) Activator.CreateInstance(horror);
                _horrors.Add(instantiatedHorror);
                Logger.Log($"Loaded horror {horror.FullName}", LogLevel.Debug);
            }
        }

        private async Task UpdateTokens()
        {
            var currentMisses = 0;
            while (true)
            {
                if (_cts.IsCancellationRequested) return; // cancel thread if we're disposed
                while (!_configuration.Enable) await Task.Delay(500); // don't bother if we aren't enabled

                if (Tokens == null) continue;
                var miss = (ushort)_missToken.Value;
                if (miss > currentMisses)
                {
                    if (_horrorLock) continue;

                    _horrorLock = true;

                    Logger.Log("Horror triggered", LogLevel.Debug);
                    currentMisses = miss;
                    var horrifyThread = new Thread(Horrify);
                    horrifyThread.SetApartmentState(ApartmentState.MTA);
                    horrifyThread.IsBackground = true;
                    horrifyThread.Start();
                } else if (miss == 0) // we've reset
                {
                    currentMisses = 0;
                }
            }
        }

        private void Horrify()
        {
            if (_horrorRandom.Next(0, 101) >= 50)
            {
                Logger.Log("Horror passed", LogLevel.Debug);
                Logger.Log("Picking horror type", LogLevel.Debug);

                var type = (HorrorType)_horrorRandom.Next(0, 3);

                switch (type)
                {
                    //audio
                    case HorrorType.Audio:
                        Logger.Log("Horror type is audio", LogLevel.Debug);
                        break;
                    //visual
                    case HorrorType.Visual:
                        Logger.Log("Horror type is visual", LogLevel.Debug);
                        break;
                    //special
                    case HorrorType.Special:
                        Logger.Log("Horror type is special", LogLevel.Debug);
                        break;
                }

                var waitMs = _horrorRandom.Next(0, 10001);
                Logger.Log($"Waiting {waitMs}ms", LogLevel.Debug);
                Thread.Sleep(waitMs);

                if (type == HorrorType.Visual)
                {
                    var horrorV = _horrors.Where(h => h.GetHorrorType() == HorrorType.Visual).OrderBy(_ => Guid.NewGuid()).First();
                    var horrorA = _horrors.Where(h => h.GetHorrorType() == HorrorType.Audio).OrderBy(_ => Guid.NewGuid()).First();
                    Logger.Log($"Selected horror {horrorV} + {horrorA}", LogLevel.Debug);
                    horrorA.Execute();
                    horrorV.Execute();
                }
                else
                {
                    var horror = _horrors.Where(h => h.GetHorrorType() == type).OrderBy(_ => Guid.NewGuid()).First();
                    Logger.Log($"Selected horror {horror}", LogLevel.Debug);
                    horror.Execute();
                }

                _horrorLock = false;
            } else
            {
                Logger.Log("Horror failed", LogLevel.Debug);
                _horrorLock = false;
            }
        }

        private void LoadConfiguration()
        {
            var config = Settings.Get<string>(_configEntry);
            _configuration = JsonConvert.DeserializeObject<HorrorConfiguration>(config);
        }

        private void SaveConfiguration()
        {
            var serializedConfig = JsonConvert.SerializeObject(_configuration);
            Settings.Add(_configEntry.Name, serializedConfig);
        }

        public void Free()
        {
            _horrorSettings?.Dispose();
        }

        public object GetUiSettings()
        {
            if (_horrorSettings != null && !_horrorSettings.IsDisposed) return _horrorSettings;
            _horrorSettings = new StreamCompanionHorrorSettings(_configuration);
            _horrorSettings.ConfigUpdated += SaveConfiguration;

            return _horrorSettings;
        }

        public void Dispose()
        {
            _horrorSettings?.Dispose();
            _cts.Cancel();
        }

        public List<IOutputPattern> GetOutputPatterns(Tokens tokens, OsuStatus status)
        {
            Tokens = tokens.ToList();
            return null;
        }
    }
}
