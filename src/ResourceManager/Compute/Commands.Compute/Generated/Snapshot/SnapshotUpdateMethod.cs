// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using AutoMapper;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateSnapshotUpdateDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pSnapshotName = new RuntimeDefinedParameter();
            pSnapshotName.Name = "SnapshotName";
            pSnapshotName.ParameterType = typeof(string);
            pSnapshotName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pSnapshotName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("SnapshotName", pSnapshotName);

            var pSnapshot = new RuntimeDefinedParameter();
            pSnapshot.Name = "Snapshot";
            pSnapshot.ParameterType = typeof(SnapshotUpdate);
            pSnapshot.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true
            });
            pSnapshot.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Snapshot", pSnapshot);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteSnapshotUpdateMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string snapshotName = (string)ParseParameter(invokeMethodInputParameters[1]);
            SnapshotUpdate snapshot = (SnapshotUpdate)ParseParameter(invokeMethodInputParameters[2]);
            Snapshot snapshotOrg = (Snapshot)ParseParameter(invokeMethodInputParameters[3]);

            var result = (snapshot == null)
                         ? SnapshotsClient.CreateOrUpdate(resourceGroupName, snapshotName, snapshotOrg)
                         : SnapshotsClient.Update(resourceGroupName, snapshotName, snapshot);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateSnapshotUpdateParameters()
        {
            string resourceGroupName = string.Empty;
            string snapshotName = string.Empty;
            SnapshotUpdate snapshot = new SnapshotUpdate();

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "SnapshotName", "Snapshot" },
                 new object[] { resourceGroupName, snapshotName, snapshot });
        }
    }

    [Cmdlet(VerbsData.Update, "AzureRmSnapshot", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSSnapshot))]
    public partial class UpdateAzureRmSnapshot : ComputeAutomationBaseCmdlet
    {
        protected override void ProcessRecord()
        {
            ComputeAutomationAutoMapperProfile.Initialize();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.ResourceGroupName, VerbsData.Update))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string snapshotName = this.SnapshotName;

                    Snapshot snapshotObj = new Snapshot();
                    Mapper.Map<PSSnapshot, Snapshot>(this.Snapshot, snapshotObj);

                    SnapshotUpdate snapshotUpdateObj = new SnapshotUpdate();
                    Mapper.Map<PSSnapshotUpdate, SnapshotUpdate>(this.SnapshotUpdate, snapshotUpdateObj);

                    var result = (this.SnapshotUpdate == null)
                                 ? SnapshotsClient.CreateOrUpdate(resourceGroupName, snapshotName, snapshotObj)
                                 : SnapshotsClient.Update(resourceGroupName, snapshotName, snapshotUpdateObj);

					var psObject = new PSSnapshot();
					Mapper.Map<Snapshot, PSSnapshot>(result, psObject);

					WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Alias("Name")]
        [AllowNull]
        public string SnapshotName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            ValueFromPipeline = true)]
        [AllowNull]
        public PSSnapshotUpdate SnapshotUpdate { get; set; }

        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 4,
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            ValueFromPipeline = true)]
        [AllowNull]
        public PSSnapshot Snapshot { get; set; }
    }
}
