using System;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using Witsml;
using WitsmlExplorer.Console.WitsmlClient;


namespace WitsmlExplorer.Console.ListCommands
{
    public class GeneralCommand : AsyncCommand<GeneralCommand.GeneralSettings>
    {

        public class GeneralSettings : CommandSettings
        {
            [CommandArgument(0, "<QUERY_IN>")]
            public string Xml { get; init; }
            [CommandArgument(1, "<WMLTYPE_IN>")]
            public string Type { get; init; }
            [CommandArgument(2, "<OPTIONS_IN>")]
            public string Options { get; init; }
        }

        private readonly IWitsmlClient witsmlClient;

        public GeneralCommand(IWitsmlClientProvider witsmlClientProvider)
        {
            witsmlClient = witsmlClientProvider?.GetClient() ?? throw new ArgumentNullException(nameof(witsmlClientProvider));
        }

        public override async Task<int> ExecuteAsync(CommandContext context, GeneralSettings settings)
        {
            if (witsmlClient == null) return -1;

            var xmlResult = await witsmlClient.GetFromStoreAsync(settings.Xml, settings.Type, settings.Options);
            {
                AnsiConsole.WriteLine(xmlResult);
            }
            return 0;
        }

    }
}
