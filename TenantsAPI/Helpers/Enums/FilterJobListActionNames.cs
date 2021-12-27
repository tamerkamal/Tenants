using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum FilterJobListActionNames
    {
        [Description("FillByJobRouting")]
        FilterByJobRouting = 1,

        [Description("FillByVisitStatus")]
        FilterByVisitStatus = 2,

        [Description("FillBySubRegionId")]
        FilterBySubRegionId = 3,

        [Description("FillByStatusAndSubRegionId")]
        FilterByStatusAndSubRegionId = 4,

        [Description("FillPerTeam")]
        FilterPerTeam = 5,

        [Description("FillByVisitStatusPerTeam")]
        FilterByVisitStatusPerTeam = 6,

        [Description("FillBySubRegionIdPerTeam")]
        FilterBySubRegionIdPerTeam = 7,

        [Description("FillByStatusAndSubRegionIdPerTeam")]
        FilterByStatusAndSubRegionIdPerTeam = 8,

        [Description("FillByJobRoutingJeopardy")]
        FilterByJobRoutingJeopardy = 9,

        [Description("FillBySubRegionIdJeopardy")]
        FilterBySubRegionIdJeopardy = 10,

        [Description("FillPerTeamJeopardy")]
        FilterPerTeamJeopardy = 11,

        [Description("FillBySubRegionIdPerTeamJeopardy")]
        FilterBySubRegionIdPerTeamJeopardy = 12
    }
}
