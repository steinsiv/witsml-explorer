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
                    NameWellbore = "",
                    NameWell = "",
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
                    NameWellbore = "",
                    NameWell = "",
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
                    NameWellbore = "",
                    NameWell = "",
                }.AsSingletonList()
            };
        }


    }
}