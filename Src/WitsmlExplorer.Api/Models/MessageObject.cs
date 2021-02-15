using System;
using Witsml.Data;

namespace WitsmlExplorer.Api.Models
{
    public class MessageObject
    {

        public string WellUid { get;set; }
        public string WellName { get; set; }
        public string WellboreName { get;set; }
        public string WellboreUid { get;set; }
        public DateTime? DateTimeCreation { get; set; }
        public DateTime? DateTimeLastChange { get; set; }

    }
}
