using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Enums
{
    public enum MajorType
    {
        MajorTypeUKNOWN,
        CHECKING,
        SAVING,
        TIME_DEPOSIT,
        COMMERCIAL_LOAN,
        MORTAGE_LOAN,
        CONSUMER_LOAN,
    }

    public enum MajorCategory
    {
        MajorCategoryUNKNOWN,
        DEP,
        LOAN
    }
}
