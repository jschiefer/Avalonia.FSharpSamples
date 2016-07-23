open System
open System.Windows.Threading
open Serilog
open Avalonia.Logging.Serilog
open Avalonia.Controls
open XamlTestApplication

let InitializeLogging() =
#if DEBUG 
    let loggerConfig = new LoggerConfiguration()
    let logger = loggerConfig.MinimumLevel.Warning().WriteTo.Trace(outputTemplate = "{Area}: {Message}").CreateLogger()
    SerilogLogger.Initialize(logger)
#endif
    
    ()

[<EntryPoint>]
let main argv = 
    let foo = Dispatcher.CurrentDispatcher
    AppBuilder.Configure<XamlTestApp>().UsePlatformDetect().Start<Views.MainWindow>()
    0 // return an integer exit code
