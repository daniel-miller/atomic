using System;
using System.Collections.Generic;

using Tek.Contract;

namespace Tek.Contract.Engine
{
    public class CreateOrganization
    {
        public Guid OrganizationId { get; set; }

        public string OrganizationName { get; set; }
        public string OrganizationSlug { get; set; }

        public int OrganizationNumber { get; set; }
        public int PartitionNumber { get; set; }

        public DateTime ModifiedWhen { get; set; }
    }

    public class ModifyOrganization
    {
        public Guid OrganizationId { get; set; }

        public string OrganizationName { get; set; }
        public string OrganizationSlug { get; set; }

        public int OrganizationNumber { get; set; }
        public int PartitionNumber { get; set; }

        public DateTime ModifiedWhen { get; set; }
    }

    public class DeleteOrganization
    {
        public Guid OrganizationId { get; set; }
    }
}