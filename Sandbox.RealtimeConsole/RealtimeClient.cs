using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Sandbox.RealtimeConsole
{
    public class RealtimeClient : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<RealtimeClient> _logger;
        private HubConnection realtimeConnection;

        public RealtimeClient(
            IConfiguration configuration,
            ILogger<RealtimeClient> logger
        )
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested && (this.realtimeConnection == null || this.realtimeConnection.State == HubConnectionState.Disconnected))
            {
                // Setup a connection to the realtime hub
                this.realtimeConnection = new HubConnectionBuilder()
                    .WithUrl(_configuration.GetValue<string>("API") + "/realtime-hub")
                    .WithAutomaticReconnect()
                    .Build();

                // When the connection is closed
                this.realtimeConnection.Closed += async (ex) =>
                {
                    _logger.LogError("Lost realtime connection");
                    if (ex != null)
                        _logger.LogError(ex.ToString());
                };

                // Test
                this.realtimeConnection.On("test", async () =>
                {
                    _logger.LogInformation("Test command executed.");
                });

                // Open file
                this.realtimeConnection.On("open-file", async (string path) =>
                {
                    _logger.LogInformation("Open file command executed.");
                    _logger.LogInformation("Path: " + path);

                    new Process()
                    {
                        StartInfo = new ProcessStartInfo(path)
                        {
                            UseShellExecute = true
                        }
                    }.Start();
                });

                // Start initial realtime connection
                await Connect();
            }
        }

        private async Task Connect()
        {
            try
            {
                // Don't connect again if already connected
                if (this.realtimeConnection.State == HubConnectionState.Disconnected)
                {
                    _logger.LogInformation("Connecting to realtime hub...");
                    await this.realtimeConnection.StartAsync();
                }

                if (this.realtimeConnection.State == HubConnectionState.Connected)
                    _logger.LogInformation("Connected.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Not able to connect. Is the API up and running?");
                _logger.LogError(ex.ToString());
            }
        }
    }
}
