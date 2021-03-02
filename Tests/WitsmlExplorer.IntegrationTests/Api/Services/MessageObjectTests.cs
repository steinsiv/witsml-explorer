using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WitsmlExplorer.Api.Services;
using Xunit;
using Xunit.Abstractions;

namespace WitsmlExplorer.IntegrationTests.Api.Services
{
    [SuppressMessage("ReSharper", "xUnit1004")]
    public class MessageObjectTests
    {
        private readonly ITestOutputHelper output;
        private readonly MessageObjectService msgObjectService;

        public MessageObjectTests(ITestOutputHelper output)
        {
            this.output = output;
            var configuration = ConfigurationReader.GetConfig();
            var witsmlClientProvider = new WitsmlClientProvider(configuration);
            msgObjectService = new MessageObjectService(witsmlClientProvider);
        }

        [Fact(Skip="Should only be run manually")]
        public async Task ReadMessageObject()
        {
            var wellUid = "W-5232880";
            var wellboreUid = "B-5232880";
            var logUid = "GM_Date_Time_GMTime";


            //var log = await msgObjectService.GetLog(wellUid, wellboreUid, logUid);

            //var logData = await msgObjectService.ReadLogData(wellUid, wellboreUid, logUid, mnemonics, true, log.StartIndex, log.EndIndex);
            //output.WriteLine($"Start: {logData.StartIndex}\tEnd: {logData.EndIndex}\tItems: {logData.Data.Count()}");
        }

        [Fact(Skip="Should only be run manually")]
        public async Task ReadLogData_DepthIndexed()
        {
            DateTime start = DateTime.Now;
            var wellUid = "49eea91c-c648-4de9-812e-5dbfff024da9";
            var wellboreUid = "5dcf13f8-373c-4ba6-a3ee-5d33bd46b63c";
            var logUid = "5fe185a1-dae3-478d-84e2-b44af1559dae";
            var mnemonics = new List<string> {"Depth", "BIT_RPM_AVG", "FLOWIN", "FLOWOUT", "HKLD_AVG"};
            //var log = await msgObjectService.GetLog(wellUid, wellboreUid, logUid);
            //var logData = await msgObjectService.ReadLogData(wellUid, wellboreUid, logUid, mnemonics, true, log.StartIndex, log.EndIndex);
            //output.WriteLine($"Start: {logData.StartIndex}\tEnd: {logData.EndIndex}\tItems: {logData.Data.Count()}");
        }
    }
}
