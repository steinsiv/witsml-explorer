using Witsml.Data;
using Witsml.Extensions;

namespace Witsml.Query
{
    public static class MessageObjectQueries
    {
        public static WitsmlMessageObjects QueryAll()
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    UidWellbore = "",
                    UidWell = "",
                    Uid = "",
                    NameWellbore = "",
                    NameWell = "",
                    Name = ""
                    //ObjectReference = new WitsmlObjectReference(),
                    CommonData = new WitsmlCommonData()
                }.AsSingletonList()
            };
        }
        public static WitsmlMessageObjects QueryByWell(string wellUid)
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    UidWellbore = "",
                    UidWell = "",
                    Uid = "",
                    NameWellbore = "",
                    NameWell = "",
                    Name = ""
                    //ObjectReference = new WitsmlObjectReference(),
                    CommonData = new WitsmlCommonData()
                }.AsSingletonList()
            };
        }

        public static WitsmlMessageObjects QueryByWellbore(string wellUid, string wellboreUid)
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    UidWellbore = "",
                    UidWell = "",
                    Uid = "",
                    NameWellbore = "",
                    NameWell = "",
                    Name = ""
                    //ObjectReference = new WitsmlObjectReference(),
                    CommonData = new WitsmlCommonData()
                }.AsSingletonList()
            };
        }
        public static WitsmlMessageObjects QueryByUid(string wellUid, string wellboreUid, string messageUid)
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    UidWellbore = "",
                    UidWell = "",
                    Uid = "",
                    NameWellbore = "",
                    NameWell = "",
                    Name = ""
                    //ObjectReference = new WitsmlObjectReference(),
                    CommonData = new WitsmlCommonData()
                }.AsSingletonList()
            };
        }
        public static WitsmlMessageObjects UpdateMessageQuery(string wellUid, string wellboreUid, string messageUid)
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    Uid = messageUid,
                    UidWellbore = wellboreUid,
                    UidWell = wellUid
                }.AsSingletonList()
            };
        }

        public static WitsmlMessageObjects DeleteMessageQuery(string wellUid, string wellboreUid, string messageUid)
        {
            return new WitsmlMessageObjects
            {
                MessageObjects = new WitsmlMessageObject
                {
                    Uid = messageUid,
                    UidWellbore = wellboreUid,
                    UidWell = wellUid
                }.AsSingletonList()
            };
        }

    }
}
