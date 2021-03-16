using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Witsml.Query;
using Witsml.ServiceReference;
using WitsmlExplorer.Api.Models;

namespace WitsmlExplorer.Api.Services
{
    public interface IMessageObjectService
    {
        Task<MessageObject> GetMessageObject(string wellUid, string wellboreUid, string msgUid);
        Task<IEnumerable<MessageObject>> GetMessageObjects(string wellUid, string wellboreUid);
        Task<IEnumerable<MessageObject>> GetMessageObjects(string wellUid = null);
    }

    public class MessageObjectService : WitsmlService, IMessageObjectService
    {
        public MessageObjectService(IWitsmlClientProvider witsmlClientProvider) : base(witsmlClientProvider) { }

        public async Task<MessageObject> GetMessageObject(string wellUid, string wellboreUid, string msgUid)
        {
            var query = MessageObjectQueries.QueryByUid(wellUid, wellboreUid, msgUid);
            var result = await WitsmlClient.GetFromStoreAsync(query, OptionsIn.All);
            var messageObject = result.MessageObjects.FirstOrDefault();
            if (messageObject == null) return null;

            return new MessageObject
            {
                WellboreUid = messageObject.UidWellbore,
                WellboreName = messageObject.NameWellbore,
                WellUid = messageObject.UidWell,
                WellName = messageObject.NameWell,
                Uid = messageObject.Uid,
                Name = messageObject.Name,

                DateTimeCreation = StringHelpers.ToDateTime(messageObject.CommonData.DTimCreation),
                DateTimeLastChange = StringHelpers.ToDateTime(messageObject.CommonData.DTimLastChange),

            };
        }

        public async Task<IEnumerable<MessageObject>> GetMessageObjects(string wellUid, string wellboreUid)
        {
            var start = DateTime.Now;
            var query = MessageObjectQueries.QueryByWellbore(wellUid, wellboreUid);
            var result = await WitsmlClient.GetFromStoreAsync(query, OptionsIn.All);
            var messageObject = result.MessageObjects.FirstOrDefault();
            if (messageObject == null) return null;

            var messageObjects = result.MessageObjects
                .Select(messageObject =>
                    new MessageObject
                    {
                        Uid = messageObject.Uid,
                        Name = messageObject.Name,
                        WellboreUid = messageObject.UidWellbore,
                        WellboreName = messageObject.NameWellbore,
                        WellUid = messageObject.UidWell,
                        WellName = messageObject.NameWell,

                        DateTimeLastChange = StringHelpers.ToDateTime(messageObject.CommonData.DTimLastChange)
                    })
                .OrderBy(messageObject => messageObject.WellboreName).ToList();
            var elapsed = DateTime.Now.Subtract(start).Milliseconds / 1000.0;
            Log.Debug($"Fetched {messageObjects.Count} messageobjects in {elapsed} seconds");
            return messageObjects;
        }

        public async Task<IEnumerable<MessageObject>> GetMessageObjects(string wellUid = null)
        {
            var start = DateTime.Now;
            var query = string.IsNullOrEmpty(wellUid) ? MessageObjectQueries.QueryAll() : MessageObjectQueries.QueryByWell(wellUid);

            var result = await WitsmlClient.GetFromStoreAsync(query, OptionsIn.Requested);
            var messageObjects = result.MessageObjects
                .Select(messageObject =>
                    new MessageObject
                    {
                        Uid = messageObject.Uid,
                        Name = messageObject.Name,
                        WellboreUid = messageObject.UidWellbore,
                        WellboreName = messageObject.NameWellbore,
                        WellUid = messageObject.UidWell,
                        WellName = messageObject.NameWell,

                        DateTimeLastChange = StringHelpers.ToDateTime(messageObject.CommonData.DTimLastChange)
                    })
                .OrderBy(messageObject => messageObject.WellboreName).ToList();
            var elapsed = DateTime.Now.Subtract(start).Milliseconds / 1000.0;
            Log.Debug($"Fetched {messageObjects.Count} messageobjects in {elapsed} seconds");
            return messageObjects;
        }
    }
}
