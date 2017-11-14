using System.Collections.Generic;

namespace MiX.Integrate.Shared.Entities.Groups
{
/// <summary>Determines the purpose and functionality of groups in the DynaMiX system</summary>
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

	/// <summary>Helper class providing predefined lists of <see cref="GroupType"/> enumeration values</summary>
	public static class GroupTypes
	{
		/// <summary>The group types that make up the organisation tree structure. Non-hierarchical groups are not included in this list.</summary>
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


		/// <summary>The group types that can exist at or above the organisation level in the hierarchy</summary>
		public static readonly List<GroupType> GROUPS_ABOVE_AND_INCLUDING_ORGANISATIONS =
			new List<GroupType>
			{
				GroupType.DataCentre,
				GroupType.RsoGroup,
				GroupType.DealerGroup,
				GroupType.MultiLevelOrg,
				GroupType.OrganisationGroup
			};



		/// <summary>The group types that can exists at or below the organisation in the hierarchicy</summary>
		public static readonly List<GroupType> GROUP_TYPES_UNDER_AND_INCLUDING_ORG_LEVEL = new List<GroupType>
				{
						GroupType.OrganisationGroup,
						GroupType.OrganisationSubGroup,
						GroupType.SiteGroup,
						GroupType.DefaultSite
				};

		/// <summary>The hierarchical group types that can contain user accounts</summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_USERS_CAN_LIVE =
				new List<GroupType>(new GroupType[]
						{
										GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg,
										GroupType.OrganisationGroup
						});

		/// <summary>The hierarchical group types not requiring a timezone</summary>
		public static readonly List<GroupType> GROUP_TYPES_WITHOUT_TIMEZONES =
				new List<GroupType>(new GroupType[]
						{
										GroupType.DataCentre,
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg
						});

		/// <summary>The hierarchical group types that can contain security groups</summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_SECURITY_GROUPS_CAN_LIVE = GROUP_TYPES_WHERE_USERS_CAN_LIVE;

		/// <summary>The hierarchical group types that can contain role groups</summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_ROLES_CAN_LIVE = GROUP_TYPES_WHERE_USERS_CAN_LIVE;

		/// <summary>The hierarchical group types that can contain locations</summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_LOCATIONS_CAN_LIVE = new List<GroupType>
				{
						GroupType.DefaultSite,
						GroupType.SiteGroup,
						GroupType.OrganisationGroup
				};

		/// <summary>The group types that can be the target of a permission assignment</summary>
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

		/// <summary>The hierarchical group types in which a new organisation can be created</summary>
		public static readonly List<GroupType> GROUP_TYPES_WHERE_ORGANISATIONS_CAN_BE_ADDED =
				new List<GroupType>(new GroupType[]
						{
										GroupType.RsoGroup,
										GroupType.DealerGroup,
										GroupType.MultiLevelOrg
						});
	}
}
