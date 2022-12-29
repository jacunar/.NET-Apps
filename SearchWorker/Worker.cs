using Newtonsoft.Json;

namespace SearchWorker {
    public class Worker : BackgroundService {
        private readonly ILogger<Worker> _logger;
        private readonly string _unidad;
        private readonly string sMatch = "*.shp";
        List<string> lstFilesFound = new();

        public Worker(ILogger<Worker> logger) {
            _logger = logger;
            _unidad = @"Z:\2022\PGR\ENTREGAS";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested) {
                try {
                    await Task.Run(() => DirSearch(_unidad), stoppingToken);
                    WriteFile(lstFilesFound);
                    await StopAsync(stoppingToken);
                } catch (Exception excpt) {
                    Console.WriteLine(excpt.Message);
                }
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                //await Task.Delay(1000, stoppingToken);
            }
            _logger.LogInformation("Finalizado");
        }

        private void DirSearch(string directory) {
            if (Directory.Exists(directory)) {
                foreach (string dir in Directory.GetDirectories(directory)) {
                    foreach (string f in Directory.GetFiles(dir, sMatch)) {
                        lstFilesFound.Add(f);
                        _logger.LogInformation(f);
                    }
                    DirSearch(dir);
                }
            }
        }

        public void WriteFile(List<string> fileFounds) {
            string included = JsonConvert.SerializeObject(fileFounds, Formatting.Indented, new JsonSerializerSettings { });
            File.WriteAllText("Z_2022_shp.json", included);
        }
    }
}