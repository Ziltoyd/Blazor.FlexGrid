﻿using Blazor.FlexGrid.Permission;

namespace Blazor.FlexGrid.Demo.Client.GridConfigurations
{
    public class TestCurrentUserPermission : ICurrentUserPermission
    {
        public bool HasClaim(string claimName)
        {
            if (claimName == "Test")
            {
                return true;
            }

            return false;
        }

        public bool IsInRole(string roleName)
        {
            if (roleName == "TestRole")
            {
                return true;
            }

            return false;
        }
    }
}
