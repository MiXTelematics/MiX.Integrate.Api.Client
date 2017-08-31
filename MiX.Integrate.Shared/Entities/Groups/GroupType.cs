using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.Groups
{
	public enum GroupType
	{
		DataCentre = 0,
		RsoGroup = 2,
		DealerGroup = 3,
		MultiLevelOrg = 12,
		OrganisationGroup = 1,
		OrganisationSubGroup = 5,
		SiteGroup = 4,
		DefaultSite = 6,

		SecurityGroup = 7,

		NotificationGroup = 8,
		NotificationAssetsGroup = 9,
		NotificationDriversGroup = 10,
		NotificationEventsGroup = 11,

		MobileDeviceAdminCommissioningGroup = 13,
		DriverUserGroup = 14
	}

	public static class GroupTypes
	{
		public static readonly List<GroupType> GROUPS_ABOVE_AND_INCLUDING_ORGANISATIONS =
				 new List<GroupType>
						 {
										 GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg,
										GroupType.OrganisationGroup
						 };
		/// <summary>
		/// The group types that make up the organisation group tree structure, groups like security groups and custom groups are outside of this structure
		/// and are not included in this list.
		/// </summary>
		public static readonly List<GroupType> GROUP_TYPES_IN_ORGANISATION_GROUP_TREE =
				new List<GroupType>(new GroupType[]
						{
										GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg,
										GroupType.OrganisationGroup,
										GroupType.OrganisationSubGroup,
										GroupType.SiteGroup,
										GroupType.DefaultSite
						});

		public static readonly List<GroupType> GROUP_TYPES_UNDER_AND_INCLUDING_ORG_LEVEL = new List<GroupType>
				{
						GroupType.OrganisationGroup,
						GroupType.OrganisationSubGroup,
						GroupType.SiteGroup,
						GroupType.DefaultSite
				};

		/// <summary>
		/// Defines the structure from the top down to the lowest level where the applicable entity can live
		/// </summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_USERS_CAN_LIVE =
				new List<GroupType>(new GroupType[]
						{
										GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg,
										GroupType.OrganisationGroup
						});


		public static readonly List<GroupType> GROUP_TYPES_WITHOUT_TIMEZONES =
				new List<GroupType>(new GroupType[]
						{
										GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg
						});

		/// <summary>
		/// Defines the structure from the top down to the lowest level where the applicable entity can live
		/// </summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_SECURITY_GROUPS_CAN_LIVE = GROUP_TYPES_WHERE_USERS_CAN_LIVE;

		/// <summary>
		/// Defines the structure from the top down to the lowest level where the applicable entity can live
		/// </summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_ROLES_CAN_LIVE = GROUP_TYPES_WHERE_USERS_CAN_LIVE;

		public static readonly List<GroupType> GROUP_TYPES_WHERE_LOCATIONS_CAN_LIVE = new List<GroupType>
				{
						GroupType.DefaultSite,
						GroupType.SiteGroup,
						GroupType.OrganisationGroup
				};

		/// <summary>
		/// Defines the levels in the tree where permissions can be assigned
		/// </summary>
		public static List<GroupType> GROUP_TYPES_WHERE_PERMISSIONS_CAN_BE_ASSIGNED
		{
			get
			{
				List<GroupType> types = new List<GroupType>();
				types.AddRange(GROUP_TYPES_IN_ORGANISATION_GROUP_TREE);
				types.Add(GroupType.MobileDeviceAdminCommissioningGroup);
				return types;
			}
		}

		public static readonly Dictionary<GroupType, string> GROUP_TYPE_SHORT_NAMES =
				new Dictionary<GroupType, string>
				{
								{GroupType.DataCentre, "DC"},
								{GroupType.RsoGroup, "RSO"},
								{GroupType.DealerGroup, "Dealer"},
								{GroupType.MultiLevelOrg, "Multi-org"},
								{GroupType.OrganisationGroup, "Org"},
								{GroupType.OrganisationSubGroup, "Group"},
								{GroupType.SiteGroup, "Site"},
								{GroupType.DefaultSite, "Site"},
								{GroupType.MobileDeviceAdminCommissioningGroup, "Commissioning"}
				};

		/// <summary>
		/// Defines a list of group types under which organisations may be created
		/// </summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_ORGANISATIONS_CAN_BE_ADDED =
				new List<GroupType>(new GroupType[]
						{
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg
						});
	}
}
